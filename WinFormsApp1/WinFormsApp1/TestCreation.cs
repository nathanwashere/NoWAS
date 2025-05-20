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
        private int currentTestId;
        private List<Question> selectedQuestions = new List<Question>();
        private string currentTestName = "Math Basics"; // Example name — replace with input later
        private int currentPersonId = 1234; // Simulated user ID (should come from login)

        public TestCreation()
        {
<<<<<<< Updated upstream
            InitializeCompoent();
        }

        private void InitializeCompoent()
        {
            throw new NotImplementedException();
=======
            InitializeComponent();
            currentTestId = GetNextTestId();
        }

        private int GetNextTestId()
        {
            int nextId = 1;
            string connectionString = @"Data Source=C:\Users\lizav\OneDrive\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db;Version=3;";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT MAX(TestID) FROM Test", conn);
                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                    nextId = Convert.ToInt32(result) + 1;
            }
            return nextId;
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            var availableQuestions = LoadQuestionsFromDB();
            var selector = new QuestionSelectionForm(availableQuestions);

            if (selector.ShowDialog() == DialogResult.OK)
            {
                selectedQuestions.AddRange(selector.SelectedQuestions);

                string connectionString = @"Data Source=C:\Users\lizav\OneDrive\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db;Version=3;";
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Enable foreign key checks
                    using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", conn))
                        pragma.ExecuteNonQuery();

                    // Insert the test only once
                    string insertTestQuery = "INSERT INTO Test (TestID, TestName, Score, PersonID, Question) VALUES (@id, @name, @score, @pid, '')";
                    using (var cmd = new SQLiteCommand(insertTestQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", currentTestId);
                        cmd.Parameters.AddWithValue("@name", currentTestName);
                        cmd.Parameters.AddWithValue("@score", 0);
                        cmd.Parameters.AddWithValue("@pid", currentPersonId);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert selected questions into TestQuestions
                    foreach (var q in selector.SelectedQuestions)
                    {
                        // Optional debug check (can be removed in final version)
                        var checkQ = new SQLiteCommand("SELECT COUNT(*) FROM Question WHERE QuestionID = @qid", conn);
                        checkQ.Parameters.AddWithValue("@qid", q.QuestionID);
                        int count = Convert.ToInt32(checkQ.ExecuteScalar());
                        if (count == 0)
                        {
                            MessageBox.Show($"Question ID {q.QuestionID} does not exist in DB.");
                            continue;
                        }

                        string insertLinkQuery = "INSERT INTO TestQuestions (TestID, QuestionID) VALUES (@tid, @qid)";
                        using (var cmd = new SQLiteCommand(insertLinkQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@tid", currentTestId);
                            cmd.Parameters.AddWithValue("@qid", q.QuestionID);
                            cmd.ExecuteNonQuery();
                        }

                        lstSelectedQuestions.Items.Add(q.ToString());
                    }

                    MessageBox.Show("Test created and questions added successfully!");
                }
            }
        }

        private List<Question> LoadQuestionsFromDB()
        {
            List<Question> questions = new List<Question>();
            string connectionString = @"Data Source=C:\Users\lizav\OneDrive\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db;Version=3;";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT QuestionID, Body, Awnser, TestID, [Difficulty level], [The cours], type FROM Question";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            QuestionID = reader.GetInt32(0),
                            Body = reader.GetString(1),
                            Answer = reader.GetString(2),
                            TestID = reader.IsDBNull(3) ? -1 : reader.GetInt32(3),
                            DifficultyLevel = reader.GetString(4),
                            Course = reader.GetString(5),
                            Type = reader.GetString(6)
                        });
                    }
                }
            }
            return questions;
>>>>>>> Stashed changes
        }
    }
}
