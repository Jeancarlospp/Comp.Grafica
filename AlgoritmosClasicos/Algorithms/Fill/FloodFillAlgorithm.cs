using System.Collections.Generic;
using System.Drawing;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.Fill
{
    /// <summary>
    /// Implementación del algoritmo Flood Fill para relleno de regiones.
    /// 
    /// FUNCIONAMIENTO:
    /// - Inicia desde un punto semilla y se expande en todas direcciones.
    /// - Rellena todos los píxeles del mismo color que el punto inicial.
    /// - Usa una cola (Queue) para procesamiento en orden BFS (Breadth-First Search).
    /// - Se detiene cuando encuentra píxeles de diferente color o los bordes.
    /// - Conectividad de 4 direcciones (arriba, abajo, izquierda, derecha).
    /// </summary>
    public class FloodFillAlgorithm : FillAlgorithm
    {
        public override string Name => "Flood Fill";

        public override string Description =>
            "Algoritmo de relleno por inundación. Inicia desde un punto semilla y se expande " +
            "en todas las direcciones rellenando píxeles del mismo color que el punto inicial. " +
            "Usa conectividad de 4 direcciones y procesamiento BFS con cola.";

        protected override List<PixelPoint> FillImplementation(Color[,] grid, PixelPoint startPoint,
            Color fillColor, Color boundaryColor)
        {
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            var filledPoints = new List<PixelPoint>();
            var queue = new Queue<PixelPoint>();
            var visited = new bool[width, height];

            Color targetColor = grid[startPoint.X, startPoint.Y];

            if (ColorsEqual(targetColor, fillColor))
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
                    if (!visited[neighbor.X, neighbor.Y] &&
                        ColorsEqual(grid[neighbor.X, neighbor.Y], targetColor))
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
