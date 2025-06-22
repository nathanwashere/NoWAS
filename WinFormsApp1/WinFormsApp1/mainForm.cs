using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        private bool isCLosing = false; // Flag to control app exit
        private string userName; // Logged-in user's name
        private string connectionString = $"Data Source={System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db"))};Version=3;";
        // SQLite connection string

        public mainForm(string USERNAME)
        {
            userName = USERNAME; // Store the username
            InitializeComponent(); // Load UI
            lblWelcome.Text = $"Welcome, {userName}!"; // Set welcome label
            LoadStudentStats(); // Load user stats
        }

        private void LoadStudentStats()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) // Open DB connection
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            COUNT(*) as TotalTests,
                            ROUND(AVG(Grade), 2) as AverageGrade
                        FROM StudentResults sr
                        JOIN Person p ON sr.StudentId = p.Id
                        WHERE p.username = @Username";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) // Prepare query
                    {
                        cmd.Parameters.AddWithValue("@Username", userName); // Bind username
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) // Execute reader
                        {
                            if (reader.Read())
                            {
                                int totalTests = 0;
                                double avgGrade = 0;

                                // Safely get values from DB
                                object totalTestsObj = reader["TotalTests"];
                                object avgGradeObj = reader["AverageGrade"];
                                if (totalTestsObj != DBNull.Value)
                                    totalTests = Convert.ToInt32(totalTestsObj);
                                if (avgGradeObj != DBNull.Value)
                                    avgGrade = Convert.ToDouble(avgGradeObj);

                                // Display stats
                                lblActiveTests.Text = $"Tests taken: {totalTests}";
                                lblAvgScore.Text = $"Average score: {avgGrade:F2}%";
                            }
                            else
                            {
                                // If no data found
                                lblActiveTests.Text = "Tests taken: 0";
                                lblAvgScore.Text = "Average score: 0%";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // On error, show message and set default stats
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblActiveTests.Text = "Tests taken: 0";
                lblAvgScore.Text = "Average score: 0%";
            }
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            StudentTracking studentTracking = new StudentTracking(userName); // Open student grade tracking
            studentTracking.Show();
            isCLosing = true; // Prevent app exit
            this.Close();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCLosing)
            {
                Application.Exit(); // Close app if user didn't navigate
            }
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            TestSelectionForm selector = new TestSelectionForm(userName); // Open test selection
            selector.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login_Signup loginForm = new Login_Signup(); // Go back to login screen
            loginForm.Show();
            isCLosing = true;
            this.Close();
        }
    }
}
