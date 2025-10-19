namespace Ejercicio2
{
    partial class Rombo
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
            this.lblDMayor = new System.Windows.Forms.Label();
            this.txtDMayor = new System.Windows.Forms.TextBox();
            this.txtDMenor = new System.Windows.Forms.TextBox();
            this.lblDMenor = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDMayor
            // 
            this.lblDMayor.AutoSize = true;
            this.lblDMayor.Location = new System.Drawing.Point(160, 51);
            this.lblDMayor.Name = "lblDMayor";
            this.lblDMayor.Size = new System.Drawing.Size(203, 20);
            this.lblDMayor.TabIndex = 0;
            this.lblDMayor.Text = "Ingrese La Diagonal Mayor:";
            // 
            // txtDMayor
            // 
            this.txtDMayor.Location = new System.Drawing.Point(395, 51);
            this.txtDMayor.Name = "txtDMayor";
            this.txtDMayor.Size = new System.Drawing.Size(100, 26);
            this.txtDMayor.TabIndex = 2;
            // 
            // txtDMenor
            // 
            this.txtDMenor.Location = new System.Drawing.Point(395, 109);
            this.txtDMenor.Name = "txtDMenor";
            this.txtDMenor.Size = new System.Drawing.Size(100, 26);
            this.txtDMenor.TabIndex = 4;
            // 
            // lblDMenor
            // 
            this.lblDMenor.AutoSize = true;
            this.lblDMenor.Location = new System.Drawing.Point(160, 115);
            this.lblDMenor.Name = "lblDMenor";
            this.lblDMenor.Size = new System.Drawing.Size(205, 20);
            this.lblDMenor.TabIndex = 5;
            this.lblDMenor.Text = "Ingrese La Diagonal Menor:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(213, 217);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(282, 42);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular Area y Perimetro";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // Rombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblDMenor);
            this.Controls.Add(this.txtDMenor);
            this.Controls.Add(this.txtDMayor);
            this.Controls.Add(this.lblDMayor);
            this.Name = "Rombo";
            this.Text = "Rombo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDMayor;
        private System.Windows.Forms.TextBox txtDMayor;
        private System.Windows.Forms.TextBox txtDMenor;
        private System.Windows.Forms.Label lblDMenor;
        private System.Windows.Forms.Button btnCalcular;
    }
}