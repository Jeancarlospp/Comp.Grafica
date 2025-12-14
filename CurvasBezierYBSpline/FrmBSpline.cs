using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CurvasBezierYBSpline.Modelos;
using CurvasBezierYBSpline.Utilidades;

namespace CurvasBezierYBSpline.Formularios
{
    public partial class FrmBSpline : Form
    {
        private CurvaBSpline curvaActual;
        private AnimadorBezier animador;
        private DoubleBufferedPanel pnlCanvas;
        private TrackBar trbParametroT;
        private Button btnIniciarAnimacion;
        private Button btnReiniciar;
        private Button btnLimpiar;
        private CheckBox chkMostrarPoligono;
        private CheckBox chkMostrarSegmentosColor;
        private CheckBox chkMostrarVectorNodos;
        private Label lblParametroT;
        private Label lblInstrucciones;
        private Label lblInfoCurva;
        
        private Punto2D puntoSeleccionado;
        private int indicePuntoSeleccionado = -1;
        private bool arrastrando = false;

        private readonly Color colorFondo = Color.FromArgb(230, 240, 250);
        private readonly Color colorCurva = Color.FromArgb(80, 120, 200);
        private readonly Color colorPuntoControl = Color.FromArgb(255, 150, 100);
        private readonly Color colorPoligono = Color.FromArgb(180, 200, 220);
        private readonly Color colorPuntoAnimado = Color.FromArgb(255, 100, 100);
        
        private readonly Color[] coloresSegmentos = new Color[]
        {
            Color.FromArgb(100, 150, 255),
            Color.FromArgb(150, 100, 255),
            Color.FromArgb(255, 150, 150),
            Color.FromArgb(150, 255, 150),
            Color.FromArgb(255, 200, 100),
            Color.FromArgb(100, 255, 200)
        };

        // Pens y brushes reutilizables
        private Pen penPoligono;
        private Pen penCurva;
        private Pen[] pensSegmentos;
        private SolidBrush brushPuntoAnimado;
        private Pen penPuntoAnimado;
        private SolidBrush brushVectorNodos;
        private Brush brushNegro;
        private Font fontConsolas;

        public FrmBSpline(CurvaBSpline curva)
        {
            InitializeComponent();
            curvaActual = curva;
            animador = new AnimadorBezier();
            animador.CambioParametro += Animador_CambioParametro;
            InicializarRecursosGraficos();
            ConfigurarFormulario();
            InicializarControles();
        }

        private void InicializarRecursosGraficos()
        {
            // Crear pens y brushes reutilizables
            penPoligono = new Pen(colorPoligono, 1.5f) { DashStyle = DashStyle.Dash };
            penCurva = new Pen(colorCurva, 3f);
            brushPuntoAnimado = new SolidBrush(colorPuntoAnimado);
            penPuntoAnimado = new Pen(Color.DarkRed, 2f);
            brushVectorNodos = new SolidBrush(Color.FromArgb(200, 255, 255, 255));
            brushNegro = Brushes.Black;
            fontConsolas = new Font("Consolas", 8);

            // Crear pens para segmentos
            pensSegmentos = new Pen[coloresSegmentos.Length];
            for (int i = 0; i < coloresSegmentos.Length; i++)
            {
                pensSegmentos[i] = new Pen(coloresSegmentos[i], 3f);
            }
        }

        private void LiberarRecursosGraficos()
        {
            // Liberar recursos gráficos
            penPoligono?.Dispose();
            penCurva?.Dispose();
            brushPuntoAnimado?.Dispose();
            penPuntoAnimado?.Dispose();
            brushVectorNodos?.Dispose();
            fontConsolas?.Dispose();

            if (pensSegmentos != null)
            {
                foreach (var pen in pensSegmentos)
                {
                    pen?.Dispose();
                }
            }
        }

        private void ConfigurarFormulario()
        {
            this.Text = $"Curvas B-Spline - {curvaActual.Nombre}";
            this.ClientSize = new Size(1200, 700);
            this.BackColor = Color.FromArgb(245, 248, 252);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InicializarControles()
        {
            // Panel de canvas con doble buffer
            pnlCanvas = new DoubleBufferedPanel
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

            int xControles = 940;
            int yInicio = 20;

            lblInstrucciones = new Label
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 100),
                Text = $"Haz clic en el canvas para\nagregar puntos de control.\n\nPuntos: {curvaActual.NumeroMinimoPuntos}-{curvaActual.NumeroMaximoPuntos}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(60, 60, 60)
            };
            this.Controls.Add(lblInstrucciones);

            yInicio += 110;
            lblInfoCurva = new Label
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 60),
                Text = curvaActual.EsCerrada ?
                    "💡 Curva cerrada:\nLa curva forma un loop" :
                    "💡 Curva abierta:\nLa curva NO pasa por\nlos puntos extremos",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(100, 100, 100),
                BackColor = Color.FromArgb(250, 250, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5)
            };
            this.Controls.Add(lblInfoCurva);

            yInicio += 70;
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

            yInicio += 60;
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

            yInicio += 30;
            chkMostrarSegmentosColor = new CheckBox
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 25),
                Text = "Colorear segmentos (control local)",
                Checked = false,
                Font = new Font("Segoe UI", 9)
            };
            chkMostrarSegmentosColor.CheckedChanged += (s, e) => pnlCanvas.Invalidate();
            this.Controls.Add(chkMostrarSegmentosColor);

            yInicio += 30;
            chkMostrarVectorNodos = new CheckBox
            {
                Location = new Point(xControles, yInicio),
                Size = new Size(240, 25),
                Text = "Mostrar vector de nodos",
                Checked = false,
                Font = new Font("Segoe UI", 9)
            };
            chkMostrarVectorNodos.CheckedChanged += (s, e) => pnlCanvas.Invalidate();
            this.Controls.Add(chkMostrarVectorNodos);

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
            AgregarItemLeyenda(x, y, colorPuntoControl, "Puntos de control");
            y += 25;
            AgregarItemLeyenda(x, y, colorCurva, "Curva B-Spline");
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
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            var puntos = curvaActual.ObtenerPuntosControl();

            if (chkMostrarPoligono.Checked && puntos.Count > 1)
            {
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    g.DrawLine(penPoligono, puntos[i].ToPointF(), puntos[i + 1].ToPointF());
                }
                
                if (curvaActual.EsCerrada && puntos.Count > 2)
                {
                    g.DrawLine(penPoligono, puntos[puntos.Count - 1].ToPointF(), puntos[0].ToPointF());
                }
            }

            if (curvaActual.EstaCompleta())
            {
                if (chkMostrarSegmentosColor.Checked)
                {
                    var segmentos = curvaActual.ObtenerSegmentosCurva();
                    for (int i = 0; i < segmentos.Count; i++)
                    {
                        if (segmentos[i].Count > 1)
                        {
                            Pen penSegmento = pensSegmentos[i % pensSegmentos.Length];
                            g.DrawCurve(penSegmento, segmentos[i].ToArray());
                        }
                    }
                }
                else
                {
                    var puntosCurva = curvaActual.ObtenerPuntosCurva();
                    if (puntosCurva.Count > 1)
                    {
                        g.DrawCurve(penCurva, puntosCurva.ToArray());
                    }
                }

                float t = animador.ObtenerParametro();
                var vectorNodos = curvaActual.ObtenerVectorNodos();
                if (vectorNodos.Count > 0)
                {
                    int grado = 3;
                    float tMin = vectorNodos[Math.Min(grado, vectorNodos.Count - 1)];
                    float tMax = vectorNodos[Math.Max(0, vectorNodos.Count - grado - 1)];
                    float tReal = tMin + (tMax - tMin) * t;
                    
                    Punto2D puntoActual = curvaActual.CalcularPuntoEnCurva(tReal);
                    if (puntoActual != null)
                    {
                        g.FillEllipse(brushPuntoAnimado,
                                     puntoActual.X - 5, puntoActual.Y - 5, 10, 10);
                        g.DrawEllipse(penPuntoAnimado,
                                     puntoActual.X - 5, puntoActual.Y - 5, 10, 10);
                    }
                }
            }

            foreach (var punto in puntos)
            {
                punto.Dibujar(g, colorPuntoControl);
            }

            if (chkMostrarVectorNodos.Checked && curvaActual.EstaCompleta())
            {
                DibujarVectorNodos(g);
            }
        }

        private void DibujarVectorNodos(Graphics g)
        {
            var vectorNodos = curvaActual.ObtenerVectorNodos();
            if (vectorNodos.Count == 0) return;

            int yPos = 10;
            string texto = "Vector de nodos: [";
            for (int i = 0; i < Math.Min(vectorNodos.Count, 15); i++)
            {
                texto += vectorNodos[i].ToString("F1");
                if (i < vectorNodos.Count - 1) texto += ", ";
            }
            if (vectorNodos.Count > 15) texto += "...";
            texto += "]";

            g.FillRectangle(brushVectorNodos, 5, yPos, 890, 25);
            g.DrawString(texto, fontConsolas, brushNegro, 10, yPos + 5);
        }

        private void PnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var puntos = curvaActual.ObtenerPuntosControl();

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

                if (puntos.Count < curvaActual.NumeroMaximoPuntos)
                {
                    curvaActual.AgregarPunto(e.X, e.Y);
                    pnlCanvas.Invalidate();

                    if (curvaActual.EstaCompleta())
                    {
                        lblInstrucciones.Text = "¡Curva completa!\n\nArrasta los puntos para\nmodificar la curva.\n\nPuedes agregar más puntos.";
                    }
                }
                else
                {
                    MessageBox.Show($"Has alcanzado el máximo de {curvaActual.NumeroMaximoPuntos} puntos.",
                                  "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Debes agregar al menos {curvaActual.NumeroMinimoPuntos} puntos primero.",
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
                lblInstrucciones.Text = $"Haz clic en el canvas para\nagregar puntos de control.\n\nPuntos: {curvaActual.NumeroMinimoPuntos}-{curvaActual.NumeroMaximoPuntos}";
                btnIniciarAnimacion.Text = "▶ Animar";
                btnIniciarAnimacion.BackColor = Color.FromArgb(100, 180, 100);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            animador?.Dispose();
            LiberarRecursosGraficos();
            base.OnFormClosing(e);
        }
    }
}