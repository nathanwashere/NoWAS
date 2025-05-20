using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
using System.Data.SQLite;
>>>>>>> Stashed changes
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TestCreation : Form
    {
<<<<<<< Updated upstream
=======
        private readonly List<Question> selectedQuestions = new();
        private readonly string currentTestName = "Math Basics";
        private readonly int currentPersonId = 1234;

        
        private Button btnAddQuestionControl;

>>>>>>> Stashed changes
        public TestCreation()
        {
            InitializeComponent();
        }
<<<<<<< Updated upstream
        private List<Question> selectedQuestions = new List<Question>();
        private int currentTestId = 1; // you can increment this per test
        private string currentTestName = "Math Basics"; // example
        private int currentPersonId = 1234; // logged-in user ID
=======
>>>>>>> Stashed changes


        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream

            var availableQuestions = LoadQuestionsFromDB();

            var selector = new QuestionSelectionForm(availableQuestions); // you build this form
            if (selector.ShowDialog() == DialogResult.OK)
            {
                string connectionString = @"data source=C:\Users\lizav\OneDrive\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db; version=3;";
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    foreach (var q in selector.SelectedQuestions)
                    {
                        selectedQuestions.Add(q);

                        // INSERT into Test table
                        string insertQuery = "INSERT INTO Test (TestID, TestName, Score, PersonID, Question) VALUES (@id, @name, @score, @pid, @question)";
                        using (var cmd = new SQLiteCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentTestId);
                            cmd.Parameters.AddWithValue("@name", currentTestName);
                            cmd.Parameters.AddWithValue("@score", 0); // default score
                            cmd.Parameters.AddWithValue("@pid", currentPersonId);
                            cmd.Parameters.AddWithValue("@question", q.Body);

                            cmd.ExecuteNonQuery();
                        }

                        // Optional: display it in the UI (e.g., a ListBox or ListView)
                        lstSelectedQuestions.Items.Add(q.ToString());
                    }
                }
            }
        }
        private List<Question> LoadQuestionsFromDB()
        {
            List<Question> questions = new List<Question>();
            string connectionString = "Data Source=DataBase.db;Version=3;";
=======
            var availableQuestions = LoadQuestionsFromDB();
            var selector = new QuestionSelectionForm(availableQuestions); // You must implement this form

            if (selector.ShowDialog() == DialogResult.OK)
            {
                foreach (var q in selector.SelectedQuestions)
                {
                    selectedQuestions.Add(q);
                    lstSelectedQuestions.Items.Add(q.ToString());
                }
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show("Please add at least one question before creating the test.");
                return;
            }

            string connectionString = @"Data Source=C:\Users\lizav\OneDrive\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db;Version=3;";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Step 1: Generate a new TestID
                long testId;
                string getIdQuery = "SELECT IFNULL(MAX(TestID), 0) + 1 FROM TestQuestions";
                using (var getIdCmd = new SQLiteCommand(getIdQuery, conn))
                {
                    testId = Convert.ToInt64(getIdCmd.ExecuteScalar());
                }

                // Step 2: Get current timestamp
                string dateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                // Step 3: Insert all questions with that TestID
                foreach (var q in selectedQuestions)
                {
                    string insertQuery = "INSERT INTO TestQuestions (TestID, TestName, Score, PersonID, Question, DateCreated) VALUES (@tid, @name, @score, @pid, @question, @date)";
                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", testId);
                        cmd.Parameters.AddWithValue("@name", currentTestName);
                        cmd.Parameters.AddWithValue("@score", 0);
                        cmd.Parameters.AddWithValue("@pid", currentPersonId);
                        cmd.Parameters.AddWithValue("@question", q.Body);
                        cmd.Parameters.AddWithValue("@date", dateCreated);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Step 4: Add test to the ListView
                var listItem = new ListViewItem(testId.ToString());
                listItem.SubItems.Add(dateCreated);
                listItem.SubItems.Add(selectedQuestions.Count.ToString());
                listItem.SubItems.Add("Mixed"); // Or calculate from topics if needed
                lvTests.Items.Add(listItem);
            }

            MessageBox.Show("Test created successfully!");

            selectedQuestions.Clear();
            lstSelectedQuestions.Items.Clear();
        }

        private List<Question> LoadQuestionsFromDB()
        {
            List<Question> questions = new();
            string connectionString = @"Data Source=C:\Users\lizav\OneDrive\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db;Version=3;";
>>>>>>> Stashed changes

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT QuestionID, Body, Answer, TestID, [Difficulty level], [Course], type FROM Question";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            QuestionID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Body = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Answer = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            TestID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            DifficultyLevel = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Course = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Type = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                }
            }

            return questions;
        }
    }
}
