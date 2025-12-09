namespace Santi_Jeancarlo_Leccion1
{
    partial class frmrombo
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
            this.grbGrafico = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.grbGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGrafico
            // 
            this.grbGrafico.Controls.Add(this.picCanvas);
            this.grbGrafico.Location = new System.Drawing.Point(391, 28);
            this.grbGrafico.Name = "grbGrafico";
            this.grbGrafico.Size = new System.Drawing.Size(940, 654);
            this.grbGrafico.TabIndex = 11;
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
            // grbInputs
            // 
            this.grbInputs.Controls.Add(this.btnGraficar);
            this.grbInputs.Location = new System.Drawing.Point(25, 28);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(302, 112);
            this.grbInputs.TabIndex = 10;
            this.grbInputs.TabStop = false;
            this.grbInputs.Text = "Entradas";
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(67, 58);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(160, 39);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Graficar ";
            this.btnGraficar.UseVisualStyleBackColor = true;
            // 
            // frmrombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 745);
            this.Controls.Add(this.grbGrafico);
            this.Controls.Add(this.grbInputs);
            this.Name = "frmrombo";
            this.Text = "Figura 1";
            this.Load += new System.EventHandler(this.frmrombo_Load);
            this.grbGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbInputs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGrafico;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.Button btnGraficar;
    }
}

