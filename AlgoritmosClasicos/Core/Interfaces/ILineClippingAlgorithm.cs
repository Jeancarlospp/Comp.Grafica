using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para todos los algoritmos de recorte de líneas.
    /// Implementada por Cohen-Sutherland, Liang-Barsky y Nicholl-Lee-Nicholl.
    /// </summary>
    public interface ILineClippingAlgorithm
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
        /// Recorta una línea contra una ventana de recorte rectangular.
        /// </summary>
        /// <param name="start">Punto inicial de la línea</param>
        /// <param name="end">Punto final de la línea</param>
        /// <param name="clipRect">Ventana de recorte</param>
        /// <returns>Línea recortada o null si está completamente fuera</returns>
        ClippedLine ClipLine(PixelPoint start, PixelPoint end, ClipRectangle clipRect);
    }
}
