using System;
using System.Collections.Generic;
using System.Drawing;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Rendering
{
    /// <summary>
    /// Clase responsable de renderizar píxeles como cuadrados visibles en un Graphics.
    /// Simula píxeles lógicos como cuadrados de tamaño configurable para mejor visualización.
    /// Esta clase es reutilizable por todos los algoritmos gráficos.
    /// </summary>
    public class PixelRenderer
    {
        private readonly int _pixelSize;
        private readonly Color _pixelColor;
        private readonly Brush _pixelBrush;
        private int _canvasHeight;

        /// <summary>
        /// Tamaño de cada píxel simulado en píxeles de pantalla.
        /// </summary>
        public int PixelSize => _pixelSize;

        /// <summary>
        /// Color utilizado para dibujar los píxeles.
        /// </summary>
        public Color PixelColor => _pixelColor;

        /// <summary>
        /// Constructor con parámetros personalizables.
        /// </summary>
        /// <param name="pixelSize">Tamaño del píxel simulado (por defecto 5)</param>
        /// <param name="pixelColor">Color del píxel (por defecto Negro)</param>
        /// <param name="canvasHeight">Alto del canvas en píxeles lógicos (para invertir Y)</param>
        public PixelRenderer(int pixelSize = 5, Color? pixelColor = null, int canvasHeight = 80)
        {
            if (pixelSize <= 0)
                throw new ArgumentException("El tamaño del píxel debe ser mayor a 0.", nameof(pixelSize));

            _pixelSize = pixelSize;
            _pixelColor = pixelColor ?? Color.Black;
            _pixelBrush = new SolidBrush(_pixelColor);
            _canvasHeight = canvasHeight;
        }

        /// <summary>
        /// Convierte la coordenada Y de origen inferior a origen superior (pantalla).
        /// </summary>
        private int InvertY(int y)
        {
            return _canvasHeight - 1 - y;
        }

        /// <summary>
        /// Dibuja un solo píxel simulado.
        /// </summary>
        /// <param name="graphics">Objeto Graphics donde dibujar</param>
        /// <param name="point">Punto a dibujar</param>
        public void DrawPixel(Graphics graphics, PixelPoint point)
        {
            if (graphics == null)
                throw new ArgumentNullException(nameof(graphics));
            
            if (point == null)
                throw new ArgumentNullException(nameof(point));

            int screenY = InvertY(point.Y);
            graphics.FillRectangle(_pixelBrush, 
                point.X * _pixelSize, 
                screenY * _pixelSize, 
                _pixelSize, 
                _pixelSize);
        }

        /// <summary>
        /// Dibuja múltiples píxeles simulados.
        /// </summary>
        /// <param name="graphics">Objeto Graphics donde dibujar</param>
        /// <param name="points">Lista de puntos a dibujar</param>
        public void DrawPixels(Graphics graphics, List<PixelPoint> points)
        {
            if (graphics == null)
                throw new ArgumentNullException(nameof(graphics));
            
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            foreach (var point in points)
            {
                DrawPixel(graphics, point);
            }
        }

        /// <summary>
        /// Dibuja un píxel con un color específico (temporal).
        /// </summary>
        /// <param name="graphics">Objeto Graphics donde dibujar</param>
        /// <param name="point">Punto a dibujar</param>
        /// <param name="color">Color específico para este píxel</param>
        public void DrawPixel(Graphics graphics, PixelPoint point, Color color)
        {
            if (graphics == null)
                throw new ArgumentNullException(nameof(graphics));
            
            if (point == null)
                throw new ArgumentNullException(nameof(point));

            int screenY = InvertY(point.Y);
            using (var brush = new SolidBrush(color))
            {
                graphics.FillRectangle(brush, 
                    point.X * _pixelSize, 
                    screenY * _pixelSize, 
                    _pixelSize, 
                    _pixelSize);
            }
        }

        /// <summary>
        /// Dibuja una grilla (opcional) para visualizar mejor los píxeles.
        /// </summary>
        /// <param name="graphics">Objeto Graphics donde dibujar</param>
        /// <param name="width">Ancho del canvas en píxeles lógicos</param>
        /// <param name="height">Alto del canvas en píxeles lógicos</param>
        public void DrawGrid(Graphics graphics, int width, int height)
        {
            if (graphics == null)
                throw new ArgumentNullException(nameof(graphics));

            using (var pen = new Pen(Color.LightGray, 1))
            {
                // Líneas verticales
                for (int x = 0; x <= width; x++)
                {
                    graphics.DrawLine(pen, 
                        x * _pixelSize, 0, 
                        x * _pixelSize, height * _pixelSize);
                }

                // Líneas horizontales
                for (int y = 0; y <= height; y++)
                {
                    graphics.DrawLine(pen, 
                        0, y * _pixelSize, 
                        width * _pixelSize, y * _pixelSize);
                }
            }
        }

        /// <summary>
        /// Limpia los recursos utilizados.
        /// </summary>
        public void Dispose()
        {
            _pixelBrush?.Dispose();
        }
    }
}
