using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    internal class CRectangle
    {
        // Datos Miembro (Atributos).
        // Ancho del rectángulo.
        private float mWidth;
        // Largo del rectángulo.
        private float mHeight;
        // Perímetro del rectángulo.
        private float mPerimeter;
        // Área del rectángulo.
        private float mArea;
        // Objeto que activa el modo gráfico.
        private Graphics mGraph;
        // Constante scale factor (Zoom In/Zoom Out).
        private const float SF = 20;
        // Objeto bolígrafo que dibuja o escribe en un lienzo (canvas).
        private Pen mPen;

        // Funciones Miembro (Métodos).

        // Constructor sin parámetros.
        public CRectangle()
        {
            mWidth = 0.0f; mHeight = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;
        }
        // Función que lee los datos de entrada del rectángulo.
        public void ReadData(TextBox txtWidth, TextBox txtHeight)
        {
            try
            {
                mWidth = float.Parse(txtWidth.Text);
                mHeight = float.Parse(txtHeight.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido...",
                "Mensaje de error");
            }
        }
        // Función que calcula el perímetro del rectángulo.
        public void PerimeterRectangle()
        {
            mPerimeter = 2 * mWidth + 2 * mHeight;
        }
        // Función que calcula el área del rectángulo.
        public void AreaRectangle()
        {
            mArea = mWidth * mHeight;
        }
        // Función que imprime el perímetro y el área del rectángulo.
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }
        // Función que inicializa los datos y controles del rectángulo.
        public void InitializeData(TextBox txtWidth, TextBox txtHeight,
        TextBox txtPerimeter, TextBox txtArea,
       PictureBox picCanvas)
        {
            mWidth = 0.0f; mHeight = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;
            txtWidth.Text = ""; txtHeight.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            // Mantiene el cursor titilando en una caja de texto.
            txtWidth.Focus();
            picCanvas.Refresh();
        }
        // Función que grafica un rectángulo.
        public void PlotShape(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            // Graficar un rectángulo.
            mGraph.DrawRectangle(mPen, 0, 0, mWidth * SF, mHeight * SF);
        }
        // Función que cierra un formulario.
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }

    }
}
