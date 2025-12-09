using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRectangle
{
    public partial class frmSquare : Form
    {
        // Definición de un objeto de tipo CSquare.
        CSquare ObjSquare = new CSquare();
        public frmSquare()
        {
            InitializeComponent();
        }

        private void frmSquare_Load(object sender, EventArgs e)
        {
            // Inicialización de los datos y controles.
            // Llamada a la función InitializeData.
            ObjSquare.InitializeData(txtSide, txtPerimeter,
            txtArea, picCanvas);
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Lectura de datos.
            // Llamada a la función ReadData.
            ObjSquare.ReadData(txtSide);
            // Cálculo del perímetro de un cuadrado.
            // Llamada a la función PerimeterSquare.
            ObjSquare.PerimeterSquare();
            // Cálculo del área de un cuadrado.
            // Llamada a la función AreaSquare.
            ObjSquare.AreaSquare();
            // Impresión de datos.
            // Llamada a la función PrintData.
            ObjSquare.PrintData(txtPerimeter, txtArea);
            // Graficación de un cuadrado.
            // Llamada a la función PlotShape.
            ObjSquare.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Inicialización de los datos y controles.
            // Llamada a la función InitializeData.
            ObjSquare.InitializeData(txtSide, txtPerimeter,
            txtArea, picCanvas);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Cierre de un formulario.
            // Llamada a la función CloseForm.
            ObjSquare.CloseForm(this);
        }

    }
}
