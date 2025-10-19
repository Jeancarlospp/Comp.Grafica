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
    public partial class Trapecio : Form
    {
        public Trapecio()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                int BMayor = int.Parse(txtBMayor.Text);
                int BMenor = int.Parse(txtBMenor.Text);
                int Altura = int.Parse(txtAltura.Text);
                int Lado = int.Parse(txtLado.Text);
                if (BMayor <= 0 || Altura <= 0 || BMenor <= 0 || Lado <= 0)
                {
                    MessageBox.Show("Ingrese un numero mayor a 0");
                }
                else
                {
                    MessageBox.Show("El area del Traprecio es: " + ((Altura/2)*(BMayor+BMenor) ) +
                        "\nEl perimetro del Trapecio es: " + (BMenor+BMayor+ (Lado * 2)));
                }



            }
            catch (Exception)
            {
                MessageBox.Show("No ingreso un numero adecuado ");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
