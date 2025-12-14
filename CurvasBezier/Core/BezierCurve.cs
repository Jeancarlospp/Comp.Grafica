using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CurvasBezier.Core
{
    /// <summary>
    /// Clase que implementa el algoritmo de De Casteljau para curvas de Bézier.
    /// No tiene dependencias de UI, solo lógica matemática pura.
    /// </summary>
    public class BezierCurve
    {
        private List<PointF> puntosControl;

        /// <summary>
        /// Constructor que inicializa la curva sin puntos de control.
        /// </summary>
        public BezierCurve()
        {
            puntosControl = new List<PointF>();
        }

        /// <summary>
        /// Constructor que inicializa la curva con puntos de control dados.
        /// </summary>
        /// <param name="puntos">Lista de puntos de control</param>
        public BezierCurve(List<PointF> puntos)
        {
            if (puntos == null)
                throw new ArgumentNullException(nameof(puntos));
            
            puntosControl = new List<PointF>(puntos);
        }

        /// <summary>
        /// Obtiene o establece los puntos de control de la curva.
        /// </summary>
        public List<PointF> PuntosControl
        {
            get { return puntosControl; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                puntosControl = value;
            }
        }

        /// <summary>
        /// Agrega un punto de control a la curva.
        /// </summary>
        /// <param name="punto">Punto a agregar</param>
        public void AgregarPunto(PointF punto)
        {
            puntosControl.Add(punto);
        }

        /// <summary>
        /// Limpia todos los puntos de control.
        /// </summary>
        public void LimpiarPuntos()
        {
            puntosControl.Clear();
        }

        /// <summary>
        /// Obtiene la cantidad de puntos de control.
        /// </summary>
        public int CantidadPuntos
        {
            get { return puntosControl.Count; }
        }

        /// <summary>
        /// Calcula un punto en la curva de Bézier usando el algoritmo de De Casteljau.
        /// </summary>
        /// <param name="t">Parámetro t en el rango [0,1]</param>
        /// <returns>Punto calculado en la curva</returns>
        public PointF CalcularPunto(double t)
        {
            if (puntosControl.Count == 0)
                throw new InvalidOperationException("No hay puntos de control definidos.");

            if (t < 0 || t > 1)
                throw new ArgumentOutOfRangeException(nameof(t), "El parámetro t debe estar en el rango [0,1].");

            return DeCasteljau(puntosControl, t);
        }

        /// <summary>
        /// Implementación recursiva del algoritmo de De Casteljau.
        /// </summary>
        /// <param name="puntos">Lista de puntos a interpolar</param>
        /// <param name="t">Parámetro t en el rango [0,1]</param>
        /// <returns>Punto interpolado</returns>
        private PointF DeCasteljau(List<PointF> puntos, double t)
        {
            if (puntos.Count == 1)
                return puntos[0];

            List<PointF> nuevosPuntos = new List<PointF>();

            for (int i = 0; i < puntos.Count - 1; i++)
            {
                PointF puntoIntermedio = InterpolacionLineal(puntos[i], puntos[i + 1], t);
                nuevosPuntos.Add(puntoIntermedio);
            }

            return DeCasteljau(nuevosPuntos, t);
        }

        /// <summary>
        /// Calcula la interpolación lineal entre dos puntos.
        /// Fórmula: P = (1 - t) * P0 + t * P1
        /// </summary>
        /// <param name="p0">Punto inicial</param>
        /// <param name="p1">Punto final</param>
        /// <param name="t">Parámetro t en el rango [0,1]</param>
        /// <returns>Punto interpolado</returns>
        private PointF InterpolacionLineal(PointF p0, PointF p1, double t)
        {
            float x = (float)((1 - t) * p0.X + t * p1.X);
            float y = (float)((1 - t) * p0.Y + t * p1.Y);
            return new PointF(x, y);
        }

        /// <summary>
        /// Calcula todos los puntos intermedios del algoritmo de De Casteljau para un valor de t.
        /// Útil para visualizar la animación del algoritmo.
        /// </summary>
        /// <param name="t">Parámetro t en el rango [0,1]</param>
        /// <returns>Lista de listas de puntos intermedios por nivel</returns>
        public List<List<PointF>> CalcularPuntosIntermedios(double t)
        {
            if (puntosControl.Count == 0)
                throw new InvalidOperationException("No hay puntos de control definidos.");

            if (t < 0 || t > 1)
                throw new ArgumentOutOfRangeException(nameof(t), "El parámetro t debe estar en el rango [0,1].");

            List<List<PointF>> todosLosPuntos = new List<List<PointF>>();
            todosLosPuntos.Add(new List<PointF>(puntosControl));

            List<PointF> puntosActuales = new List<PointF>(puntosControl);

            while (puntosActuales.Count > 1)
            {
                List<PointF> nuevosPuntos = new List<PointF>();

                for (int i = 0; i < puntosActuales.Count - 1; i++)
                {
                    PointF puntoIntermedio = InterpolacionLineal(puntosActuales[i], puntosActuales[i + 1], t);
                    nuevosPuntos.Add(puntoIntermedio);
                }

                todosLosPuntos.Add(new List<PointF>(nuevosPuntos));
                puntosActuales = nuevosPuntos;
            }

            return todosLosPuntos;
        }

        /// <summary>
        /// Genera una lista de puntos que forman la curva completa.
        /// </summary>
        /// <param name="numPuntos">Cantidad de puntos a generar</param>
        /// <returns>Lista de puntos que forman la curva</returns>
        public List<PointF> GenerarCurva(int numPuntos = 100)
        {
            if (puntosControl.Count == 0)
                throw new InvalidOperationException("No hay puntos de control definidos.");

            if (numPuntos < 2)
                throw new ArgumentException("Se requieren al menos 2 puntos.", nameof(numPuntos));

            List<PointF> puntosCurva = new List<PointF>();

            for (int i = 0; i <= numPuntos; i++)
            {
                double t = i / (double)numPuntos;
                puntosCurva.Add(CalcularPunto(t));
            }

            return puntosCurva;
        }
    }
}
