namespace VectorStar
{
    partial class frmStar
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
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.grbOpciones = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grbGrafico = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEscala = new System.Windows.Forms.Label();
            this.tbarEscala = new System.Windows.Forms.TrackBar();
            this.grbInputs.SuspendLayout();
            this.grbOpciones.SuspendLayout();
            this.grbGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarEscala)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(170, 34);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 26);
            this.txtRadio.TabIndex = 0;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(24, 34);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(129, 20);
            this.lblRadio.TabIndex = 1;
            this.lblRadio.Text = "Ingrese el Radio:";
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(67, 96);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(160, 39);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Graficar Estrella";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // grbInputs
            // 
            this.grbInputs.Controls.Add(this.lblRadio);
            this.grbInputs.Controls.Add(this.btnGraficar);
            this.grbInputs.Controls.Add(this.txtRadio);
            this.grbInputs.Location = new System.Drawing.Point(12, 12);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(302, 142);
            this.grbInputs.TabIndex = 3;
            this.grbInputs.TabStop = false;
            this.grbInputs.Text = "Entradas";
            // 
            // grbOpciones
            // 
            this.grbOpciones.Controls.Add(this.comboBox1);
            this.grbOpciones.Location = new System.Drawing.Point(21, 172);
            this.grbOpciones.Name = "grbOpciones";
            this.grbOpciones.Size = new System.Drawing.Size(293, 88);
            this.grbOpciones.TabIndex = 4;
            this.grbOpciones.TabStop = false;
            this.grbOpciones.Text = "Selecciona la opción";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Traslacion",
            "Rotacion",
            "Escala"});
            this.comboBox1.Location = new System.Drawing.Point(19, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // grbGrafico
            // 
            this.grbGrafico.Controls.Add(this.picCanvas);
            this.grbGrafico.Location = new System.Drawing.Point(352, 21);
            this.grbGrafico.Name = "grbGrafico";
            this.grbGrafico.Size = new System.Drawing.Size(940, 654);
            this.grbGrafico.TabIndex = 5;
            this.grbGrafico.TabStop = false;
            this.grbGrafico.Text = "Gráfico";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(6, 25);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(928, 623);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEscala);
            this.groupBox1.Controls.Add(this.tbarEscala);
            this.groupBox1.Location = new System.Drawing.Point(21, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblEscala
            // 
            this.lblEscala.AutoSize = true;
            this.lblEscala.Location = new System.Drawing.Point(21, 90);
            this.lblEscala.Name = "lblEscala";
            this.lblEscala.Size = new System.Drawing.Size(114, 20);
            this.lblEscala.TabIndex = 6;
            this.lblEscala.Text = "Valor actual : 0";
            // 
            // tbarEscala
            // 
            this.tbarEscala.Location = new System.Drawing.Point(6, 41);
            this.tbarEscala.Maximum = 50;
            this.tbarEscala.Minimum = -50;
            this.tbarEscala.Name = "tbarEscala";
            this.tbarEscala.Size = new System.Drawing.Size(293, 69);
            this.tbarEscala.TabIndex = 7;
            this.tbarEscala.TickFrequency = 10;
            this.tbarEscala.Scroll += new System.EventHandler(this.tbarEscala_Scroll_1);
            // 
            // frmStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 698);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbGrafico);
            this.Controls.Add(this.grbOpciones);
            this.Controls.Add(this.grbInputs);
            this.Name = "frmStar";
            this.Text = "VectorStar";
            this.Load += new System.EventHandler(this.frmStar_Load);
            this.grbInputs.ResumeLayout(false);
            this.grbInputs.PerformLayout();
            this.grbOpciones.ResumeLayout(false);
            this.grbGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarEscala)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.GroupBox grbOpciones;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox grbGrafico;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEscala;
        private System.Windows.Forms.TrackBar tbarEscala;
    }
}

