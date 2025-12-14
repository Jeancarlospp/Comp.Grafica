using System;
using System.Drawing;
using System.Windows.Forms;
using CurvasBezierYBSpline.Modelos;

namespace CurvasBezierYBSpline.Formularios
{
    public partial class FrmHome : Form
    {
        private MenuStrip mnuPrincipal;
        private ToolStripMenuItem mnuCurvasBezier;
        private ToolStripMenuItem mnuBezier2Puntos;
        private ToolStripMenuItem mnuBezier3Puntos;
        private ToolStripMenuItem mnuBezier4Puntos;
        private ToolStripMenuItem mnuBezierNPuntos;
        private ToolStripMenuItem mnuCurvasBSpline;
        private ToolStripMenuItem mnuBSplineCubicaAbierta;
        private ToolStripMenuItem mnuBSplineCubicaCerrada;
        private ToolStripMenuItem mnuBSplineCuadraticaAbierta;
        private ToolStripMenuItem mnuBSplineNPuntos;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Panel pnlContenido;

        public FrmHome()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CrearMenu();
            CrearContenido();
        }

        private void ConfigurarFormulario()
        {
            this.Icon = SystemIcons.Application;
            this.ClientSize = new Size(900, 600);
            this.Text = "Curvas de Bézier y B-Spline";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 248, 252);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void CrearMenu()
        {
            mnuPrincipal = new MenuStrip
            {
                BackColor = Color.FromArgb(230, 240, 250),
                Font = new Font("Segoe UI", 10)
            };

            // Menú Curvas de Bézier
            mnuCurvasBezier = new ToolStripMenuItem("Curvas de Bézier");

            mnuBezier2Puntos = new ToolStripMenuItem("Lineal (2 puntos)");
            mnuBezier2Puntos.Click += (s, e) => AbrirCurvaBezier(new BezierLineal());

            mnuBezier3Puntos = new ToolStripMenuItem("Cuadrática (3 puntos)");
            mnuBezier3Puntos.Click += (s, e) => AbrirCurvaBezier(new BezierCuadratica());

            mnuBezier4Puntos = new ToolStripMenuItem("Cúbica (4 puntos)");
            mnuBezier4Puntos.Click += (s, e) => AbrirCurvaBezier(new BezierCubica());

            mnuBezierNPuntos = new ToolStripMenuItem("N Puntos (personalizado)");
            mnuBezierNPuntos.Click += MnuBezierNPuntos_Click;

            mnuCurvasBezier.DropDownItems.Add(mnuBezier2Puntos);
            mnuCurvasBezier.DropDownItems.Add(mnuBezier3Puntos);
            mnuCurvasBezier.DropDownItems.Add(mnuBezier4Puntos);
            mnuCurvasBezier.DropDownItems.Add(new ToolStripSeparator());
            mnuCurvasBezier.DropDownItems.Add(mnuBezierNPuntos);

            // Menú Curvas B-Spline
            mnuCurvasBSpline = new ToolStripMenuItem("Curvas B-Spline");

            mnuBSplineCubicaAbierta = new ToolStripMenuItem("Cúbica Abierta (4-10 puntos)");
            mnuBSplineCubicaAbierta.Click += (s, e) => AbrirCurvaBSpline(new BSplineCubicaAbierta());

            mnuBSplineCubicaCerrada = new ToolStripMenuItem("Cúbica Cerrada (4-10 puntos)");
            mnuBSplineCubicaCerrada.Click += (s, e) => AbrirCurvaBSpline(new BSplineCubicaCerrada());

            mnuBSplineCuadraticaAbierta = new ToolStripMenuItem("Cuadrática Abierta (3-10 puntos)");
            mnuBSplineCuadraticaAbierta.Click += (s, e) => AbrirCurvaBSpline(new BSplineCuadraticaAbierta());

            mnuBSplineNPuntos = new ToolStripMenuItem("B-Spline con N Puntos (personalizado)");
            mnuBSplineNPuntos.Click += MnuBSplineNPuntos_Click;

            mnuCurvasBSpline.DropDownItems.Add(mnuBSplineCubicaAbierta);
            mnuCurvasBSpline.DropDownItems.Add(mnuBSplineCubicaCerrada);
            mnuCurvasBSpline.DropDownItems.Add(mnuBSplineCuadraticaAbierta);
            mnuCurvasBSpline.DropDownItems.Add(new ToolStripSeparator());
            mnuCurvasBSpline.DropDownItems.Add(mnuBSplineNPuntos);

            mnuPrincipal.Items.Add(mnuCurvasBezier);
            mnuPrincipal.Items.Add(mnuCurvasBSpline);

            this.MainMenuStrip = mnuPrincipal;
            this.Controls.Add(mnuPrincipal);
        }

        private void CrearContenido()
        {
            // Panel de contenido principal
            pnlContenido = new Panel
            {
                Location = new Point(50, 80),
                Size = new Size(800, 480),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(pnlContenido);

            // Título
            lblTitulo = new Label
            {
                Location = new Point(0, 50),
                Size = new Size(800, 60),
                Text = "Visualizador de Curvas de Bézier y B-Spline",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 100, 180),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlContenido.Controls.Add(lblTitulo);

            // Descripción
            lblDescripcion = new Label
            {
                Location = new Point(50, 130),
                Size = new Size(700, 220),
                Text = "Bienvenido al visualizador de curvas paramétricas.\n\n" +
                       "📐 Curvas de Bézier:\n" +
                       "• Pasan por los puntos extremos\n" +
                       "• Control global (mover un punto afecta toda la curva)\n" +
                       "• Ideales para trazos simples y diseño gráfico\n\n" +
                       "📊 Curvas B-Spline:\n" +
                       "• NO pasan por los puntos de control (excepto cerradas)\n" +
                       "• Control local (mover un punto afecta solo una zona)\n" +
                       "• Más flexibles para modelado CAD y animación\n\n" +
                       "Selecciona una opción del menú para comenzar.",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(80, 80, 80)
            };
            pnlContenido.Controls.Add(lblDescripcion);

            // Panel decorativo con información adicional
            Panel pnlInfo = new Panel
            {
                Location = new Point(100, 360),
                Size = new Size(600, 80),
                BackColor = Color.FromArgb(230, 240, 250),
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlContenido.Controls.Add(pnlInfo);

            Label lblInfo = new Label
            {
                Location = new Point(20, 10),
                Size = new Size(560, 60),
                Text = "💡 Tip: Haz clic en el canvas para agregar puntos. Arrastra los puntos " +
                       "para modificar la curva en tiempo real. Usa el slider o el botón de " +
                       "animación para ver cómo se construye la curva.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(60, 60, 60)
            };
            pnlInfo.Controls.Add(lblInfo);
        }

        private void MnuBezierNPuntos_Click(object sender, EventArgs e)
        {
            using (var frmDialog = new Form())
            {
                frmDialog.Text = "Curva de Bézier - N Puntos";
                frmDialog.Size = new Size(350, 180);
                frmDialog.StartPosition = FormStartPosition.CenterParent;
                frmDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmDialog.MaximizeBox = false;
                frmDialog.MinimizeBox = false;
                frmDialog.BackColor = Color.FromArgb(245, 248, 252);

                Label lblPregunta = new Label
                {
                    Location = new Point(20, 20),
                    Size = new Size(300, 30),
                    Text = "¿Cuántos puntos deseas usar? (2-10):",
                    Font = new Font("Segoe UI", 10)
                };
                frmDialog.Controls.Add(lblPregunta);

                NumericUpDown numPuntos = new NumericUpDown
                {
                    Location = new Point(20, 55),
                    Size = new Size(300, 30),
                    Minimum = 2,
                    Maximum = 10,
                    Value = 5,
                    Font = new Font("Segoe UI", 11)
                };
                frmDialog.Controls.Add(numPuntos);

                Button btnAceptar = new Button
                {
                    Location = new Point(170, 100),
                    Size = new Size(140, 35),
                    Text = "Aceptar",
                    DialogResult = DialogResult.OK,
                    BackColor = Color.FromArgb(100, 180, 100),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnAceptar.FlatAppearance.BorderSize = 0;
                frmDialog.Controls.Add(btnAceptar);

                Button btnCancelar = new Button
                {
                    Location = new Point(20, 100),
                    Size = new Size(140, 35),
                    Text = "Cancelar",
                    DialogResult = DialogResult.Cancel,
                    BackColor = Color.FromArgb(180, 180, 180),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10),
                    Cursor = Cursors.Hand
                };
                btnCancelar.FlatAppearance.BorderSize = 0;
                frmDialog.Controls.Add(btnCancelar);

                frmDialog.AcceptButton = btnAceptar;
                frmDialog.CancelButton = btnCancelar;

                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int n = (int)numPuntos.Value;
                        AbrirCurvaBezier(new BezierN(n));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear la curva: {ex.Message}",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void MnuBSplineNPuntos_Click(object sender, EventArgs e)
        {
            using (var frmDialog = new Form())
            {
                frmDialog.Text = "Curva B-Spline - N Puntos";
                frmDialog.Size = new Size(380, 280);
                frmDialog.StartPosition = FormStartPosition.CenterParent;
                frmDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmDialog.MaximizeBox = false;
                frmDialog.MinimizeBox = false;
                frmDialog.BackColor = Color.FromArgb(245, 248, 252);

                Label lblPuntos = new Label
                {
                    Location = new Point(20, 20),
                    Size = new Size(330, 25),
                    Text = "Número de puntos (3-15):",
                    Font = new Font("Segoe UI", 10)
                };
                frmDialog.Controls.Add(lblPuntos);

                NumericUpDown numPuntos = new NumericUpDown
                {
                    Location = new Point(20, 50),
                    Size = new Size(330, 30),
                    Minimum = 3,
                    Maximum = 15,
                    Value = 6,
                    Font = new Font("Segoe UI", 11)
                };
                frmDialog.Controls.Add(numPuntos);

                Label lblGrado = new Label
                {
                    Location = new Point(20, 90),
                    Size = new Size(330, 25),
                    Text = "Grado de la curva (1-5):",
                    Font = new Font("Segoe UI", 10)
                };
                frmDialog.Controls.Add(lblGrado);

                NumericUpDown numGrado = new NumericUpDown
                {
                    Location = new Point(20, 120),
                    Size = new Size(330, 30),
                    Minimum = 1,
                    Maximum = 5,
                    Value = 3,
                    Font = new Font("Segoe UI", 11)
                };
                frmDialog.Controls.Add(numGrado);

                CheckBox chkCerrada = new CheckBox
                {
                    Location = new Point(20, 165),
                    Size = new Size(330, 25),
                    Text = "Curva cerrada (forma un loop)",
                    Font = new Font("Segoe UI", 10),
                    Checked = false
                };
                frmDialog.Controls.Add(chkCerrada);

                Button btnAceptar = new Button
                {
                    Location = new Point(200, 205),
                    Size = new Size(150, 35),
                    Text = "Aceptar",
                    DialogResult = DialogResult.OK,
                    BackColor = Color.FromArgb(100, 180, 100),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnAceptar.FlatAppearance.BorderSize = 0;
                frmDialog.Controls.Add(btnAceptar);

                Button btnCancelar = new Button
                {
                    Location = new Point(20, 205),
                    Size = new Size(150, 35),
                    Text = "Cancelar",
                    DialogResult = DialogResult.Cancel,
                    BackColor = Color.FromArgb(180, 180, 180),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10),
                    Cursor = Cursors.Hand
                };
                btnCancelar.FlatAppearance.BorderSize = 0;
                frmDialog.Controls.Add(btnCancelar);

                frmDialog.AcceptButton = btnAceptar;
                frmDialog.CancelButton = btnCancelar;

                if (frmDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int n = (int)numPuntos.Value;
                        int grado = (int)numGrado.Value;
                        bool cerrada = chkCerrada.Checked;

                        if (grado >= n)
                        {
                            MessageBox.Show("El grado debe ser menor que el número de puntos.",
                                          "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        AbrirCurvaBSpline(new BSplineNPuntos(n, grado, cerrada));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear la curva: {ex.Message}",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AbrirCurvaBezier(CurvaBezier curva)
        {
            try
            {
                var frmBezier = new FrmBezier(curva);
                frmBezier.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el visualizador: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirCurvaBSpline(CurvaBSpline curva)
        {
            try
            {
                var frmBSpline = new FrmBSpline(curva);
                frmBSpline.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el visualizador: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}