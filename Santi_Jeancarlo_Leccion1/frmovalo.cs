using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santi_Jeancarlo_Leccion1
{
    public partial class frmovalo : Form
    {
        private ovalo miOvalo;
        private Bitmap canvas;
        private Graphics g;

        public frmovalo()
        {
            InitializeComponent();

            // Inicializar el canvas
            canvas = new Bitmap(picCanvas1.Width, picCanvas1.Height);
            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);
            picCanvas1.Image = canvas;

            // Conectar el evento click del botón
            btnGraficar1.Click += BtnGraficar1_Click;
        }

        private void BtnGraficar1_Click(object sender, EventArgs e)
        {
            // Limpiar el canvas
            g.Clear(Color.White);

            // Crear el óvalo en el centro del canvas con un lado de 300 píxeles
            Point centro = new Point(picCanvas1.Width / 2, picCanvas1.Height / 2);
            miOvalo = new ovalo(centro, 300);

            // Dibujar el cuadrado
            miOvalo.DibujarCuadrado(g);

            // Dibujar los puntos de división (temporal para verificación)
            miOvalo.DibujarPuntosDivision(g);

            // Dibujar las conexiones verdes
            miOvalo.DibujarConexiones(g);

            // Actualizar el PictureBox
            picCanvas1.Refresh();
        }
    }
}
