using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class mainTeacher : Form
    {
        private readonly string connectionString = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db")};Version=3;";
        // SQLite connection string
        private readonly string userName; // Logged-in teacher's username
        private bool isCLosing = false; // Flag to handle controlled closing

        public mainTeacher(String username)
        {
            userName = username; // Store username
            InitializeComponent(); // Load form UI
            LoadTeacherStats(); // Load stats on startup
        }

        private void LoadTeacherStats()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) // Open DB connection
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            COUNT(*) AS TotalTests,
                            ROUND(AVG(Score), 2) AS AverageScore
                        FROM Test
                        WHERE PersonID = (SELECT Id FROM Person WHERE username = @Username)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) // Prepare SQL command
                    {
                        cmd.Parameters.AddWithValue("@Username", userName); // Bind username

                        using (SQLiteDataReader reader = cmd.ExecuteReader()) // Execute reader
                        {
                            int totalTests = 0;
                            double avgScore = 0;

                            if (reader.Read())
                            {
                                object totalTestsObj = reader["TotalTests"];
                                object avgScoreObj = reader["AverageScore"];

                                if (totalTestsObj != DBNull.Value)
                                    totalTests = Convert.ToInt32(totalTestsObj);
                                if (avgScoreObj != DBNull.Value)
                                    avgScore = Convert.ToDouble(avgScoreObj);
                            }

                            lblTestsCreated.Text = $"Tests created: {totalTests}";
                            lblAvgScore.Text = $"Average score: {avgScore:F2}%";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show error and set default values
                MessageBox.Show("Failed to load teacher stats: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTestsCreated.Text = "Tests created: 0";
                lblAvgScore.Text = "Average score: 0%";
            }
        }

        private void btnCheckSubmissions_Click(object sender, EventArgs e)
        {
            InsertingQuestions i_q = new InsertingQuestions(this); // Open question insertion form
            i_q.Show();
            this.Hide();
        }

        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            TestCreation testCreation = new TestCreation(userName); // Open test creation form
            testCreation.Show();
            this.Hide();
        }

        private void mainTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCLosing)
            {
                Application.Exit(); // Exit application if form is closed directly
            }
        }

        private void Button1_click(object sender, EventArgs e)
        {
            StudentStatisticsForm studentStatisticsForm = new StudentStatisticsForm(userName); // Open student stats form
            studentStatisticsForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login_Signup loginForm = new Login_Signup(); // Back to login screen
            loginForm.Show();
            isCLosing = true;
            this.Close();
        }

        private void DeleteQuestionsbtn_Click(object sender, EventArgs e)
        {
            Deleting_questions DeleteQuestionForm = new Deleting_questions(this, this); // Open delete questions form
            DeleteQuestionForm.Show();
            isCLosing = true;
            this.Hide();
        }

        private void mainTeacher_Load(object sender, EventArgs e)
        {
            // Empty form load handler
        }
    }
}
