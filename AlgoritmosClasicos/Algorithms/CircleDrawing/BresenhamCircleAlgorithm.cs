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
   
            int d = 3 - 2 * radius;


            AddSymmetricPoints(points, center, x, y);
            while (x <= y)
            {
                x++;

                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                AddSymmetricPoints(points, center, x, y);
            }

            return SortPointsClockwise(points, center);
        }
    }
}
