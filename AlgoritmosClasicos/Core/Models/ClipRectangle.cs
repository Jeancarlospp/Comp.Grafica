using System;

namespace AlgoritmosClasicos.Core.Models
{
    /// <summary>
    /// Representa un rectángulo de recorte (ventana de recorte) en coordenadas de píxeles.
    /// Utilizado en algoritmos de recorte de líneas.
    /// </summary>
    public class ClipRectangle
    {
        /// <summary>
        /// Coordenada X mínima (izquierda).
        /// </summary>
        public int XMin { get; }

        /// <summary>
        /// Coordenada Y mínima (inferior).
        /// </summary>
        public int YMin { get; }

        /// <summary>
        /// Coordenada X máxima (derecha).
        /// </summary>
        public int XMax { get; }

        /// <summary>
        /// Coordenada Y máxima (superior).
        /// </summary>
        public int YMax { get; }

        /// <summary>
        /// Ancho del rectángulo.
        /// </summary>
        public int Width => XMax - XMin;

        /// <summary>
        /// Alto del rectángulo.
        /// </summary>
        public int Height => YMax - YMin;

        /// <summary>
        /// Constructor del rectángulo de recorte.
        /// </summary>
        /// <param name="xMin">Coordenada X mínima</param>
        /// <param name="yMin">Coordenada Y mínima</param>
        /// <param name="xMax">Coordenada X máxima</param>
        /// <param name="yMax">Coordenada Y máxima</param>
        public ClipRectangle(int xMin, int yMin, int xMax, int yMax)
        {
            if (xMin >= xMax)
                throw new ArgumentException("XMin debe ser menor que XMax");
            
            if (yMin >= yMax)
                throw new ArgumentException("YMin debe ser menor que YMax");

            XMin = xMin;
            YMin = yMin;
            XMax = xMax;
            YMax = yMax;
        }

        /// <summary>
        /// Verifica si un punto está completamente dentro del rectángulo.
        /// </summary>
        public bool Contains(PixelPoint point)
        {
            return point.X >= XMin && point.X <= XMax &&
                   point.Y >= YMin && point.Y <= YMax;
        }

        /// <summary>
        /// Verifica si el rectángulo es válido (tiene área positiva).
        /// </summary>
        public bool IsValid()
        {
            return Width > 0 && Height > 0;
        }

        public override string ToString()
        {
            return $"ClipRect[({XMin},{YMin}) - ({XMax},{YMax})]";
        }
    }
}
