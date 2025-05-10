using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class StudentTracking : Form
    {
        private bool isCLosing = false;
        public StudentTracking()
        {
            InitializeComponent();
        }

        private void StudentTracking_Load(object sender, EventArgs e)
        {
            // Create mock data table
            var table = new DataTable();
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Subject", typeof(string));
            table.Columns.Add("Score", typeof(int));

            // Add varied dates
            table.Rows.Add(new DateTime(2023, 10, 12), "Math", 91);
            table.Rows.Add(new DateTime(2023, 12, 5), "Physics", 87);
            table.Rows.Add(new DateTime(2024, 2, 18), "Chemistry", 93);
            table.Rows.Add(new DateTime(2024, 4, 1), "English", 79);
            table.Rows.Add(new DateTime(2024, 6, 23), "History", 84);
            table.Rows.Add(new DateTime(2024, 9, 14), "Biology", 90);
            table.Rows.Add(new DateTime(2024, 11, 27), "Computer Science", 96);

            // Bind to grid
            dgvHistory.DataSource = table;

            // Setup chart area
            chartProgress.Series.Clear();
            chartProgress.ChartAreas.Clear();
            var area = new ChartArea("MainArea");
            // treat X values as dates
            area.AxisX.LabelStyle.Format = "yyyy-MM-dd";
            area.AxisX.IntervalType = DateTimeIntervalType.Months;
            area.AxisX.Interval = 2;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartProgress.ChartAreas.Add(area);

            // Create series
            var series = new Series("Scores")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            // Add points using real DateTime
            foreach (DataRow row in table.Rows)
            {
                var dt = (DateTime)row["Date"];
                var score = (int)row["Score"];
                series.Points.AddXY(dt, score);
            }
            chartProgress.Series.Add(series);

            // Display average score
            var avg = table.AsEnumerable().Average(r => r.Field<int>("Score"));
            lblAverage.Text = $"Average Score: {avg:F2}";
        }

        private void StudentTracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCLosing)
            {
                Application.Exit();
            }
        }
    }
}
