using System;

namespace AlgoritmosClasicos.Core.Models
{
    /// <summary>
    /// Representa un punto en coordenadas de píxeles en el canvas.
    /// Esta clase es inmutable y se utiliza en todos los algoritmos gráficos.
    /// </summary>
    public class PixelPoint : IEquatable<PixelPoint>
    {
        /// <summary>
        /// Coordenada X del píxel.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Coordenada Y del píxel.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Constructor del punto píxel.
        /// </summary>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada Y</param>
        public PixelPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Valida si el punto está dentro de los límites especificados.
        /// </summary>
        /// <param name="maxX">Ancho máximo del canvas</param>
        /// <param name="maxY">Alto máximo del canvas</param>
        /// <returns>True si está dentro de los límites</returns>
        public bool IsWithinBounds(int maxX, int maxY)
        {
            return X >= 0 && X < maxX && Y >= 0 && Y < maxY;
        }

        /// <summary>
        /// Calcula la distancia euclidiana entre dos puntos.
        /// </summary>
        public double DistanceTo(PixelPoint other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            int dx = X - other.X;
            int dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        #region Equality Members

        public bool Equals(PixelPoint other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PixelPoint)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(PixelPoint left, PixelPoint right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PixelPoint left, PixelPoint right)
        {
            return !Equals(left, right);
        }

        #endregion

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
