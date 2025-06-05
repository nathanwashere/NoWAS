using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        private bool isCLosing = false;
        private string userName;
        private string connectionString = $"Data Source={System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db"))};Version=3;";

        public mainForm(string USERNAME)
        {
            userName = USERNAME;
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {userName}!";
            LoadStudentStats();
        }

        private void LoadStudentStats()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            COUNT(*) as TotalTests,
                            ROUND(AVG(Grade), 2) as AverageGrade
                        FROM StudentResults sr
                        JOIN Person p ON sr.StudentId = p.Id
                        WHERE p.username = @Username";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", userName);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalTests = 0;
                                double avgGrade = 0;
                                object totalTestsObj = reader["TotalTests"];
                                object avgGradeObj = reader["AverageGrade"];

                                if (totalTestsObj != DBNull.Value)
                                    totalTests = Convert.ToInt32(totalTestsObj);
                                if (avgGradeObj != DBNull.Value)
                                    avgGrade = Convert.ToDouble(avgGradeObj);

                                lblActiveTests.Text = $"Tests taken: {totalTests}";
                                lblAvgScore.Text = $"Average score: {avgGrade:F2}%";
                            }
                            else
                            {
                                lblActiveTests.Text = "Tests taken: 0";
                                lblAvgScore.Text = "Average score: 0%";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblActiveTests.Text = "Tests taken: 0";
                lblAvgScore.Text = "Average score: 0%";
            }
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            StudentTracking studentTracking = new StudentTracking(userName);
            studentTracking.Show();
            isCLosing = true;
            this.Close();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCLosing)
            {
                Application.Exit();
            }
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            TestSelectionForm selector = new TestSelectionForm(userName);
            selector.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login_Signup loginForm = new Login_Signup();
            loginForm.Show();
            isCLosing = true;
            this.Close();
        }
    }
}