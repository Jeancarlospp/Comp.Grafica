using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoritmosClasicos.UI.Forms;

namespace AlgoritmosClasicos
{
    /// <summary>
    /// Formulario principal de la aplicación de algoritmos clásicos de computación gráfica.
    /// </summary>
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manejador del evento click para el menú de Trazado de Líneas.
        /// </summary>
        private void mniTrazadoLineas_Click(object sender, EventArgs e)
        {
            var frmLineDrawing = new frmLineDrawing();
            frmLineDrawing.ShowDialog();
        }

        /// <summary>
        /// Manejador del evento click para el menú de Trazado de Círculos.
        /// </summary>
        private void mniTrazadoCirculos_Click(object sender, EventArgs e)
        {
            var frmCircleDrawing = new frmCircleDrawing();
            frmCircleDrawing.ShowDialog();
        }

        /// <summary>
        /// Manejador del evento click para el menú de Algoritmos de Relleno.
        /// </summary>
        private void mniAlgoritmosRelleno_Click(object sender, EventArgs e)
        {
            var frmFillAlgorithms = new frmFillAlgorithms();
            frmFillAlgorithms.ShowDialog();
        }

        /// <summary>
        /// Manejador del evento click para el menú de Recorte de Líneas.
        /// </summary>
        private void mniRecorteLineas_Click(object sender, EventArgs e)
        {
            var frmLineClipping = new frmLineClipping();
            frmLineClipping.ShowDialog();
        }

        /// <summary>
        /// Manejador del evento click para el menú de Recorte de Polígonos.
        /// </summary>
        private void mniRecortePoligonos_Click(object sender, EventArgs e)
        {
            // Funcionalidad no implementada
            MessageBox.Show("Funcionalidad de Recorte de Polígonos - Próximamente", 
                "En Desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
