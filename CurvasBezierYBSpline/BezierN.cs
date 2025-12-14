using System;
using System.Collections.Generic;

namespace CurvasBezierYBSpline.Modelos
{
    public class BezierN : CurvaBezier
    {
        public BezierN(int n)
        {
            if (n < 2 || n > 10)
                throw new ArgumentException("El número de puntos debe estar entre 2 y 10");

            NumeroMaximoPuntos = n;
            Nombre = $"Bézier de grado {n - 1} ({n} puntos)";
        }

        public override void AgregarPunto(float x, float y, bool esPuntoControl = false)
        {
            bool esControl = puntosControl.Count > 0 && puntosControl.Count < NumeroMaximoPuntos - 1;
            base.AgregarPunto(x, y, esControl);
        }

        public override Punto2D CalcularPuntoEnCurva(float t)
        {
            if (puntosControl.Count < NumeroMaximoPuntos) return null;

            int n = puntosControl.Count - 1;
            float x = 0, y = 0;

            for (int i = 0; i <= n; i++)
            {
                float coef = CoeficienteBinomial(n, i) *
                            (float)Math.Pow(1 - t, n - i) *
                            (float)Math.Pow(t, i);
                x += coef * puntosControl[i].X;
                y += coef * puntosControl[i].Y;
            }

            return new Punto2D(x, y);
        }

        public override List<List<Punto2D>> ObtenerPuntosIntermedios(float t)
        {
            var niveles = new List<List<Punto2D>>();

            if (puntosControl.Count < NumeroMaximoPuntos) return niveles;

            var nivelActual = new List<Punto2D>(puntosControl);
            niveles.Add(new List<Punto2D>(nivelActual));

            while (nivelActual.Count > 1)
            {
                var nuevoNivel = new List<Punto2D>();
                for (int i = 0; i < nivelActual.Count - 1; i++)
                {
                    nuevoNivel.Add(nivelActual[i].Interpolar(nivelActual[i + 1], t));
                }
                niveles.Add(new List<Punto2D>(nuevoNivel));
                nivelActual = nuevoNivel;
            }

            return niveles;
        }

        private int CoeficienteBinomial(int n, int k)
        {
            if (k > n) return 0;
            if (k == 0 || k == n) return 1;

            int resultado = 1;
            for (int i = 1; i <= k; i++)
            {
                resultado = resultado * (n - i + 1) / i;
            }
            return resultado;
        }
    }
}