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
    public partial class Triangulo : Form
    {
        private static Triangulo instance = null;
        private static readonly object lockObject = new object();

        private Triangulo()
        {
            InitializeComponent();
        }

        public static Triangulo GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                lock (lockObject)
                {
                    if (instance == null || instance.IsDisposed)
                    {
                        instance = new Triangulo();
                    }
                }
            }
            return instance;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                int Base = int.Parse(txtBase.Text);
                int Altura = int.Parse(txtAltura.Text);
                if (Base <= 0 || Altura <= 0)
                {
                    MessageBox.Show("Ingrese un numero mayor a 0");
                }
                else
                {
                    MessageBox.Show("El area del Triangulo es: " + ((Base * Altura)/2) +
                        "\nEl perimetro del Triangulo es: " + (Base * 3));
                }



            }
            catch (Exception)
            {
                MessageBox.Show("No ingreso un numero adecuado ");
            }
        }

        private void txtBase_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
