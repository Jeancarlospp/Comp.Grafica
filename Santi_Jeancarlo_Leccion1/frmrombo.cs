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
    public partial class frmrombo : Form
    {
        private rombo miRombo;
        private Bitmap canvas;
        private Graphics g;

        public frmrombo()
        {
            InitializeComponent();
            
            // Inicializar el canvas
            canvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);
            picCanvas.Image = canvas;
            
            // Conectar el evento click del botón
            btnGraficar.Click += BtnGraficar_Click;
        }

        private void BtnGraficar_Click(object sender, EventArgs e)
        {
            // Limpiar el canvas
            g.Clear(Color.White);
            
            // Crear el rombo en el centro del canvas con una distancia de 150 píxeles
            Point centro = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
            miRombo = new rombo(centro, 150);
            
            // Dibujar la cruz
            miRombo.DibujarCruz(g);
            
            // Dibujar las conexiones que forman el rombo
            miRombo.DibujarConexiones(g);
            
            // Actualizar el PictureBox
            picCanvas.Refresh();
        }

        private void frmrombo_Load(object sender, EventArgs e)
        {

        }
    }
}
