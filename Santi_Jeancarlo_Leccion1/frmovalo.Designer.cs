namespace Santi_Jeancarlo_Leccion1
{
    partial class frmovalo
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
            this.grbGrafico1 = new System.Windows.Forms.GroupBox();
            this.picCanvas1 = new System.Windows.Forms.PictureBox();
            this.grbInputs1 = new System.Windows.Forms.GroupBox();
            this.btnGraficar1 = new System.Windows.Forms.Button();
            this.grbGrafico1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas1)).BeginInit();
            this.grbInputs1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGrafico1
            // 
            this.grbGrafico1.Controls.Add(this.picCanvas1);
            this.grbGrafico1.Location = new System.Drawing.Point(336, 23);
            this.grbGrafico1.Name = "grbGrafico1";
            this.grbGrafico1.Size = new System.Drawing.Size(940, 654);
            this.grbGrafico1.TabIndex = 13;
            this.grbGrafico1.TabStop = false;
            this.grbGrafico1.Text = "Gráfico";
            // 
            // picCanvas1
            // 
            this.picCanvas1.Location = new System.Drawing.Point(6, 25);
            this.picCanvas1.Name = "picCanvas1";
            this.picCanvas1.Size = new System.Drawing.Size(928, 623);
            this.picCanvas1.TabIndex = 0;
            this.picCanvas1.TabStop = false;
            // 
            // grbInputs1
            // 
            this.grbInputs1.Controls.Add(this.btnGraficar1);
            this.grbInputs1.Location = new System.Drawing.Point(12, 23);
            this.grbInputs1.Name = "grbInputs1";
            this.grbInputs1.Size = new System.Drawing.Size(302, 112);
            this.grbInputs1.TabIndex = 12;
            this.grbInputs1.TabStop = false;
            this.grbInputs1.Text = "Entradas";
            // 
            // btnGraficar1
            // 
            this.btnGraficar1.Location = new System.Drawing.Point(67, 58);
            this.btnGraficar1.Name = "btnGraficar1";
            this.btnGraficar1.Size = new System.Drawing.Size(160, 39);
            this.btnGraficar1.TabIndex = 2;
            this.btnGraficar1.Text = "Graficar ";
            this.btnGraficar1.UseVisualStyleBackColor = true;
            // 
            // frmovalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 740);
            this.Controls.Add(this.grbGrafico1);
            this.Controls.Add(this.grbInputs1);
            this.Name = "frmovalo";
            this.Text = "figura2";
            this.grbGrafico1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas1)).EndInit();
            this.grbInputs1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGrafico1;
        private System.Windows.Forms.PictureBox picCanvas1;
        private System.Windows.Forms.GroupBox grbInputs1;
        private System.Windows.Forms.Button btnGraficar1;
    }
}