using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.LineClipping
{
    /// <summary>
    /// Implementación del algoritmo de Cohen-Sutherland para recorte de líneas.
    /// 
    /// FUNCIONAMIENTO:
    /// - Divide el espacio en 9 regiones usando códigos de 4 bits.
    /// - Cada bit representa una posición relativa a la ventana (arriba, abajo, izquierda, derecha).
    /// - Utiliza operaciones lógicas (AND, OR) para determinar aceptación/rechazo rápido.
    /// - Para líneas que cruzan, calcula puntos de intersección iterativamente.
    /// - Muy eficiente para casos triviales (completamente dentro o fuera).
    /// </summary>
    public class CohenSutherlandAlgorithm : LineClippingAlgorithm
    {
        // Códigos de región
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        public override string Name => "Cohen-Sutherland";

        public override string Description =>
            "Algoritmo clásico de recorte de líneas. Divide el espacio en 9 regiones usando códigos de 4 bits. " +
            "Usa operaciones lógicas para determinar aceptación/rechazo rápido. Calcula intersecciones iterativamente.";

        protected override ClippedLine ClipLineImplementation(PixelPoint start, PixelPoint end, ClipRectangle clipRect)
        {
            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;

            // Calcular códigos de región para ambos puntos
            int code0 = ComputeCode(x0, y0, clipRect);
            int code1 = ComputeCode(x1, y1, clipRect);

            bool accept = false;

            while (true)
            {
                if ((code0 | code1) == 0)
                {
                    // Ambos puntos dentro - aceptar
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != 0)
                {
                    // Ambos puntos en la misma región externa - rechazar
                    break;
                }
                else
                {
                    // Línea parcialmente dentro - calcular intersección
                    int x = 0, y = 0;

                    // Seleccionar el punto que está fuera
                    int codeOut = code0 != 0 ? code0 : code1;

                    // Encontrar punto de intersección
                    if ((codeOut & TOP) != 0)
                    {
                        // Intersección con borde superior
                        x = x0 + (x1 - x0) * (clipRect.YMax - y0) / (y1 - y0);
                        y = clipRect.YMax;
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    {
                        // Intersección con borde inferior
                        x = x0 + (x1 - x0) * (clipRect.YMin - y0) / (y1 - y0);
                        y = clipRect.YMin;
                    }
                    else if ((codeOut & RIGHT) != 0)
                    {
                        // Intersección con borde derecho
                        y = y0 + (y1 - y0) * (clipRect.XMax - x0) / (x1 - x0);
                        x = clipRect.XMax;
                    }
                    else if ((codeOut & LEFT) != 0)
                    {
                        // Intersección con borde izquierdo
                        y = y0 + (y1 - y0) * (clipRect.XMin - x0) / (x1 - x0);
                        x = clipRect.XMin;
                    }

                    // Reemplazar el punto fuera con el punto de intersección
                    if (codeOut == code0)
                    {
                        x0 = x;
                        y0 = y;
                        code0 = ComputeCode(x0, y0, clipRect);
                    }
                    else
                    {
                        x1 = x;
                        y1 = y;
                        code1 = ComputeCode(x1, y1, clipRect);
                    }
                }
            }

            if (accept)
            {
                return new ClippedLine(new PixelPoint(x0, y0), new PixelPoint(x1, y1));
            }
            else
            {
                return ClippedLine.NotVisible();
            }
        }

        /// <summary>
        /// Calcula el código de región de un punto.
        /// </summary>
        private int ComputeCode(int x, int y, ClipRectangle clipRect)
        {
            int code = INSIDE;

            if (x < clipRect.XMin)
                code |= LEFT;
            else if (x > clipRect.XMax)
                code |= RIGHT;

            if (y < clipRect.YMin)
                code |= BOTTOM;
            else if (y > clipRect.YMax)
                code |= TOP;

            return code;
        }
    }
}
