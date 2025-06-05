using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class StudentTestForm : Form
    {
        private int score = 0;
        private List<Question> questions;
        private List<Panel> allAnswerPanels = new List<Panel>();
        private int currentQuestionIndex = 0;
        private int testId;
        private string userName;

        public StudentTestForm(int testId, string userName)
        {
            this.userName = userName;
            InitializeComponent();
            this.testId = testId;
        }

        private void StudentTestForm_Load(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";
            LoadQuestionsFromDatabase(connectionString, testId);
            ShowQuestion();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentPanel();

            if (currentQuestionIndex + 1 < questions.Count)
            {
                currentQuestionIndex++;
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("End of quiz!");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SaveCurrentPanel();

            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("This is the first question.");
            }
        }

        private void ShowQuestion()
        {
            if (questions == null || questions.Count == 0 || currentQuestionIndex < 0 || currentQuestionIndex >= questions.Count)
            {
                return;
            }

            panelQuestion.Controls.Clear();
            Panel newPanel = new Panel { Dock = DockStyle.Fill };
            questions[currentQuestionIndex].Display(newPanel);

            if (currentQuestionIndex < allAnswerPanels.Count)
            {
                panelQuestion.Controls.Add(allAnswerPanels[currentQuestionIndex]);
            }
            else
            {
                allAnswerPanels.Add(newPanel);
                panelQuestion.Controls.Add(newPanel);
            }
        }

        private void SaveCurrentPanel()
        {
            if (currentQuestionIndex < allAnswerPanels.Count && panelQuestion.Controls.Count > 0)
            {
                var panel = panelQuestion.Controls[0] as Panel;
                if (panel != null)
                    allAnswerPanels[currentQuestionIndex] = panel;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            SaveCurrentPanel();

            int finalScore = 0;
            if (allAnswerPanels.Count > 0) {
                for (int i = 0; i < allAnswerPanels.Count; i++)
                {
                    if (questions[i].CheckAnswer(allAnswerPanels[i]))
                    {
                        finalScore++;
                    }
                } }

            double grade = (double)finalScore / questions.Count * 100;
            MessageBox.Show(
                $"Test completed!\nScore: {finalScore}/{questions.Count}\nGrade: {grade:F1}%",
                "Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            string username = this.userName;

            if (!string.IsNullOrWhiteSpace(username))
            {
                var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
                dbPath = Path.GetFullPath(dbPath);
                string connectionString = $"Data Source={dbPath};Version=3;";
                SaveResultForExistingPerson(username, testId, finalScore, questions.Count, grade, connectionString);
            }

            this.Close();
        }

        private void LoadQuestionsFromDatabase(string connectionString, int testId)
        {
            questions = new List<Question>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT Body, Type, Answer, PossibleAnswer1, PossibleAnswer2, PossibleAnswer3
            FROM TestQuestions
            WHERE TestID = @testId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@testId", testId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string body = reader["Body"].ToString();
                            string type = reader["Type"].ToString();
                            string answer = reader["Answer"].ToString().Trim();

                            switch (type)
                            {
                                case "Multiple Choice":
                                    var optList = new List<string>
                                    {
                                        reader["PossibleAnswer1"].ToString(),
                                        reader["PossibleAnswer2"].ToString(),
                                        reader["PossibleAnswer3"].ToString()
                                    };

                                    
                                        optList.Add(answer);

                                    while (optList.Count < 4)
                                        optList.Add("");

                                    if (optList.Count > 4)
                                    {
                                        var others = optList.Where(x => x != answer).Distinct().Take(3).ToList();
                                        others.Add(answer);
                                        optList = others;
                                    }

                                    var rng = new Random();
                                    optList = optList.OrderBy(x => rng.Next()).ToList();

                                    int correctIndex = optList.IndexOf(answer);

                                    questions.Add(new MultipleChoiceQuestion(body, optList.ToArray(), correctIndex));
                                    break;

                                case "TrueFalse":
                                    bool tf = bool.TryParse(answer, out var val) && val;
                                    questions.Add(new TrueFalseQuestion(body, tf));
                                    break;

                                case "FillInTheBlank":
                                    questions.Add(new FillInTheBlank(body, answer));
                                    break;

                                default:
                                    MessageBox.Show($"Unknown type: {type}");
                                    break;
                            }
                        }
                    }
                }
            }
            allAnswerPanels = new List<Panel>(questions.Count);
            for (int i = 0; i < allAnswerPanels.Count; i++) { allAnswerPanels[i] = new Panel(); }
        }

        private void SaveResultForExistingPerson(string username, int testId, int score, int total, double grade, string connectionString)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string getIdQuery = "SELECT Id FROM Person WHERE username = @username";
                using (var getIdCmd = new SQLiteCommand(getIdQuery, conn))
                {
                    getIdCmd.Parameters.AddWithValue("@username", username);
                    object result = getIdCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show($"המשתמש '{username}' לא נמצא במערכת.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int studentId = Convert.ToInt32(result);

                    string difficultyQuery = "SELECT Difficulty FROM Test WHERE TestID = @testId";
                    int difficulty = 0;
                    using (var diffCmd = new SQLiteCommand(difficultyQuery, conn))
                    {
                        diffCmd.Parameters.AddWithValue("@testId", testId);
                        object diffResult = diffCmd.ExecuteScalar();
                        if (diffResult != null && int.TryParse(diffResult.ToString(), out int diffVal))
                        {
                            difficulty = diffVal;
                        }
                    }

                    string insertQuery = @"INSERT INTO StudentResults 
            (StudentId, TestId, Score, TotalQuestions, Grade, TestDate, Difficulty)
            VALUES (@studentId, @testId, @score, @total, @grade, @date, @difficulty)";
                    using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@studentId", studentId);
                        insertCmd.Parameters.AddWithValue("@testId", testId);
                        insertCmd.Parameters.AddWithValue("@score", score);
                        insertCmd.Parameters.AddWithValue("@total", total);
                        insertCmd.Parameters.AddWithValue("@grade", grade);
                        insertCmd.Parameters.AddWithValue("@date", DateTime.Now);
                        insertCmd.Parameters.AddWithValue("@difficulty", difficulty);

                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
