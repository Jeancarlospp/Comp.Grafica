using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlgoritmosClasicos.Algorithms.LineDrawing;
using AlgoritmosClasicos.Algorithms.PolygonClipping;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;
using AlgoritmosClasicos.Core.Rendering;

namespace AlgoritmosClasicos.UI.Forms
{
    /// <summary>
    /// Formulario para demostrar algoritmos de recorte de polígonos.
    /// Permite dibujar un polígono por vértices y aplicar algoritmos de recorte contra una ventana de recorte.
    /// Con Cyrus-Beck, demuestra versatilidad permitiendo cambiar entre rectángulo y triángulo.
    /// </summary>
    public partial class frmPolygonClipping : Form
    {
        private readonly Dictionary<string, IPolygonClippingAlgorithm> _algorithms;
        private PixelRenderer _pixelRenderer;
        private Bitmap _canvasBitmap;
        private Graphics _canvasGraphics;
        
        // Algoritmo de líneas para dibujar aristas (reutilizado)
        private ILineDrawingAlgorithm _lineAlgorithm;
        
        // Polígono sujeto y ventana de recorte
        private Polygon _subjectPolygon;
        private ClipRectangle _clipRectangle;
        private ClipShape _clipShape;  // Para Cyrus-Beck con triángulo
        private Polygon _resultPolygon;
        
        // Estado
        private bool _polygonClosed;
        private bool _clippingApplied;
        private bool _useTriangle;  // Para Cyrus-Beck
        
        private const int PIXEL_SIZE = 5;
        private const int CANVAS_WIDTH = 150;
        private const int CANVAS_HEIGHT = 80;
        
        // Rectángulo de recorte predefinido
        private const int CLIP_X_MIN = 30;
        private const int CLIP_Y_MIN = 20;
        private const int CLIP_X_MAX = 120;
        private const int CLIP_Y_MAX = 60;
        
        private readonly Color BACKGROUND_COLOR = Color.White;
        private readonly Color POLYGON_COLOR = Color.Blue;
        private readonly Color CLIP_WINDOW_COLOR = Color.Red;
        private readonly Color RESULT_COLOR = Color.Green;
        private readonly Color VERTEX_COLOR = Color.Orange;

        public frmPolygonClipping()
        {
            InitializeComponent();

            // Inicializar algoritmos
            _algorithms = new Dictionary<string, IPolygonClippingAlgorithm>
            {
                { "Sutherland-Hodgman", new SutherlandHodgmanAlgorithm() },
                { "Liang-Barsky", new LiangBarskyPolygonAlgorithm() },
                { "Cyrus-Beck", new CyrusBeckAlgorithm() }
            };

            // Reutilizar algoritmo de líneas DDA
            _lineAlgorithm = new DDAAlgorithm();

            // Inicializar polígono y estado
            _subjectPolygon = new Polygon();
            _clipRectangle = new ClipRectangle(CLIP_X_MIN, CLIP_Y_MIN, CLIP_X_MAX, CLIP_Y_MAX);
            _clipShape = ClipShape.FromRectangle(_clipRectangle);
            _polygonClosed = false;
            _clippingApplied = false;
            _useTriangle = false;

            InitializeComponents();
            LoadAlgorithms();
            
            // Suscribir evento de cambio de algoritmo
            cmbAlgorithm.SelectedIndexChanged += cmbAlgorithm_SelectedIndexChanged;
        }

        private void InitializeComponents()
        {
            _pixelRenderer = new PixelRenderer(PIXEL_SIZE, POLYGON_COLOR, CANVAS_HEIGHT);

            int bitmapWidth = CANVAS_WIDTH * PIXEL_SIZE;
            int bitmapHeight = CANVAS_HEIGHT * PIXEL_SIZE;
            _canvasBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            _canvasGraphics = Graphics.FromImage(_canvasBitmap);
            _canvasGraphics.Clear(BACKGROUND_COLOR);
            pctCanvas.Image = _canvasBitmap;

            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);
            
            // Dibujar la forma de recorte predefinida
            DrawClipShape();
            
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
        /// Evento al cambiar el algoritmo seleccionado.
        /// Muestra el selector de forma solo si es Cyrus-Beck.
        /// </summary>
        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCyrusBeck = cmbAlgorithm.SelectedItem.ToString() == "Cyrus-Beck";
            grpShapeSelector.Visible = isCyrusBeck;
            
            if (isCyrusBeck)
            {
                lblWindowInfo.Text = "CYRUS-BECK:\r\nSoporta multiples formas!\r\n\r\n";
            }
            else
            {
                lblWindowInfo.Text = "Rectangulo predefinido:\r\n\r\nX: 30 - 120\r\nY: 20 - 60\r\n\r\n" +
                    "(Se dibuja automaticamente en rojo)";
            }
        }

        /// <summary>
        /// Evento al cambiar la forma seleccionada (rectángulo/triángulo).
        /// </summary>
        private void rbShape_CheckedChanged(object sender, EventArgs e)
        {
            if (!_clippingApplied)
            {
                _useTriangle = rbTriangle.Checked;
                
                // Actualizar clip shape
                if (_useTriangle)
                {
                    _clipShape = ClipShape.CreatePredefinedTriangle();
                }
                else
                {
                    _clipShape = ClipShape.FromRectangle(_clipRectangle);
                }
                
                // Redibujar
                _canvasGraphics.Clear(BACKGROUND_COLOR);
                _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);
                DrawClipShape();
                RedrawSubjectPolygon();
                pctCanvas.Refresh();
            }
        }

        /// <summary>
        /// Manejador de click en canvas para dibujar vértices del polígono.
        /// Reutiliza lógica del módulo de relleno.
        /// </summary>
        private void pctCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (_polygonClosed || _clippingApplied)
                return;

            try
            {
                int logicalX = e.X / PIXEL_SIZE;
                int logicalY = (CANVAS_HEIGHT * PIXEL_SIZE - e.Y) / PIXEL_SIZE;

                if (logicalX < 0 || logicalX >= CANVAS_WIDTH || 
                    logicalY < 0 || logicalY >= CANVAS_HEIGHT)
                    return;

                var clickedPoint = new PixelPoint(logicalX, logicalY);
                AddVertexToPolygon(clickedPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Agrega un vértice al polígono y dibuja la arista.
        /// </summary>
        private void AddVertexToPolygon(PixelPoint vertex)
        {
            _subjectPolygon.AddVertex(vertex);
            
            // Dibujar vértice
            _pixelRenderer.DrawPixel(_canvasGraphics, vertex, VERTEX_COLOR);
            
            // Si hay al menos 2 vértices, dibujar arista usando algoritmo de líneas
            if (_subjectPolygon.VertexCount >= 2)
            {
                var prevVertex = _subjectPolygon.GetVertex(_subjectPolygon.VertexCount - 2);
                DrawLineUsingAlgorithm(prevVertex, vertex, POLYGON_COLOR);
            }
            
            pctCanvas.Refresh();
            lblStatus.Text = $"Poligono: {_subjectPolygon.VertexCount} vertices";
        }

        /// <summary>
        /// Cierra el polígono dibujando la arista final.
        /// </summary>
        private void btnCerrarPoligono_Click(object sender, EventArgs e)
        {
            if (_subjectPolygon.VertexCount < 3)
            {
                MessageBox.Show("Necesita al menos 3 vertices para cerrar el poligono.",
                    "Poligono Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_polygonClosed)
            {
                MessageBox.Show("El poligono ya esta cerrado.",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Dibujar arista de cierre
            var lastVertex = _subjectPolygon.GetVertex(_subjectPolygon.VertexCount - 1);
            var firstVertex = _subjectPolygon.GetVertex(0);
            DrawLineUsingAlgorithm(lastVertex, firstVertex, POLYGON_COLOR);
            
            _polygonClosed = true;
            pctCanvas.Refresh();
            lblStatus.Text = "Poligono cerrado. Aplicar recorte";
            
            MessageBox.Show("Poligono cerrado exitosamente.\nAhora puede aplicar el algoritmo de recorte.",
                "Poligono Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Aplica el algoritmo de recorte seleccionado.
        /// </summary>
        private void btnAplicarRecorte_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_polygonClosed)
                {
                    MessageBox.Show("Debe cerrar el poligono primero.",
                        "Poligono No Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedAlgoName = cmbAlgorithm.SelectedItem.ToString();
                var algorithm = GetAlgorithmByName(selectedAlgoName);

                // Si es Cyrus-Beck y se seleccionó triángulo, usar ClipShape
                if (selectedAlgoName == "Cyrus-Beck" && _useTriangle)
                {
                    var cyrusBeck = algorithm as CyrusBeckAlgorithm;
                    _resultPolygon = cyrusBeck.ClipPolygonAgainstShape(_subjectPolygon, _clipShape);
                }
                else
                {
                    _resultPolygon = algorithm.ClipPolygon(_subjectPolygon, _clipRectangle);
                }
                
                _clippingApplied = true;
                RedrawAll();
                DisplayResult();

                string shapeInfo = (_useTriangle && selectedAlgoName == "Cyrus-Beck") 
                    ? " contra TRIANGULO" : " contra rectangulo";
                
                string message = _resultPolygon != null && _resultPolygon.VertexCount > 0
                    ? $"Recorte completado{shapeInfo}.\nPoligono resultante: {_resultPolygon.VertexCount} vertices."
                    : $"El poligono esta completamente fuera de la ventana{shapeInfo}.";

                MessageBox.Show(message, "Recorte Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar recorte:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Dibuja una línea usando el algoritmo de líneas (reutilizado).
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
        /// Dibuja la forma de recorte (rectángulo o triángulo según selección).
        /// </summary>
        private void DrawClipShape()
        {
            for (int i = 0; i < _clipShape.VertexCount; i++)
            {
                var edge = _clipShape.GetEdge(i);
                DrawLineUsingAlgorithm(edge.Start, edge.End, CLIP_WINDOW_COLOR);
            }
        }

        /// <summary>
        /// Dibuja un polígono completo.
        /// </summary>
        private void DrawPolygon(Polygon polygon, Color color)
        {
            if (polygon == null || polygon.VertexCount < 2)
                return;

            for (int i = 0; i < polygon.VertexCount; i++)
            {
                var edge = polygon.GetEdge(i);
                DrawLineUsingAlgorithm(edge.Item1, edge.Item2, color);
            }
        }

        /// <summary>
        /// Redibuja el polígono sujeto sin borrarlo.
        /// </summary>
        private void RedrawSubjectPolygon()
        {
            if (_subjectPolygon.VertexCount > 0)
            {
                // Dibujar vértices
                for (int i = 0; i < _subjectPolygon.VertexCount; i++)
                {
                    _pixelRenderer.DrawPixel(_canvasGraphics, _subjectPolygon.GetVertex(i), VERTEX_COLOR);
                }
                
                // Dibujar aristas
                for (int i = 0; i < _subjectPolygon.VertexCount - 1; i++)
                {
                    DrawLineUsingAlgorithm(_subjectPolygon.GetVertex(i), 
                        _subjectPolygon.GetVertex(i + 1), POLYGON_COLOR);
                }
                
                // Si está cerrado, dibujar última arista
                if (_polygonClosed)
                {
                    DrawLineUsingAlgorithm(_subjectPolygon.GetVertex(_subjectPolygon.VertexCount - 1),
                        _subjectPolygon.GetVertex(0), POLYGON_COLOR);
                }
            }
        }

        /// <summary>
        /// Redibuja todo después del recorte.
        /// </summary>
        private void RedrawAll()
        {
            _canvasGraphics.Clear(BACKGROUND_COLOR);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);

            DrawClipShape();

            if (_resultPolygon != null && _resultPolygon.VertexCount > 0)
            {
                DrawPolygon(_resultPolygon, RESULT_COLOR);
            }

            pctCanvas.Refresh();
        }

        /// <summary>
        /// Muestra el resultado en el ListBox.
        /// </summary>
        private void DisplayResult()
        {
            lstCoordinates.Items.Clear();
            
            if (_resultPolygon != null && _resultPolygon.VertexCount > 0)
            {
                lstCoordinates.Items.Add($"Vertices: {_resultPolygon.VertexCount}");
                lstCoordinates.Items.Add("");
                
                for (int i = 0; i < _resultPolygon.VertexCount; i++)
                {
                    var vertex = _resultPolygon.GetVertex(i);
                    lstCoordinates.Items.Add($"V{i + 1}: ({vertex.X}, {vertex.Y})");
                }
            }
            else
            {
                lstCoordinates.Items.Add("Poligono fuera de ventana");
            }
        }

        private IPolygonClippingAlgorithm GetAlgorithmByName(string name)
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
            _subjectPolygon.Clear();
            _resultPolygon = null;
            _polygonClosed = false;
            _clippingApplied = false;
            _useTriangle = false;
            rbRectangle.Checked = true;

            _clipShape = ClipShape.FromRectangle(_clipRectangle);

            _canvasGraphics.Clear(BACKGROUND_COLOR);
            _pixelRenderer.DrawGrid(_canvasGraphics, CANVAS_WIDTH, CANVAS_HEIGHT);
            DrawClipShape();
            pctCanvas.Refresh();

            lstCoordinates.Items.Clear();
            lblStatus.Text = "Dibuje un poligono";
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
