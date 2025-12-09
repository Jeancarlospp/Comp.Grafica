using System.Collections.Generic;
using System.Drawing;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para todos los algoritmos de relleno.
    /// Implementada por Flood Fill, Boundary Fill y Scanline Fill.
    /// </summary>
    public interface IFillAlgorithm
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
        /// Ejecuta el algoritmo de relleno desde un punto inicial.
        /// </summary>
        /// <param name="grid">Grilla de píxeles del canvas</param>
        /// <param name="startPoint">Punto inicial desde donde comenzar el relleno</param>
        /// <param name="fillColor">Color de relleno</param>
        /// <param name="boundaryColor">Color del borde (usado en Boundary Fill)</param>
        /// <returns>Lista ordenada de puntos rellenados (para animación paso a paso)</returns>
        List<PixelPoint> Fill(Color[,] grid, PixelPoint startPoint, Color fillColor, Color boundaryColor);
    }
}
