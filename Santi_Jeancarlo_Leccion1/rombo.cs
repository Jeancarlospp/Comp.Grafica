using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santi_Jeancarlo_Leccion1
{
    internal class rombo
    {
        public Point PuntoA { get; set; } 
        public Point PuntoB { get; set; }  
        public Point PuntoC { get; set; }  
        public Point PuntoD { get; set; }  
        public Point Centro { get; set; }  

        // listas para almacenar los pntos
        public List<Point> PuntosDivisionVerticalSuperior { get; set; }
        public List<Point> PuntosDivisionVerticalInferior { get; set; }
        public List<Point> PuntosDivisionHorizontalIzquierda { get; set; }
        public List<Point> PuntosDivisionHorizontalDerecha { get; set; }

        public rombo(Point centro, int distancia)
        {
            Centro = centro;
            
            PuntoA = new Point(centro.X, centro.Y - distancia);  
            PuntoB = new Point(centro.X - distancia, centro.Y);  
            PuntoC = new Point(centro.X, centro.Y + distancia);  
            PuntoD = new Point(centro.X + distancia, centro.Y);  


            CalcularPuntosDivision();
        }

        private void CalcularPuntosDivision()
        {
            PuntosDivisionVerticalSuperior = new List<Point>();
            PuntosDivisionVerticalInferior = new List<Point>();
            PuntosDivisionHorizontalIzquierda = new List<Point>();
            PuntosDivisionHorizontalDerecha = new List<Point>();


            for (int i = 1; i <= 10; i++)
            {

                PuntosDivisionVerticalSuperior.Add(new Point(Centro.X, Centro.Y - (i * (Centro.Y - PuntoA.Y) / 10)));
                
                PuntosDivisionVerticalInferior.Add(new Point(Centro.X, Centro.Y + (i * (PuntoC.Y - Centro.Y) / 10)));
                
                PuntosDivisionHorizontalIzquierda.Add(new Point(Centro.X - (i * (Centro.X - PuntoB.X) / 10), Centro.Y));

                PuntosDivisionHorizontalDerecha.Add(new Point(Centro.X + (i * (PuntoD.X - Centro.X) / 10), Centro.Y));
            }
        }

        public void DibujarCruz(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawLine(pen, PuntoA, PuntoC);
                
                g.DrawLine(pen, PuntoB, PuntoD);
            }
        }
        public void DibujarConexiones(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                for (int i = 0; i < 10; i++)
                {
                    Point puntoSuperior = PuntosDivisionVerticalSuperior[i];
                    Point puntoInferior = PuntosDivisionVerticalInferior[i];
                    Point puntoDerecha = PuntosDivisionHorizontalDerecha[9 - i];
                    Point puntoIzquierda = PuntosDivisionHorizontalIzquierda[9 - i];
                    
                    g.DrawLine(pen, puntoSuperior, puntoDerecha);
                    g.DrawLine(pen, puntoSuperior, puntoIzquierda);
                    
                    g.DrawLine(pen, puntoInferior, puntoDerecha);
                    g.DrawLine(pen, puntoInferior, puntoIzquierda);
                }
            }
        }
    }
}
