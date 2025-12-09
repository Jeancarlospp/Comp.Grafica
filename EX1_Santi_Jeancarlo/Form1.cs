using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX1_Santi_Jeancarlo
{
    public partial class Form1 : Form
    {
        private const float GRAVEDAD = 9.8f; // GRavedad
        private const float ESCALA = 2.5f;    // Pixeles por metro
        
        // Base de lanzamiento
        private PointF baseLanzamiento;
        private const int BASE_WIDTH = 60;
        private const int BASE_HEIGHT = 40;
        
        // Objetivo
        private PointF posicionObjetivo;
        private const int OBJETIVO_WIDTH = 50;
        private const int OBJETIVO_HEIGHT = 80;
        private bool moviendoObjetivo = false;
        
        // Misil
        private PointF posicionMisil;
        private const int MISIL_WIDTH = 15;
        private const int MISIL_HEIGHT = 30;
        private float anguloMisil = 0; // Angulo actual del misil en radianes
        
      
        private float velocidadInicial; // 
        private float anguloLanzamiento; // grados
        private float tiempo = 0; // tiempo en segundos
        private float velocidadX; // 
        private float velocidadY; // 
        
        private bool misilEnVuelo = false;
        private List<PointF> trayectoria; 
        
        private float nivelSuelo;

        public Form1()
        {
            InitializeComponent();
            
            this.pictureBoxCanvas.DoubleBuffered(true);
            
            InicializarSimulacion();
        }

        //Inicializo posiciones en todos los elementos

        private void InicializarSimulacion()
        {
            nivelSuelo = pictureBoxCanvas.Height - 50;
            
            // Base de lanzamiento 
            baseLanzamiento = new PointF(80, nivelSuelo - BASE_HEIGHT);
            
            // Objetivo 
            posicionObjetivo = new PointF(
                pictureBoxCanvas.Width - 150, 
                nivelSuelo - OBJETIVO_HEIGHT
            );
            
            trayectoria = new List<PointF>();
            
            // Posición inicial del misil
            ReiniciarMisil();
        }

        //Reinicia el misil a su posición inicial en la base
        private void ReiniciarMisil()
        {
            posicionMisil = new PointF(
                baseLanzamiento.X + BASE_WIDTH / 2,
                baseLanzamiento.Y - 10
            );
            tiempo = 0;
            trayectoria.Clear();
            misilEnVuelo = false;
        }

        //Dibujo de la escena

        private void pictureBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DibujarSuelo(g);
            
            DibujarBase(g);
            
            DibujarObjetivo(g);
            
            DibujarTrayectoria(g);
            
            DibujarMisil(g);
            
            if (!misilEnVuelo)
            {
                DibujarLineaPunteria(g);
            }
        }

        // Dibuja el suelo con textura de césped
        private void DibujarSuelo(Graphics g)
        {
            using (Brush brushSuelo = new SolidBrush(Color.FromArgb(101, 67, 33)))
            {
                g.FillRectangle(brushSuelo, 0, nivelSuelo, pictureBoxCanvas.Width, pictureBoxCanvas.Height - nivelSuelo);
            }
            
            using (Brush brushCesped = new SolidBrush(Color.FromArgb(34, 139, 34)))
            {
                g.FillRectangle(brushCesped, 0, nivelSuelo, pictureBoxCanvas.Width, 10);
            }
            //Cesped
            using (Pen penCesped = new Pen(Color.FromArgb(50, 205, 50), 2))
            {
                for (int i = 0; i < pictureBoxCanvas.Width; i += 20)
                {
                    g.DrawLine(penCesped, i, nivelSuelo, i + 10, nivelSuelo + 5);
                }
            }
        }


        // Dibujo la base de lanzamiento

        private void DibujarBase(Graphics g)
        {
            // Plataforma base
            using (Brush brushBase = new LinearGradientBrush(
                new Rectangle((int)baseLanzamiento.X, (int)baseLanzamiento.Y, BASE_WIDTH, BASE_HEIGHT),
                Color.DarkGray, Color.Gray, 90f))
            {
                g.FillRectangle(brushBase, baseLanzamiento.X, baseLanzamiento.Y, BASE_WIDTH, BASE_HEIGHT);
            }
            
            // Borde de la base
            using (Pen penBorde = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(penBorde, baseLanzamiento.X, baseLanzamiento.Y, BASE_WIDTH, BASE_HEIGHT);
            }
            
            using (Pen penDetalle = new Pen(Color.Yellow, 2))
            {
                g.DrawLine(penDetalle, 
                    baseLanzamiento.X + 5, baseLanzamiento.Y + BASE_HEIGHT / 2,
                    baseLanzamiento.X + BASE_WIDTH - 5, baseLanzamiento.Y + BASE_HEIGHT / 2);
            }
            

            using (Font font = new Font("Arial", 8, FontStyle.Bold))
            using (Brush brushTexto = new SolidBrush(Color.Black))
            {
                g.DrawString("BASE DE JEANSITO", font, brushTexto, baseLanzamiento.X + 10, baseLanzamiento.Y + 12);
            }
        }


        //Dibujo el edifico

        private void DibujarObjetivo(Graphics g)
        {
            // Edificio principal
            using (Brush brushEdificio = new LinearGradientBrush(
                new Rectangle((int)posicionObjetivo.X, (int)posicionObjetivo.Y, OBJETIVO_WIDTH, OBJETIVO_HEIGHT),
                Color.DarkRed, Color.Red, 90f))
            {
                g.FillRectangle(brushEdificio, posicionObjetivo.X, posicionObjetivo.Y, OBJETIVO_WIDTH, OBJETIVO_HEIGHT);
            }
            
            // Ventanas 
            using (Brush brushVentana = new SolidBrush(Color.Yellow))
            {
                for (int fila = 0; fila < 4; fila++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        float ventanaX = posicionObjetivo.X + 10 + (col * 20);
                        float ventanaY = posicionObjetivo.Y + 10 + (fila * 18);
                        g.FillRectangle(brushVentana, ventanaX, ventanaY, 10, 12);
                    }
                }
            }
            
            // Borde del edificio
            using (Pen penBorde = new Pen(Color.DarkRed, 2))
            {
                g.DrawRectangle(penBorde, posicionObjetivo.X, posicionObjetivo.Y, OBJETIVO_WIDTH, OBJETIVO_HEIGHT);
            }
            
            // Antena 
            using (Pen penAntena = new Pen(Color.Gray, 2))
            {
                float centroX = posicionObjetivo.X + OBJETIVO_WIDTH / 2;
                g.DrawLine(penAntena, centroX, posicionObjetivo.Y, centroX, posicionObjetivo.Y - 15);
                g.FillEllipse(Brushes.Red, centroX - 3, posicionObjetivo.Y - 18, 6, 6);
            }
            
            // Indicador si está siendo movido
            if (moviendoObjetivo)
            {
                using (Pen penIndicador = new Pen(Color.Yellow, 2))
                {
                    penIndicador.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(penIndicador, 
                        posicionObjetivo.X - 5, posicionObjetivo.Y - 5, 
                        OBJETIVO_WIDTH + 10, OBJETIVO_HEIGHT + 10);
                }
            }
        }


        // Dibujo el Misil

        private void DibujarMisil(Graphics g)
        {
            GraphicsState state = g.Save();
            
            //Mover y Rotar el Misil
            g.TranslateTransform(posicionMisil.X, posicionMisil.Y);
            g.RotateTransform((float)(anguloMisil * 180 / Math.PI));
            
            // Cuerpo del misil
            using (Brush brushCuerpo = new LinearGradientBrush(
                new Rectangle(-MISIL_WIDTH / 2, -MISIL_HEIGHT / 2, MISIL_WIDTH, MISIL_HEIGHT),
                Color.DarkGray, Color.LightGray, 0f))
            {
                g.FillRectangle(brushCuerpo, -MISIL_WIDTH / 2, -MISIL_HEIGHT / 2, MISIL_WIDTH, MISIL_HEIGHT);
            }
            
            // triangulo que sera la punta del misil
            Point[] punta = new Point[]
            {
                new Point(0, -MISIL_HEIGHT / 2 - 10),
                new Point(-MISIL_WIDTH / 2, -MISIL_HEIGHT / 2),
                new Point(MISIL_WIDTH / 2, -MISIL_HEIGHT / 2)
            };
            g.FillPolygon(Brushes.Red, punta);
            
            // Aletas del misil
            Point[] aletaIzq = new Point[]
            {
                new Point(-MISIL_WIDTH / 2, MISIL_HEIGHT / 2),
                new Point(-MISIL_WIDTH / 2 - 5, MISIL_HEIGHT / 2 + 8),
                new Point(-MISIL_WIDTH / 2, MISIL_HEIGHT / 2 + 8)
            };
            g.FillPolygon(Brushes.DarkRed, aletaIzq);
            
            Point[] aletaDer = new Point[]
            {
                new Point(MISIL_WIDTH / 2, MISIL_HEIGHT / 2),
                new Point(MISIL_WIDTH / 2 + 5, MISIL_HEIGHT / 2 + 8),
                new Point(MISIL_WIDTH / 2, MISIL_HEIGHT / 2 + 8)
            };
            g.FillPolygon(Brushes.DarkRed, aletaDer);
            
            // propulsion del misil
            if (misilEnVuelo)
            {
                using (Brush brushLlama1 = new SolidBrush(Color.FromArgb(200, 255, 165, 0)))
                using (Brush brushLlama2 = new SolidBrush(Color.FromArgb(200, 255, 69, 0)))
                {
                    Point[] llama = new Point[]
                    {
                        new Point(-4, MISIL_HEIGHT / 2 + 8),
                        new Point(4, MISIL_HEIGHT / 2 + 8),
                        new Point(0, MISIL_HEIGHT / 2 + 18)
                    };
                    g.FillPolygon(brushLlama1, llama);
                    
                    Point[] llamaPeq = new Point[]
                    {
                        new Point(-2, MISIL_HEIGHT / 2 + 10),
                        new Point(2, MISIL_HEIGHT / 2 + 10),
                        new Point(0, MISIL_HEIGHT / 2 + 22)
                    };
                    g.FillPolygon(brushLlama2, llamaPeq);
                }
            }
            
            g.Restore(state);
        }


        //Trayectoria del misil

        private void DibujarTrayectoria(Graphics g)
        {
            if (trayectoria.Count > 1)
            {
                using (Pen penTrayectoria = new Pen(Color.White, 2))
                {
                    penTrayectoria.DashStyle = DashStyle.Dot;
                    g.DrawLines(penTrayectoria, trayectoria.ToArray());
                }
                
                // Dibujar puntos en la trayectoria
                using (Brush brushPunto = new SolidBrush(Color.Yellow))
                {
                    for (int i = 0; i < trayectoria.Count; i += 3)
                    {
                        g.FillEllipse(brushPunto, 
                            trayectoria[i].X - 2, trayectoria[i].Y - 2, 4, 4);
                    }
                }
            }
        }

        // Linea punteada desde la direccion

        private void DibujarLineaPunteria(Graphics g)
        {
            float anguloRad = (float)(anguloLanzamiento * Math.PI / 180);
            float longitud = 100;
            
            PointF puntoInicio = new PointF(
                baseLanzamiento.X + BASE_WIDTH / 2,
                baseLanzamiento.Y
            );
            
            PointF puntoFin = new PointF(
                puntoInicio.X + longitud * (float)Math.Cos(anguloRad),
                puntoInicio.Y - longitud * (float)Math.Sin(anguloRad)
            );
            
            using (Pen penPunteria = new Pen(Color.Lime, 2))
            {
                penPunteria.DashStyle = DashStyle.Dash;
                g.DrawLine(penPunteria, puntoInicio, puntoFin);
            }
            
            // Dibujar flecha en la punta
            g.FillEllipse(Brushes.Lime, puntoFin.X - 4, puntoFin.Y - 4, 8, 8);
        }


        //Timer para la fisica del movimiento

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!misilEnVuelo) return;
            
            // Incrementar tiempo
            tiempo += 0.02f;
            
            // Ecuaciones del movimiento parabolico usadas
            // x(t) = x0 + v0x * t
            // y(t) = y0 + v0y * t - (1/2) * g * t²
            
            float puntoInicioX = baseLanzamiento.X + BASE_WIDTH / 2;
            float puntoInicioY = baseLanzamiento.Y - 10;
            
            // Posición en metros 
            float desplazamientoX = velocidadX * tiempo;
            float desplazamientoY = velocidadY * tiempo - 0.5f * GRAVEDAD * tiempo * tiempo;
            
    
            posicionMisil.X = puntoInicioX + desplazamientoX * ESCALA;
            posicionMisil.Y = puntoInicioY - desplazamientoY * ESCALA; 
            
            float velocidadActualX = velocidadX;
            float velocidadActualY = velocidadY - GRAVEDAD * tiempo;
            anguloMisil = (float)Math.Atan2(-velocidadActualY, velocidadActualX);
            
            trayectoria.Add(new PointF(posicionMisil.X, posicionMisil.Y));
            
            if (VerificarColision())
            {
                timer.Stop();
                misilEnVuelo = false;
                labelEstado.Text = "¡YEIII LE PEGASTE! ";
                labelEstado.ForeColor = Color.Black;
                MessageBox.Show("¡FELICITACIONES LO DESTRUISTE!\n\nMuy buena puunteria bro.", 
                    "Victoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Verificar si el misil tocó el suelo
            if (posicionMisil.Y >= nivelSuelo)
            {
                timer.Stop();
                misilEnVuelo = false;
                posicionMisil.Y = nivelSuelo;
                labelEstado.Text = ":((( No le pegaste";
                labelEstado.ForeColor = Color.Black;
                MessageBox.Show(" JAJAJAJJAJAFALLASTEEEE.\n\nIntenta ajustar el ángulo y la velocidad.", 
                    "Misión Fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Verificar si salió de la pantalla
            if (posicionMisil.X > pictureBoxCanvas.Width || posicionMisil.X < 0)
            {
                timer.Stop();
                misilEnVuelo = false;
                labelEstado.Text = "Misil fuera de alcance ";
                labelEstado.ForeColor = Color.Black;
                MessageBox.Show("Te saliste del mapaaaaaaa.\n\nIntenta con menos velocidad o diferente ángulo.", 
                    "Fuera de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Redibujar
            pictureBoxCanvas.Invalidate();
        }


        //Verifica si el misil colisionó con el objetivo

        private bool VerificarColision()
        {
            RectangleF rectMisil = new RectangleF(
                posicionMisil.X - MISIL_WIDTH / 2,
                posicionMisil.Y - MISIL_HEIGHT / 2,
                MISIL_WIDTH,
                MISIL_HEIGHT
            );
            
            RectangleF rectObjetivo = new RectangleF(
                posicionObjetivo.X,
                posicionObjetivo.Y,
                OBJETIVO_WIDTH,
                OBJETIVO_HEIGHT
            );
            
            return rectMisil.IntersectsWith(rectObjetivo);
        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            if (misilEnVuelo) return;

            anguloLanzamiento = (float)numericAngulo.Value;
            velocidadInicial = (float)numericVelocidad.Value;
            
            float anguloRad = (float)(anguloLanzamiento * Math.PI / 180);
            velocidadX = velocidadInicial * (float)Math.Cos(anguloRad);
            velocidadY = velocidadInicial * (float)Math.Sin(anguloRad);
            
            // Iniciar simulación
            ReiniciarMisil();
            misilEnVuelo = true;
            anguloMisil = anguloRad;
            
            labelEstado.Text = "Misil en vuelo... ";
            labelEstado.ForeColor = Color.Black;
            
            timer.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            ReiniciarMisil();
            trayectoria.Clear();
            labelEstado.Text = "Listo...";
            labelEstado.ForeColor = Color.Black;
            pictureBoxCanvas.Invalidate();
        }

        private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!misilEnVuelo)
            {
                // Verificar si el mouse está sobre el objetivo
                RectangleF rectObjetivo = new RectangleF(
                    posicionObjetivo.X,
                    posicionObjetivo.Y,
                    OBJETIVO_WIDTH,
                    OBJETIVO_HEIGHT
                );
                
                moviendoObjetivo = rectObjetivo.Contains(e.Location);
                pictureBoxCanvas.Invalidate();
            }
        }

        //Mover el objetivo
        private void pictureBoxCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (misilEnVuelo) return;
            
            // Verificar que el objetivo no este ni muy cerca ni muy lejos del objetivo
            if (e.X > baseLanzamiento.X + 200 && 
                e.X < pictureBoxCanvas.Width - OBJETIVO_WIDTH &&
                e.Y < nivelSuelo - OBJETIVO_HEIGHT)
            {
                posicionObjetivo = new PointF(e.X - OBJETIVO_WIDTH / 2, nivelSuelo - OBJETIVO_HEIGHT);
                pictureBoxCanvas.Invalidate();
                labelEstado.Text = "Objetivo reposicionado ✓";
                labelEstado.ForeColor = Color.Black;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 244);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }


    //Hailitar Controles

    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", 
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            doubleBufferPropertyInfo?.SetValue(control, enable, null);
        }
    }
}
