using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosClasicos.Algorithms.CircleDrawing;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Managers;
using AlgoritmosClasicos.Core.Models;
using AlgoritmosClasicos.Core.Rendering;

namespace AlgoritmosClasicos.UI.Forms
{
    /// <summary>
    /// Formulario para demostrar algoritmos de trazado de círculos.
    /// Soporta Bresenham, Incremental y DDA paramétrico con visualización paso a paso.
    /// Reutiliza componentes globales: PixelRenderer y CoordinateDisplayManager.
    /// </summary>
    public partial class frmCircleDrawing : Form
    {
        private readonly Dictionary<string, ICircleDrawingAlgorithm> _algorithms;
        private CoordinateDisplayManager _coordinateManager;
        private PixelRenderer _pixelRenderer;
        private Bitmap _canvasBitmap;
        private Graphics _canvasGraphics;
        private List<PixelPoint> _currentCircle;

        private const int PIXEL_SIZE = 5;
        private const int CANVAS_WIDTH = 150;
        private const int CANVAS_HEIGHT = 80;

        public frmCircleDrawing()
        {
            InitializeComponent();

            // Inicializar algoritmos
            _algorithms = new Dictionary<string, ICircleDrawingAlgorithm>
            {
                { "Bresenham", new BresenhamCircleAlgorithm() },
                { "Incremental", new IncrementalCircleAlgorithm() },
                { "DDA", new DDACircleAlgorithm() }
            };

            InitializeComponents();
            LoadAlgorithms();
        }

        /// <summary>
        /// Inicializa los componentes personalizados reutilizables.
        /// </summary>
        private void InitializeComponents()
        {
            // Reutilizar PixelRenderer global
            _pixelRenderer = new PixelRenderer(PIXEL_SIZE, Color.Black, CANVAS_HEIGHT);

            // Configurar el canvas bitmap
            int bitmapWidth = CANVAS_WIDTH * PIXEL_SIZE;
            int bitmapHeight = CANVAS_HEIGHT * PIXEL_SIZE;
            _canvasBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            _canvasGraphics = Graphics.FromImage(_canvasBitmap);
            _canvasGraphics.Clear(Color.White);
            pctCanvas.Image = _canvasBitmap;

            // Reutilizar CoordinateDisplayManager global
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
                // Validar y obtener parámetros
                if (!TryGetParameters(out int centerX, out int centerY, out int radius))
                {
                    MessageBox.Show("Por favor, ingrese valores válidos (números enteros).",
                        "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar rango
                if (!ValidateParameters(centerX, centerY, radius))
                {
                    MessageBox.Show($"Los parámetros deben estar en el rango:\n" +
                        $"Centro X: 0 a {CANVAS_WIDTH - 1}\n" +
                        $"Centro Y: 0 a {CANVAS_HEIGHT - 1}\n" +
                        $"Radio: 0 a {Math.Min(CANVAS_WIDTH, CANVAS_HEIGHT) / 2}",
                        "Parámetros Fuera de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Crear punto centro
                var center = new PixelPoint(centerX, centerY);

                // Calcular círculo
                _currentCircle = algorithm.CalculateCircle(center, radius);

                // Cargar coordenadas en el manager global
                _coordinateManager.LoadPoints(_currentCircle);

                // Dibujar resultado completo
                DrawCompleteResult();

                // Actualizar estado
                UpdateStatus();

                MessageBox.Show($"Círculo generado exitosamente con {_currentCircle.Count} puntos.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar el círculo:\n{ex.Message}",
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
            if (_currentCircle != null && _currentCircle.Count > 0)
            {
                _pixelRenderer.DrawPixels(_canvasGraphics, _currentCircle);
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

            if (_currentCircle == null || _currentCircle.Count == 0)
                return;

            int currentIndex = _coordinateManager.CurrentIndex;

            // Si no hay índice actual, no dibujar nada
            if (currentIndex < 0)
                return;

            // Dibujar todos los puntos hasta el actual
            for (int i = 0; i <= currentIndex; i++)
            {
                if (i < currentIndex)
                {
                    // Puntos anteriores en gris claro
                    _pixelRenderer.DrawPixel(_canvasGraphics, _currentCircle[i], Color.LightGray);
                }
                else
                {
                    // Punto actual en rojo
                    _pixelRenderer.DrawPixel(_canvasGraphics, _currentCircle[i], Color.Red);
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
        /// Intenta obtener los parámetros de los TextBox.
        /// </summary>
        private bool TryGetParameters(out int centerX, out int centerY, out int radius)
        {
            centerX = centerY = radius = 0;
            return int.TryParse(txtCenterX.Text, out centerX) &&
                   int.TryParse(txtCenterY.Text, out centerY) &&
                   int.TryParse(txtRadius.Text, out radius);
        }

        /// <summary>
        /// Valida que los parámetros estén dentro del rango del canvas.
        /// </summary>
        private bool ValidateParameters(int centerX, int centerY, int radius)
        {
            if (centerX < 0 || centerX >= CANVAS_WIDTH ||
                centerY < 0 || centerY >= CANVAS_HEIGHT)
                return false;

            if (radius < 0)
                return false;

            // Validar que el círculo quepa razonablemente en el canvas
            int maxRadius = Math.Min(CANVAS_WIDTH, CANVAS_HEIGHT) / 2;
            if (radius > maxRadius)
                return false;

            return true;
        }

        /// <summary>
        /// Obtiene el algoritmo por nombre.
        /// </summary>
        private ICircleDrawingAlgorithm GetAlgorithmByName(string name)
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
