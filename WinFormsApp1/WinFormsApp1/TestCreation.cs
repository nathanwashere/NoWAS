using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TestCreation : Form
    {
        private static readonly Dictionary<string, string> topicMap = new Dictionary<string, string>
{
    { "Intro to CS", "Introduction to Computer Science" } // Map short topic name to full name
};

        private readonly List<Question> selectedQuestions = new(); // Stores questions selected for the test

        //private readonly int currentPersonId = 1234; // (unused/test line)
        private string lastSelectedCategory = ""; // Track last selected category
        private string lastSelectedDifficulty = ""; // Track last selected difficulty
        private readonly string userName; // Store the logged-in user's name

        public TestCreation(string username)
        {
            InitializeComponent(); // Load form components

            userName = username; // Assign logged-in username
            LoadTestsToListView(); // Load test data to UI

            // Round button corners
            RoundButtonCorners(btnAddQuestion, btnAddQuestion.Height);
            RoundButtonCorners(btnCreate, btnCreate.Height);
            RoundButtonCorners(btnClear, btnClear.Height);
            RoundButtonCorners(btnViewDetails, btnViewDetails.Height);
            RoundButtonCorners(backToMainbtn, backToMainbtn.Height);
            RoundButtonCorners(AutomaticTest, AutomaticTest.Height);
            RoundButtonCorners(btnDeleteTest, btnDeleteTest.Height);
        }

        private int GetPersonIdFromUsername(string username)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath); // Get absolute DB path
            string connectionString = $"Data Source={dbPath};Version=3;"; // DB connection string

            using (var conn = new SQLiteConnection(connectionString)) // Open DB connection
            {
                conn.Open();
                string query = "SELECT Id FROM Person WHERE userName = @username"; // Query user ID

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username); // Bind username
                    object result = cmd.ExecuteScalar(); // Execute query

                    return result != null ? Convert.ToInt32(result) : -1; // Return ID or -1 if not found
                }
            }
        }

        private void RoundButtonCorners(Button btn, int radius) //visual method to make buttons rounded
        {
            var bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }
        private void LoadTestsToListView()
        {
            lvTests.Items.Clear(); // Clear previous items from ListView

            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath); // Get absolute DB path
            string connectionString = $"Data Source={dbPath};Version=3;"; // DB connection string

            int currentPersonId = GetPersonIdFromUsername(userName); // Get teacher's ID
            if (currentPersonId == -1)
            {
                MessageBox.Show("Unable to retrieve teacher ID."); // Show error if ID not found
                return;
            }

            using (var conn = new SQLiteConnection(connectionString)) // Open DB connection
            {
                conn.Open();

                string query = @"
            SELECT tq.TestID, tq.TestName, MAX(tq.DateCreated) AS DateCreated, COUNT(*) as QuestionCount
            FROM TestQuestions tq
            INNER JOIN Test t ON tq.TestID = t.TestID
            WHERE t.PersonID = @personId
            GROUP BY tq.TestID, tq.TestName"; // Fetch test info for this teacher

                using (var cmd = new SQLiteCommand(query, conn)) // Create command
                {
                    cmd.Parameters.AddWithValue("@personId", currentPersonId); // Bind teacher ID

                    using (var reader = cmd.ExecuteReader()) // Execute and read results
                    {
                        while (reader.Read())
                        {
                            var item = new ListViewItem(reader["TestID"].ToString()); // Test ID
                            item.SubItems.Add(reader["DateCreated"].ToString()); // Date created
                            item.SubItems.Add(reader["QuestionCount"].ToString()); // Number of questions
                            item.SubItems.Add(reader["TestName"].ToString()); // Test name
                            lvTests.Items.Add(item); // Add to ListView
                        }
                    }
                }
            }
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            // Require one category and one difficulty selected
            if (chkTopics.CheckedItems.Count == 0 || chkDifficulty.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select one category and one difficulty level.");
                return;
            }

            // Store selections
            lastSelectedCategory = chkTopics.CheckedItems[0].ToString();
            lastSelectedDifficulty = chkDifficulty.CheckedItems[0].ToString();

            // Load questions matching selection
            var availableQuestions = LoadQuestionsFromDB(lastSelectedCategory, lastSelectedDifficulty);
            var selector = new QuestionSelectionForm(availableQuestions); // Open selector modal

            if (selector.ShowDialog() == DialogResult.OK) // If user confirmed selection
            {
                if (!selector.SelectedQuestions.Any())
                {
                    MessageBox.Show("No questions were selected."); // None chosen
                    return;
                }

                foreach (var q in selector.SelectedQuestions)
                {
                    selectedQuestions.Add(q); // Add to internal list
                    lstSelectedQuestions.Items.Add(q.ToString()); // Show in UI list
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            long testId;
            int currentPersonId = GetPersonIdFromUsername(userName); // Get teacher's ID

            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show("Please add at least one question before creating the test.");
                return;
            }

            // Map short topic name to full name if exists
            string selectedCategory = topicMap.ContainsKey(lastSelectedCategory)
                ? topicMap[lastSelectedCategory]
                : lastSelectedCategory;

            // Convert difficulty string to int
            string selectedDifficultyStr = lastSelectedDifficulty;
            int difficultyValue = selectedDifficultyStr switch
            {
                "Easy" => 1,
                "Intermediate" => 2,
                "Advanced" => 3,
                _ => 0
            };

            // Validate category and difficulty
            if (string.IsNullOrEmpty(selectedCategory) || difficultyValue == 0)
            {
                MessageBox.Show("Please select both a topic and difficulty level before creating the test.");
                return;
            }

            string currentTestName = $"{selectedDifficultyStr} {selectedCategory}"; // Construct test name

            // Prepare DB connection
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Generate new TestID
                string getIdQuery = "SELECT IFNULL(MAX(TestID), 0) + 1 FROM Test";
                using (var getIdCmd = new SQLiteCommand(getIdQuery, conn))
                {
                    testId = Convert.ToInt64(getIdCmd.ExecuteScalar());
                }

                string dateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); // Current time

                // Insert into Test table
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

                // Insert each selected question
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

                        // Handle multiple-choice options
                        if (q is MultipleChoiceQuestion mcq)
                        {
                            var optionList = new List<string>(mcq.Options);

                            // Ensure correct answer is included
                            if (!optionList.Contains(mcq.Answer))
                                optionList[0] = mcq.Answer;

                            // Ensure 3 options exist
                            while (optionList.Count < 3)
                                optionList.Add("");

                            var chosenOptions = optionList.Take(3).ToArray();

                            cmd.Parameters.AddWithValue("@pa1", chosenOptions[0]);
                            cmd.Parameters.AddWithValue("@pa2", chosenOptions[1]);
                            cmd.Parameters.AddWithValue("@pa3", chosenOptions[2]);
                        }
                        else
                        {
                            // If not MCQ, leave answers null
                            cmd.Parameters.AddWithValue("@pa1", DBNull.Value);
                            cmd.Parameters.AddWithValue("@pa2", DBNull.Value);
                            cmd.Parameters.AddWithValue("@pa3", DBNull.Value);
                        }

                        // Convert difficulty to int
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

                // Add test info to ListView
                var item = new ListViewItem(testId.ToString());
                item.SubItems.Add(dateCreated);
                item.SubItems.Add(selectedQuestions.Count.ToString());
                item.SubItems.Add(selectedCategory);
                lvTests.Items.Add(item);
            }

            MessageBox.Show("Test created successfully!"); // Notify success
            selectedQuestions.Clear(); // Clear selected list
            lstSelectedQuestions.Items.Clear(); // Clear UI list
        }


        private List<Question> LoadQuestionsFromDB(string selectedCategory, string selectedDifficulty)
        {
            List<Question> questions = new(); // List to store loaded questions

            // Get absolute DB path and create connection string
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Query questions by category and difficulty
                string query = @"
            SELECT * FROM Question_new 
            WHERE TRIM(LOWER([Course])) = TRIM(LOWER(@category)) AND [Difficulty level] = @difficulty";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    // Map short name to full name if needed
                    string mappedCategory = topicMap.ContainsKey(selectedCategory)
                        ? topicMap[selectedCategory]
                        : selectedCategory;

                    cmd.Parameters.AddWithValue("@category", mappedCategory);
                    cmd.Parameters.AddWithValue("@difficulty", selectedDifficulty);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string type = reader.IsDBNull(6) ? "" : reader.GetString(6); // Get question type

                            switch (type)
                            {
                                case "Multiple Choice":
                                    // Collect possible answers
                                    var optList = new List<string>
                            {
                                reader["Possible Answer 1"].ToString(),
                                reader["Possible Answer 2"].ToString(),
                                reader["Possible Answer 3"].ToString()
                            };

                                    string answer = reader["Answer"].ToString().Trim();
                                    optList.Add(answer); // Add correct answer

                                    // Limit to 3 options + correct one
                                    if (optList.Count > 4)
                                    {
                                        var others = optList.Where(x => x != answer).Distinct().Take(3).ToList();
                                        others.Add(answer);
                                        optList = others;
                                    }

                                    // Shuffle options
                                    var rng = new Random();
                                    optList = optList.OrderBy(x => rng.Next()).ToList();
                                    int correctIndex = optList.IndexOf(answer);

                                    // Add MCQ to list
                                    questions.Add(new MultipleChoiceQuestion(reader["Body"].ToString(), optList.ToArray(), correctIndex));
                                    break;

                                case "True/False":
                                    // Parse and add True/False question
                                    bool tfAnswer = bool.TryParse(reader["Answer"].ToString(), out var val) && val;
                                    questions.Add(new TrueFalseQuestion(reader["Body"].ToString(), tfAnswer));
                                    break;

                                case "Sentence Completion":
                                    // Add Fill-in-the-Blank question
                                    questions.Add(new FillInTheBlank(reader["Body"].ToString(), reader["Answer"].ToString()));
                                    break;

                                default:
                                    break; // Unknown type – skip
                            }
                        }
                    }
                }
            }

            return questions; // Return the loaded question list
        }



        private void BtnDeleteTest_click(object sender, EventArgs e)
        {
            if (lvTests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a test to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = lvTests.SelectedItems[0];
            int testId = int.Parse(selectedItem.SubItems[0].Text); // Get selected test ID

            var confirm = MessageBox.Show($"Are you sure you want to delete test ID {testId}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Delete test questions from DB
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
            lvTests.Items.Remove(selectedItem); // Remove from UI
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lstSelectedQuestions.Items.Clear(); // Clear UI
            selectedQuestions.Clear(); // Clear list
        }

        private void BtnViewDetails_click(object sender, EventArgs e)
        {
            if (lvTests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a test to view.");
                return;
            }

            int testId = int.Parse(lvTests.SelectedItems[0].Text); // Get test ID
            List<string> questions = GetQuestionsForTest(testId); // Load questions

            // Format question text
            string formatted = string.Join($"{Environment.NewLine}-----------------------{Environment.NewLine}{Environment.NewLine}", questions);

            // Create details window
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
                        chkDifficulty.SetItemChecked(i, false); // Uncheck others
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
                        chkTopics.SetItemChecked(i, false); // Uncheck others
                }
            }
        }

        private List<string> GetQuestionsForTest(int testId)//visual for seeing the questions selected
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

                            // Format each question
                            list.Add($"Question {index++}:{Environment.NewLine}{body}{Environment.NewLine}Answer: {answer}");
                        }
                    }
                }
            }

            return list; // Return formatted question list
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            mainTeacher mainTeacher = new mainTeacher(userName); // Go back to main teacher screen
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

            // Store selections
            lastSelectedCategory = chkTopics.CheckedItems[0].ToString();
            lastSelectedDifficulty = chkDifficulty.CheckedItems[0].ToString();

            string mappedCategory = topicMap.ContainsKey(lastSelectedCategory)
                ? topicMap[lastSelectedCategory]
                : lastSelectedCategory;

            // Load and shuffle 5 random questions
            var availableQuestions = LoadQuestionsFromDB(mappedCategory, lastSelectedDifficulty);
            var random = new Random();
            var selectedForTest = availableQuestions.OrderBy(x => random.Next()).Take(5).ToList();

            foreach (var q in selectedForTest)
            {
                selectedQuestions.Add(q); // Add to list
                lstSelectedQuestions.Items.Add(q.ToString()); // Show in UI
            }
        }

    }
}

