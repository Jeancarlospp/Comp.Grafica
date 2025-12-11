using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.LineDrawing
{
    /// <summary>
    /// Implementación del algoritmo de Bresenham para trazado de líneas.
    /// 
    /// FUNCIONAMIENTO:
    /// - Utiliza solo aritmética entera, haciéndolo muy eficiente.
    /// - Usa un término de decisión para determinar qué píxel seleccionar.
    /// - El término de decisión se actualiza incrementalmente en cada paso.
    /// - Evita divisiones y operaciones de punto flotante.
    /// - Es el algoritmo más utilizado en gráficos por computadora por su eficiencia.
    /// </summary>
    public class BresenhamLineAlgorithm : LineDrawingAlgorithm
    {

        public override string Name => "Bresenham";
        public override string Description => 
            "Algoritmo eficiente que usa solo aritmética entera. Utiliza un término de decisión " +
            "incremental para seleccionar los píxeles más cercanos a la línea ideal. Es el más " +
            "rápido de los algoritmos de trazado de líneas.";

        /// <param name="start">Punto inicial</param>
        /// <param name="end">Punto final</param>
        protected override List<PixelPoint> CalculateLineImplementation(PixelPoint start, PixelPoint end)
        {
            var points = new List<PixelPoint>();

            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;
            int dx = Abs(x1 - x0);
            int dy = Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            int err = dx - dy;

            int x = x0;
            int y = y0;

            while (true)
            {
                points.Add(new PixelPoint(x, y));

                if (x == x1 && y == y1)
                    break;
                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }

            return points;
        }
    }
}
