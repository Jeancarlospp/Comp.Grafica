namespace AlgoritmosClasicos.UI.Forms
{
    partial class frmLineDrawing
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.grpStepByStep = new System.Windows.Forms.GroupBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.grpEndPoint = new System.Windows.Forms.GroupBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.lblY2 = new System.Windows.Forms.Label();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.lblX2 = new System.Windows.Forms.Label();
            this.grpStartPoint = new System.Windows.Forms.GroupBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.lblY1 = new System.Windows.Forms.Label();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.lblX1 = new System.Windows.Forms.Label();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.pctCanvas = new System.Windows.Forms.PictureBox();
            this.pnlCoordinates = new System.Windows.Forms.Panel();
            this.lstCoordinates = new System.Windows.Forms.ListBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            this.grpStepByStep.SuspendLayout();
            this.grpAlgorithm.SuspendLayout();
            this.grpEndPoint.SuspendLayout();
            this.grpStartPoint.SuspendLayout();
            this.pnlCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).BeginInit();
            this.pnlCoordinates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlControls.Controls.Add(this.grpStepByStep);
            this.pnlControls.Controls.Add(this.grpAlgorithm);
            this.pnlControls.Controls.Add(this.grpEndPoint);
            this.pnlControls.Controls.Add(this.grpStartPoint);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(10);
            this.pnlControls.Size = new System.Drawing.Size(1200, 180);
            this.pnlControls.TabIndex = 0;
            // 
            // grpStepByStep
            // 
            this.grpStepByStep.Controls.Add(this.btnLast);
            this.grpStepByStep.Controls.Add(this.btnFirst);
            this.grpStepByStep.Controls.Add(this.btnNext);
            this.grpStepByStep.Controls.Add(this.btnPrevious);
            this.grpStepByStep.Controls.Add(this.btnReset);
            this.grpStepByStep.Location = new System.Drawing.Point(780, 20);
            this.grpStepByStep.Name = "grpStepByStep";
            this.grpStepByStep.Size = new System.Drawing.Size(400, 145);
            this.grpStepByStep.TabIndex = 3;
            this.grpStepByStep.TabStop = false;
            this.grpStepByStep.Text = "Control Paso a Paso";
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(209, 100);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(170, 30);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = "Ultimo";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(20, 100);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(170, 30);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "Primero";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(209, 60);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(170, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Siguiente";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(20, 60);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(170, 30);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Anterior";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(20, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(359, 30);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reiniciar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.Controls.Add(this.btnDraw);
            this.grpAlgorithm.Controls.Add(this.cmbAlgorithm);
            this.grpAlgorithm.Controls.Add(this.lblAlgorithm);
            this.grpAlgorithm.Location = new System.Drawing.Point(400, 20);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(360, 145);
            this.grpAlgorithm.TabIndex = 2;
            this.grpAlgorithm.TabStop = false;
            this.grpAlgorithm.Text = "Algoritmo";
            // 
            // btnDraw
            // 
            this.btnDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraw.ForeColor = System.Drawing.Color.White;
            this.btnDraw.Location = new System.Drawing.Point(20, 90);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(320, 40);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "Dibujar Linea";
            this.btnDraw.UseVisualStyleBackColor = false;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Location = new System.Drawing.Point(20, 55);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(320, 25);
            this.cmbAlgorithm.TabIndex = 1;
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(16, 30);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(151, 17);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Seleccionar algoritmo:";
            // 
            // grpEndPoint
            // 
            this.grpEndPoint.Controls.Add(this.txtY2);
            this.grpEndPoint.Controls.Add(this.lblY2);
            this.grpEndPoint.Controls.Add(this.txtX2);
            this.grpEndPoint.Controls.Add(this.lblX2);
            this.grpEndPoint.Location = new System.Drawing.Point(205, 20);
            this.grpEndPoint.Name = "grpEndPoint";
            this.grpEndPoint.Size = new System.Drawing.Size(175, 145);
            this.grpEndPoint.TabIndex = 1;
            this.grpEndPoint.TabStop = false;
            this.grpEndPoint.Text = "Punto Final";
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(50, 95);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(100, 23);
            this.txtY2.TabIndex = 3;
            this.txtY2.Text = "80";
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(15, 98);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(29, 17);
            this.lblY2.TabIndex = 2;
            this.lblY2.Text = "Y2:";
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(50, 50);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(100, 23);
            this.txtX2.TabIndex = 1;
            this.txtX2.Text = "100";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(15, 53);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(29, 17);
            this.lblX2.TabIndex = 0;
            this.lblX2.Text = "X2:";
            // 
            // grpStartPoint
            // 
            this.grpStartPoint.Controls.Add(this.txtY1);
            this.grpStartPoint.Controls.Add(this.lblY1);
            this.grpStartPoint.Controls.Add(this.txtX1);
            this.grpStartPoint.Controls.Add(this.lblX1);
            this.grpStartPoint.Location = new System.Drawing.Point(20, 20);
            this.grpStartPoint.Name = "grpStartPoint";
            this.grpStartPoint.Size = new System.Drawing.Size(175, 145);
            this.grpStartPoint.TabIndex = 0;
            this.grpStartPoint.TabStop = false;
            this.grpStartPoint.Text = "Punto Inicial";
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(50, 95);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(100, 23);
            this.txtY1.TabIndex = 3;
            this.txtY1.Text = "20";
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(15, 98);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(29, 17);
            this.lblY1.TabIndex = 2;
            this.lblY1.Text = "Y1:";
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(50, 50);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(100, 23);
            this.txtX1.TabIndex = 1;
            this.txtX1.Text = "10";
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(15, 53);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(29, 17);
            this.lblX1.TabIndex = 0;
            this.lblX1.Text = "X1:";
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanvas.Controls.Add(this.pctCanvas);
            this.pnlCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCanvas.Location = new System.Drawing.Point(0, 180);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCanvas.Size = new System.Drawing.Size(950, 490);
            this.pnlCanvas.TabIndex = 1;
            // 
            // pctCanvas
            // 
            this.pctCanvas.BackColor = System.Drawing.Color.White;
            this.pctCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctCanvas.Location = new System.Drawing.Point(10, 10);
            this.pctCanvas.Name = "pctCanvas";
            this.pctCanvas.Size = new System.Drawing.Size(928, 468);
            this.pctCanvas.TabIndex = 0;
            this.pctCanvas.TabStop = false;
            // 
            // pnlCoordinates
            // 
            this.pnlCoordinates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlCoordinates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCoordinates.Controls.Add(this.lstCoordinates);
            this.pnlCoordinates.Controls.Add(this.lblCoordinates);
            this.pnlCoordinates.Controls.Add(this.lblStatus);
            this.pnlCoordinates.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCoordinates.Location = new System.Drawing.Point(950, 180);
            this.pnlCoordinates.Name = "pnlCoordinates";
            this.pnlCoordinates.Size = new System.Drawing.Size(250, 490);
            this.pnlCoordinates.TabIndex = 2;
            // 
            // lstCoordinates
            // 
            this.lstCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCoordinates.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCoordinates.FormattingEnabled = true;
            this.lstCoordinates.ItemHeight = 14;
            this.lstCoordinates.Location = new System.Drawing.Point(10, 80);
            this.lstCoordinates.Name = "lstCoordinates";
            this.lstCoordinates.Size = new System.Drawing.Size(228, 382);
            this.lstCoordinates.TabIndex = 2;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinates.Location = new System.Drawing.Point(10, 10);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(185, 17);
            this.lblCoordinates.TabIndex = 0;
            this.lblCoordinates.Text = "Coordenadas de Puntos";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(10, 40);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(139, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Sin puntos cargados";
            // 
            // frmLineDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 670);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.pnlCoordinates);
            this.Controls.Add(this.pnlControls);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmLineDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trazado de Líneas - Algoritmos de Computación Gráfica";
            this.pnlControls.ResumeLayout(false);
            this.grpStepByStep.ResumeLayout(false);
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            this.grpEndPoint.ResumeLayout(false);
            this.grpEndPoint.PerformLayout();
            this.grpStartPoint.ResumeLayout(false);
            this.grpStartPoint.PerformLayout();
            this.pnlCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).EndInit();
            this.pnlCoordinates.ResumeLayout(false);
            this.pnlCoordinates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox grpStartPoint;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.GroupBox grpEndPoint;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.PictureBox pctCanvas;
        private System.Windows.Forms.Panel pnlCoordinates;
        private System.Windows.Forms.ListBox lstCoordinates;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.GroupBox grpStepByStep;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
    }
}
