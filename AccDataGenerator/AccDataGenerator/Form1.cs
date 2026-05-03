using NationalInstruments.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AccDataGenerator
{
    

    public partial class Form1 : Form
    {
        private enum AxisType
        {
            None,
            X,
            Y,
            Z
        }

        private AxisType activeAxis = AxisType.None;

        private double[] plotXArray;
        private double[] plotYArray;
        private double[] plotZArray;
        private double[] plotTimeArray;


        public List<AccelData> DataList { get; private set; } = new List<AccelData>();
        private List<string> originalHeaderLines = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadAccelData(ofd.FileName);
                    chbX.Checked = true;
                    chbY.Checked = true;
                    chbZ.Checked = true;
                    MessageBox.Show($"Loaded {DataList.Count} rows successfully.");
                }
            }

            
        }

        private void LoadAccelData(string filePath)
        {
            DataList.Clear();
            originalHeaderLines.Clear();

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (line.StartsWith("time", StringComparison.OrdinalIgnoreCase))
                {
                    originalHeaderLines.Add(line);
                    continue;
                }

                if (line.Length == 0 || line.Contains("Trigger Time"))
                {
                    originalHeaderLines.Add(line);
                    continue;
                }

                // Split using comma as delimiter (CSV format)
                var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4)
                    continue;

                try
                {
                    var data = new AccelData
                    {
                        Time = double.Parse(parts[0], CultureInfo.InvariantCulture),
                        X = double.Parse(parts[1], CultureInfo.InvariantCulture),
                        Y = double.Parse(parts[2], CultureInfo.InvariantCulture),
                        Z = double.Parse(parts[3], CultureInfo.InvariantCulture)
                    };
                    DataList.Add(data);
                }
                catch
                {
                    // Skip invalid lines
                    continue;
                }
            }

            // Convert list to arrays
            plotTimeArray = DataList.Select(d => d.Time).ToArray();
            plotXArray = DataList.Select(d => d.X).ToArray();
            plotYArray = DataList.Select(d => d.Y).ToArray();
            plotZArray = DataList.Select(d => d.Z).ToArray();

            scatterPlot1.PlotXY(plotTimeArray, plotXArray);
            scatterPlot2.PlotXY(plotTimeArray, plotYArray);
            scatterPlot3.PlotXY(plotTimeArray, plotZArray);
        }

        private void chbX_CheckedChanged(object sender, EventArgs e)
        {
             scatterPlot1.Visible = chbX.Checked;
        }

        private void chbY_CheckedChanged(object sender, EventArgs e)
        {
            scatterPlot2.Visible = chbY.Checked;
        }

        private void chbZ_CheckedChanged(object sender, EventArgs e)
        {
            scatterPlot3.Visible = chbZ.Checked;
        }

        private int selectedIndex = 0;
        private bool isDragging = false;
        private void scatterGraph1_MouseDown(object sender, MouseEventArgs e)
        {
            if (chbX.Checked)
                activeAxis = AxisType.X;
            else if (chbY.Checked)
                activeAxis = AxisType.Y;
            else if (chbZ.Checked)
                activeAxis = AxisType.Z;
            else
                activeAxis = AxisType.None;

            var hit = scatterGraph1.HitTest(e.X, e.Y);

            // Check that we clicked inside plot area
            if (hit == NationalInstruments.UI.XYGraphHitTestInfo.Plot || hit == NationalInstruments.UI.XYGraphHitTestInfo.PlotArea)
            {
                Rectangle plotArea = scatterGraph1.PlotAreaBounds;
                double xRatio = (e.X - plotArea.X) / (double)plotArea.Width;
                //double yRatio = (plotArea.Y + plotArea.Height - e.Y) / (double)plotArea.Height;

                double xMin = xAxis1.Range.Minimum;
                double xMax = xAxis1.Range.Maximum;
                //double yMin = yAxis1.Range.Minimum;
                //double yMax = yAxis1.Range.Maximum;

                double xValue = xMin + xRatio * (xMax - xMin);
                // find nearest point
                selectedIndex = FindNearestIndex(xValue);

                if (selectedIndex >= 0)
                {
                    isDragging = true;

                    double x = DataList[selectedIndex].Time;
                    double y = 0;
                    switch (activeAxis)
                    {
                        case AxisType.X:
                            y = DataList[selectedIndex].X;
                            break;
                        case AxisType.Y:
                            y = DataList[selectedIndex].Y;
                            break;
                        case AxisType.Z:
                            y = DataList[selectedIndex].Z;
                            break;
                        default:
                            break;
                    }

                    xyPointAnnotation1.SetPosition(x, y);
                    xyPointAnnotation1.Caption = $"({x:0.00},{y:0.00})";
                }
            }
        }

        private int FindNearestIndex(double xValue)
        {
            double minDist = double.MaxValue;
            int index = -1;

            for (int i = 0; i < DataList.Count; i++)
            {
                double d = Math.Abs(DataList[i].Time - xValue);

                if (d < minDist)
                {
                    minDist = d;
                    index = i;
                }
            }

            return index;
        }

        private void scatterGraph1_PlotAreaMouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging || selectedIndex < 0)
                return;

            Rectangle plotArea = scatterGraph1.PlotAreaBounds;

            double yRatio = (plotArea.Y + plotArea.Height - e.Y) / (double)plotArea.Height;

            double yMin = yAxis1.Range.Minimum;
            double yMax = yAxis1.Range.Maximum;

            double newY = yMin + yRatio * (yMax - yMin);

            switch (activeAxis)
            {
                case AxisType.X:
                    plotXArray[selectedIndex] = newY;
                    DataList[selectedIndex].X = newY;
                    break;

                case AxisType.Y:
                    plotYArray[selectedIndex] = newY;
                    DataList[selectedIndex].Y = newY;
                    break;

                case AxisType.Z:
                    plotZArray[selectedIndex] = newY;
                    DataList[selectedIndex].Z = newY;
                    break;
            }

            // update annotation
            double x = DataList[selectedIndex].Time;

            xyPointAnnotation1.SetPosition(x, newY);
            xyPointAnnotation1.Caption = $"({x:0.00},{newY:0.00})";

            // update graph
            UpdatePlot();
        }

        private void scatterGraph1_PlotAreaMouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void UpdatePlot()
        {
            double storedXMin = xAxis1.Range.Minimum;
            double storedXMax = xAxis1.Range.Maximum;
            double storedYMin = yAxis1.Range.Minimum;
            double storedYMax = yAxis1.Range.Maximum;

            double[] t = DataList.Select(d => d.Time).ToArray();

            if (chbX.Checked)
            {
                double[] x = DataList.Select(d => d.X).ToArray();
                scatterPlot1.PlotXY(t, x);
            }

            if (chbY.Checked)
            {
                double[] y = DataList.Select(d => d.Y).ToArray();
                scatterPlot2.PlotXY(t, y);
            }

            if (chbZ.Checked)
            {
                double[] z = DataList.Select(d => d.Z).ToArray();
                scatterPlot3.PlotXY(t, z);
            }

            xAxis1.Range = new Range(storedXMin, storedXMax);
            yAxis1.Range = new Range(storedYMin, storedYMax);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = "edited_accel_data.csv";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                // write headers / metadata
                foreach (var line in originalHeaderLines)
                {
                    sw.WriteLine(line);
                }

                // write modified data
                foreach (var d in DataList)
                {
                    string line =
                        d.Time.ToString(CultureInfo.InvariantCulture) + "," +
                        d.X.ToString(CultureInfo.InvariantCulture) + "," +
                        d.Y.ToString(CultureInfo.InvariantCulture) + "," +
                        d.Z.ToString(CultureInfo.InvariantCulture);

                    sw.WriteLine(line);
                }
            }

            MessageBox.Show("File exported successfully.");
        }

        private void btnApplyFactors_Click(object sender, EventArgs e)
        {
            double xFactor = (double)nudFactorX.Value;
            double yFactor = (double)nudFactorY.Value;
            double zFactor = (double)nudFactorZ.Value;

            for (int i = 0; i < DataList.Count; i++)
            {
                double x = DataList[i].X;
                double y = DataList[i].Y;
                double z = DataList[i].Z;

                DataList[i].X = x * xFactor;
                DataList[i].Y = y * yFactor;
                DataList[i].Z  = z * zFactor;

                plotXArray[i] = x * xFactor;
                plotYArray[i] = y * yFactor;
                plotZArray[i] = z * zFactor;
            }

            scatterPlot1.PlotXY(plotTimeArray, plotXArray);
            scatterPlot2.PlotXY(plotTimeArray, plotYArray);
            scatterPlot3.PlotXY(plotTimeArray, plotZArray);
        }
    }
}
