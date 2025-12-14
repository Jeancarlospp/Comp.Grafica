using System;
using System.Collections.Generic;

namespace CurvasBezierYBSpline.Modelos
{
    public class BSplineNPuntos : CurvaBSpline
    {
        public BSplineNPuntos(int numeroPuntos, int gradoCurva = 3, bool cerrada = false)
        {
            if (numeroPuntos < 3 || numeroPuntos > 15)
                throw new ArgumentException("El número de puntos debe estar entre 3 y 15");

            if (gradoCurva < 1 || gradoCurva >= numeroPuntos)
                throw new ArgumentException($"El grado debe estar entre 1 y {numeroPuntos - 1}");

            grado = gradoCurva;
            NumeroMinimoPuntos = gradoCurva + 1;
            NumeroMaximoPuntos = numeroPuntos;
            EsCerrada = cerrada;
            Nombre = $"B-Spline Grado {grado} ({numeroPuntos} puntos)" + (cerrada ? " - Cerrada" : " - Abierta");
        }

        protected override void GenerarVectorNodos()
        {
            vectorNodos.Clear();
            int n = puntosControl.Count;
            int m = n + grado + 1;

            if (EsCerrada)
            {
                for (int i = 0; i < m; i++)
                {
                    vectorNodos.Add(i);
                }
            }
            else
            {
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
            float tMin, tMax;

            if (EsCerrada)
            {
                int n = puntosControl.Count;
                tMin = grado;
                tMax = n;
            }
            else
            {
                tMin = vectorNodos[grado];
                tMax = vectorNodos[vectorNodos.Count - grado - 1];
            }

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