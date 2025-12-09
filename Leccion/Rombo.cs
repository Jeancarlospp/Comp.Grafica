using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leccion
{
    /// <summary>
    /// Clase que representa un rombo con patrón de líneas conectadas (String Art)
    /// </summary>
    public class Rombo
    {
        // Propiedades
        private Punto centro;
        private float tamanio;
        private int numeroSegmentos;
        private List<Punto> ladoArriba_Derecha;
        private List<Punto> ladoDerecha_Abajo;
        private List<Punto> ladoAbajo_Izquierda;
        private List<Punto> ladoIzquierda_Arriba;

        // Constructor
        public Rombo(Punto centro, float tamanio, int numeroSegmentos)
        {
            this.centro = centro;
            this.tamanio = tamanio;
            this.numeroSegmentos = numeroSegmentos;
            
            ladoArriba_Derecha = new List<Punto>();
            ladoDerecha_Abajo = new List<Punto>();
            ladoAbajo_Izquierda = new List<Punto>();
            ladoIzquierda_Arriba = new List<Punto>();

            CalcularPuntos();
        }

        /// <summary>
        /// Calcula los puntos de división en cada lado del rombo
        /// </summary>
        private void CalcularPuntos()
        {
            // Vértices del rombo (rotado 45°)
            Punto verticeArriba = new Punto(centro.X, centro.Y - tamanio);
            Punto verticeDerecha = new Punto(centro.X + tamanio, centro.Y);
            Punto verticeAbajo = new Punto(centro.X, centro.Y + tamanio);
            Punto verticeIzquierda = new Punto(centro.X - tamanio, centro.Y);

            // Lado 1: Arriba ? Derecha
            for (int i = 0; i <= numeroSegmentos; i++)
            {
                float t = (float)i / numeroSegmentos;
                float x = verticeArriba.X + (verticeDerecha.X - verticeArriba.X) * t;
                float y = verticeArriba.Y + (verticeDerecha.Y - verticeArriba.Y) * t;
                ladoArriba_Derecha.Add(new Punto(x, y));
            }

            // Lado 2: Derecha ? Abajo
            for (int i = 0; i <= numeroSegmentos; i++)
            {
                float t = (float)i / numeroSegmentos;
                float x = verticeDerecha.X + (verticeAbajo.X - verticeDerecha.X) * t;
                float y = verticeDerecha.Y + (verticeAbajo.Y - verticeDerecha.Y) * t;
                ladoDerecha_Abajo.Add(new Punto(x, y));
            }

            // Lado 3: Abajo ? Izquierda
            for (int i = 0; i <= numeroSegmentos; i++)
            {
                float t = (float)i / numeroSegmentos;
                float x = verticeAbajo.X + (verticeIzquierda.X - verticeAbajo.X) * t;
                float y = verticeAbajo.Y + (verticeIzquierda.Y - verticeAbajo.Y) * t;
                ladoAbajo_Izquierda.Add(new Punto(x, y));
            }

            // Lado 4: Izquierda ? Arriba
            for (int i = 0; i <= numeroSegmentos; i++)
            {
                float t = (float)i / numeroSegmentos;
                float x = verticeIzquierda.X + (verticeArriba.X - verticeIzquierda.X) * t;
                float y = verticeIzquierda.Y + (verticeArriba.Y - verticeIzquierda.Y) * t;
                ladoIzquierda_Arriba.Add(new Punto(x, y));
            }
        }

        /// <summary>
        /// Dibuja el patrón del rombo en el objeto Graphics (String Art)
        /// Conecta punto i de un lado con punto i del lado adyacente (siguiente)
        /// </summary>
        public void Dibujar(Graphics g)
        {
            Pen lapiz = new Pen(Color.Black, 1);

            try
            {
                // Conectar cada punto del lado Arriba-Derecha con el punto correspondiente del lado Derecha-Abajo
                for (int i = 0; i <= numeroSegmentos; i++)
                {
                    Punto p1 = ladoArriba_Derecha[i];
                    Punto p2 = ladoDerecha_Abajo[numeroSegmentos - i];
                    g.DrawLine(lapiz, p1.X, p1.Y, p2.X, p2.Y);
                }

                // Conectar cada punto del lado Derecha-Abajo con el punto correspondiente del lado Abajo-Izquierda
                for (int i = 0; i <= numeroSegmentos; i++)
                {
                    Punto p1 = ladoDerecha_Abajo[i];
                    Punto p2 = ladoAbajo_Izquierda[numeroSegmentos - i];
                    g.DrawLine(lapiz, p1.X, p1.Y, p2.X, p2.Y);
                }

                // Conectar cada punto del lado Abajo-Izquierda con el punto correspondiente del lado Izquierda-Arriba
                for (int i = 0; i <= numeroSegmentos; i++)
                {
                    Punto p1 = ladoAbajo_Izquierda[i];
                    Punto p2 = ladoIzquierda_Arriba[numeroSegmentos - i];
                    g.DrawLine(lapiz, p1.X, p1.Y, p2.X, p2.Y);
                }

                // Conectar cada punto del lado Izquierda-Arriba con el punto correspondiente del lado Arriba-Derecha
                for (int i = 0; i <= numeroSegmentos; i++)
                {
                    Punto p1 = ladoIzquierda_Arriba[i];
                    Punto p2 = ladoArriba_Derecha[numeroSegmentos - i];
                    g.DrawLine(lapiz, p1.X, p1.Y, p2.X, p2.Y);
                }
            }
            finally
            {
                lapiz.Dispose();
            }
        }
    }
}
