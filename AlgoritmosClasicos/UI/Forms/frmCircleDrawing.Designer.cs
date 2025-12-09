namespace AlgoritmosClasicos.UI.Forms
{
    partial class frmCircleDrawing
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
            this.grpCircleParams = new System.Windows.Forms.GroupBox();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.txtCenterY = new System.Windows.Forms.TextBox();
            this.lblCenterY = new System.Windows.Forms.Label();
            this.txtCenterX = new System.Windows.Forms.TextBox();
            this.lblCenterX = new System.Windows.Forms.Label();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.pctCanvas = new System.Windows.Forms.PictureBox();
            this.pnlCoordinates = new System.Windows.Forms.Panel();
            this.lstCoordinates = new System.Windows.Forms.ListBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            this.grpStepByStep.SuspendLayout();
            this.grpAlgorithm.SuspendLayout();
            this.grpCircleParams.SuspendLayout();
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
            this.pnlControls.Controls.Add(this.grpCircleParams);
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
            this.grpStepByStep.TabIndex = 2;
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
            this.grpAlgorithm.TabIndex = 1;
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
            this.btnDraw.Text = "Dibujar Circulo";
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
            // grpCircleParams
            // 
            this.grpCircleParams.Controls.Add(this.txtRadius);
            this.grpCircleParams.Controls.Add(this.lblRadius);
            this.grpCircleParams.Controls.Add(this.txtCenterY);
            this.grpCircleParams.Controls.Add(this.lblCenterY);
            this.grpCircleParams.Controls.Add(this.txtCenterX);
            this.grpCircleParams.Controls.Add(this.lblCenterX);
            this.grpCircleParams.Location = new System.Drawing.Point(20, 20);
            this.grpCircleParams.Name = "grpCircleParams";
            this.grpCircleParams.Size = new System.Drawing.Size(360, 145);
            this.grpCircleParams.TabIndex = 0;
            this.grpCircleParams.TabStop = false;
            this.grpCircleParams.Text = "Parametros del Circulo";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(240, 95);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(100, 23);
            this.txtRadius.TabIndex = 5;
            this.txtRadius.Text = "30";
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(180, 98);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(50, 17);
            this.lblRadius.TabIndex = 4;
            this.lblRadius.Text = "Radio:";
            // 
            // txtCenterY
            // 
            this.txtCenterY.Location = new System.Drawing.Point(240, 50);
            this.txtCenterY.Name = "txtCenterY";
            this.txtCenterY.Size = new System.Drawing.Size(100, 23);
            this.txtCenterY.TabIndex = 3;
            this.txtCenterY.Text = "40";
            // 
            // lblCenterY
            // 
            this.lblCenterY.AutoSize = true;
            this.lblCenterY.Location = new System.Drawing.Point(180, 53);
            this.lblCenterY.Name = "lblCenterY";
            this.lblCenterY.Size = new System.Drawing.Size(51, 17);
            this.lblCenterY.TabIndex = 2;
            this.lblCenterY.Text = "Y Centro:";
            // 
            // txtCenterX
            // 
            this.txtCenterX.Location = new System.Drawing.Point(70, 50);
            this.txtCenterX.Name = "txtCenterX";
            this.txtCenterX.Size = new System.Drawing.Size(100, 23);
            this.txtCenterX.TabIndex = 1;
            this.txtCenterX.Text = "75";
            // 
            // lblCenterX
            // 
            this.lblCenterX.AutoSize = true;
            this.lblCenterX.Location = new System.Drawing.Point(15, 53);
            this.lblCenterX.Name = "lblCenterX";
            this.lblCenterX.Size = new System.Drawing.Size(49, 17);
            this.lblCenterX.TabIndex = 0;
            this.lblCenterX.Text = "X Centro:";
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
            // frmCircleDrawing
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
            this.Name = "frmCircleDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trazado de Circulos - Algoritmos de Computacion Grafica";
            this.pnlControls.ResumeLayout(false);
            this.grpStepByStep.ResumeLayout(false);
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            this.grpCircleParams.ResumeLayout(false);
            this.grpCircleParams.PerformLayout();
            this.pnlCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).EndInit();
            this.pnlCoordinates.ResumeLayout(false);
            this.pnlCoordinates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox grpCircleParams;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.TextBox txtCenterY;
        private System.Windows.Forms.Label lblCenterY;
        private System.Windows.Forms.TextBox txtCenterX;
        private System.Windows.Forms.Label lblCenterX;
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
