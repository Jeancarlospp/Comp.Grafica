namespace Ejercicio2
{
    partial class Trapecio
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
            this.lblBMenor = new System.Windows.Forms.Label();
            this.lblBMayor = new System.Windows.Forms.Label();
            this.txtBMenor = new System.Windows.Forms.TextBox();
            this.txtBMayor = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblAltura = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.lblLado = new System.Windows.Forms.Label();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblBMenor
            // 
            this.lblBMenor.AutoSize = true;
            this.lblBMenor.Location = new System.Drawing.Point(83, 72);
            this.lblBMenor.Name = "lblBMenor";
            this.lblBMenor.Size = new System.Drawing.Size(263, 20);
            this.lblBMenor.TabIndex = 0;
            this.lblBMenor.Text = "Ingrese la Base Menor del Trapecio:";
            // 
            // lblBMayor
            // 
            this.lblBMayor.AutoSize = true;
            this.lblBMayor.Location = new System.Drawing.Point(85, 138);
            this.lblBMayor.Name = "lblBMayor";
            this.lblBMayor.Size = new System.Drawing.Size(261, 20);
            this.lblBMayor.TabIndex = 1;
            this.lblBMayor.Text = "Ingrese la Base Mayor del Trapecio:";
            // 
            // txtBMenor
            // 
            this.txtBMenor.Location = new System.Drawing.Point(401, 72);
            this.txtBMenor.Name = "txtBMenor";
            this.txtBMenor.Size = new System.Drawing.Size(100, 26);
            this.txtBMenor.TabIndex = 2;
            // 
            // txtBMayor
            // 
            this.txtBMayor.Location = new System.Drawing.Point(401, 132);
            this.txtBMayor.Name = "txtBMayor";
            this.txtBMayor.Size = new System.Drawing.Size(100, 26);
            this.txtBMayor.TabIndex = 3;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(247, 334);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(214, 46);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular Área y Perímetro";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(217, 206);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(129, 20);
            this.lblAltura.TabIndex = 5;
            this.lblAltura.Text = "Ingrese la Altura:";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(401, 200);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(100, 26);
            this.txtAltura.TabIndex = 6;
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(133, 274);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(213, 20);
            this.lblLado.TabIndex = 7;
            this.lblLado.Text = "Ingrese el Lado del Trapecio:";
            this.lblLado.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(401, 268);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(100, 26);
            this.txtLado.TabIndex = 8;
            // 
            // Trapecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLado);
            this.Controls.Add(this.lblLado);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtBMayor);
            this.Controls.Add(this.txtBMenor);
            this.Controls.Add(this.lblBMayor);
            this.Controls.Add(this.lblBMenor);
            this.Name = "Trapecio";
            this.Text = "Trapecio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBMenor;
        private System.Windows.Forms.Label lblBMayor;
        private System.Windows.Forms.TextBox txtBMenor;
        private System.Windows.Forms.TextBox txtBMayor;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.TextBox txtLado;
    }
}