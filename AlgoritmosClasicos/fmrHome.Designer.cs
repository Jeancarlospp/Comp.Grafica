namespace AlgoritmosClasicos
{
    partial class frmHome
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
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mniTrazadoLineas = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTrazadoCirculos = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAlgoritmosRelleno = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRecorteLineas = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRecortePoligonos = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.mnuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTrazadoLineas,
            this.mniTrazadoCirculos,
            this.mniAlgoritmosRelleno,
            this.mniRecorteLineas,
            this.mniRecortePoligonos});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.mnuPrincipal.Size = new System.Drawing.Size(1200, 38);
            this.mnuPrincipal.TabIndex = 0;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mniTrazadoLineas
            // 
            this.mniTrazadoLineas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mniTrazadoLineas.Name = "mniTrazadoLineas";
            this.mniTrazadoLineas.Size = new System.Drawing.Size(177, 32);
            this.mniTrazadoLineas.Text = "Trazado de líneas";
            this.mniTrazadoLineas.Click += new System.EventHandler(this.mniTrazadoLineas_Click);
            // 
            // mniTrazadoCirculos
            // 
            this.mniTrazadoCirculos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mniTrazadoCirculos.Name = "mniTrazadoCirculos";
            this.mniTrazadoCirculos.Size = new System.Drawing.Size(194, 32);
            this.mniTrazadoCirculos.Text = "Trazado de círculos";
            this.mniTrazadoCirculos.Click += new System.EventHandler(this.mniTrazadoCirculos_Click);
            // 
            // mniAlgoritmosRelleno
            // 
            this.mniAlgoritmosRelleno.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mniAlgoritmosRelleno.Name = "mniAlgoritmosRelleno";
            this.mniAlgoritmosRelleno.Size = new System.Drawing.Size(218, 32);
            this.mniAlgoritmosRelleno.Text = "Algoritmos de relleno";
            this.mniAlgoritmosRelleno.Click += new System.EventHandler(this.mniAlgoritmosRelleno_Click);
            // 
            // mniRecorteLineas
            // 
            this.mniRecorteLineas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mniRecorteLineas.Name = "mniRecorteLineas";
            this.mniRecorteLineas.Size = new System.Drawing.Size(175, 32);
            this.mniRecorteLineas.Text = "Recorte de líneas";
            this.mniRecorteLineas.Click += new System.EventHandler(this.mniRecorteLineas_Click);
            // 
            // mniRecortePoligonos
            // 
            this.mniRecortePoligonos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mniRecortePoligonos.Name = "mniRecortePoligonos";
            this.mniRecortePoligonos.Size = new System.Drawing.Size(215, 32);
            this.mniRecortePoligonos.Text = "Recorte de polígonos";
            this.mniRecortePoligonos.Click += new System.EventHandler(this.mniRecortePoligonos_Click);
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCanvas.Location = new System.Drawing.Point(0, 38);
            this.pnlCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(1200, 662);
            this.pnlCanvas.TabIndex = 1;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.mnuPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mnuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmos Clásicos de Computación Gráfica";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mniTrazadoLineas;
        private System.Windows.Forms.ToolStripMenuItem mniTrazadoCirculos;
        private System.Windows.Forms.ToolStripMenuItem mniAlgoritmosRelleno;
        private System.Windows.Forms.ToolStripMenuItem mniRecorteLineas;
        private System.Windows.Forms.ToolStripMenuItem mniRecortePoligonos;
        private System.Windows.Forms.Panel pnlCanvas;
    }
}

