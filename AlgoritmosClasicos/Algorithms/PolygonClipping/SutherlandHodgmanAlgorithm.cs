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


            outputList = ClipAgainstEdge(outputList, 0, clipRectangle); 
            outputList = ClipAgainstEdge(outputList, 1, clipRectangle); 
            outputList = ClipAgainstEdge(outputList, 2, clipRectangle); 
            outputList = ClipAgainstEdge(outputList, 3, clipRectangle); 

            if (outputList.Count < 3)
                return null; 

            return new Polygon(outputList);
        }


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

                        outputList.Add(ComputeIntersection(prevVertex, currentVertex, edge, rect));
                    }

                    outputList.Add(currentVertex);
                }
                else if (prevInside)
                {

                    outputList.Add(ComputeIntersection(prevVertex, currentVertex, edge, rect));
                }

                prevVertex = currentVertex;
            }

            return outputList;
        }

        private bool IsInsideEdge(PixelPoint point, int edge, ClipRectangle rect)
        {
            switch (edge)
            {
                case 0: return point.X >= rect.XMin; 
                case 1: return point.X <= rect.XMax; 
                case 2: return point.Y >= rect.YMin; 
                case 3: return point.Y <= rect.YMax; 
                default: return false;
            }
        }
    }
}
