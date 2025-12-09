namespace EX1_Santi_Jeancarlo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.panelControls = new System.Windows.Forms.Panel();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelInstrucciones = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLanzar = new System.Windows.Forms.Button();
            this.numericVelocidad = new System.Windows.Forms.NumericUpDown();
            this.numericAngulo = new System.Windows.Forms.NumericUpDown();
            this.labelVelocidad = new System.Windows.Forms.Label();
            this.labelAngulo = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVelocidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAngulo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBoxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(1005, 562);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCanvas_Paint);
            this.pictureBoxCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseClick);
            this.pictureBoxCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseMove);
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelControls.Controls.Add(this.labelEstado);
            this.panelControls.Controls.Add(this.labelInstrucciones);
            this.panelControls.Controls.Add(this.btnReset);
            this.panelControls.Controls.Add(this.btnLanzar);
            this.panelControls.Controls.Add(this.numericVelocidad);
            this.panelControls.Controls.Add(this.numericAngulo);
            this.panelControls.Controls.Add(this.labelVelocidad);
            this.panelControls.Controls.Add(this.labelAngulo);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 462);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1005, 100);
            this.panelControls.TabIndex = 1;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelEstado.ForeColor = System.Drawing.Color.Black;
            this.labelEstado.Location = new System.Drawing.Point(660, 55);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(76, 25);
            this.labelEstado.TabIndex = 7;
            this.labelEstado.Text = "Listo...";
            // 
            // labelInstrucciones
            // 
            this.labelInstrucciones.AutoSize = true;
            this.labelInstrucciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelInstrucciones.ForeColor = System.Drawing.Color.Black;
            this.labelInstrucciones.Location = new System.Drawing.Point(660, 20);
            this.labelInstrucciones.Name = "labelInstrucciones";
            this.labelInstrucciones.Size = new System.Drawing.Size(253, 22);
            this.labelInstrucciones.TabIndex = 6;
            this.labelInstrucciones.Text = "Haz clic para mover el objetivo";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(520, 45);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reiniciar";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLanzar
            // 
            this.btnLanzar.BackColor = System.Drawing.Color.Black;
            this.btnLanzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLanzar.ForeColor = System.Drawing.Color.White;
            this.btnLanzar.Location = new System.Drawing.Point(370, 45);
            this.btnLanzar.Name = "btnLanzar";
            this.btnLanzar.Size = new System.Drawing.Size(130, 40);
            this.btnLanzar.TabIndex = 4;
            this.btnLanzar.Text = "🚀 Lanzar";
            this.btnLanzar.UseVisualStyleBackColor = false;
            this.btnLanzar.Click += new System.EventHandler(this.btnLanzar_Click);
            // 
            // numericVelocidad
            // 
            this.numericVelocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericVelocidad.Location = new System.Drawing.Point(220, 55);
            this.numericVelocidad.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericVelocidad.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericVelocidad.Name = "numericVelocidad";
            this.numericVelocidad.Size = new System.Drawing.Size(120, 30);
            this.numericVelocidad.TabIndex = 3;
            this.numericVelocidad.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // numericAngulo
            // 
            this.numericAngulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericAngulo.Location = new System.Drawing.Point(20, 55);
            this.numericAngulo.Maximum = new decimal(new int[] {
            85,
            0,
            0,
            0});
            this.numericAngulo.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericAngulo.Name = "numericAngulo";
            this.numericAngulo.Size = new System.Drawing.Size(120, 30);
            this.numericAngulo.TabIndex = 2;
            this.numericAngulo.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // labelVelocidad
            // 
            this.labelVelocidad.AutoSize = true;
            this.labelVelocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelVelocidad.ForeColor = System.Drawing.Color.Black;
            this.labelVelocidad.Location = new System.Drawing.Point(220, 20);
            this.labelVelocidad.Name = "labelVelocidad";
            this.labelVelocidad.Size = new System.Drawing.Size(172, 25);
            this.labelVelocidad.TabIndex = 1;
            this.labelVelocidad.Text = "Velocidad (m/s):";
            // 
            // labelAngulo
            // 
            this.labelAngulo.AutoSize = true;
            this.labelAngulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelAngulo.ForeColor = System.Drawing.Color.Black;
            this.labelAngulo.Location = new System.Drawing.Point(20, 20);
            this.labelAngulo.Name = "labelAngulo";
            this.labelAngulo.Size = new System.Drawing.Size(118, 25);
            this.labelAngulo.TabIndex = 0;
            this.labelAngulo.Text = "Ángulo (°):";
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 562);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.pictureBoxCanvas);
            this.Name = "Form1";
            this.Text = "Simulación Trayectoria Balística de Misil - EX1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVelocidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAngulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.NumericUpDown numericAngulo;
        private System.Windows.Forms.Label labelAngulo;
        private System.Windows.Forms.NumericUpDown numericVelocidad;
        private System.Windows.Forms.Label labelVelocidad;
        private System.Windows.Forms.Button btnLanzar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labelInstrucciones;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Timer timer;
    }
}

