using System;
using System.Collections.Generic;
using System.Drawing;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Algorithms
{
    /// <summary>
    /// Clase base abstracta para todos los algoritmos de relleno.
    /// Contiene lógica común de validación y métodos auxiliares reutilizables.
    /// </summary>
    public abstract class FillAlgorithm : IFillAlgorithm
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        /// <summary>
        /// Método plantilla que valida las entradas y ejecuta el algoritmo específico.
        /// </summary>
        public List<PixelPoint> Fill(Color[,] grid, PixelPoint startPoint, Color fillColor, Color boundaryColor)
        {
            // Validar entradas
            ValidateInputs(grid, startPoint, fillColor);

            // Ejecutar el algoritmo específico
            return FillImplementation(grid, startPoint, fillColor, boundaryColor);
        }

        /// <summary>
        /// Método abstracto que cada algoritmo concreto debe implementar.
        /// </summary>
        protected abstract List<PixelPoint> FillImplementation(Color[,] grid, PixelPoint startPoint, 
            Color fillColor, Color boundaryColor);

        /// <summary>
        /// Valida las entradas del algoritmo.
        /// </summary>
        protected virtual void ValidateInputs(Color[,] grid, PixelPoint startPoint, Color fillColor)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid), "La grilla no puede ser nula.");

            if (startPoint == null)
                throw new ArgumentNullException(nameof(startPoint), "El punto inicial no puede ser nulo.");

            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            if (startPoint.X < 0 || startPoint.X >= width || 
                startPoint.Y < 0 || startPoint.Y >= height)
            {
                throw new ArgumentException("El punto inicial está fuera de los límites de la grilla.");
            }
        }

        /// <summary>
        /// Verifica si un punto está dentro de los límites de la grilla.
        /// </summary>
        protected bool IsWithinBounds(int x, int y, int width, int height)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        /// <summary>
        /// Compara dos colores para determinar si son iguales.
        /// </summary>
        protected bool ColorsEqual(Color color1, Color color2)
        {
            return color1.R == color2.R && 
                   color1.G == color2.G && 
                   color1.B == color2.B && 
                   color1.A == color2.A;
        }

        /// <summary>
        /// Obtiene los vecinos de 4 direcciones (arriba, abajo, izquierda, derecha).
        /// </summary>
        protected List<PixelPoint> GetNeighbors4(PixelPoint point, int width, int height)
        {
            var neighbors = new List<PixelPoint>();

            // Derecha
            if (point.X + 1 < width)
                neighbors.Add(new PixelPoint(point.X + 1, point.Y));

            // Izquierda
            if (point.X - 1 >= 0)
                neighbors.Add(new PixelPoint(point.X - 1, point.Y));

            // Arriba
            if (point.Y + 1 < height)
                neighbors.Add(new PixelPoint(point.X, point.Y + 1));

            // Abajo
            if (point.Y - 1 >= 0)
                neighbors.Add(new PixelPoint(point.X, point.Y - 1));

            return neighbors;
        }

        /// <summary>
        /// Obtiene los vecinos de 8 direcciones (incluye diagonales).
        /// </summary>
        protected List<PixelPoint> GetNeighbors8(PixelPoint point, int width, int height)
        {
            var neighbors = GetNeighbors4(point, width, height);

            // Diagonal superior derecha
            if (point.X + 1 < width && point.Y + 1 < height)
                neighbors.Add(new PixelPoint(point.X + 1, point.Y + 1));

            // Diagonal superior izquierda
            if (point.X - 1 >= 0 && point.Y + 1 < height)
                neighbors.Add(new PixelPoint(point.X - 1, point.Y + 1));

            // Diagonal inferior derecha
            if (point.X + 1 < width && point.Y - 1 >= 0)
                neighbors.Add(new PixelPoint(point.X + 1, point.Y - 1));

            // Diagonal inferior izquierda
            if (point.X - 1 >= 0 && point.Y - 1 >= 0)
                neighbors.Add(new PixelPoint(point.X - 1, point.Y - 1));

            return neighbors;
        }
    }
}
