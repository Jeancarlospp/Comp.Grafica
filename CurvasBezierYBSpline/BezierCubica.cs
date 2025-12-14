using System.Collections.Generic;

namespace CurvasBezierYBSpline.Modelos
{
    public class BezierCubica : CurvaBezier
    {
        public BezierCubica()
        {
            NumeroMaximoPuntos = 4;
            Nombre = "Bézier Cúbica (4 puntos)";
        }

        public override void AgregarPunto(float x, float y, bool esPuntoControl = false)
        {
            bool esControl = puntosControl.Count == 1 || puntosControl.Count == 2;
            base.AgregarPunto(x, y, esControl);
        }

        public override Punto2D CalcularPuntoEnCurva(float t)
        {
            if (puntosControl.Count < 4) return null;

            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            float x = uuu * puntosControl[0].X +
                     3 * uu * t * puntosControl[1].X +
                     3 * u * tt * puntosControl[2].X +
                     ttt * puntosControl[3].X;

            float y = uuu * puntosControl[0].Y +
                     3 * uu * t * puntosControl[1].Y +
                     3 * u * tt * puntosControl[2].Y +
                     ttt * puntosControl[3].Y;

            return new Punto2D(x, y);
        }

        public override List<List<Punto2D>> ObtenerPuntosIntermedios(float t)
        {
            var niveles = new List<List<Punto2D>>();

            if (puntosControl.Count < 4) return niveles;

            niveles.Add(new List<Punto2D>(puntosControl));

            var q0 = puntosControl[0].Interpolar(puntosControl[1], t);
            var q1 = puntosControl[1].Interpolar(puntosControl[2], t);
            var q2 = puntosControl[2].Interpolar(puntosControl[3], t);
            niveles.Add(new List<Punto2D> { q0, q1, q2 });

            var r0 = q0.Interpolar(q1, t);
            var r1 = q1.Interpolar(q2, t);
            niveles.Add(new List<Punto2D> { r0, r1 });

            return niveles;
        }
    }
}
