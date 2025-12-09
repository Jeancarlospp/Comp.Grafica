using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorStar
{
    public partial class frmStar : Form
    {
        private Star ObjStar = new Star();
        private Traslacion traslacion;
        private Rotacion rotacion;
        private bool figuraGraficada = false;

        public frmStar()
        {
            InitializeComponent();
            
            // Habilitar el formulario para recibir eventos de teclado
            this.KeyPreview = true;
        }

        private void frmStar_Load(object sender, EventArgs e)
        {
            // Establecer Traslación como opción por defecto
            comboBox1.SelectedIndex = 0;
            
            // Configurar el PictureBox para que pueda recibir el foco
            picCanvas.TabStop = true;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            ObjStar.ReadData(txtRadio);
            
            // Dibujar en el PictureBox en lugar del Form
            ObjStar.PlotShape(picCanvas);
            
            // Inicializar las transformaciones después de graficar, pasando el PictureBox
            traslacion = new Traslacion(ObjStar, picCanvas);
            rotacion = new Rotacion(ObjStar, picCanvas);
            
            figuraGraficada = true;
            
            // Dar el foco al canvas para que las teclas funcionen inmediatamente
            picCanvas.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando cambia la selección, resetear y redibujar la figura
            // Esto asegura que ambas transformaciones partan del mismo estado base
            if (figuraGraficada && comboBox1.SelectedItem != null)
            {
                string opcionSeleccionada = comboBox1.SelectedItem.ToString();
                
                // Limpiar el canvas
                Graphics g = picCanvas.CreateGraphics();
                g.Clear(picCanvas.BackColor);
                g.Dispose();
                
                // Redibujar la figura en su posición original
                ObjStar.PlotShape(picCanvas);
                
                // Reinicializar las transformaciones
                traslacion = new Traslacion(ObjStar, picCanvas);
                rotacion = new Rotacion(ObjStar, picCanvas);
            }
            
            // Quitar el foco del ComboBox y dárselo al canvas
            // Esto evita que el ComboBox se quede resaltado en azul
            picCanvas.Focus();
        }

        // Sobrescribir ProcessCmdKey para interceptar las teclas de flecha ANTES de que naveguen
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Solo procesar si ya se ha graficado la figura
            if (!figuraGraficada || traslacion == null || rotacion == null)
                return base.ProcessCmdKey(ref msg, keyData);

            // Verificar qué opción está seleccionada en el ComboBox
            if (comboBox1.SelectedItem == null)
                return base.ProcessCmdKey(ref msg, keyData);

            string opcionSeleccionada = comboBox1.SelectedItem.ToString();

            float desplazamiento = 5; // Desplazamiento de 5 píxeles para traslación
            float anguloIncremento = 5; // Incremento de 5 grados para rotación

            bool teclaManejada = false;

            // Ejecutar la transformación según la opción seleccionada
            switch (opcionSeleccionada)
            {
                case "Traslacion":
                    // Modo Traslación - usar las 4 flechas
                    switch (keyData)
                    {
                        case Keys.Up:
                            traslacion.Trasladar(0, -desplazamiento);
                            teclaManejada = true;
                            break;
                        case Keys.Down:
                            traslacion.Trasladar(0, desplazamiento);
                            teclaManejada = true;
                            break;
                        case Keys.Left:
                            traslacion.Trasladar(-desplazamiento, 0);
                            teclaManejada = true;
                            break;
                        case Keys.Right:
                            traslacion.Trasladar(desplazamiento, 0);
                            teclaManejada = true;
                            break;
                    }
                    break;

                case "Rotacion":
                    // Modo Rotación - usar flechas izquierda (antihorario) y derecha (horario)
                    switch (keyData)
                    {
                        case Keys.Left:
                            rotacion.Rotar(-anguloIncremento); // Rotar antihorario
                            teclaManejada = true;
                            break;
                        case Keys.Right:
                            rotacion.Rotar(anguloIncremento); // Rotar horario
                            teclaManejada = true;
                            break;
                    }
                    break;

                case "Escala":
                    // Aquí puedes implementar la escala en el futuro
                    break;
            }

            // Si manejamos la tecla, retornar true para evitar que se propague
            if (teclaManejada)
                return true;

            // Si no la manejamos, dejar que el comportamiento por defecto continúe
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tbarEscala_Scroll(object sender, EventArgs e)
        {
            lblEscala.Text = "Valor Actual: " + tbarEscala.Value.ToString();
        }

        private void tbarEscala_Scroll_1(object sender, EventArgs e)
        {

        }
    }
}
