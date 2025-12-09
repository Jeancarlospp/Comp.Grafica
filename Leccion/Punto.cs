using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leccion
{
    /// <summary>
    /// Clase que representa un punto en el plano cartesiano
    /// </summary>
    public class Punto
    {
        // Propiedades
        public float X { get; set; }
        public float Y { get; set; }

        // Constructor por defecto
        public Punto()
        {
            X = 0;
            Y = 0;
        }

        // Constructor con parámetros
        public Punto(float x, float y)
        {
            X = x;
            Y = y;
        }

        // Método para obtener la representación en texto
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
