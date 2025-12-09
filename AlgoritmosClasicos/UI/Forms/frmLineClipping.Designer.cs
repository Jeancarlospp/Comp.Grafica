namespace AlgoritmosClasicos.UI.Forms
{
    partial class frmLineClipping
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlControls = new System.Windows.Forms.Panel();
            this.grpClipWindow = new System.Windows.Forms.GroupBox();
            this.txtYMax = new System.Windows.Forms.TextBox();
            this.lblYMax = new System.Windows.Forms.Label();
            this.txtXMax = new System.Windows.Forms.TextBox();
            this.lblXMax = new System.Windows.Forms.Label();
            this.txtYMin = new System.Windows.Forms.TextBox();
            this.lblYMin = new System.Windows.Forms.Label();
            this.txtXMin = new System.Windows.Forms.TextBox();
            this.lblXMin = new System.Windows.Forms.Label();
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.btnAplicarRecorte = new System.Windows.Forms.Button();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.grpDrawing = new System.Windows.Forms.GroupBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.pctCanvas = new System.Windows.Forms.PictureBox();
            this.pnlCoordinates = new System.Windows.Forms.Panel();
            this.lstCoordinates = new System.Windows.Forms.ListBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            this.grpClipWindow.SuspendLayout();
            this.grpAlgorithm.SuspendLayout();
            this.grpDrawing.SuspendLayout();
            this.pnlCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).BeginInit();
            this.pnlCoordinates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlControls.Controls.Add(this.grpClipWindow);
            this.pnlControls.Controls.Add(this.grpAlgorithm);
            this.pnlControls.Controls.Add(this.grpDrawing);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(10);
            this.pnlControls.Size = new System.Drawing.Size(1200, 180);
            this.pnlControls.TabIndex = 0;
            // 
            // grpClipWindow
            // 
            this.grpClipWindow.Controls.Add(this.txtYMax);
            this.grpClipWindow.Controls.Add(this.lblYMax);
            this.grpClipWindow.Controls.Add(this.txtXMax);
            this.grpClipWindow.Controls.Add(this.lblXMax);
            this.grpClipWindow.Controls.Add(this.txtYMin);
            this.grpClipWindow.Controls.Add(this.lblYMin);
            this.grpClipWindow.Controls.Add(this.txtXMin);
            this.grpClipWindow.Controls.Add(this.lblXMin);
            this.grpClipWindow.Location = new System.Drawing.Point(780, 20);
            this.grpClipWindow.Name = "grpClipWindow";
            this.grpClipWindow.Size = new System.Drawing.Size(400, 145);
            this.grpClipWindow.TabIndex = 2;
            this.grpClipWindow.TabStop = false;
            this.grpClipWindow.Text = "Ventana de Recorte";
            // 
            // txtYMax
            // 
            this.txtYMax.Location = new System.Drawing.Point(280, 100);
            this.txtYMax.Name = "txtYMax";
            this.txtYMax.Size = new System.Drawing.Size(100, 23);
            this.txtYMax.TabIndex = 7;
            this.txtYMax.Text = "60";
            // 
            // lblYMax
            // 
            this.lblYMax.AutoSize = true;
            this.lblYMax.Location = new System.Drawing.Point(215, 103);
            this.lblYMax.Name = "lblYMax";
            this.lblYMax.Size = new System.Drawing.Size(52, 17);
            this.lblYMax.TabIndex = 6;
            this.lblYMax.Text = "Y Max:";
            // 
            // txtXMax
            // 
            this.txtXMax.Location = new System.Drawing.Point(280, 60);
            this.txtXMax.Name = "txtXMax";
            this.txtXMax.Size = new System.Drawing.Size(100, 23);
            this.txtXMax.TabIndex = 5;
            this.txtXMax.Text = "120";
            // 
            // lblXMax
            // 
            this.lblXMax.AutoSize = true;
            this.lblXMax.Location = new System.Drawing.Point(215, 63);
            this.lblXMax.Name = "lblXMax";
            this.lblXMax.Size = new System.Drawing.Size(53, 17);
            this.lblXMax.TabIndex = 4;
            this.lblXMax.Text = "X Max:";
            // 
            // txtYMin
            // 
            this.txtYMin.Location = new System.Drawing.Point(85, 100);
            this.txtYMin.Name = "txtYMin";
            this.txtYMin.Size = new System.Drawing.Size(100, 23);
            this.txtYMin.TabIndex = 3;
            this.txtYMin.Text = "20";
            // 
            // lblYMin
            // 
            this.lblYMin.AutoSize = true;
            this.lblYMin.Location = new System.Drawing.Point(25, 103);
            this.lblYMin.Name = "lblYMin";
            this.lblYMin.Size = new System.Drawing.Size(49, 17);
            this.lblYMin.TabIndex = 2;
            this.lblYMin.Text = "Y Min:";
            // 
            // txtXMin
            // 
            this.txtXMin.Location = new System.Drawing.Point(85, 60);
            this.txtXMin.Name = "txtXMin";
            this.txtXMin.Size = new System.Drawing.Size(100, 23);
            this.txtXMin.TabIndex = 1;
            this.txtXMin.Text = "30";
            // 
            // lblXMin
            // 
            this.lblXMin.AutoSize = true;
            this.lblXMin.Location = new System.Drawing.Point(25, 63);
            this.lblXMin.Name = "lblXMin";
            this.lblXMin.Size = new System.Drawing.Size(50, 17);
            this.lblXMin.TabIndex = 0;
            this.lblXMin.Text = "X Min:";
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.Controls.Add(this.btnAplicarRecorte);
            this.grpAlgorithm.Controls.Add(this.cmbAlgorithm);
            this.grpAlgorithm.Controls.Add(this.lblAlgorithm);
            this.grpAlgorithm.Location = new System.Drawing.Point(400, 20);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(360, 145);
            this.grpAlgorithm.TabIndex = 1;
            this.grpAlgorithm.TabStop = false;
            this.grpAlgorithm.Text = "Algoritmo de Recorte";
            // 
            // btnAplicarRecorte
            // 
            this.btnAplicarRecorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAplicarRecorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarRecorte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarRecorte.ForeColor = System.Drawing.Color.White;
            this.btnAplicarRecorte.Location = new System.Drawing.Point(20, 90);
            this.btnAplicarRecorte.Name = "btnAplicarRecorte";
            this.btnAplicarRecorte.Size = new System.Drawing.Size(320, 40);
            this.btnAplicarRecorte.TabIndex = 2;
            this.btnAplicarRecorte.Text = "Aplicar Recorte";
            this.btnAplicarRecorte.UseVisualStyleBackColor = false;
            this.btnAplicarRecorte.Click += new System.EventHandler(this.btnAplicarRecorte_Click);
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
            // grpDrawing
            // 
            this.grpDrawing.Controls.Add(this.lblInstructions);
            this.grpDrawing.Controls.Add(this.btnClear);
            this.grpDrawing.Location = new System.Drawing.Point(20, 20);
            this.grpDrawing.Name = "grpDrawing";
            this.grpDrawing.Size = new System.Drawing.Size(360, 145);
            this.grpDrawing.TabIndex = 0;
            this.grpDrawing.TabStop = false;
            this.grpDrawing.Text = "Dibujo de Lineas";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(15, 30);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(330, 70);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "1. Click para inicio de linea\r\n2. Click para fin de linea\r\n3. Configure ventana de recorte\r\n4. Seleccione algoritmo\r\n5. Click Aplicar Recorte";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(20, 105);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(320, 30);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Limpiar Canvas";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.pctCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pctCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctCanvas.Location = new System.Drawing.Point(10, 10);
            this.pctCanvas.Name = "pctCanvas";
            this.pctCanvas.Size = new System.Drawing.Size(928, 468);
            this.pctCanvas.TabIndex = 0;
            this.pctCanvas.TabStop = false;
            this.pctCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctCanvas_MouseClick);
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
            this.lblCoordinates.Text = "Lineas Recortadas";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(10, 40);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Dibuje una linea";
            // 
            // frmLineClipping
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
            this.Name = "frmLineClipping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recorte de Lineas - Algoritmos de Computacion Grafica";
            this.pnlControls.ResumeLayout(false);
            this.grpClipWindow.ResumeLayout(false);
            this.grpClipWindow.PerformLayout();
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            this.grpDrawing.ResumeLayout(false);
            this.pnlCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).EndInit();
            this.pnlCoordinates.ResumeLayout(false);
            this.pnlCoordinates.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox grpDrawing;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.Button btnAplicarRecorte;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.GroupBox grpClipWindow;
        private System.Windows.Forms.TextBox txtYMax;
        private System.Windows.Forms.Label lblYMax;
        private System.Windows.Forms.TextBox txtXMax;
        private System.Windows.Forms.Label lblXMax;
        private System.Windows.Forms.TextBox txtYMin;
        private System.Windows.Forms.Label lblYMin;
        private System.Windows.Forms.TextBox txtXMin;
        private System.Windows.Forms.Label lblXMin;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.PictureBox pctCanvas;
        private System.Windows.Forms.Panel pnlCoordinates;
        private System.Windows.Forms.ListBox lstCoordinates;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label lblStatus;
    }
}
