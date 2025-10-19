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
    public partial class Circulo : Form
    {
        public Circulo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Radio = int.Parse(txtRadio.Text);

                if (Radio <= 0)
                {
                    MessageBox.Show("Ingrese un numero mayor a 0");
                }
                else
                {
                    MessageBox.Show("El area del Cículo es: " + (Math.PI * Math.Pow(Radio,2) +
                        "\nEl perimetro del Círculo es: " + ((2*Math.PI*Radio))));
                }



            }
            catch (Exception)
            {
                MessageBox.Show("No ingreso un número adecuado ");
            }
        }
    }
}
