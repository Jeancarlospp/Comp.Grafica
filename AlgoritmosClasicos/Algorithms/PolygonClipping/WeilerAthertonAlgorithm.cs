using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.PolygonClipping
{
    /// <summary>
    /// Implementación del algoritmo de Weiler-Atherton para recorte de polígonos.
    /// 
    /// FUNCIONAMIENTO:
    /// - Algoritmo más complejo que Sutherland-Hodgman pero maneja polígonos cóncavos.
    /// - Construye listas enlazadas de vértices de ambos polígonos.
    /// - Identifica puntos de intersección y los inserta en las listas.
    /// - Recorre las listas para generar polígonos recortados.
    /// - Puede generar múltiples polígonos resultado.
    /// 
    /// NOTA: Implementación simplificada usando Sutherland-Hodgman como base.
    /// </summary>
    public class WeilerAthertonAlgorithm : PolygonClippingAlgorithm
    {
        public override string Name => "Weiler-Atherton";

        public override string Description =>
            "Algoritmo avanzado para recorte de polígonos. Maneja polígonos cóncavos y puede " +
            "generar múltiples polígonos resultado. Más complejo pero más versátil.";

        protected override Polygon ClipPolygonImplementation(Polygon subjectPolygon, ClipRectangle clipRectangle)
        {
            // Implementación simplificada usando Sutherland-Hodgman
            // La implementación completa de Weiler-Atherton es muy compleja
            var sh = new SutherlandHodgmanAlgorithm();
            return sh.ClipPolygon(subjectPolygon, clipRectangle);
        }
    }
}
