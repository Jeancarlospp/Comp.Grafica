using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorStar
{
    internal class Rotacion
    {
        // Ángulo de rotación acumulado en grados
        private float anguloRotacion = 0;
        private PictureBox canvas;
        private Star figura;

        // Punto fijo de rotación (centro de la figura)
        private float puntoFijoX;
        private float puntoFijoY;

        // Constructor que recibe la figura a rotar y el canvas
        public Rotacion(Star star, PictureBox pictureBox)
        {
            figura = star;
            canvas = pictureBox;
            
            // Por defecto, el punto fijo es el centro del PictureBox
            puntoFijoX = pictureBox.Width / 2;
            puntoFijoY = pictureBox.Height / 2;
        }

        // Método para rotar la figura
        public void Rotar(float incrementoGrados)
        {
            anguloRotacion += incrementoGrados;
            
            // Normalizar el ángulo entre 0 y 360 grados
            if (anguloRotacion >= 360)
                anguloRotacion -= 360;
            if (anguloRotacion < 0)
                anguloRotacion += 360;
            
            // Limpiar y redibujar
            LimpiarGrafico();
            figura.PlotShapeConRotacion(canvas, puntoFijoX, puntoFijoY, anguloRotacion);
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

        // Obtener ángulo de rotación actual
        public float GetAnguloRotacion()
        {
            return anguloRotacion;
        }

        // Establecer punto fijo de rotación
        public void SetPuntoFijo(float x, float y)
        {
            puntoFijoX = x;
            puntoFijoY = y;
        }

        // Resetear rotación
        public void ResetearRotacion()
        {
            anguloRotacion = 0;
            LimpiarGrafico();
            figura.PlotShape(canvas);
        }
    }
}
