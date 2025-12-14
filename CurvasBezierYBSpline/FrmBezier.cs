using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CurvasBezierYBSpline.Modelos;
using CurvasBezierYBSpline.Utilidades;

namespace CurvasBezierYBSpline.Formularios
{
    public partial class FrmBezier : Form
    {
        private CurvaBezier curvaActual;
        private AnimadorBezier animador;
        private Panel pnlCanvas;
        private TrackBar trbParametroT;
        private Button btnIniciarAnimacion;
        private Button btnReiniciar;
        private Button btnLimpiar;
        private CheckBox chkMostrarConstruccion;
        private CheckBox chkMostrarPoligono;
        private Label lblParametroT;
        private Label lblInstrucciones;

        private Punto2D puntoSeleccionado;
        private int indicePuntoSeleccionado = -1;
        private bool arrastrando = false;

        // Colores pastel suaves
        private readonly Color colorFondo = Color.FromArgb(230, 240, 250);
        private readonly Color colorCurva = Color.FromArgb(80, 120, 200);
        private readonly Color colorPuntoExterno = Color.FromArgb(100, 150, 255);
        private readonly Color colorPuntoControl = Color.FromArgb(255, 150, 100);
        private readonly Color colorPoligono = Color.FromArgb(180, 200, 220);
        private readonly Color colorLineaConstruccion1 = Color.FromArgb(150, 200, 150);
        private readonly Color colorLineaConstruccion2 = Color.FromArgb(255, 180, 150);
        private readonly Color colorPuntoAnimado = Color.FromArgb(255, 100, 100);

        public FrmBezier(CurvaBezier curva)
        {
            InitializeComponent();
            curvaActual = curva;
            animador = new AnimadorBezier();
            animador.CambioParametro += Animador_CambioParametro;
            ConfigurarFormulario();
            InicializarControles();
        }

        private void ConfigurarFormulario()
        {
            this.Text = $"Curvas de Bézier - {curvaActual.Nombre}";
            this.BackColor = Color.FromArgb(245, 248, 252);
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InicializarControles()
        {
            // Panel de canvas
            pnlCanvas = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(900, 600),
                BackColor = colorFondo,
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlCanvas.Paint += PnlCanvas_Paint;
            pnlCanvas.MouseDown += PnlCanvas_MouseDown;
            pnlCanvas.MouseMove += PnlCanvas_MouseMove;
            pnlCanvas.MouseUp += PnlCanvas_MouseUp;
            this.Controls.Add(pnlCanvas);

            // Panel de controles
            int xControles = 940;
            int yInicio = 20;

            // Label de instrucciones
            lblInstrucciones = new Label
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 80),
                Text = $"Haz clic en el canvas para\nagregar puntos.\n\nPuntos necesarios: {curvaActual.NumeroMaximoPuntos}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(60, 60, 60)
            };
            this.Controls.Add(lblInstrucciones);

            // TrackBar para parámetro t
            yInicio += 100;
            Label lblT = new Label
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 20),
                Text = "Parámetro t:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblT);

            trbParametroT = new TrackBar
            {
                Location = new Point(xControles, yInicio + 25),
                Size = new Size(240, 45),
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                TickFrequency = 10
            };
            trbParametroT.ValueChanged += TrbParametroT_ValueChanged;
            this.Controls.Add(trbParametroT);

            lblParametroT = new Label
            {
                Location = new Point(xControles, yInicio + 70),
                Size = new Size(240, 20),
                Text = "t = 0.00",
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblParametroT);

            // Botones de control
            yInicio += 110;
            btnIniciarAnimacion = new Button
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(110, 35),
                Text = "▶ Animar",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(100, 180, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnIniciarAnimacion.FlatAppearance.BorderSize = 0;
            btnIniciarAnimacion.Click += BtnIniciarAnimacion_Click;
            this.Controls.Add(btnIniciarAnimacion);

            btnReiniciar = new Button
            {
                Location = new Point(xControles + 120, yInicio),
                Size = new Size(110, 35),
                Text = "⟲ Reiniciar",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(100, 150, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnReiniciar.FlatAppearance.BorderSize = 0;
            btnReiniciar.Click += BtnReiniciar_Click;
            this.Controls.Add(btnReiniciar);

            yInicio += 50;
            btnLimpiar = new Button
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 35),
                Text = "🗑 Limpiar Canvas",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(220, 100, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.Click += BtnLimpiar_Click;
            this.Controls.Add(btnLimpiar);

            // CheckBoxes para opciones de visualización
            yInicio += 60;
            chkMostrarConstruccion = new CheckBox
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 25),
                Text = "Mostrar líneas de construcción",
                Checked = true,
                Font = new Font("Segoe UI", 9)
            };
            chkMostrarConstruccion.CheckedChanged += (s, e) => pnlCanvas.Invalidate();
            this.Controls.Add(chkMostrarConstruccion);

            yInicio += 30;
            chkMostrarPoligono = new CheckBox
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 25),
                Text = "Mostrar polígono de control",
                Checked = true,
                Font = new Font("Segoe UI", 9)
            };
            chkMostrarPoligono.CheckedChanged += (s, e) => pnlCanvas.Invalidate();
            this.Controls.Add(chkMostrarPoligono);

            // Leyenda de colores
            yInicio += 50;
            CrearLeyenda(xControles, yInicio);
        }

        private void CrearLeyenda(int x, int y)
        {
            Label lblLeyenda = new Label
            {
                Location = new Point(x, y),
                Size = new Size(240, 20),
                Text = "Leyenda:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblLeyenda);

            y += 25;
            AgregarItemLeyenda(x, y, colorPuntoExterno, "Puntos externos");
            y += 25;
            AgregarItemLeyenda(x, y, colorPuntoControl, "Puntos de control");
            y += 25;
            AgregarItemLeyenda(x, y, colorCurva, "Curva de Bézier");
        }

        private void AgregarItemLeyenda(int x, int y, Color color, string texto)
        {
            Panel pnlColor = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(20, 20),
                BackColor = color,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(pnlColor);

            Label lblTexto = new Label
            {
                Location = new Point(x + 25, y),
                Size = new Size(200, 20),
                Text = texto,
                Font = new Font("Segoe UI", 8),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblTexto);
        }

        private void PnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var puntos = curvaActual.ObtenerPuntosControl();

            // Dibujar polígono de control
            if (chkMostrarPoligono.Checked && puntos.Count > 1)
            {
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    g.DrawLine(new Pen(colorPoligono, 1.5f) { DashStyle = DashStyle.Dash },
                              puntos[i].ToPointF(), puntos[i + 1].ToPointF());
                }
            }

            // Dibujar líneas de construcción si está animando o moviendo el slider
            if (chkMostrarConstruccion.Checked && curvaActual.EstaCompleta())
            {
                float t = animador.ObtenerParametro();
                var niveles = curvaActual.ObtenerPuntosIntermedios(t);

                // Dibujar niveles de construcción
                for (int nivel = 1; nivel < niveles.Count; nivel++)
                {
                    Color colorLinea = nivel == 1 ? colorLineaConstruccion1 : colorLineaConstruccion2;
                    float grosor = 2f - (nivel * 0.3f);

                    for (int i = 0; i < niveles[nivel].Count - 1; i++)
                    {
                        g.DrawLine(new Pen(colorLinea, grosor),
                                  niveles[nivel][i].ToPointF(),
                                  niveles[nivel][i + 1].ToPointF());
                    }

                    // Dibujar puntos intermedios
                    foreach (var punto in niveles[nivel])
                    {
                        punto.Dibujar(g, colorPuntoAnimado);
                    }
                }
            }

            // Dibujar la curva completa
            if (curvaActual.EstaCompleta())
            {
                var puntosCurva = curvaActual.ObtenerPuntosCurva();
                if (puntosCurva.Count > 1)
                {
                    g.DrawCurve(new Pen(colorCurva, 3f), puntosCurva.ToArray());
                }

                // Dibujar el punto actual en la curva
                float t = animador.ObtenerParametro();
                Punto2D puntoActual = curvaActual.CalcularPuntoEnCurva(t);
                if (puntoActual != null)
                {
                    g.FillEllipse(new SolidBrush(colorPuntoAnimado),
                                 puntoActual.X - 5, puntoActual.Y - 5, 10, 10);
                    g.DrawEllipse(new Pen(Color.DarkRed, 2f),
                                 puntoActual.X - 5, puntoActual.Y - 5, 10, 10);
                }
            }

            // Dibujar puntos de control
            foreach (var punto in puntos)
            {
                Color colorPunto = punto.EsPuntoControl ? colorPuntoControl : colorPuntoExterno;
                punto.Dibujar(g, colorPunto);
            }
        }

        private void PnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var puntos = curvaActual.ObtenerPuntosControl();

                // Verificar si se hizo clic en un punto existente
                for (int i = 0; i < puntos.Count; i++)
                {
                    if (puntos[i].ContieneClick(e.Location))
                    {
                        puntoSeleccionado = puntos[i];
                        indicePuntoSeleccionado = i;
                        arrastrando = true;
                        return;
                    }
                }

                // Si no, agregar nuevo punto
                if (!curvaActual.EstaCompleta())
                {
                    curvaActual.AgregarPunto(e.X, e.Y);
                    pnlCanvas.Invalidate();

                    if (curvaActual.EstaCompleta())
                    {
                        lblInstrucciones.Text = "¡Curva completa!\n\nArrasta los puntos para\nmodificar la curva.";
                    }
                }
            }
        }

        private void PnlCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando && puntoSeleccionado != null)
            {
                curvaActual.ActualizarPunto(indicePuntoSeleccionado, e.X, e.Y);
                pnlCanvas.Invalidate();
            }
        }

        private void PnlCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
            puntoSeleccionado = null;
            indicePuntoSeleccionado = -1;
        }

        private void TrbParametroT_ValueChanged(object sender, EventArgs e)
        {
            if (!animador.EstaAnimando())
            {
                float t = trbParametroT.Value / 100f;
                animador.EstablecerParametro(t);
                lblParametroT.Text = $"t = {t:F2}";
            }
        }

        private void Animador_CambioParametro(object sender, float t)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, float>(Animador_CambioParametro), sender, t);
                return;
            }

            trbParametroT.Value = (int)(t * 100);
            lblParametroT.Text = $"t = {t:F2}";
            pnlCanvas.Invalidate();
        }

        private void BtnIniciarAnimacion_Click(object sender, EventArgs e)
        {
            if (!curvaActual.EstaCompleta())
            {
                MessageBox.Show($"Debes agregar {curvaActual.NumeroMaximoPuntos} puntos primero.",
                              "Curva incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (animador.EstaAnimando())
            {
                animador.Pausar();
                btnIniciarAnimacion.Text = "▶ Animar";
                btnIniciarAnimacion.BackColor = Color.FromArgb(100, 180, 100);
            }
            else
            {
                animador.Iniciar();
                btnIniciarAnimacion.Text = "⏸ Pausar";
                btnIniciarAnimacion.BackColor = Color.FromArgb(200, 150, 100);
            }
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            animador.Reiniciar();
            btnIniciarAnimacion.Text = "▶ Animar";
            btnIniciarAnimacion.BackColor = Color.FromArgb(100, 180, 100);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de que deseas limpiar el canvas?",
                                          "Confirmar limpieza", MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                curvaActual.LimpiarPuntos();
                animador.Reiniciar();
                pnlCanvas.Invalidate();
                lblInstrucciones.Text = $"Haz clic en el canvas para\nagregar puntos.\n\nPuntos necesarios: {curvaActual.NumeroMaximoPuntos}";
                btnIniciarAnimacion.Text = "▶ Animar";
                btnIniciarAnimacion.BackColor = Color.FromArgb(100, 180, 100);
            }
        }
    }
}
