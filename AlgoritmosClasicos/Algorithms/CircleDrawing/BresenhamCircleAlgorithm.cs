using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.CircleDrawing
{
    /// <summary>
    /// Implementación del algoritmo de Bresenham para trazado de círculos.
    /// 
    /// FUNCIONAMIENTO:
    /// - Utiliza solo aritmética entera para máxima eficiencia.
    /// - Usa un parámetro de decisión para determinar los píxeles a dibujar.
    /// - Aprovecha la simetría de 8 vías del círculo (solo calcula 1/8 del círculo).
    /// - Es el algoritmo más eficiente para dibujar círculos por computadora.
    /// - El parámetro de decisión se actualiza incrementalmente en cada iteración.
    /// </summary>
    public class BresenhamCircleAlgorithm : CircleDrawingAlgorithm
    {
        public override string Name => "Bresenham para Círculos";

        public override string Description =>
            "Algoritmo eficiente que usa solo aritmética entera. Utiliza un parámetro de decisión " +
            "incremental y aprovecha la simetría de 8 vías del círculo para calcular todos los " +
            "puntos dibujando solo un octavo del círculo.";

        protected override List<PixelPoint> CalculateCircleImplementation(PixelPoint center, int radius)
        {
            var points = new List<PixelPoint>();

            int x = 0;
            int y = radius;
            
            // Parámetro de decisión inicial
            int d = 3 - 2 * radius;

            // Agregar los puntos iniciales (simetría de 8 vías)
            AddSymmetricPoints(points, center, x, y);

            // Iterar mientras x <= y (solo 1/8 del círculo)
            while (x <= y)
            {
                x++;

                // Actualizar y y el parámetro de decisión según la condición
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                // Agregar los 8 puntos simétricos
                AddSymmetricPoints(points, center, x, y);
            }

            // Ordenar puntos en sentido horario para mejor visualización paso a paso
            return SortPointsClockwise(points, center);
        }
    }
}
