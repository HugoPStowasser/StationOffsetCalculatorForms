using StationOffsetCalculator.Core.Models;
using StationOffsetCalculator.Core.Services;
using Point = StationOffsetCalculator.Core.Models.Point;

namespace StationOffsetCalculator.WinForms
{
    public partial class MainForm : Form
    {
        private Polyline polyline;
        private Point targetPoint;
        private PolylineReader polylineReader;
        private Core.Services.StationOffsetCalculator calculator;
        private double station;
        private double offset;
        private Point nearestPoint;
        private int nearestSegmentIndex;

        private float scale = 1.0f;
        private RectangleF bounds;

        public MainForm()
        {
            InitializeComponent();
            polylineReader = new PolylineReader();
            calculator = new Core.Services.StationOffsetCalculator();

            // Associar eventos
            this.polylinePanel.Paint += PolylinePanel_Paint;
            this.btnLoadPolyline.Click += BtnLoadPolyline_Click;
            this.btnCalculate.Click += BtnCalculate_Click;

            polylinePanel.Resize += (s, e) => {
                if (polyline != null)
                {
                    CalculateBounds();
                    polylinePanel.Invalidate();
                }
            };
        }

        private void BtnLoadPolyline_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Select Polyline File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtFilePath.Text = openFileDialog.FileName;
                        polyline = polylineReader.ReadFromFile(openFileDialog.FileName);
                        CalculateBounds();
                        polylinePanel.Invalidate();
                        txtStatus.Text = $"Polyline loaded with {polyline.Points.Count} points.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (polyline == null)
            {
                MessageBox.Show("Please load a polyline first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!double.TryParse(txtX.Text, out double x) || !double.TryParse(txtY.Text, out double y))
                {
                    MessageBox.Show("Please enter valid numeric values for X and Y coordinates.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                targetPoint = new Point(x, y);

                var result = calculator.Calculate(polyline, targetPoint);
                station = result.Station;
                offset = result.Offset;
                nearestPoint = result.NearestPoint;
                nearestSegmentIndex = result.SegmentIndex;

                txtStation.Text = station.ToString("F4");
                txtOffset.Text = offset.ToString("F4");
                txtNearestPoint.Text = $"({nearestPoint.X:F2}, {nearestPoint.Y:F2})";

                polylinePanel.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PolylinePanel_Paint(object sender, PaintEventArgs e)
        {
            if (polyline == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            CalculateBounds();

            using (Pen polylinePen = new Pen(Color.SaddleBrown, 2))
            {
                for (int i = 0; i < polyline.Segments.Count; i++)
                {
                    var segment = polyline.Segments[i];
                    PointF p1 = WorldToScreen(segment.Start.X, segment.Start.Y);
                    PointF p2 = WorldToScreen(segment.End.X, segment.End.Y);
                    g.DrawLine(polylinePen, p1, p2);
                }
            }

            using (Brush vertexBrush = new SolidBrush(Color.SaddleBrown))
            {
                foreach (var point in polyline.Points)
                {
                    PointF screenPoint = WorldToScreen(point.X, point.Y);
                    g.FillEllipse(vertexBrush, screenPoint.X - 4, screenPoint.Y - 4, 8, 8);
                }
            }

            using (Brush startEndBrush = new SolidBrush(Color.Black))
            {
                PointF start = WorldToScreen(polyline.Points[0].X, polyline.Points[0].Y);
                PointF end = WorldToScreen(polyline.Points[polyline.Points.Count - 1].X, polyline.Points[polyline.Points.Count - 1].Y);

                g.FillEllipse(startEndBrush, start.X - 5, start.Y - 5, 10, 10);
                g.FillEllipse(startEndBrush, end.X - 5, end.Y - 5, 10, 10);

                g.DrawString("Start", new Font("Arial", 8), startEndBrush, start.X + 5, start.Y - 15);
                g.DrawString("End", new Font("Arial", 8), startEndBrush, end.X + 5, end.Y - 15);
            }

            if (targetPoint != null && nearestPoint != null)
            {
                PointF targetScreenPoint = WorldToScreen(targetPoint.X, targetPoint.Y);
                PointF nearestScreenPoint = WorldToScreen(nearestPoint.X, nearestPoint.Y);

                using (Brush targetBrush = new SolidBrush(Color.Blue))
                {
                    g.FillEllipse(targetBrush, targetScreenPoint.X - 5, targetScreenPoint.Y - 5, 10, 10);
                    g.DrawString("Point", new Font("Arial", 8), targetBrush, targetScreenPoint.X + 5, targetScreenPoint.Y - 15);
                }
                
                using (Pen offsetPen = new Pen(Color.Gray, 1))
                {
                    offsetPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(offsetPen, targetScreenPoint, nearestScreenPoint);

                    g.DrawString("O", new Font("Arial", 8), Brushes.Black,
                                 (targetScreenPoint.X + nearestScreenPoint.X) / 2 - 5,
                                 (targetScreenPoint.Y + nearestScreenPoint.Y) / 2 - 5);
                }

                using (Pen polylinePen = new Pen(Color.SaddleBrown, 2))
                {
                    for (int i = 0; i < polyline.Segments.Count; i++)
                    {
                        var segment = polyline.Segments[i];
                        PointF p1 = WorldToScreen(segment.Start.X, segment.Start.Y);
                        PointF p2 = WorldToScreen(segment.End.X, segment.End.Y);
                        g.DrawLine(polylinePen, p1, p2);

                        float midX = (p1.X + p2.X) / 2;
                        float midY = (p1.Y + p2.Y) / 2;
                        g.DrawString($"s{i + 1}", new Font("Arial", 8), Brushes.Black, midX - 10, midY - 15);
                    }
                }

                if (nearestSegmentIndex >= 0 && nearestSegmentIndex < polyline.Segments.Count)
                {
                    var highlightSegment = polyline.Segments[nearestSegmentIndex];
                    PointF p1 = WorldToScreen(highlightSegment.Start.X, highlightSegment.Start.Y);
                    PointF p2 = WorldToScreen(highlightSegment.End.X, highlightSegment.End.Y);

                    using (Pen highlightPen = new Pen(Color.Red, 3))
                    {
                        g.DrawLine(highlightPen, p1, p2);

                    }
                }

                using (Brush nearestBrush = new SolidBrush(Color.Green))
                {
                    g.FillEllipse(nearestBrush, nearestScreenPoint.X - 4, nearestScreenPoint.Y - 4, 8, 8);
                }

                string stationText = $"S = station (s1 + s2 + ...)";
                string offsetText = $"O = offset";
                g.DrawString(stationText, new Font("Arial", 8), Brushes.Black, 10, polylinePanel.Height - 40);
                g.DrawString(offsetText, new Font("Arial", 8), Brushes.Black, 10, polylinePanel.Height - 25);
            }
        }

        private void CalculateBounds()
        {
            if (polyline == null || polyline.Points.Count == 0)
                return;

            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            foreach (var point in polyline.Points)
            {
                minX = Math.Min(minX, (float)point.X);
                minY = Math.Min(minY, (float)point.Y);
                maxX = Math.Max(maxX, (float)point.X);
                maxY = Math.Max(maxY, (float)point.Y);
            }

            if (targetPoint != null)
            {
                minX = Math.Min(minX, (float)targetPoint.X);
                minY = Math.Min(minY, (float)targetPoint.Y);
                maxX = Math.Max(maxX, (float)targetPoint.X);
                maxY = Math.Max(maxY, (float)targetPoint.Y);
            }

            float margin = Math.Max(maxX - minX, maxY - minY) * 0.05f;
            minX -= margin;
            minY -= margin;
            maxX += margin;
            maxY += margin;

            bounds = new RectangleF(minX, minY, maxX - minX, maxY - minY);

            float panelWidth = polylinePanel.Width;
            float panelHeight = polylinePanel.Height;

            scale = Math.Min(panelWidth / bounds.Width, panelHeight / bounds.Height);
        }

        private PointF WorldToScreen(double worldX, double worldY)
        {
            float centerX = polylinePanel.Width / 2;
            float centerY = polylinePanel.Height / 2;

            float x = (float)((worldX - (bounds.Left + bounds.Width / 2)) * scale) + centerX;
            float y = (float)(((bounds.Top + bounds.Height / 2) - worldY) * scale) + centerY;

            return new PointF(x, y);
        }
    }
}