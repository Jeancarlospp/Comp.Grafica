using System.Collections.Generic;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para todos los algoritmos de trazado de líneas.
    /// Implementada por DDA, Bresenham y Midpoint.
    /// </summary>
    public interface ILineDrawingAlgorithm
    {
        /// <summary>
        /// Nombre descriptivo del algoritmo.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Descripción breve del algoritmo y su funcionamiento.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Calcula todos los puntos píxel necesarios para dibujar una línea
        /// desde el punto inicial hasta el punto final.
        /// </summary>
        /// <param name="start">Punto inicial de la línea</param>
        /// <param name="end">Punto final de la línea</param>
        /// <returns>Lista ordenada de puntos que forman la línea</returns>
        List<PixelPoint> CalculateLine(PixelPoint start, PixelPoint end);
    }
}
