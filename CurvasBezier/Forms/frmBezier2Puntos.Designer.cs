using System;
using System.Windows.Forms;

namespace CurvasBezier.Forms
{
    partial class frmBezier2Puntos
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
            this.pnlControles = new System.Windows.Forms.Panel();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblParametro = new System.Windows.Forms.Label();
            this.trkParametro = new System.Windows.Forms.TrackBar();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pctCanvasCurva = new System.Windows.Forms.PictureBox();
            this.tmrAnimacion = new System.Windows.Forms.Timer(this.components);
            this.pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkParametro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvasCurva)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControles
            // 
            this.pnlControles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControles.Controls.Add(this.btnReiniciar);
            this.pnlControles.Controls.Add(this.btnPlay);
            this.pnlControles.Controls.Add(this.lblParametro);
            this.pnlControles.Controls.Add(this.trkParametro);
            this.pnlControles.Controls.Add(this.lblTitulo);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1000, 120);
            this.pnlControles.TabIndex = 0;
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(850, 65);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(120, 40);
            this.btnReiniciar.TabIndex = 4;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(700, 65);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(120, 40);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "? Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblParametro
            // 
            this.lblParametro.AutoSize = true;
            this.lblParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametro.Location = new System.Drawing.Point(20, 65);
            this.lblParametro.Name = "lblParametro";
            this.lblParametro.Size = new System.Drawing.Size(121, 20);
            this.lblParametro.TabIndex = 2;
            this.lblParametro.Text = "Parámetro t: 0";
            // 
            // trkParametro
            // 
            this.trkParametro.Location = new System.Drawing.Point(160, 60);
            this.trkParametro.Maximum = 100;
            this.trkParametro.Name = "trkParametro";
            this.trkParametro.Size = new System.Drawing.Size(500, 69);
            this.trkParametro.TabIndex = 1;
            this.trkParametro.TickFrequency = 5;
            this.trkParametro.Scroll += new System.EventHandler(this.trkParametro_Scroll);
            this.trkParametro.ValueChanged += new System.EventHandler(this.trkParametro_ValueChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(494, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Curva de Bézier - 2 Puntos de Control";
            // 
            // pctCanvasCurva
            // 
            this.pctCanvasCurva.BackColor = System.Drawing.Color.White;
            this.pctCanvasCurva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctCanvasCurva.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctCanvasCurva.Location = new System.Drawing.Point(0, 120);
            this.pctCanvasCurva.Name = "pctCanvasCurva";
            this.pctCanvasCurva.Size = new System.Drawing.Size(1000, 580);
            this.pctCanvasCurva.TabIndex = 1;
            this.pctCanvasCurva.TabStop = false;
            this.pctCanvasCurva.Paint += new System.Windows.Forms.PaintEventHandler(this.pctCanvasCurva_Paint);
            this.pctCanvasCurva.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctCanvasCurva_MouseClick);
            // 
            // tmrAnimacion
            // 
            this.tmrAnimacion.Interval = 30;
            this.tmrAnimacion.Tick += new System.EventHandler(this.tmrAnimacion_Tick);
            // 
            // frmBezier2Puntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pctCanvasCurva);
            this.Controls.Add(this.pnlControles);
            this.Name = "frmBezier2Puntos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curva de Bézier - 2 Puntos";
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkParametro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvasCurva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.PictureBox pctCanvasCurva;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TrackBar trkParametro;
        private System.Windows.Forms.Label lblParametro;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Timer tmrAnimacion;
    }
}
