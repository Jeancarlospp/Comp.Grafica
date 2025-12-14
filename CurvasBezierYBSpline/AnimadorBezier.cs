using System;
using System.Windows.Forms;

namespace CurvasBezierYBSpline.Utilidades
{
    public class AnimadorBezier
    {
        private Timer timer;
        private float parametroT;
        private float velocidad;
        private bool animando;

        public event EventHandler<float> CambioParametro;

        public AnimadorBezier(float velocidadInicial = 0.01f)
        {
            velocidad = velocidadInicial;
            parametroT = 0f;
            animando = false;

            timer = new Timer();
            timer.Interval = 16; // ~60 FPS
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            parametroT += velocidad;

            if (parametroT >= 1f)
            {
                parametroT = 1f;
                Pausar();
            }

            CambioParametro?.Invoke(this, parametroT);
        }

        public void Iniciar()
        {
            if (!animando)
            {
                animando = true;
                timer.Start();
            }
        }

        public void Pausar()
        {
            animando = false;
            timer.Stop();
        }

        public void Reiniciar()
        {
            Pausar();
            parametroT = 0f;
            CambioParametro?.Invoke(this, parametroT);
        }

        public void EstablecerParametro(float t)
        {
            parametroT = Math.Max(0f, Math.Min(1f, t));
            CambioParametro?.Invoke(this, parametroT);
        }

        public float ObtenerParametro() => parametroT;

        public bool EstaAnimando() => animando;

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
