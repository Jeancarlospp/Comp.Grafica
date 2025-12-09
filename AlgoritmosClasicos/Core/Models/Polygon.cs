using System;
using System.Collections.Generic;

namespace AlgoritmosClasicos.Core.Models
{
    /// <summary>
    /// Representa un polígono como una lista ordenada de vértices.
    /// Utilizado en algoritmos de recorte de polígonos.
    /// </summary>
    public class Polygon
    {
        private readonly List<PixelPoint> _vertices;

        /// <summary>
        /// Lista de vértices del polígono.
        /// </summary>
        public List<PixelPoint> Vertices => _vertices;

        /// <summary>
        /// Número de vértices en el polígono.
        /// </summary>
        public int VertexCount => _vertices.Count;

        /// <summary>
        /// Indica si el polígono está cerrado (tiene al menos 3 vértices).
        /// </summary>
        public bool IsClosed => _vertices.Count >= 3;

        /// <summary>
        /// Constructor por defecto que crea un polígono vacío.
        /// </summary>
        public Polygon()
        {
            _vertices = new List<PixelPoint>();
        }

        /// <summary>
        /// Constructor que crea un polígono con una lista de vértices.
        /// </summary>
        public Polygon(List<PixelPoint> vertices)
        {
            if (vertices == null)
                throw new ArgumentNullException(nameof(vertices));
            
            _vertices = new List<PixelPoint>(vertices);
        }

        /// <summary>
        /// Agrega un vértice al polígono.
        /// </summary>
        public void AddVertex(PixelPoint vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException(nameof(vertex));
            
            _vertices.Add(vertex);
        }

        /// <summary>
        /// Obtiene un vértice en el índice especificado.
        /// </summary>
        public PixelPoint GetVertex(int index)
        {
            if (index < 0 || index >= _vertices.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            return _vertices[index];
        }

        /// <summary>
        /// Obtiene una arista del polígono (par de vértices consecutivos).
        /// </summary>
        public Tuple<PixelPoint, PixelPoint> GetEdge(int index)
        {
            if (index < 0 || index >= _vertices.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var start = _vertices[index];
            var end = _vertices[(index + 1) % _vertices.Count];
            return new Tuple<PixelPoint, PixelPoint>(start, end);
        }

        /// <summary>
        /// Limpia todos los vértices del polígono.
        /// </summary>
        public void Clear()
        {
            _vertices.Clear();
        }

        /// <summary>
        /// Verifica si el polígono es válido (tiene al menos 3 vértices).
        /// </summary>
        public bool IsValid()
        {
            return _vertices.Count >= 3;
        }

        public override string ToString()
        {
            return $"Polygon[{_vertices.Count} vertices]";
        }
    }
}
