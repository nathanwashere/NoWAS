using System.Data.SQLite;

namespace WinFormsApp1
{
    public partial class InsertingQuestions : Form
    {
        private Form main;
        public InsertingQuestions(Form main)
        {
            InitializeComponent();
            this.main = main;

            // Fixed window size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            /*
            // Manual positioning
            this.StartPosition = FormStartPosition.Manual;
            // Set desired size
            this.Size = new Size(1100, 800);*/

            this.StartPosition = FormStartPosition.Manual;
            // Set desired location on screen
            this.Location = new System.Drawing.Point(100, 100);

            // Disable resizing
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void InsertingQuestions_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exit the entire application when this form is closed
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void course_Click(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void InsertingQuestions_Load(object sender, EventArgs e)
        {
            // Stretch the background image to fill the form
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Build the database path
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            // 2. Read values from TextBoxes
            string qText = question_text.Text;
            string tText = type_text.Text;
            string cText = course_text.Text;
            string caText = c_a_text.Text;
            string lvlText = level_text.Text;
            string p_a1Text = Possible_answer_1.Text;
            string p_a2Text = Possible_answer_2.Text;
            string p_a3Text = Possible_answer_3.Text;

            // Check required fields
            if (!AreRequiredFieldsFilled())
            {
                MessageBox.Show(
                    "All required fields must be filled in.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                // Stop operation if fields are not filled
                return;
            }

            // If question type is "True or False", validate correct answer
            if (type_text.Text.Trim().ToLower() == "true/false")
            {
                string answer = c_a_text.Text.Trim().ToLower();
                if (caText.Trim().ToLower() != "true" && caText.Trim().ToLower() != "false")
                {
                    MessageBox.Show(
                        "For 'True or False' questions, the correct answer must be either 'true' or 'false'.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            // 3. INSERT query
            string query = @"
                INSERT INTO Question_new 
                    (Body, type, [Course], answer, [Difficulty level], [Possible answer 1], [Possible answer 2], [Possible answer 3]) 
                VALUES 
                    (@q, @t, @c, @ca, @lvl, @p_a1, @p_a2, @p_a3);";

            // 4. Execute the insertion
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(query, conn))
            {
                // Add parameters (prevents SQL Injection)
                cmd.Parameters.AddWithValue("@q", qText);
                cmd.Parameters.AddWithValue("@t", tText);
                cmd.Parameters.AddWithValue("@c", cText);
                cmd.Parameters.AddWithValue("@ca", caText);
                cmd.Parameters.AddWithValue("@lvl", lvlText);

                if (type_text.Text == "Multiple Choice")
                {
                    cmd.Parameters.AddWithValue("@p_a1", p_a1Text);
                    cmd.Parameters.AddWithValue("@p_a2", p_a2Text);
                    cmd.Parameters.AddWithValue("@p_a3", p_a3Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_a1", DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_a2", DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_a3", DBNull.Value);
                }

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(
                        "The question was inserted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Clear fields after insertion
                    question_text.Clear();
                    type_text.SelectedIndex = -1;
                    course_text.SelectedIndex = -1;
                    c_a_text.Clear();
                    level_text.SelectedIndex = -1;
                    Possible_answer_1.Clear();
                    Possible_answer_2.Clear();
                    Possible_answer_3.Clear();

                    // Hide possible answer fields if not required
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    Possible_answer_1.Visible = false;
                    Possible_answer_2.Visible = false;
                    Possible_answer_3.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error during insertion: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void Deleting_questions_Click(object sender, EventArgs e)
        {
            Deleting_questions deleting_Questions = new Deleting_questions(this.main, this);
            deleting_Questions.Show();
            this.Hide();
        }

        private void type_text_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if question type is "Multiple Choice"
            if (type_text.Text == "Multiple Choice")
            {
                this.SuspendLayout();
                // Show textboxes for possible answers
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                Possible_answer_1.Visible = true;
                Possible_answer_2.Visible = true;
                Possible_answer_3.Visible = true;
                this.ResumeLayout();
            }
            else
            {
                this.SuspendLayout();
                // Hide textboxes for possible answers
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                Possible_answer_1.Visible = false;
                Possible_answer_2.Visible = false;
                Possible_answer_3.Visible = false;
                this.ResumeLayout();
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void question_Click(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        public bool AreRequiredFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(question_text.Text) ||
                string.IsNullOrWhiteSpace(type_text.Text) ||
                string.IsNullOrWhiteSpace(course_text.Text) ||
                string.IsNullOrWhiteSpace(c_a_text.Text) ||
                string.IsNullOrWhiteSpace(level_text.Text))
            {
                return false;
            }

            if (type_text.Text == "Multiple Choice")
            {
                if (string.IsNullOrWhiteSpace(Possible_answer_1.Text) ||
                    string.IsNullOrWhiteSpace(Possible_answer_2.Text) ||
                    string.IsNullOrWhiteSpace(Possible_answer_3.Text))
                {
                    return false;
                }
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.main.Show();
            this.Close();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            // (Empty handler)
        }

        private void button1_Resize(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Calculate font size based on button height
            float newFontSize = btn.Height * 0.4f;

            btn.Font = new Font(btn.Font.FontFamily, newFontSize, btn.Font.Style);
        }

        private void Deleting_questions_Resize(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Calculate font size based on button height
            float newFontSize = btn.Height * 0.4f;

            btn.Font = new Font(btn.Font.FontFamily, newFontSize, btn.Font.Style);
        }

        private void button2_Resize(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Calculate font size based on button height
            float newFontSize = btn.Height * 0.4f;

            btn.Font = new Font(btn.Font.FontFamily, newFontSize, btn.Font.Style);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            // (Empty handler)
        }

        private void Possible_answer_1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
