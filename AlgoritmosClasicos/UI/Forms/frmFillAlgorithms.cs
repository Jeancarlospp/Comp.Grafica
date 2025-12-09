using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosClasicos.Algorithms.Fill;
using AlgoritmosClasicos.Algorithms.LineDrawing;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Managers;
using AlgoritmosClasicos.Core.Models;
using AlgoritmosClasicos.Core.Rendering;

namespace AlgoritmosClasicos.UI.Forms
{
    /// <summary>
    /// Formulario para demostrar algoritmos de relleno.
    /// Permite dibujo por vértices con líneas automáticas y relleno interactivo.
    /// Reutiliza componentes globales: PixelRenderer, CoordinateDisplayManager y algoritmos de líneas.
    /// </summary>
    public partial class frmFillAlgorithms : Form
    {
        // Enumeración para los modos de operación
        private enum Modo
        {
            Dibujo,
            Relleno
        }

        private readonly Dictionary<string, IFillAlgorithm> _algorithms;
        private CoordinateDisplayManager _coordinateManager;
        private PixelRenderer _pixelRenderer;
        private Bitmap _canvasBitmap;
        private Graphics _canvasGraphics;
        private CanvasGrid _canvasGrid;
        private List<PixelPoint> _filledPoints;
        private Color[,] _gridBeforeFill;

        // Lista de vértices y algoritmo de líneas
        private List<PixelPoint> _vertices;
        private ILineDrawingAlgorithm _lineAlgorithm;
        private Modo _modoActual;
        private bool _figuraCerrada;

        private const int PIXEL_SIZE = 5;
        private const int CANVAS_WIDTH = 150;
        private const int CANVAS_HEIGHT = 80;
        
        private readonly Color BACKGROUND_COLOR = Color.White;
        private readonly Color DRAW_COLOR = Color.Black;
        private readonly Color FILL_COLOR = Color.FromArgb(100, 150, 255);
        private readonly Color BOUNDARY_COLOR = Color.Black;
        private readonly Color VERTEX_COLOR = Color.Red;

        public frmFillAlgorithms()
        {
            InitializeComponent();

            // Inicializar algoritmos de relleno
            _algorithms = new Dictionary<string, IFillAlgorithm>
            {
                { "Flood Fill", new FloodFillAlgorithm() },
                { "Boundary Fill", new BoundaryFillAlgorithm() },
                { "Scanline Fill", new ScanlineFillAlgorithm() }
            };

            // Reutilizar algoritmo de líneas DDA
            _lineAlgorithm = new DDAAlgorithm();

            // Inicializar estado
            _vertices = new List<PixelPoint>();
            _modoActual = Modo.Dibujo;
            _figuraCerrada = false;

            InitializeComponents();
            LoadAlgorithms();
        }

        private void InitializeComponents()
        {
            _pixelRenderer = new PixelRenderer(PIXEL_SIZE, DRAW_COLOR, CANVAS_HEIGHT);

            int bitmapWidth = CANVAS_WIDTH * PIXEL_SIZE;
            int bitmapHeight = CANVAS_HEIGHT * PIXEL_SIZE;
            _canvasBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            _canvasGraphics = Graphics.FromImage(_canvasBitmap);
            _canvasGraphics.Clear(BACKGROUND_COLOR);
            pctCanvas.Image = _canvasBitmap;

            _canvasGrid = new CanvasGrid(CANVAS_WIDTH, CANVAS_HEIGHT, BACKGROUND_COLOR);
            _coordinateManager = new CoordinateDisplayManager(lstCoordinates);

            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);
            pctCanvas.Refresh();
        }

        private void LoadAlgorithms()
        {
            cmbAlgorithm.Items.Clear();
            foreach (var algo in _algorithms.Values)
            {
                cmbAlgorithm.Items.Add(algo.Name);
            }
            cmbAlgorithm.SelectedIndex = 0;
        }

        /// <summary>
        /// Manejador del evento click en el canvas.
        /// Modo DIBUJO: Agrega vértices y dibuja líneas automáticamente
        /// Modo RELLENO: Ejecuta algoritmo de relleno
        /// </summary>
        private void pctCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int logicalX = e.X / PIXEL_SIZE;
                int logicalY = (CANVAS_HEIGHT * PIXEL_SIZE - e.Y) / PIXEL_SIZE;

                if (logicalX < 0 || logicalX >= CANVAS_WIDTH || 
                    logicalY < 0 || logicalY >= CANVAS_HEIGHT)
                    return;

                var clickedPoint = new PixelPoint(logicalX, logicalY);

                if (_modoActual == Modo.Dibujo)
                {
                    // MODO DIBUJO: Agregar vértice y dibujar línea (si no está cerrada)
                    if (!_figuraCerrada)
                    {
                        AddVertexAndDrawLine(clickedPoint);
                    }
                }
                else
                {
                    // MODO RELLENO: Ejecutar algoritmo
                    ExecuteFill(clickedPoint);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Agrega un vértice y dibuja línea desde el anterior.
        /// </summary>
        private void AddVertexAndDrawLine(PixelPoint vertex)
        {
            // Agregar vértice
            _vertices.Add(vertex);

            // Dibujar el vértice resaltado
            _pixelRenderer.DrawPixel(_canvasGraphics, vertex, VERTEX_COLOR);

            // Si hay al menos 2 vértices, dibujar línea al anterior
            if (_vertices.Count >= 2)
            {
                var prevVertex = _vertices[_vertices.Count - 2];
                DrawLineUsingAlgorithm(prevVertex, vertex);
            }

            pctCanvas.Refresh();
        }

        /// <summary>
        /// Cierra la figura dibujando línea desde el último vértice al primero.
        /// </summary>
        private void btnCerrarFigura_Click(object sender, EventArgs e)
        {
            if (_vertices.Count < 3)
            {
                MessageBox.Show("Necesita al menos 3 vértices para cerrar una figura.",
                    "Figura Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_figuraCerrada)
            {
                MessageBox.Show("La figura ya está cerrada.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Dibujar línea de cierre
            var lastVertex = _vertices[_vertices.Count - 1];
            var firstVertex = _vertices[0];
            DrawLineUsingAlgorithm(lastVertex, firstVertex);
            
            // Marcar como cerrada
            _figuraCerrada = true;
            
            MessageBox.Show("Figura cerrada exitosamente.\nAhora puede presionar el botón azul para activar el modo relleno.",
                "Figura Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            pctCanvas.Refresh();
        }

        /// <summary>
        /// Activa el modo relleno cuando se presiona el botón azul.
        /// </summary>
        private void btnActivarModoRelleno_Click(object sender, EventArgs e)
        {
            // Validar que haya una figura cerrada
            if (!_figuraCerrada)
            {
                MessageBox.Show("Debe cerrar la figura primero usando el botón 'Cerrar Figura'.",
                    "Figura No Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cambiar a modo relleno
            _modoActual = Modo.Relleno;
            
            MessageBox.Show("Modo RELLENO activado.\nAhora haga click dentro de la figura para rellenarla con el algoritmo seleccionado.",
                "Modo Relleno Activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Dibuja una línea entre dos vértices reutilizando el algoritmo de líneas.
        /// </summary>
        private void DrawLineUsingAlgorithm(PixelPoint start, PixelPoint end)
        {
            // Reutilizar algoritmo de líneas DDA
            var linePoints = _lineAlgorithm.CalculateLine(start, end);

            // Dibujar cada punto de la línea en la grilla y canvas
            foreach (var point in linePoints)
            {
                _canvasGrid.SetPixel(point, DRAW_COLOR);
                _pixelRenderer.DrawPixel(_canvasGraphics, point, DRAW_COLOR);
            }
        }

        /// <summary>
        /// Ejecuta el algoritmo de relleno seleccionado.
        /// </summary>
        private void ExecuteFill(PixelPoint startPoint)
        {
            try
            {
                var selectedAlgoName = cmbAlgorithm.SelectedItem.ToString();
                var algorithm = GetAlgorithmByName(selectedAlgoName);

                if (algorithm == null)
                {
                    MessageBox.Show("Seleccione un algoritmo.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar estado antes del relleno
                _gridBeforeFill = _canvasGrid.GetGridCopy();

                // Ejecutar algoritmo
                _filledPoints = algorithm.Fill(_canvasGrid.GetGrid(), startPoint, FILL_COLOR, BOUNDARY_COLOR);

                // Cargar coordenadas
                _coordinateManager.LoadPoints(_filledPoints);

                // Dibujar resultado
                RedrawCanvas();
                UpdateStatus();

                MessageBox.Show($"Relleno completado: {_filledPoints.Count} píxeles.\nUse los controles paso a paso.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al rellenar:\n{ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Redibuja todo el canvas.
        /// </summary>
        private void RedrawCanvas()
        {
            _canvasGraphics.Clear(BACKGROUND_COLOR);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);

            // Dibujar todos los píxeles de la grilla
            for (int x = 0; x < CANVAS_WIDTH; x++)
            {
                for (int y = 0; y < CANVAS_HEIGHT; y++)
                {
                    Color pixelColor = _canvasGrid.GetPixel(x, y);
                    if (pixelColor != BACKGROUND_COLOR)
                    {
                        _pixelRenderer.DrawPixel(_canvasGraphics, new PixelPoint(x, y), pixelColor);
                    }
                }
            }

            // Redibujar vértices en modo dibujo
            if (_modoActual == Modo.Dibujo)
            {
                foreach (var vertex in _vertices)
                {
                    _pixelRenderer.DrawPixel(_canvasGraphics, vertex, VERTEX_COLOR);
                }
            }

            pctCanvas.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _canvasGrid.Clear();
            _canvasGraphics.Clear(BACKGROUND_COLOR);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);
            pctCanvas.Refresh();

            _coordinateManager.Clear();
            _filledPoints = null;
            _gridBeforeFill = null;
            _vertices.Clear();
            _modoActual = Modo.Dibujo;
            _figuraCerrada = false;
            UpdateStatus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_gridBeforeFill != null)
            {
                _canvasGrid.RestoreGrid(_gridBeforeFill);
                RedrawCanvas();
            }
            _coordinateManager.Reset();
            UpdateStatus();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_coordinateManager.PreviousPoint())
            {
                DrawStepByStep();
                UpdateStatus();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_coordinateManager.NextPoint())
            {
                DrawStepByStep();
                UpdateStatus();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _coordinateManager.GoToFirst();
            DrawStepByStep();
            UpdateStatus();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            _coordinateManager.GoToLast();
            DrawStepByStep();
            UpdateStatus();
        }

        /// <summary>
        /// Dibuja el estado paso a paso.
        /// </summary>
        private void DrawStepByStep()
        {
            if (_gridBeforeFill == null || _filledPoints == null)
                return;

            _canvasGrid.RestoreGrid(_gridBeforeFill);
            int currentIndex = _coordinateManager.CurrentIndex;

            if (currentIndex < 0)
            {
                RedrawCanvas();
                return;
            }

            // Aplicar relleno hasta el punto currentIndex
            for (int i = 0; i <= currentIndex; i++)
            {
                var point = _filledPoints[i];
                
                if (i < currentIndex)
                    _canvasGrid.SetPixel(point, FILL_COLOR);
                else
                    _canvasGrid.SetPixel(point, Color.Yellow); // Punto actual en amarillo
            }

            RedrawCanvas();
        }

        private void UpdateStatus()
        {
            lblStatus.Text = _coordinateManager.GetStatusInfo();
        }

        private IFillAlgorithm GetAlgorithmByName(string name)
        {
            foreach (var kvp in _algorithms)
            {
                if (kvp.Value.Name == name)
                    return kvp.Value;
            }
            return null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _canvasGraphics?.Dispose();
            _canvasBitmap?.Dispose();
            _pixelRenderer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
