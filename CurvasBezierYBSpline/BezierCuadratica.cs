using System.Collections.Generic;

namespace CurvasBezierYBSpline.Modelos
{
    public class BezierCuadratica : CurvaBezier
    {
        public BezierCuadratica()
        {
            NumeroMaximoPuntos = 3;
            Nombre = "Bézier Cuadrática (3 puntos)";
        }

        public override void AgregarPunto(float x, float y, bool esPuntoControl = false)
        {
            bool esControl = puntosControl.Count == 1;
            base.AgregarPunto(x, y, esControl);
        }

        public override Punto2D CalcularPuntoEnCurva(float t)
        {
            if (puntosControl.Count < 3) return null;

            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;

            float x = uu * puntosControl[0].X + 2 * u * t * puntosControl[1].X + tt * puntosControl[2].X;
            float y = uu * puntosControl[0].Y + 2 * u * t * puntosControl[1].Y + tt * puntosControl[2].Y;

            return new Punto2D(x, y);
        }

        public override List<List<Punto2D>> ObtenerPuntosIntermedios(float t)
        {
            var niveles = new List<List<Punto2D>>();

            if (puntosControl.Count < 3) return niveles;

            niveles.Add(new List<Punto2D>(puntosControl));

            var q0 = puntosControl[0].Interpolar(puntosControl[1], t);
            var q1 = puntosControl[1].Interpolar(puntosControl[2], t);
            niveles.Add(new List<Punto2D> { q0, q1 });

            return niveles;
        }
    }
}