using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.LineDrawing
{
    /// <summary>
    /// Implementación del algoritmo de Punto Medio (Midpoint) para trazado de líneas.
    /// 
    /// FUNCIONAMIENTO:
    /// - Similar a Bresenham, pero se basa en la ecuación implícita de la línea.
    /// - Evalúa el punto medio entre dos píxeles candidatos.
    /// - Usa un parámetro de decisión para elegir el píxel más cercano a la línea real.
    /// - También utiliza solo aritmética entera para eficiencia.
    /// - Divide el problema en octantes según la pendiente de la línea.
    /// </summary>
    public class MidpointLineAlgorithm : LineDrawingAlgorithm
    {
        public override string Name => "Punto Medio (Midpoint)";

        public override string Description => 
            "Algoritmo basado en la ecuación implícita de la línea. Evalúa el punto medio entre " +
            "píxeles candidatos y usa un parámetro de decisión incremental. Divide el trazado " +
            "en octantes para manejar diferentes pendientes.";

        protected override List<PixelPoint> CalculateLineImplementation(PixelPoint start, PixelPoint end)
        {
            var points = new List<PixelPoint>();

            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;

            int dx = Abs(x1 - x0);
            int dy = Abs(y1 - y0);

            // Determinar si la pendiente es suave (|m| <= 1) o pronunciada (|m| > 1)
            bool isSteep = dy > dx;

            // Si la línea es pronunciada, intercambiar x e y
            if (isSteep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
                Swap(ref dx, ref dy);
            }

            // Asegurar que dibujamos de izquierda a derecha
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            // Dirección de incremento en Y
            int yStep = y0 < y1 ? 1 : -1;

            // Parámetro de decisión inicial
            int decision = 2 * dy - dx;
            
            // Incrementos del parámetro de decisión
            int incrE = 2 * dy;           // Incremento si elegimos E (Este)
            int incrNE = 2 * (dy - dx);   // Incremento si elegimos NE (Noreste)

            int x = x0;
            int y = y0;

            // Dibujar la línea
            for (int i = 0; i <= dx; i++)
            {
                // Agregar el punto (revertir intercambio si fue necesario)
                if (isSteep)
                    points.Add(new PixelPoint(y, x));
                else
                    points.Add(new PixelPoint(x, y));

                // Actualizar coordenadas basándose en el parámetro de decisión
                if (decision <= 0)
                {
                    // Elegir píxel E (Este)
                    decision += incrE;
                }
                else
                {
                    // Elegir píxel NE (Noreste/Sureste)
                    y += yStep;
                    decision += incrNE;
                }

                x++;
            }

            return points;
        }
    }
}
