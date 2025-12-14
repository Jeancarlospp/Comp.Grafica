using System;
using System.Collections.Generic;
using System.Drawing;

namespace CurvasBezierYBSpline.Modelos
{
    public abstract class CurvaBSpline
    {
        protected List<Punto2D> puntosControl;
        protected List<PointF> puntosCurva;
        protected List<float> vectorNodos;
        protected int grado;

        public int NumeroMinimoPuntos { get; protected set; }
        public int NumeroMaximoPuntos { get; protected set; }
        public string Nombre { get; protected set; }
        public bool EsCerrada { get; protected set; }

        protected CurvaBSpline()
        {
            puntosControl = new List<Punto2D>();
            puntosCurva = new List<PointF>();
            vectorNodos = new List<float>();
        }

        public virtual void AgregarPunto(float x, float y)
        {
            if (puntosControl.Count < NumeroMaximoPuntos)
            {
                puntosControl.Add(new Punto2D(x, y, true));

                if (puntosControl.Count >= NumeroMinimoPuntos)
                {
                    GenerarVectorNodos();
                    CalcularCurvaCompleta();
                }
            }
        }

        public List<Punto2D> ObtenerPuntosControl() => puntosControl;
        public List<PointF> ObtenerPuntosCurva() => puntosCurva;
        public List<float> ObtenerVectorNodos() => vectorNodos;

        public void LimpiarPuntos()
        {
            puntosControl.Clear();
            puntosCurva.Clear();
            vectorNodos.Clear();
        }

        public bool EstaCompleta() => puntosControl.Count >= NumeroMinimoPuntos;

        protected abstract void GenerarVectorNodos();

        public abstract Punto2D CalcularPuntoEnCurva(float t);

        protected virtual void CalcularCurvaCompleta()
        {
            puntosCurva.Clear();

            if (puntosControl.Count < NumeroMinimoPuntos) return;

            int pasos = 200;
            float tMin = vectorNodos[grado];
            float tMax = vectorNodos[vectorNodos.Count - grado - 1];

            for (int i = 0; i <= pasos; i++)
            {
                float t = tMin + (tMax - tMin) * i / (float)pasos;

                // Asegurar que t no exceda ligeramente tMax por errores de punto flotante
                if (t > tMax) t = tMax;

                Punto2D punto = CalcularPuntoEnCurva(t);
                if (punto != null)
                {
                    puntosCurva.Add(punto.ToPointF());
                }
            }
        }

        public void ActualizarPunto(int indice, float x, float y)
        {
            if (indice >= 0 && indice < puntosControl.Count)
            {
                puntosControl[indice].X = x;
                puntosControl[indice].Y = y;
                if (EstaCompleta())
                {
                    CalcularCurvaCompleta();
                }
            }
        }

        protected float FuncionBaseN(int i, int k, float t)
        {
            if (k == 0)
            {
                // Caso especial: si estamos en el último nodo válido, incluir el punto final
                if (Math.Abs(t - vectorNodos[vectorNodos.Count - 1]) < 1e-6f)
                {
                    return (i == puntosControl.Count - 1) ? 1.0f : 0.0f;
                }

                return (t >= vectorNodos[i] && t < vectorNodos[i + 1]) ? 1.0f : 0.0f;
            }

            float denominador1 = vectorNodos[i + k] - vectorNodos[i];
            float denominador2 = vectorNodos[i + k + 1] - vectorNodos[i + 1];

            float termino1 = 0.0f;
            float termino2 = 0.0f;

            if (Math.Abs(denominador1) > 1e-6f)
            {
                termino1 = ((t - vectorNodos[i]) / denominador1) * FuncionBaseN(i, k - 1, t);
            }

            if (Math.Abs(denominador2) > 1e-6f)
            {
                termino2 = ((vectorNodos[i + k + 1] - t) / denominador2) * FuncionBaseN(i + 1, k - 1, t);
            }

            return termino1 + termino2;
        }

        public virtual List<List<PointF>> ObtenerSegmentosCurva()
        {
            var segmentos = new List<List<PointF>>();

            if (!EstaCompleta()) return segmentos;

            int numSegmentos = puntosControl.Count - grado;

            for (int seg = 0; seg < numSegmentos; seg++)
            {
                var segmento = new List<PointF>();

                float tInicio = vectorNodos[grado + seg];
                float tFin = vectorNodos[grado + seg + 1];

                int pasos = 30;
                for (int i = 0; i <= pasos; i++)
                {
                    float t = tInicio + (tFin - tInicio) * i / (float)pasos;
                    Punto2D punto = CalcularPuntoEnCurva(t);
                    if (punto != null)
                    {
                        segmento.Add(punto.ToPointF());
                    }
                }

                if (segmento.Count > 0)
                {
                    segmentos.Add(segmento);
                }
            }

            return segmentos;
        }
    }
}