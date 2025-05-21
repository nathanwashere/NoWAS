using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TestCreation : Form
    {
        private readonly List<Question> selectedQuestions = new();
        private readonly string currentTestName = "Math Basics";
        private readonly int currentPersonId = 1234;

        public TestCreation()
        {
            InitializeComponent();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
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
            long testId;
            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show("Please add at least one question before creating the test.");
                return;
            }

            string connectionString = @"Data Source=C:\Users\lizav\OneDrive\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db;Version=3;";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Step 1: Generate a new TestID manually
               
                string getIdQuery = "SELECT IFNULL(MAX(TestID), 0) + 1 FROM TestQuestions";
                using (var getIdCmd = new SQLiteCommand(getIdQuery, conn))
                {
                    testId = Convert.ToInt64(getIdCmd.ExecuteScalar());
                }

                // Step 2: Get current timestamp
                string dateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                // Step 3: Insert each question under this test
                foreach (var q in selectedQuestions)
                {
                    string insertQuery = "INSERT INTO TestQuestions (TestID, TestName, Score, PersonID, Question, DateCreated) " +
                                         "VALUES (@tid, @name, @score, @pid, @question, @date)";
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

                // Step 4: Show test in ListView
                var item = new ListViewItem(testId.ToString());
                item.SubItems.Add(dateCreated);
                item.SubItems.Add(selectedQuestions.Count.ToString());
                item.SubItems.Add("Mixed"); // Can be enhanced later
                lvTests.Items.Add(item);
            }

            MessageBox.Show("Test created successfully!");
            selectedQuestions.Clear();
            lstSelectedQuestions.Items.Clear();
            StudentTestForm studentTestForm = new StudentTestForm((int)testId);
            studentTestForm.Show();
        }

        private List<Question> LoadQuestionsFromDB()
        {
            List<Question> questions = new();
            string connectionString = @"Data Source=C:\Users\avivb\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT QuestionID, Body, Answer, TestID, [Difficulty level], [Course], type FROM Question";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string type = reader.IsDBNull(6) ? "" : reader.GetString(6);

                        switch (type)
                        {
                            case "Multiple Choice":
                                
                                string[] options = new string[] {
            reader["Possible answer 1"].ToString(),
            reader["Possible answer 2"].ToString(),
            reader["Possible answer 3"].ToString()
        };
                                string correctAnswer = reader["Answer"].ToString();
                                int correctIndex = Array.IndexOf(options, correctAnswer);
                                questions.Add(new MultipleChoiceQuestion(
                                    reader["Body"].ToString(),
                                    options,
                                    correctIndex
                                ));
                                break;

                            case "TrueFalse":
                                bool tfAnswer = bool.TryParse(reader["Answer"].ToString(), out var val) && val;
                                questions.Add(new TrueFalseQuestion(reader["Body"].ToString(), tfAnswer));
                                break;

                            case "FillInTheBlank":
                                questions.Add(new FillInTheBlank(reader["Body"].ToString(), reader["Answer"].ToString()));
                                break;

                            default:
                                
                                break;
                        }

                    }
                }
            }

            return questions;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
