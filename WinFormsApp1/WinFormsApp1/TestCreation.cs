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
            LoadTestsToListView();
        }

        private void LoadTestsToListView()
        {
            lvTests.Items.Clear();
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TestID, TestName, DateCreated, COUNT(*) as QuestionCount FROM TestQuestions GROUP BY TestID";
                using (var cmd = new SQLiteCommand(query, conn))
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

            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";
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
                        cmd.Parameters.AddWithValue("@type", q.Type); // הוסף Property Type במחלקה!
                        cmd.Parameters.AddWithValue("@answer", q.Answer); // כנ"ל – תוודא שיש בכל שאלה
                                                                          // בדוק לפי טיפוס השאלה:
                        if (q is MultipleChoiceQuestion mcq)
                        {
                            // נבנה רשימה חדשה של אופציות, ודואגים שהתשובה הנכונה בפנים, בלי כפילויות
                            var optionList = new List<string>(mcq.Options);
                            if (!optionList.Contains(mcq.Answer))
                                optionList[0] = mcq.Answer; // נחליף את הראשונה בתשובה הנכונה אם היא לא שם (או תוכל להכניס אותה במקום רנדומלי)

                            // שמור שלוש אופציות בלבד (אם יש יותר)
                            while (optionList.Count < 3)
                                optionList.Add(""); // תשלים אם חסר

                            // אם יש יותר משלוש אופציות, קח רק שלוש (כולל הנכונה!)
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

                        cmd.Parameters.AddWithValue("@level", q.DifficultyLevel ?? "");
                        cmd.Parameters.AddWithValue("@course", q.Course ?? "");
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
            //StudentTestForm studentTestForm = new StudentTestForm((int)testId);
           // studentTestForm.Show();
        }

        private List<Question> LoadQuestionsFromDB()
        {
            List<Question> questions = new();
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT QuestionID, Body, Answer, TestID, [Difficulty level], [Course], type, [Possible answer 1], [Possible answer 2], [Possible answer 3] FROM Question_new";


                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string type = reader.IsDBNull(6) ? "" : reader.GetString(6);

                        switch (type)
                        {
                            case "Multiple Choice":
                                // שליפת שלוש תשובות אפשריות מה־DB (היכן ששמרת Distractors)
                                var optList = new List<string>
    {
        reader["Possible Answer 1"].ToString(),
        reader["Possible Answer 2"].ToString(),
        reader["Possible Answer 3"].ToString()
    };
                                string answer = reader["Answer"].ToString().Trim();

                                // אם התשובה כבר בפנים, אין צורך להוסיף פעמיים
                                if (!optList.Contains(answer))
                                    optList.Add(answer);

                                // אם יש יותר מ־4, קח רק 4 (זהירות על התשובה הנכונה!)
                                if (optList.Count > 4)
                                {
                                    // נשאיר את התשובה הנכונה ובחר עוד 3 (בלי כפילויות)
                                    var others = optList.Where(x => x != answer).Distinct().Take(3).ToList();
                                    others.Add(answer); // הוספנו את התשובה הנכונה
                                    optList = others;
                                }

                                // ערבוב (shuffle) כדי שהתשובה לא תמיד תהיה באותו מקום
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
            mainTeacher mainTeacher = new mainTeacher();
            mainTeacher.Show();
        }

    }
}
