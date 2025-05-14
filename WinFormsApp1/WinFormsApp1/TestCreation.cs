using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WinFormsApp1
{
    public partial class TestCreation : Form
    {
        public TestCreation()
        {
            InitializeComponent();
        }
        private List<Question> selectedQuestions = new List<Question>();
        private int currentTestId = 1; // you can increment this per test
        private string currentTestName = "Math Basics"; // example
        private int currentPersonId = 1234; // logged-in user ID


        private void btnAddQuestion_Click(object sender, EventArgs e)
        {

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
                            Awnser = reader.GetString(2),
                            TestID = reader.GetInt32(3),
                            DifficultyLevel = reader.GetString(4),
                            Cours = reader.GetString(5),
                            Type = reader.GetString(6)
                        });
                    }
                }
            }

            return questions;
        }
    }
}
