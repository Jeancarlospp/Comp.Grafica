using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CurvasBezier.Core;

namespace CurvasBezier.Forms
{
    public partial class frmBezier2Puntos : Form
    {
        private BezierCurve curva;
        private const int MAX_PUNTOS = 2;
        private const int RADIO_PUNTO = 6;
        private bool animacionActiva;

        public frmBezier2Puntos()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            try
            {
                curva = new BezierCurve();
                animacionActiva = false;
                
                pctCanvasCurva.GetType().GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValue(pctCanvasCurva, true, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctCanvasCurva_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;

                if (curva.CantidadPuntos >= MAX_PUNTOS)
                {
                    MessageBox.Show($"Ya hay {MAX_PUNTOS} puntos. Use Reiniciar.", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                curva.AgregarPunto(new PointF(e.X, e.Y));

                if (curva.CantidadPuntos == MAX_PUNTOS)
                {
                    btnPlay.Enabled = true;
                }

                pctCanvasCurva.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctCanvasCurva_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (curva.CantidadPuntos == 0)
                {
                    DibujarInstrucciones(g);
                    return;
                }

                if (curva.CantidadPuntos == MAX_PUNTOS)
                {
                    DibujarCurva(g);
                }

                DibujarLineasPoligonales(g);
                DibujarPuntosControl(g);

                if (curva.CantidadPuntos == MAX_PUNTOS)
                {
                    DibujarPuntoAnimado(g);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DibujarInstrucciones(Graphics g)
        {
            string texto = "Haga click para colocar los puntos de control\n" +
                          $"Puntos restantes: {MAX_PUNTOS - curva.CantidadPuntos}";
            
            using (Font fuente = new Font("Arial", 12))
            using (StringFormat formato = new StringFormat())
            {
                formato.Alignment = StringAlignment.Center;
                formato.LineAlignment = StringAlignment.Center;
                
                g.DrawString(texto, fuente, Brushes.Gray,
                    new RectangleF(0, 0, pctCanvasCurva.Width, pctCanvasCurva.Height),
                    formato);
            }
        }

        private void DibujarCurva(Graphics g)
        {
            List<PointF> puntos = curva.GenerarCurva(100);
            
            using (Pen lapiz = new Pen(Color.Green, 3))
            {
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    g.DrawLine(lapiz, puntos[i], puntos[i + 1]);
                }
            }
        }

        private void DibujarLineasPoligonales(Graphics g)
        {
            if (curva.CantidadPuntos < 2)
                return;

            using (Pen lapiz = new Pen(Color.Red, 2))
            {
                lapiz.DashStyle = DashStyle.Dash;
                
                for (int i = 0; i < curva.PuntosControl.Count - 1; i++)
                {
                    g.DrawLine(lapiz, curva.PuntosControl[i], curva.PuntosControl[i + 1]);
                }
            }
        }

        private void DibujarPuntosControl(Graphics g)
        {
            for (int i = 0; i < curva.PuntosControl.Count; i++)
            {
                PointF punto = curva.PuntosControl[i];
                
                using (Brush brocha = new SolidBrush(Color.Red))
                {
                    g.FillEllipse(brocha,
                        punto.X - RADIO_PUNTO,
                        punto.Y - RADIO_PUNTO,
                        RADIO_PUNTO * 2,
                        RADIO_PUNTO * 2);
                }
                
                using (Pen lapiz = new Pen(Color.White, 2))
                {
                    g.DrawEllipse(lapiz,
                        punto.X - RADIO_PUNTO,
                        punto.Y - RADIO_PUNTO,
                        RADIO_PUNTO * 2,
                        RADIO_PUNTO * 2);
                }
                
                using (Font fuente = new Font("Arial", 9, FontStyle.Bold))
                {
                    string etiqueta = $"P{i}";
                    SizeF tamaño = g.MeasureString(etiqueta, fuente);
                    g.DrawString(etiqueta, fuente, Brushes.Black,
                        punto.X - tamaño.Width / 2,
                        punto.Y - RADIO_PUNTO - tamaño.Height - 2);
                }
            }
        }

        private void DibujarPuntoAnimado(Graphics g)
        {
            try
            {
                double t = trkParametro.Value / 100.0;
                PointF puntoActual = curva.CalcularPunto(t);
                int radioGrande = RADIO_PUNTO + 4;
                
                using (Pen lapiz = new Pen(Color.Black, 3))
                {
                    g.DrawEllipse(lapiz,
                        puntoActual.X - radioGrande,
                        puntoActual.Y - radioGrande,
                        radioGrande * 2,
                        radioGrande * 2);
                }
                
                using (Brush brocha = new SolidBrush(Color.Yellow))
                {
                    g.FillEllipse(brocha,
                        puntoActual.X - RADIO_PUNTO,
                        puntoActual.Y - RADIO_PUNTO,
                        RADIO_PUNTO * 2,
                        RADIO_PUNTO * 2);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error dibujando punto: {ex.Message}");
            }
        }

        private void trkParametro_Scroll(object sender, EventArgs e)
        {
            ActualizarVisualizacion();
        }

        private void trkParametro_ValueChanged(object sender, EventArgs e)
        {
            ActualizarVisualizacion();
        }

        private void ActualizarVisualizacion()
        {
            try
            {
                double t = trkParametro.Value / 100.0;
                lblParametro.Text = $"Parámetro t: {t:F2}";
                
                if (curva.CantidadPuntos == MAX_PUNTOS)
                {
                    pctCanvasCurva.Refresh();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error actualizando: {ex.Message}");
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (curva.CantidadPuntos < MAX_PUNTOS)
                {
                    MessageBox.Show($"Debe colocar {MAX_PUNTOS} puntos primero.", 
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                animacionActiva = !animacionActiva;

                if (animacionActiva)
                {
                    btnPlay.Text = "? Pausa";
                    tmrAnimacion.Start();
                }
                else
                {
                    btnPlay.Text = "? Play";
                    tmrAnimacion.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            try
            {
                if (trkParametro.Value < trkParametro.Maximum)
                {
                    trkParametro.Value++;
                }
                else
                {
                    trkParametro.Value = 0;
                }
            }
            catch (Exception ex)
            {
                tmrAnimacion.Stop();
                animacionActiva = false;
                btnPlay.Text = "? Play";
                MessageBox.Show($"Error en animación: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (animacionActiva)
                {
                    tmrAnimacion.Stop();
                    animacionActiva = false;
                    btnPlay.Text = "? Play";
                }

                curva.LimpiarPuntos();
                trkParametro.Value = 0;
                lblParametro.Text = "Parámetro t: 0";
                btnPlay.Enabled = false;

                pctCanvasCurva.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reiniciar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
