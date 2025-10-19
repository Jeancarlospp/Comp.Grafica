using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangulo fmr1 = Rectangulo.GetInstance();
            fmr1.MdiParent = this;
            fmr1.Show();
            fmr1.Activate();
        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cuadrado fmr1 = new Cuadrado();
            fmr1.MdiParent = this;
            fmr1.Show();    
        }

        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Triangulo fmr1 = new Triangulo();
            fmr1.MdiParent = this;
            fmr1.Show();
        }

        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rombo fmr1 = new Rombo();
            fmr1.MdiParent = this;
            fmr1.Show();
        }

        private void romboideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Romboide fmr1 = new Romboide();
            fmr1.MdiParent = this;
            fmr1.Show();    
        }

        private void trapecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trapecio fmr1 = new Trapecio();
            fmr1.MdiParent = this;
            fmr1.Show();
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Circulo fmr1 = new Circulo();
            fmr1.MdiParent = this;
            fmr1.Show();
        }
    }
}
