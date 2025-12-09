using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AlgoritmosClasicos.Core.Models;

namespace AlgoritmosClasicos.Core.Managers
{
    /// <summary>
    /// Manager global reutilizable para mostrar coordenadas de puntos generados por algoritmos.
    /// Este componente se utiliza en TODOS los algoritmos de la aplicación:
    /// - Trazado de líneas
    /// - Trazado de círculos
    /// - Algoritmos de relleno
    /// - Recorte de líneas
    /// - Recorte de polígonos
    /// 
    /// Soporta tanto modo continuo como modo paso a paso.
    /// </summary>
    public class CoordinateDisplayManager
    {
        private readonly ListBox _listBox;
        private List<PixelPoint> _currentPoints;
        private int _currentIndex;

        /// <summary>
        /// Puntos actualmente cargados en el manager.
        /// </summary>
        public List<PixelPoint> CurrentPoints => _currentPoints;

        /// <summary>
        /// Índice del punto actual en modo paso a paso.
        /// </summary>
        public int CurrentIndex => _currentIndex;

        /// <summary>
        /// Total de puntos cargados.
        /// </summary>
        public int TotalPoints => _currentPoints?.Count ?? 0;

        /// <summary>
        /// Constructor que requiere un ListBox donde mostrar las coordenadas.
        /// </summary>
        /// <param name="listBox">Control ListBox para mostrar coordenadas</param>
        public CoordinateDisplayManager(ListBox listBox)
        {
            _listBox = listBox ?? throw new ArgumentNullException(nameof(listBox));
            _currentPoints = new List<PixelPoint>();
            _currentIndex = -1;
        }

        /// <summary>
        /// Carga una nueva lista de puntos y los muestra en el ListBox.
        /// </summary>
        /// <param name="points">Lista de puntos a mostrar</param>
        public void LoadPoints(List<PixelPoint> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            _currentPoints = new List<PixelPoint>(points);
            _currentIndex = -1;
            RefreshDisplay();
        }

        /// <summary>
        /// Refresca la visualización completa de todas las coordenadas.
        /// </summary>
        public void RefreshDisplay()
        {
            _listBox.BeginUpdate();
            _listBox.Items.Clear();

            if (_currentPoints != null && _currentPoints.Count > 0)
            {
                for (int i = 0; i < _currentPoints.Count; i++)
                {
                    var point = _currentPoints[i];
                    string display = $"[{i}] {point}";
                    
                    // Resaltar el punto actual en modo paso a paso
                    if (i == _currentIndex)
                    {
                        display = " " + display + " ";
                    }
                    
                    _listBox.Items.Add(display);
                }
            }
            else
            {
                _listBox.Items.Add("(Sin coordenadas)");
            }

            _listBox.EndUpdate();

            // Auto-scroll al punto actual
            if (_currentIndex >= 0 && _currentIndex < _listBox.Items.Count)
            {
                _listBox.TopIndex = _currentIndex;
            }
        }

        /// <summary>
        /// Resalta un punto específico (usado en modo paso a paso).
        /// </summary>
        /// <param name="index">Índice del punto a resaltar</param>
        public void HighlightPoint(int index)
        {
            if (index < 0 || index >= TotalPoints)
                throw new ArgumentOutOfRangeException(nameof(index), 
                    "El índice está fuera del rango de puntos disponibles.");

            _currentIndex = index;
            RefreshDisplay();
        }

        /// <summary>
        /// Avanza al siguiente punto en modo paso a paso.
        /// </summary>
        /// <returns>True si se avanzó exitosamente, False si ya estaba en el último punto</returns>
        public bool NextPoint()
        {
            if (_currentIndex < TotalPoints - 1)
            {
                _currentIndex++;
                RefreshDisplay();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrocede al punto anterior en modo paso a paso.
        /// </summary>
        /// <returns>True si se retrocedió exitosamente, False si ya estaba en el primer punto</returns>
        public bool PreviousPoint()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                RefreshDisplay();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reinicia la navegación paso a paso al inicio.
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
            RefreshDisplay();
        }

        /// <summary>
        /// Va directamente al primer punto.
        /// </summary>
        public void GoToFirst()
        {
            if (TotalPoints > 0)
            {
                _currentIndex = 0;
                RefreshDisplay();
            }
        }

        /// <summary>
        /// Va directamente al último punto.
        /// </summary>
        public void GoToLast()
        {
            if (TotalPoints > 0)
            {
                _currentIndex = TotalPoints - 1;
                RefreshDisplay();
            }
        }

        /// <summary>
        /// Limpia todos los puntos y resetea el display.
        /// </summary>
        public void Clear()
        {
            _currentPoints.Clear();
            _currentIndex = -1;
            RefreshDisplay();
        }

        /// <summary>
        /// Obtiene el punto actualmente resaltado (si existe).
        /// </summary>
        /// <returns>Punto actual o null si no hay punto seleccionado</returns>
        public PixelPoint GetCurrentPoint()
        {
            if (_currentIndex >= 0 && _currentIndex < TotalPoints)
            {
                return _currentPoints[_currentIndex];
            }
            return null;
        }

        /// <summary>
        /// Obtiene información resumida del estado actual.
        /// </summary>
        public string GetStatusInfo()
        {
            if (TotalPoints == 0)
                return "Sin puntos cargados";

            if (_currentIndex < 0)
                return $"Total de puntos: {TotalPoints}";

            return $"Punto {_currentIndex + 1} de {TotalPoints}: {_currentPoints[_currentIndex]}";
        }
    }
}
