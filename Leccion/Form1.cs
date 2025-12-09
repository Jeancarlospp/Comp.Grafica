using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leccion
{
    public partial class figura1 : Form
    {
        // Atributo privado para almacenar el rombo
        private Rombo miRombo;
        // Número de segmentos fijo (10 partes como indica el ejercicio)
        private const int NUMERO_SEGMENTOS = 10;

        public figura1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento del botón Graficar
        /// </summary>
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                // Calcular el centro y tamaño del rombo basado en el PictureBox
                float centroX = picCanvas.Width / 2f;
                float centroY = picCanvas.Height / 2f;
                
                // Aumentar el tamaño para que se vea más grande (80% del espacio disponible)
                float tamanio = Math.Min(picCanvas.Width, picCanvas.Height) * 0.4f;

                Punto centro = new Punto(centroX, centroY);

                // Crear el rombo con 10 segmentos
                miRombo = new Rombo(centro, tamanio, NUMERO_SEGMENTOS);

                // Refrescar el PictureBox para que se dibuje
                picCanvas.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, 
                              "Error", 
                              MessageBoxButtons.OK, 
                              MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento Paint del PictureBox para dibujar
        /// </summary>
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Obtener el objeto Graphics
            Graphics g = e.Graphics;

            // Configurar para mejor calidad de dibujo
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Limpiar el fondo
            g.Clear(Color.White);

            // Si existe un rombo, dibujarlo
            if (miRombo != null)
            {
                miRombo.Dibujar(g);
                // Opcional: descomentar para ver el contorno del rombo
                // miRombo.DibujarContorno(g);
            }
        }
    }
}
