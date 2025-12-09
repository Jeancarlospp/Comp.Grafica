using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Algorithms
{
    /// <summary>
    /// Clase base abstracta para todos los algoritmos de trazado de círculos.
    /// Contiene lógica común de validación y métodos auxiliares reutilizables.
    /// </summary>
    public abstract class CircleDrawingAlgorithm : ICircleDrawingAlgorithm
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        /// <summary>
        /// Método plantilla que valida las entradas y ejecuta el algoritmo específico.
        /// </summary>
        public List<PixelPoint> CalculateCircle(PixelPoint center, int radius)
        {
            // Validar entradas
            ValidateInputs(center, radius);

            // Si el radio es 0, retornar solo el centro
            if (radius == 0)
            {
                return new List<PixelPoint> { center };
            }

            // Ejecutar el algoritmo específico
            return CalculateCircleImplementation(center, radius);
        }

        /// <summary>
        /// Método abstracto que cada algoritmo concreto debe implementar.
        /// </summary>
        protected abstract List<PixelPoint> CalculateCircleImplementation(PixelPoint center, int radius);

        /// <summary>
        /// Valida que el centro no sea nulo y que el radio sea válido.
        /// </summary>
        protected virtual void ValidateInputs(PixelPoint center, int radius)
        {
            if (center == null)
                throw new ArgumentNullException(nameof(center), "El centro del círculo no puede ser nulo.");

            if (radius < 0)
                throw new ArgumentException("El radio no puede ser negativo.", nameof(radius));

            const int MAX_RADIUS = 1000;
            if (radius > MAX_RADIUS)
                throw new ArgumentException($"El radio excede el máximo permitido ({MAX_RADIUS}).", nameof(radius));

            // Validar que las coordenadas del centro estén en un rango razonable
            const int MAX_COORDINATE = 10000;
            if (Math.Abs(center.X) > MAX_COORDINATE || Math.Abs(center.Y) > MAX_COORDINATE)
                throw new ArgumentException("Las coordenadas del centro están fuera del rango permitido.");
        }

        /// <summary>
        /// Agrega los 8 puntos simétricos de un círculo dado un punto (x, y) relativo al centro.
        /// Esto aprovecha la simetría de 8 vías del círculo.
        /// </summary>
        protected void AddSymmetricPoints(List<PixelPoint> points, PixelPoint center, int x, int y)
        {
            // Los 8 puntos simétricos son:
            // (x, y), (y, x), (-x, y), (-y, x), (x, -y), (y, -x), (-x, -y), (-y, -x)
            
            points.Add(new PixelPoint(center.X + x, center.Y + y));  // Octante 1
            points.Add(new PixelPoint(center.X + y, center.Y + x));  // Octante 2
            points.Add(new PixelPoint(center.X - y, center.Y + x));  // Octante 3
            points.Add(new PixelPoint(center.X - x, center.Y + y));  // Octante 4
            points.Add(new PixelPoint(center.X - x, center.Y - y));  // Octante 5
            points.Add(new PixelPoint(center.X - y, center.Y - x));  // Octante 6
            points.Add(new PixelPoint(center.X + y, center.Y - x));  // Octante 7
            points.Add(new PixelPoint(center.X + x, center.Y - y));  // Octante 8
        }

        /// <summary>
        /// Calcula el valor absoluto de un número.
        /// </summary>
        protected int Abs(int value)
        {
            return value < 0 ? -value : value;
        }

        /// <summary>
        /// Ordena los puntos del círculo en sentido horario comenzando desde el punto más a la derecha.
        /// Esto es útil para la visualización paso a paso.
        /// </summary>
        protected List<PixelPoint> SortPointsClockwise(List<PixelPoint> points, PixelPoint center)
        {
            // Calcular el ángulo de cada punto respecto al centro
            var pointsWithAngle = new List<(PixelPoint point, double angle)>();
            
            foreach (var point in points)
            {
                int dx = point.X - center.X;
                int dy = point.Y - center.Y;
                double angle = Math.Atan2(dy, dx);
                pointsWithAngle.Add((point, angle));
            }

            // Ordenar por ángulo
            pointsWithAngle.Sort((a, b) => a.angle.CompareTo(b.angle));

            // Extraer solo los puntos
            var sortedPoints = new List<PixelPoint>();
            foreach (var item in pointsWithAngle)
            {
                sortedPoints.Add(item.point);
            }

            return sortedPoints;
        }
    }
}
