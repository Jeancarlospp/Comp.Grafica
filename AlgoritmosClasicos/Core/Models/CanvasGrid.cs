using System.Drawing;

namespace AlgoritmosClasicos.Core.Models
{
    /// <summary>
    /// Clase que gestiona el estado de la grilla de píxeles del canvas.
    /// Almacena el color de cada píxel y proporciona métodos para manipularlos.
    /// Reutilizable para todos los algoritmos de relleno.
    /// </summary>
    public class CanvasGrid
    {
        private readonly Color[,] _grid;
        private readonly int _width;
        private readonly int _height;
        private readonly Color _backgroundColor;

        /// <summary>
        /// Ancho de la grilla en píxeles lógicos.
        /// </summary>
        public int Width => _width;

        /// <summary>
        /// Alto de la grilla en píxeles lógicos.
        /// </summary>
        public int Height => _height;

        /// <summary>
        /// Color de fondo predeterminado.
        /// </summary>
        public Color BackgroundColor => _backgroundColor;

        /// <summary>
        /// Constructor que inicializa la grilla con un tamaño y color de fondo.
        /// </summary>
        public CanvasGrid(int width, int height, Color backgroundColor)
        {
            _width = width;
            _height = height;
            _backgroundColor = backgroundColor;
            _grid = new Color[width, height];
            Clear();
        }

        /// <summary>
        /// Obtiene el color de un píxel específico.
        /// </summary>
        public Color GetPixel(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                return _grid[x, y];
            return _backgroundColor;
        }

        /// <summary>
        /// Establece el color de un píxel específico.
        /// </summary>
        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                _grid[x, y] = color;
        }

        /// <summary>
        /// Obtiene el color en una coordenada de PixelPoint.
        /// </summary>
        public Color GetPixel(PixelPoint point)
        {
            return GetPixel(point.X, point.Y);
        }

        /// <summary>
        /// Establece el color en una coordenada de PixelPoint.
        /// </summary>
        public void SetPixel(PixelPoint point, Color color)
        {
            SetPixel(point.X, point.Y, color);
        }

        /// <summary>
        /// Limpia toda la grilla con el color de fondo.
        /// </summary>
        public void Clear()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _grid[x, y] = _backgroundColor;
                }
            }
        }

        /// <summary>
        /// Obtiene una copia del array de colores.
        /// Útil para pasarlo a algoritmos sin modificar el original.
        /// </summary>
        public Color[,] GetGridCopy()
        {
            var copy = new Color[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    copy[x, y] = _grid[x, y];
                }
            }
            return copy;
        }

        /// <summary>
        /// Obtiene la referencia directa al array de colores.
        /// ADVERTENCIA: Modificar este array afectará la grilla original.
        /// </summary>
        public Color[,] GetGrid()
        {
            return _grid;
        }

        /// <summary>
        /// Restaura la grilla desde un array de colores.
        /// </summary>
        public void RestoreGrid(Color[,] gridState)
        {
            if (gridState.GetLength(0) != _width || gridState.GetLength(1) != _height)
                return;

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _grid[x, y] = gridState[x, y];
                }
            }
        }

        /// <summary>
        /// Verifica si un punto está dentro de los límites de la grilla.
        /// </summary>
        public bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }

        /// <summary>
        /// Verifica si un punto está dentro de los límites de la grilla.
        /// </summary>
        public bool IsWithinBounds(PixelPoint point)
        {
            return IsWithinBounds(point.X, point.Y);
        }
    }
}
