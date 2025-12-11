using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.CircleDrawing
{
    /// <summary>
    /// Implementación del algoritmo DDA (Digital Differential Analyzer) adaptado para círculos.
    /// 
    /// FUNCIONAMIENTO:
    /// - Utiliza la ecuación paramétrica del círculo: x = r*cos(?), y = r*sin(?)
    /// - Incrementa el ángulo ? en pequeños pasos.
    /// - Usa aritmética de punto flotante para calcular las coordenadas.
    /// - Redondea los valores a coordenadas enteras.
    /// - Menos eficiente que Bresenham debido al uso de funciones trigonométricas.
    /// - Genera puntos de forma secuencial alrededor del círculo.
    /// </summary>
    public class DDACircleAlgorithm : CircleDrawingAlgorithm
    {
        public override string Name => "DDA para Círculos (Paramétrico)";

        public override string Description =>
            "Algoritmo basado en la ecuación paramétrica del círculo. Usa funciones trigonométricas " +
            "(seno y coseno) e incrementa el ángulo en pequeños pasos. Genera puntos secuencialmente " +
            "alrededor del círculo usando aritmética de punto flotante.";

        protected override List<PixelPoint> CalculateCircleImplementation(PixelPoint center, int radius)
        {
            var points = new List<PixelPoint>();

            double circumference = 2.0 * Math.PI * radius;
            int steps = (int)Math.Ceiling(circumference);

            if (steps < 8)
                steps = 8;

            double angleIncrement = (2.0 * Math.PI) / steps;


            double angle = 0.0;

            for (int i = 0; i < steps; i++)
            {
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                int pixelX = center.X + (int)Math.Round(x);
                int pixelY = center.Y + (int)Math.Round(y);

                var point = new PixelPoint(pixelX, pixelY);

                if (points.Count == 0 || !points[points.Count - 1].Equals(point))
                {
                    points.Add(point);
                }


                angle += angleIncrement;
            }

            if (points.Count > 0 && !points[points.Count - 1].Equals(points[0]))
            {
                points.Add(points[0]);
            }

            return points;
        }
    }
}
