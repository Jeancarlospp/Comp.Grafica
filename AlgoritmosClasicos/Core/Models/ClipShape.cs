using System.Collections.Generic;

namespace AlgoritmosClasicos.Core.Models
{
    /// <summary>
    /// Representa una forma de recorte que puede ser un rectángulo o un polígono arbitrario.
    /// Utilizado específicamente en el algoritmo de Cyrus-Beck para demostrar su versatilidad.
    /// </summary>
    public class ClipShape
    {
        /// <summary>
        /// Tipo de forma de recorte.
        /// </summary>
        public enum ShapeType
        {
            Rectangle,
            Triangle,
            CustomPolygon
        }

        /// <summary>
        /// Tipo de la forma.
        /// </summary>
        public ShapeType Type { get; private set; }

        /// <summary>
        /// Lista ordenada de vértices que definen la forma.
        /// Los vértices deben estar en orden (horario o antihorario).
        /// </summary>
        public List<PixelPoint> Vertices { get; private set; }

        /// <summary>
        /// Número de vértices de la forma.
        /// </summary>
        public int VertexCount => Vertices.Count;

        /// <summary>
        /// Constructor privado.
        /// </summary>
        private ClipShape(ShapeType type, List<PixelPoint> vertices)
        {
            Type = type;
            Vertices = new List<PixelPoint>(vertices);
        }

        /// <summary>
        /// Crea una forma de recorte rectangular a partir de un ClipRectangle.
        /// </summary>
        public static ClipShape FromRectangle(ClipRectangle rect)
        {
            // Vértices en orden ANTIHORARIO para que las normales calculadas apunten hacia adentro
            var vertices = new List<PixelPoint>
            {
                new PixelPoint(rect.XMin, rect.YMin),  // Inferior izquierda
                new PixelPoint(rect.XMin, rect.YMax),  // Superior izquierda
                new PixelPoint(rect.XMax, rect.YMax),  // Superior derecha
                new PixelPoint(rect.XMax, rect.YMin)   // Inferior derecha
            };

            return new ClipShape(ShapeType.Rectangle, vertices);
        }

        /// <summary>
        /// Crea una forma de recorte triangular predefinida.
        /// Triángulo centrado en el canvas.
        /// </summary>
        public static ClipShape CreatePredefinedTriangle()
        {
            var vertices = new List<PixelPoint>
            {
                new PixelPoint(30, 20),   // Vértice inferior izquierdo
                new PixelPoint(75, 70),   // Vértice superior (pico)
                new PixelPoint(120, 20)   // Vértice inferior derecho
            };

            return new ClipShape(ShapeType.Triangle, vertices);
        }

        /// <summary>
        /// Crea una forma de recorte con vértices personalizados.
        /// </summary>
        public static ClipShape FromVertices(List<PixelPoint> vertices)
        {
            return new ClipShape(ShapeType.CustomPolygon, vertices);
        }

        /// <summary>
        /// Obtiene un vértice en el índice especificado.
        /// </summary>
        public PixelPoint GetVertex(int index)
        {
            return Vertices[index];
        }

        /// <summary>
        /// Obtiene una arista (par de vértices consecutivos).
        /// La última arista conecta el último vértice con el primero.
        /// </summary>
        public (PixelPoint Start, PixelPoint End) GetEdge(int index)
        {
            var start = Vertices[index];
            var end = Vertices[(index + 1) % VertexCount];
            return (start, end);
        }

        public override string ToString()
        {
            return $"ClipShape[{Type}, {VertexCount} vertices]";
        }
    }
}
