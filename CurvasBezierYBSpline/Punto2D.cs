using System;
using System.Drawing;

namespace CurvasBezierYBSpline.Modelos
{
    public class Punto2D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public bool EsPuntoControl { get; set; }

        private const float RADIO_PUNTO = 6f;
        private const float RADIO_SELECCION = 10f;

        public Punto2D(float x, float y, bool esPuntoControl = false)
        {
            X = x;
            Y = y;
            EsPuntoControl = esPuntoControl;
        }

        public PointF ToPointF() => new PointF(X, Y);

        public bool ContieneClick(Point click)
        {
            float dx = click.X - X;
            float dy = click.Y - Y;
            return (dx * dx + dy * dy) <= (RADIO_SELECCION * RADIO_SELECCION);
        }

        public void Dibujar(Graphics g, Color color)
        {
            float radio = EsPuntoControl ? RADIO_PUNTO * 1.2f : RADIO_PUNTO;
            g.FillEllipse(new SolidBrush(color), X - radio, Y - radio, radio * 2, radio * 2);
            g.DrawEllipse(new Pen(Color.FromArgb(100, 0, 0, 0), 1.5f), X - radio, Y - radio, radio * 2, radio * 2);
        }

        public Punto2D Interpolar(Punto2D otro, float t)
        {
            return new Punto2D(
                X * (1 - t) + otro.X * t,
                Y * (1 - t) + otro.Y * t
            );
        }
    }
}