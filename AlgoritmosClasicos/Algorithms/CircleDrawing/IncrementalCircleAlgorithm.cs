using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.CircleDrawing
{
    /// <summary>
    /// Implementación del algoritmo Incremental (Punto Medio) para trazado de círculos.
    /// 
    /// FUNCIONAMIENTO:
    /// - Basado en la ecuación implícita del círculo: x² + y² - r² = 0
    /// - Evalúa el punto medio entre dos píxeles candidatos.
    /// - Usa un parámetro de decisión para elegir el píxel más cercano al círculo ideal.
    /// - Utiliza solo aritmética entera para eficiencia.
    /// - Aprovecha la simetría de 8 vías del círculo.
    /// - Similar a Bresenham pero basado en la ecuación del círculo.
    /// </summary>
    public class IncrementalCircleAlgorithm : CircleDrawingAlgorithm
    {
        public override string Name => "Incremental (Punto Medio)";

        public override string Description =>
            "Algoritmo basado en la ecuación implícita del círculo. Evalúa el punto medio entre " +
            "píxeles candidatos usando un parámetro de decisión incremental. Utiliza aritmética " +
            "entera y la simetría de 8 vías para eficiencia.";

        protected override List<PixelPoint> CalculateCircleImplementation(PixelPoint center, int radius)
        {
            var points = new List<PixelPoint>();

            int x = 0;
            int y = radius;

            int p = 1 - radius;

            AddSymmetricPoints(points, center, x, y);

            while (x < y)
            {
                x++;

                if (p < 0)
                {
                    p = p + 2 * x + 1;
                }
                else
                {
                    y--;
                    p = p + 2 * (x - y) + 1;
                }

                AddSymmetricPoints(points, center, x, y);
            }

            return SortPointsClockwise(points, center);
        }
    }
}
