using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CurvasBezier.Core;

namespace CurvasBezier.Forms
{
    /// <summary>
    /// Formulario para visualizar curvas de Bézier cuadráticas con 3 puntos de control.
    /// Implementa el algoritmo de De Casteljau con visualización de líneas auxiliares.
    /// </summary>
    public partial class frmBezier3Puntos : Form
    {
        private BezierCurve curva;
        private const int MAX_PUNTOS = 3;
        private const int RADIO_PUNTO = 6;
        private bool animacionActiva;
        private bool mostrarLineasAuxiliares;

        public frmBezier3Puntos()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        /// <summary>
        /// Inicializa los componentes y variables del formulario.
        /// </summary>
        private void InicializarComponentes()
        {
            try
            {
                curva = new BezierCurve();
                animacionActiva = false;
                mostrarLineasAuxiliares = true;
                
                // Configurar PictureBox para doble buffer (evitar parpadeo)
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

        /// <summary>
        /// Maneja el evento de click en el canvas para colocar puntos de control.
        /// </summary>
        private void pctCanvasCurva_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left)
                    return;

                if (curva.CantidadPuntos >= MAX_PUNTOS)
                {
                    MessageBox.Show($"Ya hay {MAX_PUNTOS} puntos. Use Reiniciar para comenzar de nuevo.", 
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
                MessageBox.Show($"Error al colocar punto: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de pintado del canvas.
        /// </summary>
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

                // Dibujar la curva completa (línea verde) si tenemos todos los puntos
                if (curva.CantidadPuntos == MAX_PUNTOS)
                {
                    DibujarCurva(g);
                    
                    // Dibujar líneas auxiliares del algoritmo De Casteljau
                    if (mostrarLineasAuxiliares)
                    {
                        DibujarLineasAuxiliares(g);
                    }
                }

                // Dibujar líneas poligonales entre puntos de control
                DibujarLineasPoligonales(g);

                // Dibujar puntos de control
                DibujarPuntosControl(g);

                // Dibujar punto animado si tenemos todos los puntos
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

        /// <summary>
        /// Dibuja las instrucciones iniciales en el canvas.
        /// </summary>
        private void DibujarInstrucciones(Graphics g)
        {
            string texto = "Haga click en el canvas para colocar los puntos de control\n" +
                          $"Puntos restantes: {MAX_PUNTOS - curva.CantidadPuntos}\n\n" +
                          "Con 3 puntos podrá visualizar una curva cuadrática de Bézier";
            
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

        /// <summary>
        /// Dibuja la curva de Bézier completa.
        /// </summary>
        private void DibujarCurva(Graphics g)
        {
            List<PointF> puntosCurva = curva.GenerarCurva(100);
            
            using (Pen lapiz = new Pen(Color.Green, 3))
            {
                for (int i = 0; i < puntosCurva.Count - 1; i++)
                {
                    g.DrawLine(lapiz, puntosCurva[i], puntosCurva[i + 1]);
                }
            }
        }

        /// <summary>
        /// Dibuja las líneas poligonales entre los puntos de control.
        /// </summary>
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

        /// <summary>
        /// Dibuja las líneas auxiliares del algoritmo de De Casteljau.
        /// Para 3 puntos: P0, P1, P2 -> Q0, Q1 -> R0
        /// </summary>
        private void DibujarLineasAuxiliares(Graphics g)
        {
            try
            {
                double t = trkParametro.Value / 100.0;
                List<List<PointF>> puntosIntermedios = curva.CalcularPuntosIntermedios(t);

                // puntosIntermedios[0] = [P0, P1, P2] (puntos de control originales)
                // puntosIntermedios[1] = [Q0, Q1] (primera interpolación)
                // puntosIntermedios[2] = [R0] (punto final en la curva)

                if (puntosIntermedios.Count >= 2)
                {
                    // Dibujar primera interpolación: P0->Q0->P1, P1->Q1->P2
                    List<PointF> primeraInterpolacion = puntosIntermedios[1];
                    
                    using (Pen lapizAzul = new Pen(Color.Blue, 2))
                    {
                        lapizAzul.DashStyle = DashStyle.Dot;
                        
                        // Línea de P0 a P1 pasando por Q0
                        if (primeraInterpolacion.Count >= 1)
                        {
                            g.DrawLine(lapizAzul, curva.PuntosControl[0], primeraInterpolacion[0]);
                            g.DrawLine(lapizAzul, primeraInterpolacion[0], curva.PuntosControl[1]);
                        }
                        
                        // Línea de P1 a P2 pasando por Q1
                        if (primeraInterpolacion.Count >= 2)
                        {
                            g.DrawLine(lapizAzul, curva.PuntosControl[1], primeraInterpolacion[1]);
                            g.DrawLine(lapizAzul, primeraInterpolacion[1], curva.PuntosControl[2]);
                        }
                    }
                    
                    // Dibujar puntos Q0 y Q1
                    using (Brush brochaAzul = new SolidBrush(Color.Blue))
                    {
                        for (int i = 0; i < primeraInterpolacion.Count; i++)
                        {
                            PointF punto = primeraInterpolacion[i];
                            g.FillEllipse(brochaAzul,
                                punto.X - 4,
                                punto.Y - 4,
                                8, 8);
                            
                            // Etiqueta del punto
                            using (Font fuente = new Font("Arial", 8, FontStyle.Bold))
                            {
                                g.DrawString($"Q{i}", fuente, Brushes.Blue,
                                    punto.X + 8, punto.Y - 15);
                            }
                        }
                    }
                }

                if (puntosIntermedios.Count >= 3)
                {
                    // Dibujar segunda interpolación: línea entre Q0 y Q1
                    List<PointF> primeraInterpolacion = puntosIntermedios[1];
                    
                    if (primeraInterpolacion.Count >= 2)
                    {
                        using (Pen lapizMagenta = new Pen(Color.Magenta, 2))
                        {
                            lapizMagenta.DashStyle = DashStyle.Dot;
                            g.DrawLine(lapizMagenta, primeraInterpolacion[0], primeraInterpolacion[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error dibujando líneas auxiliares: {ex.Message}");
            }
        }

        /// <summary>
        /// Dibuja los puntos de control.
        /// </summary>
        private void DibujarPuntosControl(Graphics g)
        {
            for (int i = 0; i < curva.PuntosControl.Count; i++)
            {
                PointF punto = curva.PuntosControl[i];
                
                // Círculo relleno rojo
                using (Brush brocha = new SolidBrush(Color.Red))
                {
                    g.FillEllipse(brocha,
                        punto.X - RADIO_PUNTO,
                        punto.Y - RADIO_PUNTO,
                        RADIO_PUNTO * 2,
                        RADIO_PUNTO * 2);
                }
                
                // Borde blanco
                using (Pen lapiz = new Pen(Color.White, 2))
                {
                    g.DrawEllipse(lapiz,
                        punto.X - RADIO_PUNTO,
                        punto.Y - RADIO_PUNTO,
                        RADIO_PUNTO * 2,
                        RADIO_PUNTO * 2);
                }
                
                // Etiqueta del punto
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

        /// <summary>
        /// Dibuja el punto animado sobre la curva.
        /// </summary>
        private void DibujarPuntoAnimado(Graphics g)
        {
            try
            {
                double t = trkParametro.Value / 100.0;
                PointF puntoActual = curva.CalcularPunto(t);
                int radioGrande = RADIO_PUNTO + 4;
                
                // Círculo exterior negro
                using (Pen lapiz = new Pen(Color.Black, 3))
                {
                    g.DrawEllipse(lapiz,
                        puntoActual.X - radioGrande,
                        puntoActual.Y - radioGrande,
                        radioGrande * 2,
                        radioGrande * 2);
                }
                
                // Círculo interior amarillo
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
                System.Diagnostics.Debug.WriteLine($"Error dibujando punto animado: {ex.Message}");
            }
        }

        /// <summary>
        /// Maneja el cambio del TrackBar (evento Scroll).
        /// </summary>
        private void trkParametro_Scroll(object sender, EventArgs e)
        {
            ActualizarVisualizacion();
        }

        /// <summary>
        /// Maneja el cambio de valor del TrackBar (evento ValueChanged).
        /// </summary>
        private void trkParametro_ValueChanged(object sender, EventArgs e)
        {
            ActualizarVisualizacion();
        }

        /// <summary>
        /// Actualiza la visualización de la curva y el parámetro t.
        /// </summary>
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

        /// <summary>
        /// Maneja el cambio del CheckBox de líneas auxiliares.
        /// </summary>
        private void chkMostrarLineasAuxiliares_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                mostrarLineasAuxiliares = chkMostrarLineasAuxiliares.Checked;
                
                if (curva.CantidadPuntos == MAX_PUNTOS)
                {
                    pctCanvasCurva.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el click del botón Play/Pause.
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (curva.CantidadPuntos < MAX_PUNTOS)
                {
                    MessageBox.Show($"Debe colocar {MAX_PUNTOS} puntos de control primero.", 
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

        /// <summary>
        /// Maneja el evento Tick del Timer de animación.
        /// </summary>
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
                    // Reiniciar el ciclo
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

        /// <summary>
        /// Maneja el click del botón Reiniciar.
        /// </summary>
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                // Detener animación si está activa
                if (animacionActiva)
                {
                    tmrAnimacion.Stop();
                    animacionActiva = false;
                    btnPlay.Text = "? Play";
                }

                // Reiniciar valores
                curva.LimpiarPuntos();
                trkParametro.Value = 0;
                lblParametro.Text = "Parámetro t: 0";
                btnPlay.Enabled = false;

                // Redibujar
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
