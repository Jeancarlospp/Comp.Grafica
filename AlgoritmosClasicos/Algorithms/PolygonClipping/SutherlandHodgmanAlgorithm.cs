using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.PolygonClipping
{
    /// <summary>
    /// Implementación del algoritmo de Sutherland-Hodgman para recorte de polígonos.
    /// 
    /// FUNCIONAMIENTO:
    /// - Algoritmo clásico para recortar polígonos convexos contra una ventana rectangular.
    /// - Procesa el polígono contra cada borde de la ventana secuencialmente.
    /// - Para cada borde, clasifica cada arista como dentro/fuera y calcula intersecciones.
    /// - Eficiente y simple de implementar.
    /// - Funciona mejor con polígonos convexos.
    /// </summary>
    public class SutherlandHodgmanAlgorithm : PolygonClippingAlgorithm
    {
        public override string Name => "Sutherland-Hodgman";

        public override string Description =>
            "Algoritmo clásico de recorte de polígonos. Procesa el polígono contra cada borde " +
            "de la ventana secuencialmente. Simple y eficiente para polígonos convexos.";

        protected override Polygon ClipPolygonImplementation(Polygon subjectPolygon, ClipRectangle clipRectangle)
        {
            List<PixelPoint> outputList = new List<PixelPoint>(subjectPolygon.Vertices);

            // Recortar contra cada borde: izquierda, derecha, inferior, superior
            outputList = ClipAgainstEdge(outputList, 0, clipRectangle); // Izquierda
            outputList = ClipAgainstEdge(outputList, 1, clipRectangle); // Derecha
            outputList = ClipAgainstEdge(outputList, 2, clipRectangle); // Inferior
            outputList = ClipAgainstEdge(outputList, 3, clipRectangle); // Superior

            if (outputList.Count < 3)
                return null; // Polígono completamente fuera

            return new Polygon(outputList);
        }

        /// <summary>
        /// Recorta una lista de vértices contra un borde específico.
        /// </summary>
        private List<PixelPoint> ClipAgainstEdge(List<PixelPoint> inputList, int edge, ClipRectangle rect)
        {
            List<PixelPoint> outputList = new List<PixelPoint>();

            if (inputList.Count == 0)
                return outputList;

            PixelPoint prevVertex = inputList[inputList.Count - 1];

            foreach (var currentVertex in inputList)
            {
                bool currentInside = IsInsideEdge(currentVertex, edge, rect);
                bool prevInside = IsInsideEdge(prevVertex, edge, rect);

                if (currentInside)
                {
                    if (!prevInside)
                    {
                        // Entrando: agregar intersección
                        outputList.Add(ComputeIntersection(prevVertex, currentVertex, edge, rect));
                    }
                    // Agregar vértice actual
                    outputList.Add(currentVertex);
                }
                else if (prevInside)
                {
                    // Saliendo: agregar intersección
                    outputList.Add(ComputeIntersection(prevVertex, currentVertex, edge, rect));
                }

                prevVertex = currentVertex;
            }

            return outputList;
        }

        /// <summary>
        /// Verifica si un punto está dentro de un borde específico.
        /// </summary>
        private bool IsInsideEdge(PixelPoint point, int edge, ClipRectangle rect)
        {
            switch (edge)
            {
                case 0: return point.X >= rect.XMin; // Izquierda
                case 1: return point.X <= rect.XMax; // Derecha
                case 2: return point.Y >= rect.YMin; // Inferior
                case 3: return point.Y <= rect.YMax; // Superior
                default: return false;
            }
        }
    }
}
