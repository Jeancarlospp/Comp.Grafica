using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosClasicos.Algorithms.LineClipping;
using AlgoritmosClasicos.Algorithms.LineDrawing;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;
using AlgoritmosClasicos.Core.Rendering;

namespace AlgoritmosClasicos.UI.Forms
{
    /// <summary>
    /// Formulario para demostrar algoritmos de recorte de líneas.
    /// Permite dibujar líneas, definir ventana de recorte y aplicar algoritmos de recorte.
    /// Reutiliza componentes globales: PixelRenderer y algoritmos de líneas.
    /// </summary>
    public partial class frmLineClipping : Form
    {
        private readonly Dictionary<string, ILineClippingAlgorithm> _algorithms;
        private PixelRenderer _pixelRenderer;
        private Bitmap _canvasBitmap;
        private Graphics _canvasGraphics;
        
        // Algoritmo de líneas para dibujar
        private ILineDrawingAlgorithm _lineAlgorithm;
        
        // Estado de dibujo
        private List<Tuple<PixelPoint, PixelPoint>> _lines; // Líneas originales
        private List<ClippedLine> _clippedLines; // Líneas recortadas
        private PixelPoint _currentStartPoint; // Punto de inicio temporal
        private bool _waitingForEndPoint; // Esperando segundo click
        private bool _recorteAplicado; // Ya se aplicó el recorte
        
        private const int PIXEL_SIZE = 5;
        private const int CANVAS_WIDTH = 150;
        private const int CANVAS_HEIGHT = 80;
        
        private readonly Color BACKGROUND_COLOR = Color.White;
        private readonly Color ORIGINAL_LINE_COLOR = Color.Gray;
        private readonly Color CLIPPED_LINE_COLOR = Color.Blue;
        private readonly Color CLIP_WINDOW_COLOR = Color.Red;
        private readonly Color START_POINT_COLOR = Color.Green;

        public frmLineClipping()
        {
            InitializeComponent();

            // Inicializar algoritmos de recorte
            _algorithms = new Dictionary<string, ILineClippingAlgorithm>
            {
                { "Cohen-Sutherland", new CohenSutherlandAlgorithm() },
                { "Liang-Barsky", new LiangBarskyAlgorithm() },
                { "Nicholl-Lee-Nicholl", new NichollLeeNichollAlgorithm() }
            };

            // Reutilizar algoritmo de líneas
            _lineAlgorithm = new DDAAlgorithm();

            // Inicializar estado
            _lines = new List<Tuple<PixelPoint, PixelPoint>>();
            _clippedLines = new List<ClippedLine>();
            _waitingForEndPoint = false;
            _recorteAplicado = false;

            InitializeComponents();
            LoadAlgorithms();
        }

        private void InitializeComponents()
        {
            _pixelRenderer = new PixelRenderer(PIXEL_SIZE, ORIGINAL_LINE_COLOR, CANVAS_HEIGHT);

            int bitmapWidth = CANVAS_WIDTH * PIXEL_SIZE;
            int bitmapHeight = CANVAS_HEIGHT * PIXEL_SIZE;
            _canvasBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            _canvasGraphics = Graphics.FromImage(_canvasBitmap);
            _canvasGraphics.Clear(BACKGROUND_COLOR);
            pctCanvas.Image = _canvasBitmap;

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
        /// Manejador de click en canvas para dibujar líneas.
        /// </summary>
        private void pctCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (_recorteAplicado)
                return; // No permitir más dibujo después del recorte

            try
            {
                int logicalX = e.X / PIXEL_SIZE;
                int logicalY = (CANVAS_HEIGHT * PIXEL_SIZE - e.Y) / PIXEL_SIZE;

                if (logicalX < 0 || logicalX >= CANVAS_WIDTH || 
                    logicalY < 0 || logicalY >= CANVAS_HEIGHT)
                    return;

                var clickedPoint = new PixelPoint(logicalX, logicalY);

                if (!_waitingForEndPoint)
                {
                    // Primer click - punto inicial
                    _currentStartPoint = clickedPoint;
                    _waitingForEndPoint = true;
                    
                    // Dibujar punto de inicio
                    _pixelRenderer.DrawPixel(_canvasGraphics, clickedPoint, START_POINT_COLOR);
                    pctCanvas.Refresh();
                    
                    lblStatus.Text = "Click para punto final";
                }
                else
                {
                    // Segundo click - punto final
                    _lines.Add(new Tuple<PixelPoint, PixelPoint>(_currentStartPoint, clickedPoint));
                    
                    // Dibujar línea
                    DrawLineUsingAlgorithm(_currentStartPoint, clickedPoint, ORIGINAL_LINE_COLOR);
                    
                    _waitingForEndPoint = false;
                    _currentStartPoint = null;
                    
                    lblStatus.Text = $"Lineas dibujadas: {_lines.Count}";
                    pctCanvas.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aplica el algoritmo de recorte seleccionado.
        /// </summary>
        private void btnAplicarRecorte_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lines.Count == 0)
                {
                    MessageBox.Show("Dibuje al menos una línea primero.", "Sin Líneas", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener ventana de recorte
                if (!TryGetClipWindow(out ClipRectangle clipRect))
                {
                    MessageBox.Show("Ingrese valores válidos para la ventana de recorte.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener algoritmo
                var selectedAlgoName = cmbAlgorithm.SelectedItem.ToString();
                var algorithm = GetAlgorithmByName(selectedAlgoName);

                // Aplicar recorte a todas las líneas
                _clippedLines.Clear();
                int visibleCount = 0;

                foreach (var line in _lines)
                {
                    var clipped = algorithm.ClipLine(line.Item1, line.Item2, clipRect);
                    if (clipped.IsVisible)
                    {
                        _clippedLines.Add(clipped);
                        visibleCount++;
                    }
                }

                // Marcar como aplicado
                _recorteAplicado = true;

                // Redibujar todo
                RedrawAll(clipRect);

                // Mostrar resultado en lista
                DisplayClippedLines();

                MessageBox.Show($"Recorte completado.\n{visibleCount} de {_lines.Count} líneas visibles.",
                    "Recorte Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar recorte:\n{ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Dibuja una línea usando el algoritmo de líneas.
        /// </summary>
        private void DrawLineUsingAlgorithm(PixelPoint start, PixelPoint end, Color color)
        {
            var linePoints = _lineAlgorithm.CalculateLine(start, end);
            foreach (var point in linePoints)
            {
                _pixelRenderer.DrawPixel(_canvasGraphics, point, color);
            }
        }

        /// <summary>
        /// Dibuja la ventana de recorte.
        /// </summary>
        private void DrawClipWindow(ClipRectangle clipRect)
        {
            // Dibujar los 4 bordes del rectángulo
            DrawLineUsingAlgorithm(
                new PixelPoint(clipRect.XMin, clipRect.YMin),
                new PixelPoint(clipRect.XMax, clipRect.YMin),
                CLIP_WINDOW_COLOR);

            DrawLineUsingAlgorithm(
                new PixelPoint(clipRect.XMax, clipRect.YMin),
                new PixelPoint(clipRect.XMax, clipRect.YMax),
                CLIP_WINDOW_COLOR);

            DrawLineUsingAlgorithm(
                new PixelPoint(clipRect.XMax, clipRect.YMax),
                new PixelPoint(clipRect.XMin, clipRect.YMax),
                CLIP_WINDOW_COLOR);

            DrawLineUsingAlgorithm(
                new PixelPoint(clipRect.XMin, clipRect.YMax),
                new PixelPoint(clipRect.XMin, clipRect.YMin),
                CLIP_WINDOW_COLOR);
        }

        /// <summary>
        /// Redibuja todo: líneas originales, ventana y líneas recortadas.
        /// </summary>
        private void RedrawAll(ClipRectangle clipRect)
        {
            _canvasGraphics.Clear(BACKGROUND_COLOR);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);

            // Dibujar líneas originales en gris claro
            foreach (var line in _lines)
            {
                DrawLineUsingAlgorithm(line.Item1, line.Item2, Color.LightGray);
            }

            // Dibujar ventana de recorte en rojo
            DrawClipWindow(clipRect);

            // Dibujar líneas recortadas en azul
            foreach (var clipped in _clippedLines)
            {
                if (clipped.IsVisible)
                {
                    DrawLineUsingAlgorithm(clipped.Start, clipped.End, CLIPPED_LINE_COLOR);
                }
            }

            pctCanvas.Refresh();
        }

        /// <summary>
        /// Muestra las líneas recortadas en el ListBox.
        /// </summary>
        private void DisplayClippedLines()
        {
            lstCoordinates.Items.Clear();
            
            int index = 1;
            foreach (var clipped in _clippedLines)
            {
                if (clipped.IsVisible)
                {
                    lstCoordinates.Items.Add($"Linea {index}:");
                    lstCoordinates.Items.Add($"  Inicio: ({clipped.Start.X},{clipped.Start.Y})");
                    lstCoordinates.Items.Add($"  Fin: ({clipped.End.X},{clipped.End.Y})");
                    lstCoordinates.Items.Add("");
                    index++;
                }
            }

            if (_clippedLines.Count == 0)
            {
                lstCoordinates.Items.Add("Ninguna linea visible");
            }
        }

        /// <summary>
        /// Intenta obtener la ventana de recorte de los TextBoxes.
        /// </summary>
        private bool TryGetClipWindow(out ClipRectangle clipRect)
        {
            clipRect = null;

            if (!int.TryParse(txtXMin.Text, out int xMin) ||
                !int.TryParse(txtYMin.Text, out int yMin) ||
                !int.TryParse(txtXMax.Text, out int xMax) ||
                !int.TryParse(txtYMax.Text, out int yMax))
            {
                return false;
            }

            if (xMin >= xMax || yMin >= yMax)
                return false;

            try
            {
                clipRect = new ClipRectangle(xMin, yMin, xMax, yMax);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private ILineClippingAlgorithm GetAlgorithmByName(string name)
        {
            foreach (var kvp in _algorithms)
            {
                if (kvp.Value.Name == name)
                    return kvp.Value;
            }
            return null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _lines.Clear();
            _clippedLines.Clear();
            _currentStartPoint = null;
            _waitingForEndPoint = false;
            _recorteAplicado = false;

            _canvasGraphics.Clear(BACKGROUND_COLOR);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);
            pctCanvas.Refresh();

            lstCoordinates.Items.Clear();
            lblStatus.Text = "Dibuje una linea";
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
