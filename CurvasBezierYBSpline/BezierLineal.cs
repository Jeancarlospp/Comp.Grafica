using System.Collections.Generic;

namespace CurvasBezierYBSpline.Modelos
{
    public class BezierLineal : CurvaBezier
    {
        public BezierLineal()
        {
            NumeroMaximoPuntos = 2;
            Nombre = "Bézier Lineal (2 puntos)";
        }

        public override void AgregarPunto(float x, float y, bool esPuntoControl = false)
        {
            base.AgregarPunto(x, y, false);
        }

        public override Punto2D CalcularPuntoEnCurva(float t)
        {
            if (puntosControl.Count < 2) return null;

            Punto2D p0 = puntosControl[0];
            Punto2D p1 = puntosControl[1];

            return p0.Interpolar(p1, t);
        }

        public override List<List<Punto2D>> ObtenerPuntosIntermedios(float t)
        {
            var niveles = new List<List<Punto2D>>();

            if (puntosControl.Count >= 2)
            {
                niveles.Add(new List<Punto2D>(puntosControl));
            }

            return niveles;
        }
    }
}