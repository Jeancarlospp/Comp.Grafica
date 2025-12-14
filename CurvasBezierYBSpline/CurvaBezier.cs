using System;
using System.Collections.Generic;
using System.Drawing;

namespace CurvasBezierYBSpline.Modelos
{
    public abstract class CurvaBezier
    {
        protected List<Punto2D> puntosControl;
        protected List<PointF> puntosCurva;
        public int NumeroMaximoPuntos { get; protected set; }
        public string Nombre { get; protected set; }

        protected CurvaBezier()
        {
            puntosControl = new List<Punto2D>();
            puntosCurva = new List<PointF>();
        }

        public virtual void AgregarPunto(float x, float y, bool esPuntoControl = false)
        {
            if (puntosControl.Count < NumeroMaximoPuntos)
            {
                puntosControl.Add(new Punto2D(x, y, esPuntoControl));
                if (puntosControl.Count == NumeroMaximoPuntos)
                {
                    CalcularCurvaCompleta();
                }
            }
        }

        public List<Punto2D> ObtenerPuntosControl() => puntosControl;

        public List<PointF> ObtenerPuntosCurva() => puntosCurva;

        public void LimpiarPuntos()
        {
            puntosControl.Clear();
            puntosCurva.Clear();
        }

        public bool EstaCompleta() => puntosControl.Count == NumeroMaximoPuntos;

        public abstract Punto2D CalcularPuntoEnCurva(float t);

        public abstract List<List<Punto2D>> ObtenerPuntosIntermedios(float t);

        protected virtual void CalcularCurvaCompleta()
        {
            puntosCurva.Clear();
            int pasos = 100;
            for (int i = 0; i <= pasos; i++)
            {
                float t = i / (float)pasos;
                Punto2D punto = CalcularPuntoEnCurva(t);
                puntosCurva.Add(punto.ToPointF());
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
    }
}