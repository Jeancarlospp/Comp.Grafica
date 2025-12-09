using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para todos los algoritmos de recorte de polígonos.
    /// Implementada por Sutherland-Hodgman, Weiler-Atherton y Cyrus-Beck.
    /// </summary>
    public interface IPolygonClippingAlgorithm
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
        /// Recorta un polígono contra un rectángulo de recorte.
        /// </summary>
        /// <param name="subjectPolygon">Polígono a recortar</param>
        /// <param name="clipRectangle">Rectángulo de recorte</param>
        /// <returns>Polígono recortado o null si está completamente fuera</returns>
        Polygon ClipPolygon(Polygon subjectPolygon, ClipRectangle clipRectangle);
    }
}
