using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CSquare
    {
        // Datos Miembro (Atributos).

        // Lado del cuadrado.
        private float mSide;
        // Perímetro del cuadrado.
        private float mPerimeter;
        // Área del cuadrado.
        private float mArea;
        // Objeto que activa el modo gráfico.
        private Graphics mGraph;
        // Constante scale factor (Zoom In/Zoom Out).
        private const float SF = 20;
        // Objeto bolígrafo que dibuja o escribe en un lienzo (canvas).
        private Pen mPen;
        // Funciones Miembro (Métodos).
        // Constructor sin parámetros.
        public CSquare()
        {
            mSide = 0.0f; mPerimeter = 0.0f; mArea = 0.0f;
        }
        // Función que lee el lado del cuadrado.
        public void ReadData(TextBox txtSide)
        {
            try
            {
                mSide = float.Parse(txtSide.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido...", "Mensaje de error");
            }
        }
        // Función que calcula el perímetro del cuadrado.
        public void PerimeterSquare()
        {
            mPerimeter = 4 * mSide;
        }
        // Función que calcula el área del cuadrado.
        public void AreaSquare()
        {
            mArea = (float)Math.Pow(mSide, 2);
        }
        // Función que imprime el perímetro y el área del cuadrado.
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }
        // Función que inicializa los datos y controles del cuadrado.
        public void InitializeData(TextBox txtSide, TextBox txtPerimeter,
        TextBox txtArea, PictureBox picCanvas)
        {
            mSide = 0.0f; mPerimeter = 0.0f; mArea = 0.0f;
            txtSide.Text = ""; txtPerimeter.Text = ""; txtArea.Text = "";
            // Mantiene el cursor titilando en una caja de texto.
            txtSide.Focus();
            picCanvas.Refresh();
        }
        // Función que grafica un cuadrado.
        public void PlotShape(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            // Graficar un cuadrado en función de un rectángulo.
            mGraph.DrawRectangle(mPen, 0, 0, mSide * SF, mSide * SF);
        }
        // Función que cierra un formulario.
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }

    }
}
