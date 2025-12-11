using System;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.LineClipping
{
    /// <summary>
    /// Implementación del algoritmo de Liang-Barsky para recorte de líneas.
    /// 
    /// FUNCIONAMIENTO:
    /// - Usa forma paramétrica de la línea: P(t) = P0 + t*(P1-P0), donde 0 <= t <= 1
    /// - Calcula parámetros t de entrada y salida de la ventana de recorte.
    /// - Más eficiente que Cohen-Sutherland (menos cálculos de intersección).
    /// - Evita división por cero y maneja líneas paralelas a los bordes.
    /// - Solo calcula intersecciones si la línea puede ser visible.
    /// </summary>
    public class LiangBarskyAlgorithm : LineClippingAlgorithm
    {
        public override string Name => "Liang-Barsky";

        public override string Description =>
            "Algoritmo eficiente basado en forma paramétrica de la línea. Calcula parámetros t de entrada/salida " +
            "de la ventana. Más rápido que Cohen-Sutherland con menos cálculos. Maneja casos especiales elegantemente.";

        protected override ClippedLine ClipLineImplementation(PixelPoint start, PixelPoint end, ClipRectangle clipRect)
        {
            float x0 = start.X;
            float y0 = start.Y;
            float x1 = end.X;
            float y1 = end.Y;

            float dx = x1 - x0;
            float dy = y1 - y0;

            float t0 = 0.0f;
            float t1 = 1.0f;

            float[] p = { -dx, dx, -dy, dy };
            float[] q = { x0 - clipRect.XMin, clipRect.XMax - x0, 
                         y0 - clipRect.YMin, clipRect.YMax - y0 };

            for (int i = 0; i < 4; i++)
            {
                if (p[i] == 0)
                {
                    if (q[i] < 0)
                    {
                        return ClippedLine.NotVisible();
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
                return ClippedLine.NotVisible();
            }

            int clippedX0 = (int)Math.Round(x0 + t0 * dx);
            int clippedY0 = (int)Math.Round(y0 + t0 * dy);
            int clippedX1 = (int)Math.Round(x0 + t1 * dx);
            int clippedY1 = (int)Math.Round(y0 + t1 * dy);

            return new ClippedLine(
                new PixelPoint(clippedX0, clippedY0),
                new PixelPoint(clippedX1, clippedY1)
            );
        }
    }
}
