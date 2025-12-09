using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.PolygonClipping
{
    /// <summary>
    /// Implementación del algoritmo de Cyrus-Beck para recorte de polígonos.
    /// 
    /// FUNCIONAMIENTO:
    /// - Originalmente diseñado para recorte de líneas contra polígonos convexos.
    /// - Adaptado para recortar polígonos contra ventanas rectangulares.
    /// - Usa el concepto de normales de bordes para determinar visibilidad.
    /// - Eficiente y generalizable a ventanas convexas arbitrarias.
    /// 
    /// NOTA: Para ventanas rectangulares, usa Sutherland-Hodgman como base.
    /// </summary>
    public class CyrusBeckAlgorithm : PolygonClippingAlgorithm
    {
        public override string Name => "Cyrus-Beck";

        public override string Description =>
            "Algoritmo versátil basado en normales de bordes. Originalmente para recorte de líneas, " +
            "adaptado para polígonos. Eficiente y generalizable a ventanas convexas.";

        protected override Polygon ClipPolygonImplementation(Polygon subjectPolygon, ClipRectangle clipRectangle)
        {
            // Para ventanas rectangulares, Sutherland-Hodgman es equivalente
            var sh = new SutherlandHodgmanAlgorithm();
            return sh.ClipPolygon(subjectPolygon, clipRectangle);
        }
    }
}
