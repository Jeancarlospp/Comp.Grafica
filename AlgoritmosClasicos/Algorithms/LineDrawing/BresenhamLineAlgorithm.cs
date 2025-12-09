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
        /// <summary>
        /// Nombre del algoritmo.
        /// </summary>
        public override string Name => "Bresenham";

        /// <summary>
        /// Descripción del algoritmo.
        /// </summary>
        public override string Description => 
            "Algoritmo eficiente que usa solo aritmética entera. Utiliza un término de decisión " +
            "incremental para seleccionar los píxeles más cercanos a la línea ideal. Es el más " +
            "rápido de los algoritmos de trazado de líneas.";

        /// <summary>
        /// Calcula los puntos de la línea usando el algoritmo de Bresenham.
        /// 
        /// Funcionamiento:
        /// 1. Calcula las diferencias absolutas dx y dy
        /// 2. Determina la dirección de incremento en X e Y
        /// 3. Usa una variable de decisión (error) para elegir si incrementar Y
        /// 4. Itera desde el punto inicial hasta el final actualizando el error
        /// </summary>
        /// <param name="start">Punto inicial</param>
        /// <param name="end">Punto final</param>
        /// <returns>Lista de puntos que forman la línea</returns>
        protected override List<PixelPoint> CalculateLineImplementation(PixelPoint start, PixelPoint end)
        {
            var points = new List<PixelPoint>();

            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;

            // Calcular diferencias absolutas
            int dx = Abs(x1 - x0);
            int dy = Abs(y1 - y0);

            // Determinar dirección de incremento
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            // Término de error inicial
            int err = dx - dy;

            // Coordenadas actuales
            int x = x0;
            int y = y0;

            // Iterar hasta alcanzar el punto final
            while (true)
            {
                // Agregar el punto actual
                points.Add(new PixelPoint(x, y));

                // Verificar si hemos llegado al punto final
                if (x == x1 && y == y1)
                    break;

                // Calcular el doble del error
                int e2 = 2 * err;

                // Ajustar coordenadas basándose en el error
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
