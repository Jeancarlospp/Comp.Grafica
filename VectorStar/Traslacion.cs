using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorStar
{
    internal class Traslacion
    {
        // Propiedades para el desplazamiento
        private float offsetX = 0;
        private float offsetY = 0;
        private PictureBox canvas;
        private Star figura;

        // Constructor que recibe la figura a trasladar y el canvas
        public Traslacion(Star star, PictureBox pictureBox)
        {
            figura = star;
            canvas = pictureBox;
        }

        // Método para trasladar la figura
        public void Trasladar(float deltaX, float deltaY)
        {
            offsetX += deltaX;
            offsetY += deltaY;
            
            // Limpiar y redibujar
            LimpiarGrafico();
            figura.PlotShapeConDesplazamiento(canvas, offsetX, offsetY);
        }

        // Método para limpiar el gráfico
        private void LimpiarGrafico()
        {
            if (canvas != null)
            {
                Graphics g = canvas.CreateGraphics();
                g.Clear(canvas.BackColor);
                g.Dispose();
            }
        }

        // Obtener desplazamiento actual en X
        public float GetOffsetX()
        {
            return offsetX;
        }

        // Obtener desplazamiento actual en Y
        public float GetOffsetY()
        {
            return offsetY;
        }

        // Resetear desplazamiento
        public void ResetearPosicion()
        {
            offsetX = 0;
            offsetY = 0;
            LimpiarGrafico();
            figura.PlotShape(canvas);
        }
    }
}
