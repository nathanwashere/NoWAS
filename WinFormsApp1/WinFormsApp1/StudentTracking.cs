using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class StudentTracking : Form
    {
        private bool isClosing = false;
        private DataTable scoreTable;
        private DateTime lastRefreshTime;

        public StudentTracking()
        {
            InitializeComponent();
        }

        private void StudentTracking_Load(object sender, EventArgs e)
        {
            // Initialize UI components
            SetupUIComponents();

            // Create and load mock data table
            CreateMockData();

            // Load data into UI
            RefreshData();
        }

        private void SetupUIComponents()
        {
            // Set default filter period
            cmbFilterPeriod.SelectedIndex = 4; // All Time

            // Set up event handlers
            btnRefresh.Click += BtnRefresh_Click;
            cmbFilterPeriod.SelectedIndexChanged += CmbFilterPeriod_SelectedIndexChanged;
            btnSearch.Click += BtnSearch_Click;
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;

            // Setup chart area (this will be populated with data later)
            SetupChartArea();
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search by test name";
                txtSearch.ForeColor = Color.Silver;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by test name")
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = Color.White;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            if (scoreTable == null) return;

            // Clone the original data
            DataTable filteredTable = scoreTable.Clone();

            string searchText = txtSearch.Text.Trim().ToLower();
            if (searchText == "search by test name" || string.IsNullOrEmpty(searchText))
            {
                // Show all data if search box is empty or has default text
                dgvHistory.DataSource = scoreTable;
                return;
            }

            // Add rows that match the search text
            foreach (DataRow row in scoreTable.Rows)
            {
                if (row["Subject"].ToString().ToLower().Contains(searchText))
                {
                    filteredTable.ImportRow(row);
                }
            }

            dgvHistory.DataSource = filteredTable;
            statusLabel.Text = $"Found {filteredTable.Rows.Count} matches | Last updated: {lastRefreshTime:HH:mm:ss}";
        }

        private void CmbFilterPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void SetupChartArea()
        {
            chartProgress.Series.Clear();
            chartProgress.ChartAreas.Clear();

            // Create chart area
            var area = new ChartArea("MainArea");

            // Configure X axis
            area.AxisX.LabelStyle.Format = "yyyy-MM-dd";
            area.AxisX.IntervalType = DateTimeIntervalType.Months;
            area.AxisX.Interval = 2;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64);
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisX.LineColor = Color.White;
            area.AxisX.Title = "Assessment Date";
            area.AxisX.TitleForeColor = Color.White;

            // Configure Y axis
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64);
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisY.LineColor = Color.White;
            area.AxisY.Title = "Score (%)";
            area.AxisY.TitleForeColor = Color.White;
            area.AxisY.Minimum = 50; // Set minimum to 50 to better visualize differences

            // Set background colors
            area.BackColor = Color.FromArgb(45, 45, 48);

            chartProgress.ChartAreas.Add(area);
        }

        private void CreateMockData()
        {
            scoreTable = new DataTable();
            scoreTable.Columns.Add("Date", typeof(DateTime));
            scoreTable.Columns.Add("Subject", typeof(string));
            scoreTable.Columns.Add("Score", typeof(double));
            scoreTable.Columns.Add("Comments", typeof(string));

            // Add more varied dates and scores
            scoreTable.Rows.Add(new DateTime(2023, 10, 12), "Math Midterm", 91.5, "Strong performance in algebra");
            scoreTable.Rows.Add(new DateTime(2023, 11, 18), "Physics Lab", 87.2, "Good lab work, needs improvement in theory");
            scoreTable.Rows.Add(new DateTime(2023, 12, 5), "Physics Final", 82.8, "Struggled with quantum concepts");
            scoreTable.Rows.Add(new DateTime(2024, 1, 22), "English Essay", 88.0, "Well-structured arguments");
            scoreTable.Rows.Add(new DateTime(2024, 2, 18), "Chemistry Midterm", 93.5, "Excellent understanding of organic chemistry");
            scoreTable.Rows.Add(new DateTime(2024, 3, 10), "Math Final", 89.7, "Good progress from midterm");
            scoreTable.Rows.Add(new DateTime(2024, 4, 1), "English Final", 79.3, "Grammar issues affected score");
            scoreTable.Rows.Add(new DateTime(2024, 5, 15), "Programming Project", 95.0, "Outstanding project implementation");
            scoreTable.Rows.Add(new DateTime(2024, 6, 23), "History Research", 84.5, "Good research but lacking depth in analysis");
            scoreTable.Rows.Add(new DateTime(2024, 7, 8), "Statistics Quiz", 77.0, "Needs improvement in probability concepts");
            scoreTable.Rows.Add(new DateTime(2024, 8, 20), "Art Project", 92.0, "Creative and well-executed");
            scoreTable.Rows.Add(new DateTime(2024, 9, 14), "Biology Midterm", 90.2, "Strong understanding of cellular processes");
            scoreTable.Rows.Add(new DateTime(2024, 10, 5), "Chemistry Final", 86.8, "Good theoretical knowledge");
            scoreTable.Rows.Add(new DateTime(2024, 11, 27), "Computer Science Project", 96.5, "Exceptional coding skills");
        }

        private void RefreshData()
        {
            DataTable filteredData = GetFilteredData();

            // Bind to grid
            dgvHistory.DataSource = filteredData;

            // Format the grid
            FormatDataGrid();

            // Update chart with filtered data
            UpdateChart(filteredData);

            // Calculate and display statistics
            UpdateStatistics(filteredData);

            // Update status
            lastRefreshTime = DateTime.Now;
            statusLabel.Text = $"Ready | Last updated: {lastRefreshTime:HH:mm:ss}";
        }

        private void FormatDataGrid()
        {
            // Format Date column
            if (dgvHistory.Columns.Contains("Date"))
            {
                dgvHistory.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }

            // Format Score column
            if (dgvHistory.Columns.Contains("Score"))
            {
                dgvHistory.Columns["Score"].DefaultCellStyle.Format = "F1";
            }

            // Auto-resize columns
            dgvHistory.AutoResizeColumns();
        }

        private DataTable GetFilteredData()
        {
            if (scoreTable == null || scoreTable.Rows.Count == 0)
                return scoreTable;

            // Filter based on selected time period
            DateTime cutoffDate = DateTime.Now;
            string filterText = cmbFilterPeriod.SelectedItem?.ToString() ?? "All Time";

            switch (filterText)
            {
                case "Last Week":
                    cutoffDate = DateTime.Now.AddDays(-7);
                    break;
                case "Last Month":
                    cutoffDate = DateTime.Now.AddMonths(-1);
                    break;
                case "Last Quarter":
                    cutoffDate = DateTime.Now.AddMonths(-3);
                    break;
                case "Last Year":
                    cutoffDate = DateTime.Now.AddYears(-1);
                    break;
                default: // All Time
                    return scoreTable;
            }

            // Create filtered DataTable
            DataTable filteredTable = scoreTable.Clone();
            foreach (DataRow row in scoreTable.Rows)
            {
                if ((DateTime)row["Date"] >= cutoffDate)
                {
                    filteredTable.ImportRow(row);
                }
            }
            return filteredTable;
        }

        private void UpdateChart(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return;

            // Sort the data by date
            DataView dv = new DataView(dataTable);
            dv.Sort = "Date ASC";
            DataTable sortedData = dv.ToTable();

            // Clear existing series
            chartProgress.Series.Clear();

            // Create series for scores
            var scoresSeries = new Series("Scores")
            {
                ChartType = SeriesChartType.SplineArea,
                XValueType = ChartValueType.DateTime,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = Color.White,
                MarkerBorderColor = Color.White,
                Color = Color.FromArgb(100, 114, 137, 218),
                BorderColor = Color.FromArgb(114, 137, 218),
                BorderWidth = 2
            };

            // Create series for trend line
            var trendSeries = new Series("TrendLine")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                Color = Color.FromArgb(255, 193, 7),
                BorderWidth = 3
            };

            // Add points using real DateTime and calculate trendline points
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            foreach (DataRow row in sortedData.Rows)
            {
                var dt = (DateTime)row["Date"];
                var score = Convert.ToDouble(row["Score"]);

                scoresSeries.Points.AddXY(dt, score);

                // Store values for trendline calculation
                xValues.Add(dt.ToOADate());
                yValues.Add(score);
            }

            // Calculate and add trendline if we have enough data points
            if (sortedData.Rows.Count >= 2)
            {
                CalculateAndAddTrendLine(xValues, yValues, trendSeries);
            }

            // Add series
            chartProgress.Series.Add(scoresSeries);
            chartProgress.Series.Add(trendSeries);

            // Set legend
            chartProgress.Legends[0].BackColor = Color.FromArgb(45, 45, 48);
            chartProgress.Legends[0].ForeColor = Color.White;
            chartProgress.Legends[0].Title = "Legend";
            chartProgress.Series[0].LegendText = "Individual Scores";
            chartProgress.Series[1].LegendText = "Average Trend";
        }

        private void CalculateAndAddTrendLine(List<double> xValues, List<double> yValues, Series trendSeries)
        {
            if (xValues.Count < 2) return;

            // Calculate linear regression for trendline
            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;
            int n = xValues.Count;

            for (int i = 0; i < n; i++)
            {
                sumX += xValues[i];
                sumY += yValues[i];
                sumXY += xValues[i] * yValues[i];
                sumX2 += xValues[i] * xValues[i];
            }

            double xMean = sumX / n;
            double yMean = sumY / n;

            double slope = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double intercept = yMean - slope * xMean;

            // Add trendline points
            double startX = xValues.Min();
            double endX = xValues.Max();

            // Calculate Y values for trendline
            double startY = slope * startX + intercept;
            double endY = slope * endX + intercept;

            // Add points to trendline series
            trendSeries.Points.AddXY(DateTime.FromOADate(startX), startY);
            trendSeries.Points.AddXY(DateTime.FromOADate(endX), endY);

            // Calculate recent trend (last 2 data points if available)
            if (n >= 2)
            {
                double recentSlope = (yValues[n - 1] - yValues[n - 2]) / (xValues[n - 1] - xValues[n - 2]);
                double recentPercent = recentSlope * 30; // Scale for better visualization

                UpdateRecentTrend(recentPercent);
            }
        }

        private void UpdateStatistics(DataTable data)
        {
            if (data == null || data.Rows.Count == 0)
            {
                lblAverage.Text = "Average Score\nNo Data";
                lblHighestScore.Text = "Highest Score\nNo Data";
                lblLowestScore.Text = "Lowest Score\nNo Data";
                lblRecentTrend.Text = "Recent Trend\nNo Data";
                return;
            }

            // Calculate statistics
            double averageScore = CalculateAverageScore(data);
            double highestScore = CalculateHighestScore(data);
            double lowestScore = CalculateLowestScore(data);

            // Update labels
            lblAverage.Text = $"Average Score\n{averageScore:F1}";
            lblHighestScore.Text = $"Highest Score\n{highestScore:F1}";
            lblLowestScore.Text = $"Lowest Score\n{lowestScore:F1}";

            // Apply color based on average score
            if (averageScore >= 90)
                panel1.BackColor = Color.FromArgb(78, 93, 148); // Blue
            else if (averageScore >= 80)
                panel1.BackColor = Color.FromArgb(46, 125, 50); // Green
            else if (averageScore >= 70)
                panel1.BackColor = Color.FromArgb(255, 152, 0); // Orange
            else
                panel1.BackColor = Color.FromArgb(211, 47, 47); // Red
        }

        private void UpdateRecentTrend(double trendPercentage)
        {
            string trendSymbol = trendPercentage > 0 ? "↑" : (trendPercentage < 0 ? "↓" : "→");

            // Update recent trend label
            lblRecentTrend.Text = $"Recent Trend\n{trendSymbol} {Math.Abs(trendPercentage):F1}%";

            // Apply color based on trend
            if (trendPercentage > 5)
                panelRecentTrend.BackColor = Color.FromArgb(46, 125, 50); // Green - strong positive
            else if (trendPercentage > 0)
                panelRecentTrend.BackColor = Color.FromArgb(121, 85, 163); // Purple - slight positive
            else if (trendPercentage > -5)
                panelRecentTrend.BackColor = Color.FromArgb(255, 152, 0); // Orange - slight negative
            else
                panelRecentTrend.BackColor = Color.FromArgb(211, 47, 47); // Red - strong negative
        }

        #region Statistical Functions

        /// <summary>
        /// Calculates the average score from the data table
        /// </summary>
        private double CalculateAverageScore(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return 0;

            double sum = 0;
            int count = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                sum += Convert.ToDouble(row["Score"]);
                count++;
            }

            return count > 0 ? sum / count : 0;
        }

        /// <summary>
        /// Calculates the highest score from the data table
        /// </summary>
        private double CalculateHighestScore(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return 0;

            double highest = double.MinValue;

            foreach (DataRow row in dataTable.Rows)
            {
                double score = Convert.ToDouble(row["Score"]);
                if (score > highest)
                    highest = score;
            }

            return highest;
        }

        /// <summary>
        /// Calculates the lowest score from the data table
        /// </summary>
        private double CalculateLowestScore(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return 0;

            double lowest = double.MaxValue;

            foreach (DataRow row in dataTable.Rows)
            {
                double score = Convert.ToDouble(row["Score"]);
                if (score < lowest)
                    lowest = score;
            }

            return lowest;
        }

        /// <summary>
        /// Calculates the standard deviation of scores
        /// </summary>
        private double CalculateStandardDeviation(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count <= 1)
                return 0;

            double mean = CalculateAverageScore(dataTable);
            double sumOfSquaredDifferences = 0;
            int count = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                double score = Convert.ToDouble(row["Score"]);
                sumOfSquaredDifferences += Math.Pow(score - mean, 2);
                count++;
            }

            return Math.Sqrt(sumOfSquaredDifferences / count);
        }

        /// <summary>
        /// Calculates the median score from the data table
        /// </summary>
        private double CalculateMedianScore(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return 0;

            // Extract all scores into a list
            List<double> scores = new List<double>();
            foreach (DataRow row in dataTable.Rows)
            {
                scores.Add(Convert.ToDouble(row["Score"]));
            }

            // Sort the list
            scores.Sort();

            // Find median
            int count = scores.Count;
            if (count % 2 == 0) // Even number of scores
            {
                return (scores[(count / 2) - 1] + scores[count / 2]) / 2;
            }
            else // Odd number of scores
            {
                return scores[count / 2];
            }
        }

        /// <summary>
        /// Calculates the mode (most frequent score) from the data table
        /// </summary>
        private double CalculateModeScore(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
                return 0;

            Dictionary<double, int> scoreFrequency = new Dictionary<double, int>();

            foreach (DataRow row in dataTable.Rows)
            {
                double score = Math.Round(Convert.ToDouble(row["Score"]), 1); // Round to 1 decimal place
                if (scoreFrequency.ContainsKey(score))
                    scoreFrequency[score]++;
                else
                    scoreFrequency[score] = 1;
            }

            // Find the score with the highest frequency
            double mode = 0;
            int maxFrequency = 0;

            foreach (var pair in scoreFrequency)
            {
                if (pair.Value > maxFrequency)
                {
                    maxFrequency = pair.Value;
                    mode = pair.Key;
                }
            }

            return mode;
        }

        #endregion

        private void StudentTracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isClosing)
            {
                Application.Exit();
            }
        }
    }
}