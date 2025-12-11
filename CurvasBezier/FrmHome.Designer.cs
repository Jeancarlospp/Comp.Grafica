namespace CurvasBezier
{
    partial class FrmHome
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
            this.mniBezier2Puntos = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBezier3Puntos = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBezier4Puntos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniBezier2Puntos,
            this.mniBezier3Puntos,
            this.mniBezier4Puntos});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1200, 33);
            this.mnuPrincipal.TabIndex = 0;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mniBezier2Puntos
            // 
            this.mniBezier2Puntos.Name = "mniBezier2Puntos";
            this.mniBezier2Puntos.Size = new System.Drawing.Size(189, 29);
            this.mniBezier2Puntos.Text = "Curva Bézier 2 puntos";
            // 
            // mniBezier3Puntos
            // 
            this.mniBezier3Puntos.Name = "mniBezier3Puntos";
            this.mniBezier3Puntos.Size = new System.Drawing.Size(189, 29);
            this.mniBezier3Puntos.Text = "Curva Bézier 3 puntos";
            // 
            // mniBezier4Puntos
            // 
            this.mniBezier4Puntos.Name = "mniBezier4Puntos";
            this.mniBezier4Puntos.Size = new System.Drawing.Size(189, 29);
            this.mniBezier4Puntos.Text = "Curva Bézier 4 puntos";
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.mnuPrincipal);
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curvas de Bézier - Algoritmo De Casteljau";
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mniBezier2Puntos;
        private System.Windows.Forms.ToolStripMenuItem mniBezier3Puntos;
        private System.Windows.Forms.ToolStripMenuItem mniBezier4Puntos;
    }
}

