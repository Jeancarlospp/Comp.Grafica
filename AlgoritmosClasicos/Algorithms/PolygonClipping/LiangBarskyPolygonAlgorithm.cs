using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.PolygonClipping
{
    /// <summary>
    /// Implementación del algoritmo de Liang-Barsky para recorte de polígonos.
    /// 
    /// FUNCIONAMIENTO:
    /// - Extiende el algoritmo de Liang-Barsky de recorte de líneas a polígonos.
    /// - Recorta cada arista del polígono independientemente usando forma paramétrica.
    /// - Usa parámetros t de entrada y salida para determinar segmentos visibles.
    /// - Más eficiente que Sutherland-Hodgman con menos cálculos de intersección.
    /// - Reutiliza la lógica matemática del algoritmo de Liang-Barsky para líneas.
    /// 
    /// VENTAJAS:
    /// - Simple y eficiente (menos cálculos que Sutherland-Hodgman)
    /// - Evita división por cero y maneja líneas paralelas
    /// - Reutiliza código existente
    /// </summary>
    public class LiangBarskyPolygonAlgorithm : PolygonClippingAlgorithm
    {
        public override string Name => "Liang-Barsky";

        public override string Description =>
            "Algoritmo eficiente que extiende Liang-Barsky de líneas a polígonos. Recorta cada arista " +
            "usando forma paramétrica con parámetros t de entrada/salida. Menos cálculos que Sutherland-Hodgman.";

        protected override Polygon ClipPolygonImplementation(Polygon subjectPolygon, ClipRectangle clipRectangle)
        {
            List<PixelPoint> clippedVertices = new List<PixelPoint>();

            for (int i = 0; i < subjectPolygon.VertexCount; i++)
            {
                var edge = subjectPolygon.GetEdge(i);
                var p1 = edge.Item1;
                var p2 = edge.Item2;

                var clippedEdge = ClipEdgeLiangBarsky(p1, p2, clipRectangle);

                if (clippedEdge != null)
                {
                    if (clippedVertices.Count == 0 || 
                        !clippedVertices[clippedVertices.Count - 1].Equals(clippedEdge.Item1))
                    {
                        clippedVertices.Add(clippedEdge.Item1);
                    }

                    if (!clippedEdge.Item1.Equals(clippedEdge.Item2))
                    {
                        clippedVertices.Add(clippedEdge.Item2);
                    }
                }
            }

            clippedVertices = RemoveConsecutiveDuplicates(clippedVertices);

            if (clippedVertices.Count < 3)
                return null; 

            return new Polygon(clippedVertices);
        }

        private Tuple<PixelPoint, PixelPoint> ClipEdgeLiangBarsky(PixelPoint p1, PixelPoint p2, ClipRectangle rect)
        {
            float x1 = p1.X;
            float y1 = p1.Y;
            float x2 = p2.X;
            float y2 = p2.Y;

            float dx = x2 - x1;
            float dy = y2 - y1;

            float t0 = 0.0f;  
            float t1 = 1.0f;  

            float[] p = { -dx, dx, -dy, dy };
            float[] q = { x1 - rect.XMin, rect.XMax - x1, 
                         y1 - rect.YMin, rect.YMax - y1 };

            for (int i = 0; i < 4; i++)
            {
                if (p[i] == 0)
                {
                    if (q[i] < 0)
                    {
                        return null;
                    }
                }
                else
                {
                    float t = q[i] / p[i];

                    if (p[i] < 0)
                    {
                        t0 = Math.Max(t0, t);
                    }
                    else
                    {
                        t1 = Math.Min(t1, t);
                    }
                }
            }

            if (t0 > t1)
            {
                return null;
            }

            int clippedX1 = (int)Math.Round(x1 + t0 * dx);
            int clippedY1 = (int)Math.Round(y1 + t0 * dy);
            int clippedX2 = (int)Math.Round(x1 + t1 * dx);
            int clippedY2 = (int)Math.Round(y1 + t1 * dy);

            return new Tuple<PixelPoint, PixelPoint>(
                new PixelPoint(clippedX1, clippedY1),
                new PixelPoint(clippedX2, clippedY2)
            );
        }

        private List<PixelPoint> RemoveConsecutiveDuplicates(List<PixelPoint> vertices)
        {
            if (vertices.Count == 0)
                return vertices;

            List<PixelPoint> result = new List<PixelPoint>();
            result.Add(vertices[0]);

            for (int i = 1; i < vertices.Count; i++)
            {
                if (!vertices[i].Equals(vertices[i - 1]))
                {
                    result.Add(vertices[i]);
                }
            }

            if (result.Count > 1 && result[result.Count - 1].Equals(result[0]))
            {
                result.RemoveAt(result.Count - 1);
            }

            return result;
        }
    }
}
