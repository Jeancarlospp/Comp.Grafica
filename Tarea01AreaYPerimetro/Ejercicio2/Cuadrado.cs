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
    public partial class Cuadrado : Form
    {
        public Cuadrado()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                int Lado = int.Parse(txtLado.Text);
                if (Lado <= 0)
                {
                    MessageBox.Show("Ingrese un numero mayor a 0");
                }
                else
                {
                    MessageBox.Show("El area del cuadrado es: " + (Lado * Lado) +
                        "\nEl perimetro del cuadrado es: " + ((Lado * 2) + (Lado * 2)));
                }



            }
            catch (Exception)
            {
                MessageBox.Show("No ingreso un numero adecuado ");
            }
        }
    }
}
