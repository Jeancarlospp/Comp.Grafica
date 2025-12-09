using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Algorithms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Algorithms.LineDrawing
{
    /// <summary>
    /// Implementación del algoritmo DDA (Digital Differential Analyzer) para trazado de líneas.
    /// 
    /// FUNCIONAMIENTO:
    /// - Calcula incrementos en X e Y basándose en la pendiente de la línea.
    /// - Utiliza aritmética de punto flotante para calcular las posiciones.
    /// - Redondea los valores flotantes a las coordenadas enteras más cercanas.
    /// - Es simple pero puede ser menos eficiente que Bresenham debido al uso de flotantes.
    /// </summary>
    public class DDAAlgorithm : LineDrawingAlgorithm
    {
        public override string Name => "DDA (Digital Differential Analyzer)";

        public override string Description => 
            "Algoritmo que utiliza incrementos diferenciales y aritmética de punto flotante " +
            "para calcular los píxeles de una línea. Incrementa en pasos unitarios sobre el eje " +
            "con mayor diferencia de coordenadas.";

        protected override List<PixelPoint> CalculateLineImplementation(PixelPoint start, PixelPoint end)
        {
            var points = new List<PixelPoint>();

            // Calcular diferencias
            int dx = end.X - start.X;
            int dy = end.Y - start.Y;

            // Determinar el número de pasos (el mayor entre dx y dy)
            int steps = Math.Max(Abs(dx), Abs(dy));

            // Calcular incrementos
            float xIncrement = (float)dx / steps;
            float yIncrement = (float)dy / steps;

            // Inicializar coordenadas flotantes
            float x = start.X;
            float y = start.Y;

            // Agregar el punto inicial
            points.Add(new PixelPoint((int)Math.Round(x), (int)Math.Round(y)));

            // Iterar y calcular cada punto
            for (int i = 1; i <= steps; i++)
            {
                x += xIncrement;
                y += yIncrement;

                // Redondear y agregar el punto
                points.Add(new PixelPoint((int)Math.Round(x), (int)Math.Round(y)));
            }

            return points;
        }
    }
}
