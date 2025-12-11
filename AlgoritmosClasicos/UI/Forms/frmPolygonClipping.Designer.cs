namespace AlgoritmosClasicos.UI.Forms
{
    partial class frmPolygonClipping
    {
        private System.ComponentModel.IContainer components = null;

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
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.btnAplicarRecorte = new System.Windows.Forms.Button();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.grpClipWindow = new System.Windows.Forms.GroupBox();
            this.lblWindowInfo = new System.Windows.Forms.Label();
            this.grpShapeSelector = new System.Windows.Forms.GroupBox();
            this.rbTriangle = new System.Windows.Forms.RadioButton();
            this.rbRectangle = new System.Windows.Forms.RadioButton();
            this.grpDrawing = new System.Windows.Forms.GroupBox();
            this.btnCerrarPoligono = new System.Windows.Forms.Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.pctCanvas = new System.Windows.Forms.PictureBox();
            this.pnlCoordinates = new System.Windows.Forms.Panel();
            this.lstCoordinates = new System.Windows.Forms.ListBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            this.grpAlgorithm.SuspendLayout();
            this.grpClipWindow.SuspendLayout();
            this.grpShapeSelector.SuspendLayout();
            this.grpDrawing.SuspendLayout();
            this.pnlCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).BeginInit();
            this.pnlCoordinates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlControls.Controls.Add(this.grpAlgorithm);
            this.pnlControls.Controls.Add(this.grpClipWindow);
            this.pnlControls.Controls.Add(this.grpDrawing);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(10);
            this.pnlControls.Size = new System.Drawing.Size(1200, 180);
            this.pnlControls.TabIndex = 0;
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.Controls.Add(this.btnAplicarRecorte);
            this.grpAlgorithm.Controls.Add(this.cmbAlgorithm);
            this.grpAlgorithm.Controls.Add(this.lblAlgorithm);
            this.grpAlgorithm.Location = new System.Drawing.Point(780, 20);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(400, 145);
            this.grpAlgorithm.TabIndex = 2;
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
            this.btnAplicarRecorte.Size = new System.Drawing.Size(360, 40);
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
            this.cmbAlgorithm.Size = new System.Drawing.Size(360, 25);
            this.cmbAlgorithm.TabIndex = 1;
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);
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
            // grpClipWindow
            // 
            this.grpClipWindow.Controls.Add(this.grpShapeSelector);
            this.grpClipWindow.Controls.Add(this.lblWindowInfo);
            this.grpClipWindow.Location = new System.Drawing.Point(400, 20);
            this.grpClipWindow.Name = "grpClipWindow";
            this.grpClipWindow.Size = new System.Drawing.Size(360, 145);
            this.grpClipWindow.TabIndex = 1;
            this.grpClipWindow.TabStop = false;
            this.grpClipWindow.Text = "Ventana de Recorte";
            // 
            // grpShapeSelector
            // 
            this.grpShapeSelector.Controls.Add(this.rbTriangle);
            this.grpShapeSelector.Controls.Add(this.rbRectangle);
            this.grpShapeSelector.Location = new System.Drawing.Point(200, 30);
            this.grpShapeSelector.Name = "grpShapeSelector";
            this.grpShapeSelector.Size = new System.Drawing.Size(145, 100);
            this.grpShapeSelector.TabIndex = 2;
            this.grpShapeSelector.TabStop = false;
            this.grpShapeSelector.Text = "Forma";
            this.grpShapeSelector.Visible = false;
            // 
            // rbRectangle
            // 
            this.rbRectangle.AutoSize = true;
            this.rbRectangle.Checked = true;
            this.rbRectangle.Location = new System.Drawing.Point(15, 30);
            this.rbRectangle.Name = "rbRectangle";
            this.rbRectangle.Size = new System.Drawing.Size(97, 21);
            this.rbRectangle.TabIndex = 0;
            this.rbRectangle.TabStop = true;
            this.rbRectangle.Text = "Rectángulo";
            this.rbRectangle.UseVisualStyleBackColor = true;
            this.rbRectangle.CheckedChanged += new System.EventHandler(this.rbShape_CheckedChanged);
            // 
            // rbTriangle
            // 
            this.rbTriangle.AutoSize = true;
            this.rbTriangle.Location = new System.Drawing.Point(15, 60);
            this.rbTriangle.Name = "rbTriangle";
            this.rbTriangle.Size = new System.Drawing.Size(85, 21);
            this.rbTriangle.TabIndex = 1;
            this.rbTriangle.Text = "Triángulo";
            this.rbTriangle.UseVisualStyleBackColor = true;
            this.rbTriangle.CheckedChanged += new System.EventHandler(this.rbShape_CheckedChanged);
            // 
            // lblWindowInfo
            // 
            this.lblWindowInfo.Location = new System.Drawing.Point(20, 35);
            this.lblWindowInfo.Name = "lblWindowInfo";
            this.lblWindowInfo.Size = new System.Drawing.Size(165, 95);
            this.lblWindowInfo.TabIndex = 0;
            this.lblWindowInfo.Text = "Rectangulo:\r\nX: 30 - 120\r\nY: 20 - 60\r\n\r\nTriangulo:\r\nV1: (30,20)\r\nV2: (75,70)\r\nV3: (120,20)";
            // 
            // grpDrawing
            // 
            this.grpDrawing.Controls.Add(this.btnCerrarPoligono);
            this.grpDrawing.Controls.Add(this.lblInstructions);
            this.grpDrawing.Controls.Add(this.btnClear);
            this.grpDrawing.Location = new System.Drawing.Point(20, 20);
            this.grpDrawing.Name = "grpDrawing";
            this.grpDrawing.Size = new System.Drawing.Size(360, 145);
            this.grpDrawing.TabIndex = 0;
            this.grpDrawing.TabStop = false;
            this.grpDrawing.Text = "Dibujo de Poligono";
            // 
            // btnCerrarPoligono
            // 
            this.btnCerrarPoligono.Location = new System.Drawing.Point(180, 105);
            this.btnCerrarPoligono.Name = "btnCerrarPoligono";
            this.btnCerrarPoligono.Size = new System.Drawing.Size(160, 30);
            this.btnCerrarPoligono.TabIndex = 2;
            this.btnCerrarPoligono.Text = "Cerrar Poligono";
            this.btnCerrarPoligono.UseVisualStyleBackColor = true;
            this.btnCerrarPoligono.Click += new System.EventHandler(this.btnCerrarPoligono_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.Location = new System.Drawing.Point(15, 30);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(330, 65);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "1. Click en vertices del poligono\r\n2. Click Cerrar Poligono\r\n3. Seleccionar algoritmo\r\n4. Click Aplicar Recorte";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(20, 105);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 30);
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
            this.lblCoordinates.Size = new System.Drawing.Size(168, 17);
            this.lblCoordinates.TabIndex = 0;
            this.lblCoordinates.Text = "Poligono Resultante";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(10, 40);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(135, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Dibuje un poligono";
            // 
            // frmPolygonClipping
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
            this.Name = "frmPolygonClipping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recorte de Poligonos - Algoritmos de Computacion Grafica";
            this.pnlControls.ResumeLayout(false);
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            this.grpClipWindow.ResumeLayout(false);
            this.grpShapeSelector.ResumeLayout(false);
            this.grpShapeSelector.PerformLayout();
            this.grpDrawing.ResumeLayout(false);
            this.pnlCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctCanvas)).BeginInit();
            this.pnlCoordinates.ResumeLayout(false);
            this.pnlCoordinates.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox grpDrawing;
        private System.Windows.Forms.Button btnCerrarPoligono;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpClipWindow;
        private System.Windows.Forms.GroupBox grpShapeSelector;
        private System.Windows.Forms.RadioButton rbTriangle;
        private System.Windows.Forms.RadioButton rbRectangle;
        private System.Windows.Forms.Label lblWindowInfo;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.Button btnAplicarRecorte;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.PictureBox pctCanvas;
        private System.Windows.Forms.Panel pnlCoordinates;
        private System.Windows.Forms.ListBox lstCoordinates;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label lblStatus;
    }
}
