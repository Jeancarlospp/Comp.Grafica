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

            // Parámetro de decisión inicial basado en la ecuación del círculo
            // p = 1 - r (evaluando en el punto medio inicial)
            int p = 1 - radius;

            // Agregar los puntos iniciales
            AddSymmetricPoints(points, center, x, y);

            // Iterar mientras x <= y (solo necesitamos calcular 1/8 del círculo)
            while (x < y)
            {
                x++;

                // Actualizar el parámetro de decisión
                if (p < 0)
                {
                    // Punto medio está dentro del círculo, elegir píxel E (Este)
                    p = p + 2 * x + 1;
                }
                else
                {
                    // Punto medio está fuera del círculo, elegir píxel SE (Sureste)
                    y--;
                    p = p + 2 * (x - y) + 1;
                }

                // Agregar los 8 puntos simétricos
                AddSymmetricPoints(points, center, x, y);
            }

            // Ordenar puntos en sentido horario para mejor visualización
            return SortPointsClockwise(points, center);
        }
    }
}
