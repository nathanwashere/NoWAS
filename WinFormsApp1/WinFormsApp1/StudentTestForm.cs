using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public StudentTestForm(int testId)
        {
            InitializeComponent();
            this.testId = testId;
        }

        private void StudentTestForm_Load(object sender, EventArgs e)
        {
            questions = new List<Question>
            {
                new MultipleChoiseQuestion("What is 2 + 2?", new[] { "3", "4", "5", "6" }, 1),
                new TrueFalseQuestion("The Earth is flat.", false),
                new FillInTheBlank("Complete: The capital of France is ____.", "Paris")
            };
            //string connStr = "Data Source=.;Initial Catalog=QuizDB;Integrated Security=True;";
            //LoadQuestionsFromDatabase(connStr, testId);
            //ShowQuestion();



            ShowQuestion();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentPanel();

            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Count)
            {
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("End of quiz!");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                SaveCurrentPanel();

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
            panelQuestion.Controls.Clear();
            Panel newPanel = new Panel { Dock = DockStyle.Fill };
            questions[currentQuestionIndex].Display(newPanel);
            panelQuestion.Controls.Add(newPanel);

            // Reuse saved answer panel if exists
            if (currentQuestionIndex < allAnswerPanels.Count)
            {
                panelQuestion.Controls.Clear();
                panelQuestion.Controls.Add(allAnswerPanels[currentQuestionIndex]);
            }
            else
            {
                allAnswerPanels.Add(newPanel);
            }
        }

        private void SaveCurrentPanel()
        {
            if (currentQuestionIndex < allAnswerPanels.Count)
            {
                allAnswerPanels[currentQuestionIndex] = panelQuestion.Controls[0] as Panel;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            SaveCurrentPanel();

            int finalScore = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].CheckAnswer(allAnswerPanels[i]))
                {
                    finalScore++;
                }
            }

            double grade = (double)finalScore / questions.Count * 100;
            MessageBox.Show(
                $"Test completed!\nScore: {finalScore}/{questions.Count}\nGrade: {grade:F1}%",
                "Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            //string studentName = Microsoft.VisualBasic.Interaction.InputBox("Enter your full name to save your result:", "Student Login", "Your Name");
            //SaveResultForExistingStudent(studentName, finalScore, questions.Count, grade, connectionString);

            this.Close();
        }
        private void LoadQuestionsFromDatabase(string connectionString, int testId)
        {
            questions = new List<Question>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT QuestionID, Body, Answer, Type
            FROM Question
            WHERE TestID = @testId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@testId", testId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string text = reader["Body"].ToString();
                    string answer = reader["Answer"].ToString();
                    string type = reader["Type"].ToString();

                    switch (type)
                    {
                        case "MultipleChoice":
                           
                            string[] opts = answer.Split(';');
                            int correctIndex = 0; // ← זמני
                            questions.Add(new MultipleChoiseQuestion(text, opts, correctIndex));
                            break;

                        case "TrueFalse":
                            bool tfAnswer = bool.TryParse(answer, out var val) && val;
                            questions.Add(new TrueFalseQuestion(text, tfAnswer));
                            break;

                        case "FillInTheBlank":
                            questions.Add(new FillInTheBlank(text, answer));
                            break;

                        default:
                            MessageBox.Show($"Unknown question type: {type}");
                            break;
                    }
                }

                reader.Close();
            }
        }



        private void SaveResultForExistingStudent(string studentName, int score, int total, double grade, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

       
                string getIdQuery = "SELECT Id FROM Students WHERE Name = @name";
                SqlCommand getIdCmd = new SqlCommand(getIdQuery, conn);
                getIdCmd.Parameters.AddWithValue("@name", studentName);

                object result = getIdCmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show($"Student '{studentName}' not found in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int studentId = Convert.ToInt32(result);

                
                string insertQuery = @"INSERT INTO StudentResults (StudentId, Score, TotalQuestions, Grade, TestDate)
                               VALUES (@studentId, @score, @total, @grade, @date)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@studentId", studentId);
                insertCmd.Parameters.AddWithValue("@score", score);
                insertCmd.Parameters.AddWithValue("@total", total);
                insertCmd.Parameters.AddWithValue("@grade", grade);
                insertCmd.Parameters.AddWithValue("@date", DateTime.Now);

                insertCmd.ExecuteNonQuery();
            }
        }


    }
}
