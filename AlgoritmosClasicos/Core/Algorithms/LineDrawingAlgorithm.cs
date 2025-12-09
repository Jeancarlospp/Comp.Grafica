using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Algorithms
{
    /// <summary>
    /// Clase base abstracta para todos los algoritmos de trazado de líneas.
    /// Contiene lógica común de validación y estructuración.
    /// </summary>
    public abstract class LineDrawingAlgorithm : ILineDrawingAlgorithm
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        /// <summary>
        /// Método plantilla que valida las entradas y ejecuta el algoritmo específico.
        /// </summary>
        public List<PixelPoint> CalculateLine(PixelPoint start, PixelPoint end)
        {
            // Validar entradas
            ValidatePoints(start, end);

            // Si los puntos son iguales, retornar lista con un solo punto
            if (start.Equals(end))
            {
                return new List<PixelPoint> { start };
            }

            // Ejecutar el algoritmo específico
            return CalculateLineImplementation(start, end);
        }

        /// <summary>
        /// Método abstracto que cada algoritmo concreto debe implementar.
        /// </summary>
        protected abstract List<PixelPoint> CalculateLineImplementation(PixelPoint start, PixelPoint end);

        /// <summary>
        /// Valida que los puntos no sean nulos y sean válidos.
        /// </summary>
        protected virtual void ValidatePoints(PixelPoint start, PixelPoint end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start), "El punto inicial no puede ser nulo.");

            if (end == null)
                throw new ArgumentNullException(nameof(end), "El punto final no puede ser nulo.");

            // Validar que las coordenadas estén en un rango razonable
            const int MAX_COORDINATE = 10000;
            
            if (Math.Abs(start.X) > MAX_COORDINATE || Math.Abs(start.Y) > MAX_COORDINATE)
                throw new ArgumentException("Las coordenadas del punto inicial están fuera del rango permitido.");

            if (Math.Abs(end.X) > MAX_COORDINATE || Math.Abs(end.Y) > MAX_COORDINATE)
                throw new ArgumentException("Las coordenadas del punto final están fuera del rango permitido.");
        }

        /// <summary>
        /// Método auxiliar para intercambiar dos valores.
        /// </summary>
        protected void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Calcula el valor absoluto de un número.
        /// </summary>
        protected int Abs(int value)
        {
            return value < 0 ? -value : value;
        }

        /// <summary>
        /// Retorna el signo de un número (-1, 0, o 1).
        /// </summary>
        protected int Sign(int value)
        {
            if (value > 0) return 1;
            if (value < 0) return -1;
            return 0;
        }
    }
}
