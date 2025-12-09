namespace AlgoritmosClasicos.Core.Models
{
    /// <summary>
    /// Representa una línea recortada con sus puntos de inicio y fin.
    /// Puede ser null si la línea está completamente fuera de la ventana de recorte.
    /// </summary>
    public class ClippedLine
    {
        /// <summary>
        /// Punto de inicio de la línea recortada.
        /// </summary>
        public PixelPoint Start { get; }

        /// <summary>
        /// Punto final de la línea recortada.
        /// </summary>
        public PixelPoint End { get; }

        /// <summary>
        /// Indica si la línea es visible (está dentro de la ventana).
        /// </summary>
        public bool IsVisible { get; }

        /// <summary>
        /// Constructor para línea visible recortada.
        /// </summary>
        public ClippedLine(PixelPoint start, PixelPoint end)
        {
            Start = start;
            End = end;
            IsVisible = true;
        }

        /// <summary>
        /// Constructor para línea no visible.
        /// </summary>
        private ClippedLine()
        {
            Start = null;
            End = null;
            IsVisible = false;
        }

        /// <summary>
        /// Crea una línea marcada como no visible.
        /// </summary>
        public static ClippedLine NotVisible()
        {
            return new ClippedLine();
        }

        public override string ToString()
        {
            if (!IsVisible)
                return "ClippedLine[Not Visible]";
            
            return $"ClippedLine[{Start} -> {End}]";
        }
    }
}
