namespace AccDataGenerator
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.chbZ = new System.Windows.Forms.CheckBox();
            this.chbY = new System.Windows.Forms.CheckBox();
            this.chbX = new System.Windows.Forms.CheckBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.scatterGraph1 = new NationalInstruments.UI.WindowsForms.ScatterGraph();
            this.xyPointAnnotation1 = new NationalInstruments.UI.XYPointAnnotation();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.scatterPlot1 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot2 = new NationalInstruments.UI.ScatterPlot();
            this.scatterPlot3 = new NationalInstruments.UI.ScatterPlot();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.chbZ);
            this.panel1.Controls.Add(this.chbY);
            this.panel1.Controls.Add(this.chbX);
            this.panel1.Controls.Add(this.btnLoadFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(828, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 601);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(18, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chbZ
            // 
            this.chbZ.AutoSize = true;
            this.chbZ.Location = new System.Drawing.Point(135, 96);
            this.chbZ.Name = "chbZ";
            this.chbZ.Size = new System.Drawing.Size(33, 17);
            this.chbZ.TabIndex = 3;
            this.chbZ.Text = "Z";
            this.chbZ.UseVisualStyleBackColor = true;
            this.chbZ.CheckedChanged += new System.EventHandler(this.chbZ_CheckedChanged);
            // 
            // chbY
            // 
            this.chbY.AutoSize = true;
            this.chbY.Location = new System.Drawing.Point(75, 96);
            this.chbY.Name = "chbY";
            this.chbY.Size = new System.Drawing.Size(33, 17);
            this.chbY.TabIndex = 2;
            this.chbY.Text = "Y";
            this.chbY.UseVisualStyleBackColor = true;
            this.chbY.CheckedChanged += new System.EventHandler(this.chbY_CheckedChanged);
            // 
            // chbX
            // 
            this.chbX.AutoSize = true;
            this.chbX.Location = new System.Drawing.Point(18, 96);
            this.chbX.Name = "chbX";
            this.chbX.Size = new System.Drawing.Size(33, 17);
            this.chbX.TabIndex = 1;
            this.chbX.Text = "X";
            this.chbX.UseVisualStyleBackColor = true;
            this.chbX.CheckedChanged += new System.EventHandler(this.chbX_CheckedChanged);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(18, 12);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(150, 23);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // scatterGraph1
            // 
            this.scatterGraph1.Annotations.AddRange(new NationalInstruments.UI.XYAnnotation[] {
            this.xyPointAnnotation1});
            this.scatterGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterGraph1.InteractionMode = ((NationalInstruments.UI.GraphInteractionModes)((((((((NationalInstruments.UI.GraphInteractionModes.ZoomX | NationalInstruments.UI.GraphInteractionModes.ZoomY) 
            | NationalInstruments.UI.GraphInteractionModes.ZoomAroundPoint) 
            | NationalInstruments.UI.GraphInteractionModes.PanX) 
            | NationalInstruments.UI.GraphInteractionModes.PanY) 
            | NationalInstruments.UI.GraphInteractionModes.DragCursor) 
            | NationalInstruments.UI.GraphInteractionModes.DragAnnotationCaption) 
            | NationalInstruments.UI.GraphInteractionModes.EditRange)));
            this.scatterGraph1.Location = new System.Drawing.Point(0, 0);
            this.scatterGraph1.Name = "scatterGraph1";
            this.scatterGraph1.Plots.AddRange(new NationalInstruments.UI.ScatterPlot[] {
            this.scatterPlot1,
            this.scatterPlot2,
            this.scatterPlot3});
            this.scatterGraph1.Size = new System.Drawing.Size(828, 601);
            this.scatterGraph1.TabIndex = 1;
            this.scatterGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.scatterGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            this.scatterGraph1.PlotAreaMouseMove += new System.Windows.Forms.MouseEventHandler(this.scatterGraph1_PlotAreaMouseMove);
            this.scatterGraph1.PlotAreaMouseUp += new System.Windows.Forms.MouseEventHandler(this.scatterGraph1_PlotAreaMouseUp);
            this.scatterGraph1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scatterGraph1_MouseDown);
            // 
            // xyPointAnnotation1
            // 
            this.xyPointAnnotation1.ArrowHeadStyle = NationalInstruments.UI.ArrowStyle.None;
            this.xyPointAnnotation1.ArrowLineStyle = NationalInstruments.UI.LineStyle.None;
            this.xyPointAnnotation1.Caption = "xyPointAnnotation1";
            this.xyPointAnnotation1.CaptionAlignment = new NationalInstruments.UI.AnnotationCaptionAlignment(NationalInstruments.UI.BoundsAlignment.None, 0F, 25F);
            this.xyPointAnnotation1.XAxis = this.xAxis1;
            this.xyPointAnnotation1.XPosition = 1D;
            this.xyPointAnnotation1.YAxis = this.yAxis1;
            this.xyPointAnnotation1.YPosition = 9D;
            // 
            // xAxis1
            // 
            this.xAxis1.AutoMinorDivisionFrequency = 5;
            this.xAxis1.Caption = "Time";
            this.xAxis1.MajorDivisions.GridVisible = true;
            this.xAxis1.MinorDivisions.GridVisible = true;
            // 
            // yAxis1
            // 
            this.yAxis1.AutoMinorDivisionFrequency = 5;
            this.yAxis1.Caption = "Amplitude";
            this.yAxis1.MajorDivisions.GridVisible = true;
            this.yAxis1.MinorDivisions.GridVisible = true;
            // 
            // scatterPlot1
            // 
            this.scatterPlot1.LineColor = System.Drawing.Color.Red;
            this.scatterPlot1.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.scatterPlot1.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.scatterPlot1.PointSize = new System.Drawing.Size(4, 4);
            this.scatterPlot1.PointStyle = NationalInstruments.UI.PointStyle.EmptyCircle;
            this.scatterPlot1.XAxis = this.xAxis1;
            this.scatterPlot1.YAxis = this.yAxis1;
            // 
            // scatterPlot2
            // 
            this.scatterPlot2.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.scatterPlot2.PointSize = new System.Drawing.Size(4, 4);
            this.scatterPlot2.PointStyle = NationalInstruments.UI.PointStyle.EmptyCircle;
            this.scatterPlot2.XAxis = this.xAxis1;
            this.scatterPlot2.YAxis = this.yAxis1;
            // 
            // scatterPlot3
            // 
            this.scatterPlot3.LineColor = System.Drawing.Color.Cyan;
            this.scatterPlot3.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.scatterPlot3.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.scatterPlot3.PointSize = new System.Drawing.Size(4, 4);
            this.scatterPlot3.PointStyle = NationalInstruments.UI.PointStyle.EmptyCircle;
            this.scatterPlot3.XAxis = this.xAxis1;
            this.scatterPlot3.YAxis = this.yAxis1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.scatterGraph1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scatterGraph1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadFile;
        private NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph1;
        private NationalInstruments.UI.ScatterPlot scatterPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.ScatterPlot scatterPlot2;
        private NationalInstruments.UI.ScatterPlot scatterPlot3;
        private System.Windows.Forms.CheckBox chbZ;
        private System.Windows.Forms.CheckBox chbY;
        private System.Windows.Forms.CheckBox chbX;
        private NationalInstruments.UI.XYPointAnnotation xyPointAnnotation1;
        private System.Windows.Forms.Button btnExport;
    }
}

