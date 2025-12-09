using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosClasicos.Algorithms.LineDrawing;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Managers;
using AlgoritmosClasicos.Core.Models;
using AlgoritmosClasicos.Core.Rendering;

namespace AlgoritmosClasicos.UI.Forms
{
    /// <summary>
    /// Formulario para demostrar algoritmos de trazado de líneas.
    /// Soporta DDA, Bresenham y Midpoint con visualización paso a paso.
    /// </summary>
    public partial class frmLineDrawing : Form
    {
        private readonly Dictionary<string, ILineDrawingAlgorithm> _algorithms;
        private CoordinateDisplayManager _coordinateManager;
        private PixelRenderer _pixelRenderer;
        private Bitmap _canvasBitmap;
        private Graphics _canvasGraphics;
        private List<PixelPoint> _currentLine;

        private const int PIXEL_SIZE = 5;
        private const int CANVAS_WIDTH = 150;
        private const int CANVAS_HEIGHT = 80;

        public frmLineDrawing()
        {
            InitializeComponent();
            
            // Inicializar algoritmos
            _algorithms = new Dictionary<string, ILineDrawingAlgorithm>
            {
                { "DDA", new DDAAlgorithm() },
                { "Bresenham", new BresenhamLineAlgorithm() },
                { "Punto Medio", new MidpointLineAlgorithm() }
            };

            InitializeComponents();
            LoadAlgorithms();
        }

        /// <summary>
        /// Inicializa los componentes personalizados.
        /// </summary>
        private void InitializeComponents()
        {
            // Inicializar el renderer de píxeles con altura del canvas para invertir Y
            _pixelRenderer = new PixelRenderer(PIXEL_SIZE, Color.Black, CANVAS_HEIGHT);

            // Configurar el canvas bitmap
            int bitmapWidth = CANVAS_WIDTH * PIXEL_SIZE;
            int bitmapHeight = CANVAS_HEIGHT * PIXEL_SIZE;
            _canvasBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            _canvasGraphics = Graphics.FromImage(_canvasBitmap);
            _canvasGraphics.Clear(Color.White);
            pctCanvas.Image = _canvasBitmap;

            // Inicializar el manager de coordenadas
            _coordinateManager = new CoordinateDisplayManager(lstCoordinates);

            // Dibujar grilla opcional
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);
            pctCanvas.Refresh();
        }

        /// <summary>
        /// Carga los algoritmos disponibles en el ComboBox.
        /// </summary>
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
        /// Manejador del botón Dibujar.
        /// </summary>
        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar y obtener coordenadas
                if (!TryGetCoordinates(out int x1, out int y1, out int x2, out int y2))
                {
                    MessageBox.Show("Por favor, ingrese coordenadas válidas (números enteros).",
                        "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar rango
                if (!ValidateCoordinatesRange(x1, y1, x2, y2))
                {
                    MessageBox.Show($"Las coordenadas deben estar en el rango:\n" +
                        $"X: 0 a {CANVAS_WIDTH - 1}\n" +
                        $"Y: 0 a {CANVAS_HEIGHT - 1}",
                        "Coordenadas Fuera de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener algoritmo seleccionado
                var selectedAlgoName = cmbAlgorithm.SelectedItem.ToString();
                var algorithm = GetAlgorithmByName(selectedAlgoName);

                if (algorithm == null)
                {
                    MessageBox.Show("Por favor, seleccione un algoritmo.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear puntos
                var startPoint = new PixelPoint(x1, y1);
                var endPoint = new PixelPoint(x2, y2);

                // Calcular línea
                _currentLine = algorithm.CalculateLine(startPoint, endPoint);

                // Cargar coordenadas en el manager
                _coordinateManager.LoadPoints(_currentLine);

                // Dibujar resultado completo
                DrawCompleteResult();

                // Actualizar estado
                UpdateStatus();

                MessageBox.Show($"Línea generada exitosamente con {_currentLine.Count} puntos.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar la línea:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Dibuja el resultado completo en el canvas.
        /// </summary>
        private void DrawCompleteResult()
        {
            // Limpiar canvas
            _canvasGraphics.Clear(Color.White);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);

            // Dibujar todos los puntos
            if (_currentLine != null && _currentLine.Count > 0)
            {
                _pixelRenderer.DrawPixels(_canvasGraphics, _currentLine);
            }

            pctCanvas.Refresh();
        }

        /// <summary>
        /// Manejador del botón Reset.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            _coordinateManager.Reset();
            DrawStepByStep();
            UpdateStatus();
        }

        /// <summary>
        /// Manejador del botón Anterior.
        /// </summary>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_coordinateManager.PreviousPoint())
            {
                DrawStepByStep();
                UpdateStatus();
            }
        }

        /// <summary>
        /// Manejador del botón Siguiente.
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_coordinateManager.NextPoint())
            {
                DrawStepByStep();
                UpdateStatus();
            }
        }

        /// <summary>
        /// Manejador del botón Primero.
        /// </summary>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            _coordinateManager.GoToFirst();
            DrawStepByStep();
            UpdateStatus();
        }

        /// <summary>
        /// Manejador del botón Último.
        /// </summary>
        private void btnLast_Click(object sender, EventArgs e)
        {
            _coordinateManager.GoToLast();
            DrawStepByStep();
            UpdateStatus();
        }

        /// <summary>
        /// Dibuja el estado paso a paso actual.
        /// </summary>
        private void DrawStepByStep()
        {
            // Limpiar canvas
            _canvasGraphics.Clear(Color.White);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);

            if (_currentLine == null || _currentLine.Count == 0)
                return;

            int currentIndex = _coordinateManager.CurrentIndex;

            // Si no hay índice actual, no dibujar nada
            if (currentIndex < 0)
                return;

            // Dibujar todos los puntos hasta el actual en gris claro
            for (int i = 0; i <= currentIndex; i++)
            {
                if (i < currentIndex)
                {
                    _pixelRenderer.DrawPixel(_canvasGraphics, _currentLine[i], Color.LightGray);
                }
                else
                {
                    // Dibujar el punto actual en rojo
                    _pixelRenderer.DrawPixel(_canvasGraphics, _currentLine[i], Color.Red);
                }
            }

            pctCanvas.Refresh();
        }

        /// <summary>
        /// Actualiza la etiqueta de estado.
        /// </summary>
        private void UpdateStatus()
        {
            lblStatus.Text = _coordinateManager.GetStatusInfo();
        }

        /// <summary>
        /// Intenta obtener las coordenadas de los TextBox.
        /// </summary>
        private bool TryGetCoordinates(out int x1, out int y1, out int x2, out int y2)
        {
            x1 = y1 = x2 = y2 = 0;
            return int.TryParse(txtX1.Text, out x1) &&
                   int.TryParse(txtY1.Text, out y1) &&
                   int.TryParse(txtX2.Text, out x2) &&
                   int.TryParse(txtY2.Text, out y2);
        }

        /// <summary>
        /// Valida que las coordenadas estén dentro del rango del canvas.
        /// </summary>
        private bool ValidateCoordinatesRange(int x1, int y1, int x2, int y2)
        {
            return x1 >= 0 && x1 < CANVAS_WIDTH &&
                   y1 >= 0 && y1 < CANVAS_HEIGHT &&
                   x2 >= 0 && x2 < CANVAS_WIDTH &&
                   y2 >= 0 && y2 < CANVAS_HEIGHT;
        }

        /// <summary>
        /// Obtiene el algoritmo por nombre.
        /// </summary>
        private ILineDrawingAlgorithm GetAlgorithmByName(string name)
        {
            foreach (var kvp in _algorithms)
            {
                if (kvp.Value.Name == name)
                    return kvp.Value;
            }
            return null;
        }

        /// <summary>
        /// Limpia recursos al cerrar el formulario.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _canvasGraphics?.Dispose();
            _canvasBitmap?.Dispose();
            _pixelRenderer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
