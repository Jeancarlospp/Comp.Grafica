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
    public partial class Rectangulo : Form
    {
        private static Rectangulo instance = null;
        private static readonly object lockObject = new object();

        private Rectangulo()
        {
            InitializeComponent();
        }

        public static Rectangulo GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                lock (lockObject)
                {
                    if (instance == null || instance.IsDisposed)
                    {
                        instance = new Rectangulo();
                    }
                }
            }
            return instance;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                    MessageBox.Show("El area del rectangulo es: " + (Base * Altura) + 
                        "\nEl perimetro del rectangulo es: " + ((Base * 2) + (Altura * 2)));
                }



            }
            catch (Exception)
            {
                MessageBox.Show("No ingreso un numero adecuado ");
            }
        }
    }
}
