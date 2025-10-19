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
    public partial class Rombo : Form
    {
        public Rombo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                int DMayor = int.Parse(txtDMayor.Text);
                int DMenor = int.Parse(txtDMenor.Text);
                if (DMayor <= 0 || DMenor <= 0)
                {
                    MessageBox.Show("Ingrese un numero mayor a 0");
                }
                if (DMenor>= DMayor)
                {
                    MessageBox.Show("La Diagonal Mayor debe ser mayor que la Diagonal Menor");
                }
                else
                {
                    MessageBox.Show("El area del Rombo es: " + ((DMayor * DMenor) / 2) +
                        "\nEl perimetro del Rombo es: " + (2 * Math.Sqrt(Math.Pow(DMenor, 2) + Math.Pow(DMayor, 2))));
                }



            }
            catch (Exception)
            {
                MessageBox.Show("No ingreso un numero adecuado ");
            }
        }
    }
}
