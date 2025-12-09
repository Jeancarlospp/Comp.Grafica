using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star
{
    internal class Star
    {
        private Graphics mGraph;
        private float Altura;
        private Pen mPen;
        private float mitadAncho;
        private float mitadAlto;
        private float coorX;
        private float coorY;
        private float grados;
        private float coorX1;
        private float coorY1;
        private float coorX2;
        private float coorY2;
        private float coorX3;
        private float coorY3;
        private float coorX4;
        private float coorY4;


        public void ReadData(TextBox txtAltura)
        {
            try
            {
               Altura = float.Parse(txtAltura.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido...", "Mensaje de error");
            }
        }
        
        public void PlotShape(Form fmrStar)
        {
            mitadAncho = (fmrStar.ClientSize.Width / 2); 
            mitadAlto = (fmrStar.ClientSize.Height / 2);
            
            mGraph = fmrStar.CreateGraphics();
            mPen = new Pen(Color.Pink, 2);

            grados = 72 * (float)Math.PI / 180;

            coorX = mitadAncho + (Altura * (float)Math.Cos(grados * 0 - (float)Math.PI / 2));
            coorY = mitadAlto + (Altura * (float)Math.Sin(grados * 0 - (float)Math.PI / 2));
            
            coorX1 = mitadAncho + (Altura * (float)Math.Cos(grados * 2 - (float)Math.PI / 2));
            coorY1 = mitadAlto + (Altura * (float)Math.Sin(grados * 2 - (float)Math.PI / 2));

            mGraph.DrawLine(mPen, coorX, coorY, coorX1, coorY1);

            coorX2 = mitadAncho + (Altura * (float)Math.Cos(grados * 4 - (float)Math.PI / 2));
            coorY2 = mitadAlto + (Altura * (float)Math.Sin(grados * 4 - (float)Math.PI / 2));

            mGraph.DrawLine(mPen, coorX1, coorY1, coorX2, coorY2);


            coorX3 = mitadAncho + (Altura * (float)Math.Cos(grados * 6 - (float)Math.PI / 2));
            coorY3 = mitadAlto + (Altura * (float)Math.Sin(grados * 6 - (float)Math.PI / 2));

            mGraph.DrawLine(mPen, coorX2, coorY2, coorX3, coorY3);

            coorX4 = mitadAncho + (Altura * (float)Math.Cos(grados * 8 - (float)Math.PI / 2));
            coorY4 = mitadAlto + (Altura * (float)Math.Sin(grados * 8 - (float)Math.PI / 2));

            mGraph.DrawLine(mPen, coorX3, coorY3, coorX4, coorY4);

            mGraph.DrawLine(mPen, coorX4, coorY4, coorX, coorY);
        }
    }
}
