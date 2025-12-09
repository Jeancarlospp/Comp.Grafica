using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santi_Jeancarlo_Leccion1
{
    internal class ovalo
    {
        // Propiedades para los 4 vértices del cuadrado
        public Point VerticeA { get; set; }  // Superior izquierdo
        public Point VerticeB { get; set; }  // Superior derecho
        public Point VerticeC { get; set; }  // Inferior derecho
        public Point VerticeD { get; set; }  // Inferior izquierdo
        public Point Centro { get; set; }

        // Listas para almacenar los puntos de cada lado (incluyendo vértice inicial)
        // Cada lista tiene 21 puntos: punto[0] = vértice, puntos[1-20] = divisiones
        public List<Point> LadoSuperior { get; set; }     // De A a B (izquierda a derecha)
        public List<Point> LadoDerecho { get; set; }      // De B a C (arriba a abajo)
        public List<Point> LadoInferior { get; set; }     // De C a D (derecha a izquierda)
        public List<Point> LadoIzquierdo { get; set; }    // De D a A (abajo a arriba)

        // Constructor que recibe el centro y el tamaño del lado del cuadrado
        public ovalo(Point centro, int lado)
        {
            Centro = centro;
            int mitad = lado / 2;

            // Calcular los 4 vértices del cuadrado
            VerticeA = new Point(centro.X - mitad, centro.Y - mitad);  // Superior izquierdo
            VerticeB = new Point(centro.X + mitad, centro.Y - mitad);  // Superior derecho
            VerticeC = new Point(centro.X + mitad, centro.Y + mitad);  // Inferior derecho
            VerticeD = new Point(centro.X - mitad, centro.Y + mitad);  // Inferior izquierdo

            // Calcular los puntos de cada lado
            CalcularPuntosDeLados();
        }

        // Método para calcular los 21 puntos de cada lado (vértice + 20 divisiones)
        private void CalcularPuntosDeLados()
        {
            LadoSuperior = new List<Point>();
            LadoDerecho = new List<Point>();
            LadoInferior = new List<Point>();
            LadoIzquierdo = new List<Point>();

            // LADO SUPERIOR: De A (superior izquierdo) a B (superior derecho)
            // Punto 1 = Vértice A
            LadoSuperior.Add(VerticeA);
            for (int i = 1; i <= 20; i++)
            {
                int x = VerticeA.X + (i * (VerticeB.X - VerticeA.X) / 20);
                LadoSuperior.Add(new Point(x, VerticeA.Y));
            }

            // LADO DERECHO: De B (superior derecho) a C (inferior derecho)
            // Punto 1 = Vértice B
            LadoDerecho.Add(VerticeB);
            for (int i = 1; i <= 20; i++)
            {
                int y = VerticeB.Y + (i * (VerticeC.Y - VerticeB.Y) / 20);
                LadoDerecho.Add(new Point(VerticeB.X, y));
            }

            // LADO INFERIOR: De C (inferior derecho) a D (inferior izquierdo)
            // Punto 1 = Vértice C
            LadoInferior.Add(VerticeC);
            for (int i = 1; i <= 20; i++)
            {
                int x = VerticeC.X - (i * (VerticeC.X - VerticeD.X) / 20);
                LadoInferior.Add(new Point(x, VerticeC.Y));
            }

            // LADO IZQUIERDO: De D (inferior izquierdo) a A (superior izquierdo)
            // Punto 1 = Vértice D
            LadoIzquierdo.Add(VerticeD);
            for (int i = 1; i <= 20; i++)
            {
                int y = VerticeD.Y - (i * (VerticeD.Y - VerticeA.Y) / 20);
                LadoIzquierdo.Add(new Point(VerticeD.X, y));
            }
        }

        // Método para dibujar el cuadrado
        public void DibujarCuadrado(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                // Dibujar los 4 lados del cuadrado
                g.DrawLine(pen, VerticeA, VerticeB);  // Superior
                g.DrawLine(pen, VerticeB, VerticeC);  // Derecho
                g.DrawLine(pen, VerticeC, VerticeD);  // Inferior
                g.DrawLine(pen, VerticeD, VerticeA);  // Izquierdo
            }
        }

        // Método para dibujar los puntos de división (temporal para verificación)
        public void DibujarPuntosDivision(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                int radioPunto = 5;

                // Dibujar puntos del lado superior
                for (int i = 0; i < LadoSuperior.Count; i++)
                {
                    Point p = LadoSuperior[i];
                    g.FillEllipse(brush, p.X - radioPunto / 2, p.Y - radioPunto / 2, radioPunto, radioPunto);
                }

                // Dibujar puntos del lado derecho
                for (int i = 0; i < LadoDerecho.Count; i++)
                {
                    Point p = LadoDerecho[i];
                    g.FillEllipse(brush, p.X - radioPunto / 2, p.Y - radioPunto / 2, radioPunto, radioPunto);
                }

                // Dibujar puntos del lado inferior
                for (int i = 0; i < LadoInferior.Count; i++)
                {
                    Point p = LadoInferior[i];
                    g.FillEllipse(brush, p.X - radioPunto / 2, p.Y - radioPunto / 2, radioPunto, radioPunto);
                }

                // Dibujar puntos del lado izquierdo
                for (int i = 0; i < LadoIzquierdo.Count; i++)
                {
                    Point p = LadoIzquierdo[i];
                    g.FillEllipse(brush, p.X - radioPunto / 2, p.Y - radioPunto / 2, radioPunto, radioPunto);
                }
            }
        }

        // Método para dibujar las conexiones que forman el óvalo
        public void DibujarConexiones(Graphics g)
        {
            // Conexiones del lado superior (verde)
            using (Pen penVerde = new Pen(Color.Green, 2))
            {
                // Conexión 1: LadoSuperior con LadoIzquierdo (invertido)
                for (int i = 0; i < 21; i++)
                {
                    Point puntoSuperior = LadoSuperior[i];
                    Point puntoIzquierdo = LadoIzquierdo[20 - i];
                    
                    g.DrawLine(penVerde, puntoSuperior, puntoIzquierdo);
                }

                // Conexión 2: LadoSuperior con LadoDerecho (punto a punto)
                for (int i = 0; i < 21; i++)
                {
                    Point puntoSuperior = LadoSuperior[i];
                    Point puntoDerecho = LadoDerecho[i];
                    
                    g.DrawLine(penVerde, puntoSuperior, puntoDerecho);
                }
            }

            // Conexiones del lado inferior (azul)
            using (Pen penAzul = new Pen(Color.Blue, 2))
            {
                // Conexión 3: LadoInferior con LadoDerecho (punto a punto)
                for (int i = 0; i < 21; i++)
                {
                    Point puntoInferior = LadoInferior[i];
                    Point puntoDerecho = LadoDerecho[i];
                    
                    g.DrawLine(penAzul, puntoInferior, puntoDerecho);
                }

                // Conexión 4: LadoInferior con LadoIzquierdo (invertido)
                for (int i = 0; i < 21; i++)
                {
                    Point puntoInferior = LadoInferior[i];
                    Point puntoIzquierdo = LadoIzquierdo[20 - i];
                    
                    g.DrawLine(penAzul, puntoInferior, puntoIzquierdo);
                }
            }
        }
    }
}
