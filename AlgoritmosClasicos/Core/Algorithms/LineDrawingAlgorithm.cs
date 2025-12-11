using System;
using System.Collections.Generic;
using AlgoritmosClasicos.Core.Interfaces;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Algorithms
{

    public abstract class LineDrawingAlgorithm : ILineDrawingAlgorithm
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public List<PixelPoint> CalculateLine(PixelPoint start, PixelPoint end)
        {

            ValidatePoints(start, end);

            if (start.Equals(end))
            {
                return new List<PixelPoint> { start };
            }

            return CalculateLineImplementation(start, end);
        }

        protected abstract List<PixelPoint> CalculateLineImplementation(PixelPoint start, PixelPoint end);

        protected virtual void ValidatePoints(PixelPoint start, PixelPoint end)
        {
            if (start == null)
                throw new ArgumentNullException(nameof(start), "El punto inicial no puede ser nulo.");

            if (end == null)
                throw new ArgumentNullException(nameof(end), "El punto final no puede ser nulo.");

            const int MAX_COORDINATE = 10000;
            
            if (Math.Abs(start.X) > MAX_COORDINATE || Math.Abs(start.Y) > MAX_COORDINATE)
                throw new ArgumentException("Las coordenadas del punto inicial están fuera del rango permitido.");

            if (Math.Abs(end.X) > MAX_COORDINATE || Math.Abs(end.Y) > MAX_COORDINATE)
                throw new ArgumentException("Las coordenadas del punto final están fuera del rango permitido.");
        }


        protected void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        protected int Abs(int value)
        {
            return value < 0 ? -value : value;
        }
        protected int Sign(int value)
        {
            if (value > 0) return 1;
            if (value < 0) return -1;
            return 0;
        }
    }
}
