using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class StudentTracking : Form
    {
        private string connectionString = $"Data Source={System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db"))};Version=3;";
        private string username;
        private int studentId; // Added to store student ID from Person table
        private bool isClosing = false;
        private DataTable scoreTable;
        private DateTime lastRefreshTime;

        public StudentTracking(string userName)
        {
            username = userName;
            InitializeComponent();

            // Set the form title to include the username
            this.Text = $"Student Progress Tracking - {username}";
        }

        private void StudentTracking_Load(object sender, EventArgs e)
        {
            // Update the header subtitle to show the logged-in user
            lblHeaderSubtitle.Text = $"Student: {username} | Monitoring performance";

            // Get student ID from Person table
            GetStudentId();

            // Initialize UI components
            SetupUIComponents();

            // Load real data into UI (no more mock data)
            RefreshData();
        }

        // New method to get student ID from Person table
        private void GetStudentId()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID FROM Person WHERE userName = @Username AND type = 'Student'";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        studentId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Error: Student not found in database.", "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isClosing = true;
                        this.Close();
                    }
                }
            }
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

        // Method to get actual student results from the database
        private void LoadStudentResults()
        {
            // Create our table structure
            scoreTable = new DataTable();
            scoreTable.Columns.Add("Date", typeof(DateTime));
            scoreTable.Columns.Add("Subject", typeof(string));
            scoreTable.Columns.Add("Score", typeof(double));

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // We need to join with a Tests table, but since it doesn't exist,
                // we'll use TestId as subject name with a prefix
                string query = @"
                    SELECT 
                        TestId,
                        Score, 
                        TotalQuestions,
                        Grade,
                        datetime(TestDate) as TestDate
                    FROM 
                        StudentResults 
                    WHERE 
                        StudentId = @StudentId
                    ORDER BY 
                        TestDate DESC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime testDate;
                            if (!DateTime.TryParse(reader["TestDate"].ToString(), out testDate))
                            {
                                testDate = DateTime.Now; // Default to current date if parsing fails
                            }

                            int testId = Convert.ToInt32(reader["TestId"]);
                            double score = Convert.ToDouble(reader["Score"]);
                            int totalQuestions = Convert.ToInt32(reader["TotalQuestions"]);
                            double grade = Convert.ToDouble(reader["Grade"]);

                            // Calculate percentage score
                            double percentScore = totalQuestions > 0 ? (score / totalQuestions) * 100 : grade;

                            // Create a subject name from TestId (since there's no Tests table)
                            string subject = DetermineSubjectFromTestId(testId);

                            // Add to our table
                            scoreTable.Rows.Add(testDate, subject, percentScore);
                        }
                    }
                }
            }
        }

        // Helper method to determine subject from test ID
        private string DetermineSubjectFromTestId(int testId)
        {
            // In a real application, you would have a Tests table to get the actual subject
            // Since we don't have that table, we'll create generic subjects based on the test ID

            // Using modulus to cycle through different subjects
            switch (testId % 6)
            {
                case 0:
                    return $"Math Test {testId}";
                case 1:
                    return $"Physics Test {testId}";
                case 2:
                    return $"English Test {testId}";
                case 3:
                    return $"Chemistry Test {testId}";
                case 4:
                    return $"Biology Test {testId}";
                case 5:
                    return $"Computer Science Test {testId}";
                default:
                    return $"Test {testId}";
            }
        }

        private void RefreshData()
        {
            // Get real data from the database
            LoadStudentResults();

            // Get filtered data based on selected time period
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

            // Calculate recent trend
            // For just 2 points or when we only have a few data points, use the overall trend
            double recentPercent;

            if (n == 2)
            {
                // With only 2 points, calculate the percent change directly
                double percentChange = ((yValues[1] - yValues[0]) / yValues[0]) * 100;
                recentPercent = percentChange;
            }
            else if (n > 2)
            {
                // With more than 2 points, focus on the most recent change
                double recentSlope = (yValues[n - 1] - yValues[n - 2]) / (xValues[n - 1] - xValues[n - 2]);

                // Convert the slope to a more meaningful percentage
                // This is the rate of change over time, scaled to show meaningful change
                double timeDiff = xValues[n - 1] - xValues[n - 2]; // Time difference in days
                recentPercent = (recentSlope * timeDiff / yValues[n - 2]) * 100;
            }
            else
            {
                // Fallback, shouldn't happen as we check for n < 2 at the start
                recentPercent = 0;
            }

            UpdateRecentTrend(recentPercent);
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
            // Cap extreme values to avoid overwhelming UI
            if (trendPercentage > 50) trendPercentage = 50;
            if (trendPercentage < -50) trendPercentage = -50;

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