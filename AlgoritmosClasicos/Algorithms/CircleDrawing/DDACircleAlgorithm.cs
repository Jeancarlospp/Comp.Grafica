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

            // Calcular el número de pasos basado en la circunferencia
            // Usamos aproximadamente un punto por píxel de la circunferencia
            double circumference = 2.0 * Math.PI * radius;
            int steps = (int)Math.Ceiling(circumference);

            // Asegurar al menos 8 pasos para círculos muy pequeños
            if (steps < 8)
                steps = 8;

            // Calcular el incremento angular
            double angleIncrement = (2.0 * Math.PI) / steps;

            // Ángulo actual
            double angle = 0.0;

            // Generar puntos alrededor del círculo
            for (int i = 0; i < steps; i++)
            {
                // Calcular coordenadas usando ecuaciones paramétricas
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);

                // Convertir a coordenadas enteras y agregar al centro
                int pixelX = center.X + (int)Math.Round(x);
                int pixelY = center.Y + (int)Math.Round(y);

                // Agregar el punto
                var point = new PixelPoint(pixelX, pixelY);
                
                // Evitar duplicados consecutivos
                if (points.Count == 0 || !points[points.Count - 1].Equals(point))
                {
                    points.Add(point);
                }

                // Incrementar el ángulo
                angle += angleIncrement;
            }

            // Asegurar que el círculo se cierre agregando el primer punto al final si es necesario
            if (points.Count > 0 && !points[points.Count - 1].Equals(points[0]))
            {
                points.Add(points[0]);
            }

            return points;
        }
    }
}
