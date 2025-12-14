using System;
using System.Collections.Generic;

namespace CurvasBezierYBSpline.Modelos
{
    public class BSplineCubicaCerrada : CurvaBSpline
    {
        public BSplineCubicaCerrada()
        {
            grado = 3;
            NumeroMinimoPuntos = 4;
            NumeroMaximoPuntos = 10;
            Nombre = "B-Spline Cúbica Cerrada (4-10 puntos)";
            EsCerrada = true;
        }

        protected override void GenerarVectorNodos()
        {
            vectorNodos.Clear();
            int n = puntosControl.Count;
            int m = n + grado + 1;

            for (int i = 0; i < m; i++)
            {
                vectorNodos.Add(i);
            }
        }

        public override Punto2D CalcularPuntoEnCurva(float t)
        {
            if (puntosControl.Count < NumeroMinimoPuntos) return null;

            float x = 0, y = 0;
            int n = puntosControl.Count;

            for (int i = 0; i < n; i++)
            {
                float base_val = FuncionBaseN(i, grado, t);
                x += base_val * puntosControl[i].X;
                y += base_val * puntosControl[i].Y;
            }

            return new Punto2D(x, y);
        }

        protected override void CalcularCurvaCompleta()
        {
            puntosCurva.Clear();

            if (puntosControl.Count < NumeroMinimoPuntos) return;

            int pasos = 200;
            int n = puntosControl.Count;
            float tMin = grado;
            float tMax = n;

            for (int i = 0; i <= pasos; i++)
            {
                float t = tMin + (tMax - tMin) * i / (float)pasos;
                Punto2D punto = CalcularPuntoEnCurva(t);
                if (punto != null)
                {
                    puntosCurva.Add(punto.ToPointF());
                }
            }
        }
    }
}