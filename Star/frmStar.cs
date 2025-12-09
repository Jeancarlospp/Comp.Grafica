using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star
{
    public partial class frmStar : Form
    {
        private Star ObjStar = new Star();
        public frmStar()
        {
            InitializeComponent();
        }

        private void frmStar_Load(object sender, EventArgs e)
        {

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            ObjStar.ReadData(txtAltura);
            ObjStar.PlotShape(this);
        }
    }
}
