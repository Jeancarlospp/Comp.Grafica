using System.Collections.Generic;
using System.Drawing;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.Fill
{
    /// <summary>
    /// Implementación del algoritmo Scanline Fill para relleno de regiones.
    /// 
    /// FUNCIONAMIENTO:
    /// - Más eficiente que Flood Fill y Boundary Fill.
    /// - Rellena líneas horizontales completas (scanlines) en lugar de píxeles individuales.
    /// - Para cada punto, encuentra el inicio y fin de la línea horizontal.
    /// - Luego busca segmentos en las líneas superior e inferior.
    /// - Reduce significativamente el número de operaciones.
    /// - Usa una pila (Stack) para procesamiento.
    /// </summary>
    public class ScanlineFillAlgorithm : FillAlgorithm
    {
        public override string Name => "Scanline Fill";

        public override string Description =>
            "Algoritmo de relleno por líneas de barrido. Más eficiente que Flood Fill. " +
            "Rellena líneas horizontales completas (scanlines) en lugar de píxeles individuales. " +
            "Busca segmentos en líneas adyacentes y reduce operaciones significativamente.";

        protected override List<PixelPoint> FillImplementation(Color[,] grid, PixelPoint startPoint,
            Color fillColor, Color boundaryColor)
        {
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            var filledPoints = new List<PixelPoint>();
            var stack = new Stack<PixelPoint>();

            Color targetColor = grid[startPoint.X, startPoint.Y];

            if (ColorsEqual(targetColor, fillColor))
                return filledPoints;

            stack.Push(startPoint);

            while (stack.Count > 0)
            {
                var point = stack.Pop();
                int x = point.X;
                int y = point.Y;

                if (!ColorsEqual(grid[x, y], targetColor))
                    continue;

                int leftX = x;
                while (leftX > 0 && ColorsEqual(grid[leftX - 1, y], targetColor))
                {
                    leftX--;
                }

                int rightX = x;
                while (rightX < width - 1 && ColorsEqual(grid[rightX + 1, y], targetColor))
                {
                    rightX++;
                }

                for (int i = leftX; i <= rightX; i++)
                {
                    grid[i, y] = fillColor;
                    filledPoints.Add(new PixelPoint(i, y));
                }

                if (y + 1 < height)
                {
                    ScanLine(grid, stack, leftX, rightX, y + 1, targetColor, width, height);
                }

                if (y - 1 >= 0)
                {
                    ScanLine(grid, stack, leftX, rightX, y - 1, targetColor, width, height);
                }
            }

            return filledPoints;
        }

        private void ScanLine(Color[,] grid, Stack<PixelPoint> stack, int leftX, int rightX, 
            int y, Color targetColor, int width, int height)
        {
            bool spanAdded = false;

            for (int x = leftX; x <= rightX; x++)
            {
                if (IsWithinBounds(x, y, width, height) && ColorsEqual(grid[x, y], targetColor))
                {
                    if (!spanAdded)
                    {
                        stack.Push(new PixelPoint(x, y));
                        spanAdded = true;
                    }
                }
                else
                {
                    spanAdded = false;
                }
            }
        }
    }
}
