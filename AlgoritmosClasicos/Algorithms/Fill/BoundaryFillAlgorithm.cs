using System.Collections.Generic;
using System.Drawing;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.Fill
{
    /// <summary>
    /// Implementación del algoritmo Boundary Fill para relleno de regiones.
    /// 
    /// FUNCIONAMIENTO:
    /// - Inicia desde un punto semilla y se expande hasta encontrar un color de borde.
    /// - A diferencia de Flood Fill, busca un color específico de borde/frontera.
    /// - Rellena todos los píxeles que NO sean del color de borde ni del color de relleno.
    /// - Usa una cola (Queue) para procesamiento en orden BFS.
    /// - Conectividad de 4 direcciones.
    /// - Útil cuando hay un contorno/borde específico que delimita el área.
    /// </summary>
    public class BoundaryFillAlgorithm : FillAlgorithm
    {
        public override string Name => "Boundary Fill";

        public override string Description =>
            "Algoritmo de relleno por frontera. Se expande desde un punto semilla hasta " +
            "encontrar píxeles de un color de borde específico. Rellena todo lo que no sea " +
            "el color de borde. Usa conectividad de 4 direcciones y procesamiento BFS.";

        protected override List<PixelPoint> FillImplementation(Color[,] grid, PixelPoint startPoint,
            Color fillColor, Color boundaryColor)
        {
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            var filledPoints = new List<PixelPoint>();
            var queue = new Queue<PixelPoint>();
            var visited = new bool[width, height];

            Color startColor = grid[startPoint.X, startPoint.Y];

            if (ColorsEqual(startColor, boundaryColor) || ColorsEqual(startColor, fillColor))
                return filledPoints;

            queue.Enqueue(startPoint);
            visited[startPoint.X, startPoint.Y] = true;

            while (queue.Count > 0)
            {
                var currentPoint = queue.Dequeue();

                grid[currentPoint.X, currentPoint.Y] = fillColor;
                filledPoints.Add(currentPoint);

                var neighbors = GetNeighbors4(currentPoint, width, height);

                foreach (var neighbor in neighbors)
                {
                    Color neighborColor = grid[neighbor.X, neighbor.Y];

                    if (!visited[neighbor.X, neighbor.Y] &&
                        !ColorsEqual(neighborColor, boundaryColor) &&
                        !ColorsEqual(neighborColor, fillColor))
                    {
                        visited[neighbor.X, neighbor.Y] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return filledPoints;
        }
    }
}
