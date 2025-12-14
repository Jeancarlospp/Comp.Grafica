using System;
using System.Collections.Generic;

namespace CurvasBezierYBSpline.Modelos
{
    public class BSplineCubicaAbierta : CurvaBSpline
    {
        public BSplineCubicaAbierta()
        {
            grado = 3;
            NumeroMinimoPuntos = 4;
            NumeroMaximoPuntos = 10;
            Nombre = "B-Spline Cúbica Abierta (4-10 puntos)";
            EsCerrada = false;
        }

        protected override void GenerarVectorNodos()
        {
            vectorNodos.Clear();
            int n = puntosControl.Count;
            int m = n + grado + 1;

            for (int i = 0; i < m; i++)
            {
                if (i <= grado)
                {
                    vectorNodos.Add(0);
                }
                else if (i >= n)
                {
                    vectorNodos.Add(n - grado);
                }
                else
                {
                    vectorNodos.Add(i - grado);
                }
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
    }
}