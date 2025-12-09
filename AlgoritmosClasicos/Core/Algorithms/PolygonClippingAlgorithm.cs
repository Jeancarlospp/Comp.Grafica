using System;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Algorithms
{
    /// <summary>
    /// Clase base abstracta para todos los algoritmos de recorte de polígonos.
    /// Contiene lógica común de validación y métodos auxiliares reutilizables.
    /// </summary>
    public abstract class PolygonClippingAlgorithm : IPolygonClippingAlgorithm
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        /// <summary>
        /// Método plantilla que valida las entradas y ejecuta el algoritmo específico.
        /// </summary>
        public Polygon ClipPolygon(Polygon subjectPolygon, ClipRectangle clipRectangle)
        {
            // Validar entradas
            ValidateInputs(subjectPolygon, clipRectangle);

            // Ejecutar el algoritmo específico
            return ClipPolygonImplementation(subjectPolygon, clipRectangle);
        }

        /// <summary>
        /// Método abstracto que cada algoritmo concreto debe implementar.
        /// </summary>
        protected abstract Polygon ClipPolygonImplementation(Polygon subjectPolygon, ClipRectangle clipRectangle);

        /// <summary>
        /// Valida las entradas del algoritmo.
        /// </summary>
        protected virtual void ValidateInputs(Polygon subjectPolygon, ClipRectangle clipRectangle)
        {
            if (subjectPolygon == null)
                throw new ArgumentNullException(nameof(subjectPolygon), "El polígono sujeto no puede ser nulo.");

            if (clipRectangle == null)
                throw new ArgumentNullException(nameof(clipRectangle), "El rectángulo de recorte no puede ser nulo.");

            if (!subjectPolygon.IsValid())
                throw new ArgumentException("El polígono sujeto no es válido (necesita al menos 3 vértices).");

            if (!clipRectangle.IsValid())
                throw new ArgumentException("El rectángulo de recorte no es válido.");
        }

        /// <summary>
        /// Verifica si un punto está dentro del rectángulo de recorte.
        /// </summary>
        protected bool IsInside(PixelPoint point, ClipRectangle rect)
        {
            return point.X >= rect.XMin && point.X <= rect.XMax &&
                   point.Y >= rect.YMin && point.Y <= rect.YMax;
        }

        /// <summary>
        /// Calcula la intersección entre una línea y un borde del rectángulo.
        /// </summary>
        protected PixelPoint ComputeIntersection(PixelPoint p1, PixelPoint p2, int edge, ClipRectangle rect)
        {
            float x1 = p1.X;
            float y1 = p1.Y;
            float x2 = p2.X;
            float y2 = p2.Y;

            float x = 0, y = 0;

            // edge: 0=izquierda, 1=derecha, 2=inferior, 3=superior
            switch (edge)
            {
                case 0: // Izquierda
                    x = rect.XMin;
                    y = y1 + (y2 - y1) * (rect.XMin - x1) / (x2 - x1);
                    break;
                case 1: // Derecha
                    x = rect.XMax;
                    y = y1 + (y2 - y1) * (rect.XMax - x1) / (x2 - x1);
                    break;
                case 2: // Inferior
                    y = rect.YMin;
                    x = x1 + (x2 - x1) * (rect.YMin - y1) / (y2 - y1);
                    break;
                case 3: // Superior
                    y = rect.YMax;
                    x = x1 + (x2 - x1) * (rect.YMax - y1) / (y2 - y1);
                    break;
            }

            return new PixelPoint((int)Math.Round(x), (int)Math.Round(y));
        }
    }
}
