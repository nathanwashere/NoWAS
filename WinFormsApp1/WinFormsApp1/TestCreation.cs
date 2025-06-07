using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TestCreation : Form
    {
        private readonly List<Question> selectedQuestions = new();

        //private readonly int currentPersonId = 1234;
        private string lastSelectedCategory = "";
        private string lastSelectedDifficulty = "";
        private readonly string userName;
        public TestCreation(string username)
        {
            InitializeComponent();
            userName = username;
            LoadTestsToListView();
           
        }
        private int GetPersonIdFromUsername(string username)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id FROM Person WHERE userName = @username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private void LoadTestsToListView()
        {
            lvTests.Items.Clear();
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            int currentPersonId = GetPersonIdFromUsername(userName);
            if (currentPersonId == -1)
            {
                MessageBox.Show("Unable to retrieve teacher ID.");
                return;
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT tq.TestID, tq.TestName, MAX(tq.DateCreated) AS DateCreated, COUNT(*) as QuestionCount
            FROM TestQuestions tq
            INNER JOIN Test t ON tq.TestID = t.TestID
            WHERE t.PersonID = @personId
            GROUP BY tq.TestID, tq.TestName";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@personId", currentPersonId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ListViewItem(reader["TestID"].ToString());
                            item.SubItems.Add(reader["DateCreated"].ToString());
                            item.SubItems.Add(reader["QuestionCount"].ToString());
                            item.SubItems.Add(reader["TestName"].ToString());
                            lvTests.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (chkTopics.CheckedItems.Count == 0 || chkDifficulty.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select one category and one difficulty level.");
                return;
            }

            // Always store the selected values immediately
            lastSelectedCategory = chkTopics.CheckedItems[0].ToString();
            lastSelectedDifficulty = chkDifficulty.CheckedItems[0].ToString();

            var availableQuestions = LoadQuestionsFromDB(lastSelectedCategory, lastSelectedDifficulty);
            var selector = new QuestionSelectionForm(availableQuestions);

            if (selector.ShowDialog() == DialogResult.OK)
            {
                if (!selector.SelectedQuestions.Any())
                {
                    MessageBox.Show("No questions were selected.");
                    return;
                }

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
            int currentPersonId = GetPersonIdFromUsername(userName);

            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show("Please add at least one question before creating the test.");
                return;
            }

            // Get selected category
            string selectedCategory = lastSelectedCategory;
            string selectedDifficultyStr = lastSelectedDifficulty;
            int difficultyValue = selectedDifficultyStr switch
            {
                "Easy" => 1,
                "Intermediate" => 2,
                "Advanced" => 3,
                _ => 0
            };

            if (string.IsNullOrEmpty(selectedCategory) || difficultyValue == 0)
            {
                MessageBox.Show("Please select both a topic and difficulty level before creating the test.");
                return;
            }
            string currentTestName = $"{selectedDifficultyStr} {selectedCategory}";

            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Generate new TestID manually
                string getIdQuery = "SELECT IFNULL(MAX(TestID), 0) + 1 FROM Test";
                using (var getIdCmd = new SQLiteCommand(getIdQuery, conn))
                {
                    testId = Convert.ToInt64(getIdCmd.ExecuteScalar());
                }

                // Get current timestamp
                string dateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                // INSERT into Test table (new line)
                string insertTestQuery = @"
            INSERT INTO Test (TestID, TestName, Score, PersonID, Question, Category, Difficulty)
            VALUES (@tid, @name, @score, @pid, @question, @category, @difficulty)";
                using (var insertTestCmd = new SQLiteCommand(insertTestQuery, conn))
                {
                    insertTestCmd.Parameters.AddWithValue("@tid", testId);
                    insertTestCmd.Parameters.AddWithValue("@name", currentTestName);
                    insertTestCmd.Parameters.AddWithValue("@score", 0);
                    insertTestCmd.Parameters.AddWithValue("@pid", currentPersonId);
                    insertTestCmd.Parameters.AddWithValue("@question", "Mixed");
                    insertTestCmd.Parameters.AddWithValue("@category", selectedCategory);
                    insertTestCmd.Parameters.AddWithValue("@difficulty", difficultyValue);
                    insertTestCmd.ExecuteNonQuery();
                }

                // INSERT each question
                foreach (var q in selectedQuestions)
                {
                    string insertQuery = @"
                INSERT INTO TestQuestions 
                (TestID, TestName, Score, PersonID, Body, Type, Answer, PossibleAnswer1, PossibleAnswer2, PossibleAnswer3, DifficultyLevel, Course, DateCreated) 
                VALUES 
                (@tid, @name, @score, @pid, @body, @type, @answer, @pa1, @pa2, @pa3, @level, @course, @date)";
                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", testId);
                        cmd.Parameters.AddWithValue("@name", currentTestName);
                        cmd.Parameters.AddWithValue("@score", 0);
                        cmd.Parameters.AddWithValue("@pid", currentPersonId);
                        cmd.Parameters.AddWithValue("@body", q.Body);
                        cmd.Parameters.AddWithValue("@type", q.Type);
                        cmd.Parameters.AddWithValue("@answer", q.Answer);

                        if (q is MultipleChoiceQuestion mcq)
                        {
                            var optionList = new List<string>(mcq.Options);
                            if (!optionList.Contains(mcq.Answer))
                                optionList[0] = mcq.Answer;

                            while (optionList.Count < 3)
                                optionList.Add("");

                            var chosenOptions = optionList.Take(3).ToArray();

                            cmd.Parameters.AddWithValue("@pa1", chosenOptions.Length > 0 ? chosenOptions[0] : DBNull.Value);
                            cmd.Parameters.AddWithValue("@pa2", chosenOptions.Length > 1 ? chosenOptions[1] : DBNull.Value);
                            cmd.Parameters.AddWithValue("@pa3", chosenOptions.Length > 2 ? chosenOptions[2] : DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@pa1", DBNull.Value);
                            cmd.Parameters.AddWithValue("@pa2", DBNull.Value);
                            cmd.Parameters.AddWithValue("@pa3", DBNull.Value);
                        }

                        // המרה של DifficultyLevel ל-1,2,3
                        int difficultyInt = q.DifficultyLevel switch
                        {
                            "Easy" => 1,
                            "Intermediate" => 2,
                            "Advanced" => 3,
                            _ => 0
                        };
                        cmd.Parameters.AddWithValue("@level", difficultyInt);

                        cmd.Parameters.AddWithValue("@course", q.Course ?? "");
                        cmd.Parameters.AddWithValue("@date", dateCreated);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Add to ListView
                var item = new ListViewItem(testId.ToString());
                item.SubItems.Add(dateCreated);
                item.SubItems.Add(selectedQuestions.Count.ToString());
                item.SubItems.Add(selectedCategory);
                lvTests.Items.Add(item);
            }

            MessageBox.Show("Test created successfully!");
            selectedQuestions.Clear();
            lstSelectedQuestions.Items.Clear();
        }

        private List<Question> LoadQuestionsFromDB(string selectedCategory, string selectedDifficulty)
        {
            List<Question> questions = new();
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT * FROM Question_new 
            WHERE [Course] = @category AND [Difficulty level] = @difficulty";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    // 🔽 Add parameters here
                    cmd.Parameters.AddWithValue("@category", selectedCategory);
                    cmd.Parameters.AddWithValue("@difficulty", selectedDifficulty);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string type = reader.IsDBNull(6) ? "" : reader.GetString(6);

                            switch (type)
                            {
                                case "Multiple Choice":
                                    var optList = new List<string>
                            {
                                reader["Possible Answer 1"].ToString(),
                                reader["Possible Answer 2"].ToString(),
                                reader["Possible Answer 3"].ToString()
                            };

                                    string answer = reader["Answer"].ToString().Trim();
                                    optList.Add(answer);

                                    if (optList.Count > 4)
                                    {
                                        var others = optList.Where(x => x != answer).Distinct().Take(3).ToList();
                                        others.Add(answer);
                                        optList = others;
                                    }

                                    var rng = new Random();
                                    optList = optList.OrderBy(x => rng.Next()).ToList();
                                    int correctIndex = optList.IndexOf(answer);

                                    questions.Add(new MultipleChoiceQuestion(reader["Body"].ToString(), optList.ToArray(), correctIndex));
                                    break;

                                case "True/False":
                                    bool tfAnswer = bool.TryParse(reader["Answer"].ToString(), out var val) && val;
                                    questions.Add(new TrueFalseQuestion(reader["Body"].ToString(), tfAnswer));
                                    break;

                                case "Sentence Completion":
                                    questions.Add(new FillInTheBlank(reader["Body"].ToString(), reader["Answer"].ToString()));
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            return questions;
        }


        private void BtnDeleteTest_click(object sender, EventArgs e)
        {
            if (lvTests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a test to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = lvTests.SelectedItems[0];
            int testId = int.Parse(selectedItem.SubItems[0].Text);

            var confirm = MessageBox.Show($"Are you sure you want to delete test ID {testId}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM TestQuestions WHERE TestID = @testId";
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@testId", testId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Test deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lvTests.Items.Remove(selectedItem);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lstSelectedQuestions.Items.Clear();
            selectedQuestions.Clear();
        }

        private void BtnViewDetails_click(object sender, EventArgs e)
        {
            if (lvTests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a test to view.");
                return;
            }

            int testId = int.Parse(lvTests.SelectedItems[0].Text);
            List<string> questions = GetQuestionsForTest(testId);

            string formatted = string.Join($"{Environment.NewLine}-----------------------{Environment.NewLine}{Environment.NewLine}", questions);

            Form detailsForm = new Form
            {
                Text = $"Test ID {testId} Details",
                Size = new Size(700, 500),
                StartPosition = FormStartPosition.CenterScreen
            };

            TextBox box = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 11),
                BackColor = Color.White,
                Text = formatted
            };

            detailsForm.Controls.Add(box);
            detailsForm.Show();
        }
        private void chkDifficulty_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < chkDifficulty.Items.Count; i++)
                {
                    if (i != e.Index)
                        chkDifficulty.SetItemChecked(i, false);
                }
            }
        }

        private void chkTopics_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < chkTopics.Items.Count; i++)
                {
                    if (i != e.Index)
                        chkTopics.SetItemChecked(i, false);
                }
            }
        }

        private List<string> GetQuestionsForTest(int testId)
        {
            var list = new List<string>();
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Body, Answer FROM TestQuestions WHERE TestID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", testId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        int index = 1;
                        while (reader.Read())
                        {
                            string body = reader["Body"].ToString();
                            string answer = reader["Answer"].ToString();

                            list.Add($"Question {index++}:{Environment.NewLine}{body}{Environment.NewLine}Answer: {answer}");
                        }
                    }
                }
            }

            return list;
        }
        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            mainTeacher mainTeacher = new mainTeacher(userName);
            mainTeacher.Show();
            this.Hide();
        }
        private void AutomaticTest_Click(object sender, EventArgs e)
        {
            if (chkTopics.CheckedItems.Count == 0 || chkDifficulty.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select one category and one difficulty level.");
                return;
            }
            // Always store the selected values immediately
            lastSelectedCategory = chkTopics.CheckedItems[0].ToString();
            lastSelectedDifficulty = chkDifficulty.CheckedItems[0].ToString();
            var availableQuestions = LoadQuestionsFromDB(lastSelectedCategory, lastSelectedDifficulty);

            var random = new Random();
            var selectedForTest = availableQuestions.OrderBy(x => random.Next()).Take(5).ToList();
            foreach (var q in selectedForTest)
            {
                selectedQuestions.Add(q);
                lstSelectedQuestions.Items.Add(q.ToString());
            }
        }
    }
}

