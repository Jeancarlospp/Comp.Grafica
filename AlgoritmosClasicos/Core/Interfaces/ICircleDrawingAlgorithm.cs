using System.Collections.Generic;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para todos los algoritmos de trazado de círculos.
    /// Implementada por Bresenham, Incremental y DDA para círculos.
    /// </summary>
    public interface ICircleDrawingAlgorithm
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
        /// Calcula todos los puntos píxel necesarios para dibujar un círculo
        /// dado un centro y un radio.
        /// </summary>
        /// <param name="center">Centro del círculo</param>
        /// <param name="radius">Radio del círculo</param>
        /// <returns>Lista ordenada de puntos que forman el círculo</returns>
        List<PixelPoint> CalculateCircle(PixelPoint center, int radius);
    }
}
