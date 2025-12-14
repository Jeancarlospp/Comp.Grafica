using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurvasBezier.Forms;

namespace CurvasBezier
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        /// <summary>
        /// Configura los eventos de los menús.
        /// </summary>
        private void ConfigurarEventos()
        {
            mniBezier2Puntos.Click += mniBezier2Puntos_Click;
            mniBezier3Puntos.Click += mniBezier3Puntos_Click;
        }

        /// <summary>
        /// Maneja el click en el menú de curva Bézier con 2 puntos.
        /// </summary>
        private void mniBezier2Puntos_Click(object sender, EventArgs e)
        {
            try
            {
                frmBezier2Puntos formulario = new frmBezier2Puntos();
                formulario.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el click en el menú de curva Bézier con 3 puntos.
        /// </summary>
        private void mniBezier3Puntos_Click(object sender, EventArgs e)
        {
            try
            {
                frmBezier3Puntos formulario = new frmBezier3Puntos();
                formulario.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
