using System;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Algorithms
{
    /// <summary>
    /// Clase base abstracta para todos los algoritmos de recorte de líneas.
    /// Contiene lógica común de validación y métodos auxiliares reutilizables.
    /// </summary>
    public abstract class LineClippingAlgorithm : ILineClippingAlgorithm
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        /// <summary>
        /// Método plantilla que valida las entradas y ejecuta el algoritmo específico.
        /// </summary>
        public ClippedLine ClipLine(PixelPoint start, PixelPoint end, ClipRectangle clipRect)
        {
            // Validar entradas
            ValidateInputs(start, end, clipRect);

            // Ejecutar el algoritmo específico
            return ClipLineImplementation(start, end, clipRect);
        }

        /// <summary>
        /// Método abstracto que cada algoritmo concreto debe implementar.
        /// </summary>
        protected abstract ClippedLine ClipLineImplementation(PixelPoint start, PixelPoint end, ClipRectangle clipRect);

        /// <summary>
        /// Valida las entradas del algoritmo.
        /// </summary>
        protected virtual void ValidateInputs(PixelPoint start, PixelPoint end, ClipRectangle clipRect)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start), "El punto inicial no puede ser nulo.");

            if (end == null)
                throw new ArgumentNullException(nameof(end), "El punto final no puede ser nulo.");

            if (clipRect == null)
                throw new ArgumentNullException(nameof(clipRect), "La ventana de recorte no puede ser nula.");

            if (!clipRect.IsValid())
                throw new ArgumentException("La ventana de recorte no es válida.");
        }

        /// <summary>
        /// Verifica si un valor está entre dos límites (inclusivo).
        /// </summary>
        protected bool IsBetween(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}
