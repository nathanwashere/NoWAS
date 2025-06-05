using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

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
            cmbFilterDifficulty.SelectedIndex = 0; // All Difficulties
            cmbTableFilter.SelectedIndex = 0; // All Results

            // Set up event handlers
            btnRefresh.Click += BtnRefresh_Click;
            btnGoBack.Click += BtnGoBack_Click;
            cmbFilterPeriod.SelectedIndexChanged += CmbFilterPeriod_SelectedIndexChanged;
            cmbFilterDifficulty.SelectedIndexChanged += CmbFilterDifficulty_SelectedIndexChanged;
            cmbTableFilter.SelectedIndexChanged += CmbTableFilter_SelectedIndexChanged;
            btnSearch.Click += BtnSearch_Click;
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;

            // Setup chart area (this will be populated with data later)
            SetupChartArea();
        }

        // Event handler for Go Back button
        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            new mainForm(username).Show();
            this.Hide();
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

        private void CmbFilterDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void CmbTableFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scoreTable == null) return;

            string filterType = cmbTableFilter.SelectedItem?.ToString() ?? "All Results";
            DataTable filteredTable = scoreTable.Clone();

            foreach (DataRow row in scoreTable.Rows)
            {
                bool shouldInclude = true;

                switch (filterType)
                {
                    case "Easy Tests":
                        shouldInclude = Convert.ToInt32(row["Difficulty"]) == 1;
                        break;
                    case "Medium Tests":
                        shouldInclude = Convert.ToInt32(row["Difficulty"]) == 2;
                        break;
                    case "Hard Tests":
                        shouldInclude = Convert.ToInt32(row["Difficulty"]) == 3;
                        break;
                    case "Last Week":
                        shouldInclude = (DateTime)row["Date"] >= DateTime.Now.AddDays(-7);
                        break;
                    case "Last Month":
                        shouldInclude = (DateTime)row["Date"] >= DateTime.Now.AddMonths(-1);
                        break;
                    case "Last Quarter":
                        shouldInclude = (DateTime)row["Date"] >= DateTime.Now.AddMonths(-3);
                        break;
                    case "Last Year":
                        shouldInclude = (DateTime)row["Date"] >= DateTime.Now.AddYears(-1);
                        break;
                }

                if (shouldInclude)
                {
                    filteredTable.ImportRow(row);
                }
            }

            dgvHistory.DataSource = filteredTable;
            FormatDataGrid();
            statusLabel.Text = $"Showing {filteredTable.Rows.Count} results | Filter: {filterType} | Last updated: {lastRefreshTime:HH:mm:ss}";
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

            // Configure X axis for equal spacing (ordinal)
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisX.LineColor = Color.White;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64);
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.Title = "Assessment Date";
            area.AxisX.TitleForeColor = Color.White;
            area.AxisX.Interval = 1; // Show every label
            area.AxisX.IsLabelAutoFit = false;

            // Configure Y axis
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64);
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisY.LineColor = Color.White;
            area.AxisY.Title = "Score (%)";
            area.AxisY.TitleForeColor = Color.White;
            area.AxisY.Minimum = 0; // Set minimum to 0
            area.AxisY.Maximum = 100; // Set maximum to 100

            // Set background colors
            area.BackColor = Color.FromArgb(45, 45, 48);

            chartProgress.ChartAreas.Add(area);
        }

        // Method to parse the datetime string properly
        private DateTime ParseTestDate(string dateString)
        {
            try
            {
                // Handle the format: 2025-05-21 14:33:29.1089522
                if (DateTime.TryParse(dateString, out DateTime result))
                {
                    return result;
                }

                // Alternative parsing if the above fails
                string[] formats = {
                    "yyyy-MM-dd HH:mm:ss.fffffff",
                    "yyyy-MM-dd HH:mm:ss.ffffff",
                    "yyyy-MM-dd HH:mm:ss.fffff",
                    "yyyy-MM-dd HH:mm:ss.ffff",
                    "yyyy-MM-dd HH:mm:ss.fff",
                    "yyyy-MM-dd HH:mm:ss.ff",
                    "yyyy-MM-dd HH:mm:ss.f",
                    "yyyy-MM-dd HH:mm:ss",
                    "yyyy-MM-dd"
                };

                foreach (string format in formats)
                {
                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    {
                        return result;
                    }
                }

                // If all parsing fails, return current date
                return DateTime.Now;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        // Method to get actual student results from the database
        private void LoadStudentResults()
        {
            // Create our table structure
            scoreTable = new DataTable();
            scoreTable.Columns.Add("Date", typeof(DateTime));
            scoreTable.Columns.Add("Subject", typeof(string));
            scoreTable.Columns.Add("Score", typeof(double));
            scoreTable.Columns.Add("Difficulty", typeof(int));

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        sr.TestId,
                        sr.Score, 
                        sr.TotalQuestions,
                        sr.Grade,
                        sr.TestDate,
                        sr.Difficulty,
                        t.TestName
                    FROM 
                        StudentResults sr
                    LEFT JOIN 
                        Test t ON sr.TestId = t.TestID
                    WHERE 
                        sr.StudentId = @StudentId
                    ORDER BY 
                        sr.TestDate ASC";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Parse the test date properly
                            DateTime testDate = ParseTestDate(reader["TestDate"].ToString());

                            int testId = Convert.ToInt32(reader["TestId"]);
                            double score = Convert.ToDouble(reader["Score"]);
                            int totalQuestions = Convert.ToInt32(reader["TotalQuestions"]);
                            double grade = Convert.ToDouble(reader["Grade"]);
                            int difficulty = Convert.ToInt32(reader["Difficulty"]);

                            // Calculate percentage score
                            double percentScore = totalQuestions > 0 ? (score / totalQuestions) * 100 : grade;

                            // Use TestName if available, otherwise create a generic name
                            string subject = reader["TestName"] != DBNull.Value ?
                                reader["TestName"].ToString() :
                                DetermineSubjectFromTestId(testId);

                            // Add to our table
                            scoreTable.Rows.Add(testDate, subject, percentScore, difficulty);
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
                dgvHistory.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
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

            // Create filtered DataTable
            DataTable filteredTable = scoreTable.Clone();

            foreach (DataRow row in scoreTable.Rows)
            {
                bool timeFilterPassed = true;
                bool difficultyFilterPassed = true;

                // Apply time filter
                string filterText = cmbFilterPeriod.SelectedItem?.ToString() ?? "All Time";
                if (filterText != "All Time")
                {
                    DateTime cutoffDate = DateTime.Now;
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
                    }
                    timeFilterPassed = (DateTime)row["Date"] >= cutoffDate;
                }

                // Apply difficulty filter
                string difficultyFilter = cmbFilterDifficulty.SelectedItem?.ToString() ?? "All Difficulties";
                if (difficultyFilter != "All Difficulties")
                {
                    int difficulty = Convert.ToInt32(row["Difficulty"]);
                    switch (difficultyFilter)
                    {
                        case "Easy (1)":
                            difficultyFilterPassed = difficulty == 1;
                            break;
                        case "Medium (2)":
                            difficultyFilterPassed = difficulty == 2;
                            break;
                        case "Hard (3)":
                            difficultyFilterPassed = difficulty == 3;
                            break;
                    }
                }

                if (timeFilterPassed && difficultyFilterPassed)
                {
                    filteredTable.ImportRow(row);
                }
            }

            // Update status with filter information
            string filterInfo = $"Period: {cmbFilterPeriod.SelectedItem}, Difficulty: {cmbFilterDifficulty.SelectedItem}";
            statusLabel.Text = $"Showing {filteredTable.Rows.Count} results | {filterInfo} | Last updated: {lastRefreshTime:HH:mm:ss}";

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

            // Create series for scores with equal spacing
            var scoresSeries = new Series("Scores")
            {
                ChartType = SeriesChartType.SplineArea,
                XValueType = ChartValueType.String, // Changed to String for equal spacing
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = Color.White,
                MarkerBorderColor = Color.White,
                Color = Color.FromArgb(100, 114, 137, 218),
                BorderColor = Color.FromArgb(114, 137, 218),
                BorderWidth = 2
            };

            // Create series for average trend line
            var averageTrendSeries = new Series("AverageTrend")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                Color = Color.FromArgb(255, 193, 7),
                BorderWidth = 3,
                BorderDashStyle = ChartDashStyle.Dash
            };

            // Add points using ordinal values for equal spacing
            List<double> yValues = new List<double>();
            List<string> dateLabels = new List<string>();
            int pointIndex = 0;

            foreach (DataRow row in sortedData.Rows)
            {
                var dt = (DateTime)row["Date"];
                var score = Convert.ToDouble(row["Score"]);

                // Create a formatted date label
                string dateLabel = dt.ToString("MM/dd");
                dateLabels.Add(dateLabel);

                // Use ordinal index for X value to ensure equal spacing
                scoresSeries.Points.AddXY(pointIndex, score);
                scoresSeries.Points[pointIndex].AxisLabel = dateLabel;

                yValues.Add(score);
                pointIndex++;
            }

            // Calculate and add average trend line
            if (sortedData.Rows.Count >= 1)
            {
                AddAverageTrendLine(yValues, averageTrendSeries, sortedData.Rows.Count);
            }

            // Add series
            chartProgress.Series.Add(scoresSeries);
            if (averageTrendSeries.Points.Count > 0)
            {
                chartProgress.Series.Add(averageTrendSeries);
            }

            // Configure the chart area for better label display
            var chartArea = chartProgress.ChartAreas[0];

            // Set X-axis properties for equal spacing
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Number;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.IsLabelAutoFit = true;
            chartArea.AxisX.LabelAutoFitMaxFontSize = 10;

            // Adjust margins if there are many points
            if (sortedData.Rows.Count > 10)
            {
                chartArea.AxisX.LabelStyle.Angle = -90;
                chartArea.AxisX.IntervalOffset = 0;

                // Show every nth label if there are too many points
                int labelInterval = Math.Max(1, sortedData.Rows.Count / 10);
                chartArea.AxisX.Interval = labelInterval;
            }

            // Set legend
            if (chartProgress.Legends.Count > 0)
            {
                chartProgress.Legends[0].BackColor = Color.FromArgb(45, 45, 48);
                chartProgress.Legends[0].ForeColor = Color.White;
                chartProgress.Legends[0].Title = "Legend";
                chartProgress.Series[0].LegendText = "Individual Scores";
                if (chartProgress.Series.Count > 1)
                {
                    chartProgress.Series[1].LegendText = "Average Trend";
                }
            }
        }

        private void AddAverageTrendLine(List<double> yValues, Series averageTrendSeries, int dataPointCount)
        {
            if (yValues.Count < 1) return;

            // Calculate the overall average score
            double averageScore = yValues.Average();

            // Add horizontal line representing the average across all data points
            averageTrendSeries.Points.AddXY(0, averageScore);
            averageTrendSeries.Points.AddXY(dataPointCount - 1, averageScore);

            // Calculate trend based on comparing recent performance to overall average
            double recentTrendPercentage = CalculateRecentTrendFromAverage(yValues, averageScore);
            UpdateRecentTrend(recentTrendPercentage);
        }

        private double CalculateRecentTrendFromAverage(List<double> yValues, double overallAverage)
        {
            if (yValues.Count < 2) return 0;

            // Take the last 3 scores or half of all scores, whichever is smaller
            int recentCount = Math.Min(3, Math.Max(1, yValues.Count / 2));
            var recentScores = yValues.Skip(yValues.Count - recentCount).ToList();
            double recentAverage = recentScores.Average();

            // Calculate percentage difference from overall average
            if (overallAverage > 0)
            {
                return ((recentAverage - overallAverage) / overallAverage) * 100;
            }
            else
            {
                return recentAverage - overallAverage; // Simple difference if overall average is 0
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

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}