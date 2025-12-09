using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorStar
{
    internal class Star
    {
        private float radio, cateto, coor;
        private float x,x1,x2;
        private float y,y1,y2;
        private Graphics mGraph;
        private Pen mPen,mPen1;
        private double anguloBase, anguloRotado;

        public void ReadData(TextBox txtRadio)
        {
            try
            {
                radio = float.Parse(txtRadio.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido...", "Mensaje de error");
            }

        }

        // Método público que recibe un PictureBox
        public void PlotShape(PictureBox canvas)
        {
            PlotShapeConDesplazamiento(canvas, 0, 0);
        }

        // Método interno que permite dibujar con desplazamiento
        internal void PlotShapeConDesplazamiento(PictureBox canvas, float offsetX, float offsetY)
        {
            DibujarEstrella(canvas, offsetX, offsetY, 0);
        }

        // Método interno que permite dibujar con rotación
        internal void PlotShapeConRotacion(PictureBox canvas, float centroX, float centroY, float anguloRotacionGrados)
        {
            DibujarEstrella(canvas, 0, 0, anguloRotacionGrados);
        }

        // Método privado que realiza el dibujo con transformaciones
        private void DibujarEstrella(PictureBox canvas, float offsetX, float offsetY, float anguloRotacionGrados)
        {
            // Calcular el centro basado en el tamaño del PictureBox
            x = (canvas.Width / 2) + offsetX;
            y = (canvas.Height / 2) + offsetY;

            // Crear Graphics desde el PictureBox
            mGraph = canvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 2);
            mPen1 = new Pen(Color.Green, 2);

            cateto = (float)(radio -(radio/Math.Sqrt(2)));
            coor = radio - cateto;

            Brush[] colores =
            {
                Brushes.OrangeRed, Brushes.Aqua,Brushes.RosyBrown,Brushes.YellowGreen,
                Brushes.Thistle, Brushes.Lavender, Brushes.HotPink, Brushes.Salmon
            }; 

            // Convertir ángulo de rotación a radianes
            double anguloRotacionRad = anguloRotacionGrados * Math.PI / 180;

            for (int i = 0; i < 8; i++)
            {
                // Ángulo base + rotación adicional
                anguloBase = (i * 45 * Math.PI / 180) + anguloRotacionRad;

                x1 = x + (float)(radio * Math.Cos(anguloBase - Math.PI / 2));
                y1 = y + (float)(radio * Math.Sin(anguloBase - Math.PI / 2));

                anguloRotado = (anguloBase - Math.PI / 2) + Math.PI / 4;
                x2 = x + (float)(coor * Math.Cos(anguloRotado));
                y2 = y + (float)(coor * Math.Sin(anguloRotado));

                mGraph.DrawLine(mPen, x2, y2, x1, y1); 
                mGraph.DrawLine(mPen1, x1, y1, x, y);

                PointF v1 = new PointF(x, y);
                PointF v2 = new PointF(x1,y1);
                PointF v3 = new PointF(x2, y2);

                PointF [] vertices = { v1, v2, v3 };

                mGraph.FillPolygon(colores[i % colores.Length], vertices);
            }
        }
    }
}
