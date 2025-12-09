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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
            
            // Conectar el evento Click del menú Figura1
            figura1ToolStripMenuItem.Click += Figura1ToolStripMenuItem_Click;
            
            // Conectar el evento Click del menú Figura2
            figura2ToolStripMenuItem.Click += Figura2ToolStripMenuItem_Click;
        }

        private void Figura1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario frmrombo
            frmrombo formRombo = new frmrombo();
            
            // Configurarlo como formulario hijo MDI
            formRombo.MdiParent = this;
            
            // Mostrar el formulario
            formRombo.Show();
        }

        private void Figura2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario frmovalo
            frmovalo formOvalo = new frmovalo();
            
            // Configurarlo como formulario hijo MDI
            formOvalo.MdiParent = this;
            
            // Mostrar el formulario
            formOvalo.Show();
        }
    }
}
