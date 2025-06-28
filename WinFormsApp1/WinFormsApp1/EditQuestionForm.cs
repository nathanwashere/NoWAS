using DocumentFormat.OpenXml.Wordprocessing;
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
using System.IO;

namespace WinFormsApp1
{
    public partial class EditQuestionForm : Form
    {
        private int questionId; // stores the ID of the question being edited
        private Form previousForm; // reference to the form to return to when closing
        private Form main; // reference to the main form

        public EditQuestionForm(DataGridViewRow row, Form main, Form BackForm)
        {
            InitializeComponent();
            this.main = main;
            previousForm = BackForm; // Initialize the form to return to after editing

            // Set the form to a fixed single border so it cannot be resized
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            /* // Position the form manually
             this.StartPosition = FormStartPosition.Manual;
             // Set a consistent form size of 1150x800
             //this.Size = new Size(1150, 800);*/

            this.StartPosition = FormStartPosition.Manual;
            // Place the form at coordinates (100, 100) on the screen
            this.Location = new System.Drawing.Point(100, 100);

            // Disable the maximize button and enable the minimize button
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            // Retrieve the QuestionID from the selected DataGridView row
            questionId = Convert.ToInt32(row.Cells["QuestionID"].Value);

            // Populate form fields with data from the selected row
            question_text.Text = row.Cells["Body"].Value?.ToString();
            type_text.SelectedItem = row.Cells["type"].Value?.ToString();
            course_text.Text = row.Cells["Course"].Value?.ToString();
            c_a_text.Text = row.Cells["answer"].Value?.ToString();
            level_text.Text = row.Cells["Difficulty level"].Value?.ToString();

            Possible_answer_1.Text = row.Cells["Possible answer 1"].Value?.ToString();
            Possible_answer_2.Text = row.Cells["Possible answer 2"].Value?.ToString();
            Possible_answer_3.Text = row.Cells["Possible answer 3"].Value?.ToString();
        }

        private void EditQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exit the entire application when this form is closed
            Application.Exit();
        }

        private void save_Click(object sender, EventArgs e)
        {
            // Perform basic validation of required fields
            if (string.IsNullOrWhiteSpace(question_text.Text) ||
                string.IsNullOrWhiteSpace(type_text.Text) ||
                string.IsNullOrWhiteSpace(course_text.Text) ||
                string.IsNullOrWhiteSpace(c_a_text.Text) ||
                string.IsNullOrWhiteSpace(level_text.Text))
            {
                MessageBox.Show("יש למלא את כל השדות החובה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build database connection string
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            // Define the UPDATE query to save changes to the database
            string query = @"
                UPDATE Question_new 
                SET 
                    Body = @q, 
                    type = @t, 
                    [Course] = @c, 
                    Answer = @ca, 
                    [Difficulty level] = @lvl, 
                    [Possible answer 1] = @p1, 
                    [Possible answer 2] = @p2, 
                    [Possible answer 3] = @p3 
                WHERE QuestionID = @id";

            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(query, conn))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@q", question_text.Text);
                cmd.Parameters.AddWithValue("@t", type_text.Text);
                cmd.Parameters.AddWithValue("@c", course_text.Text);
                cmd.Parameters.AddWithValue("@ca", c_a_text.Text);
                cmd.Parameters.AddWithValue("@lvl", level_text.Text);
                cmd.Parameters.AddWithValue("@p1", Possible_answer_1.Text);
                cmd.Parameters.AddWithValue("@p2", Possible_answer_2.Text);
                cmd.Parameters.AddWithValue("@p3", Possible_answer_3.Text);
                cmd.Parameters.AddWithValue("@id", questionId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("השאלה עודכנה בהצלחה!");
                    // Indicate to the calling form that the update succeeded
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה בעדכון השאלה: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void c_a_Click(object sender, EventArgs e)
        {
            // (Empty handler for the correct answer label click event)
        }

        private void type_text_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show or hide the possible answer textboxes depending on question type
            if (type_text.Text == "Multiple Choice")
            {
                // Display labels and textboxes for multiple-choice answers
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                Possible_answer_1.Visible = true;
                Possible_answer_2.Visible = true;
                Possible_answer_3.Visible = true;
            }
            else
            {
                // Hide multiple-choice answer fields if type is not "Multiple Choice"
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                Possible_answer_1.Visible = false;
                Possible_answer_2.Visible = false;
                Possible_answer_3.Visible = false;
            }
        }

        private void EditQuestionForm_Load(object sender, EventArgs e)
        {
            // Stretch the background image to fill the form
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void save_Click1(object sender, EventArgs e)
        {
            // Perform basic validation of required fields
            if (!AreRequiredFieldsFilled())
            {
                MessageBox.Show("All required fields must be filled in.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If question type is "True or False", only allow "true" or "false" as the correct answer
            if (type_text.Text.Trim().ToLower() == "true or false")
            {
                string answer = c_a_text.Text.Trim().ToLower();
                if (answer != "true" && answer != "false")
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

            // Build database connection string
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            // Define the UPDATE query to save changes to the database
            string query = @"
                UPDATE Question_new 
                SET 
                    Body = @q, 
                    type = @t, 
                    [Course] = @c, 
                    Answer = @ca, 
                    [Difficulty level] = @lvl, 
                    [Possible answer 1] = @p1, 
                    [Possible answer 2] = @p2, 
                    [Possible answer 3] = @p3 
                WHERE QuestionID = @id";

            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(query, conn))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@q", question_text.Text);
                cmd.Parameters.AddWithValue("@t", type_text.Text);
                cmd.Parameters.AddWithValue("@c", course_text.Text);
                cmd.Parameters.AddWithValue("@ca", c_a_text.Text);
                cmd.Parameters.AddWithValue("@lvl", level_text.Text);
                cmd.Parameters.AddWithValue("@p1", Possible_answer_1.Text);
                cmd.Parameters.AddWithValue("@p2", Possible_answer_2.Text);
                cmd.Parameters.AddWithValue("@p3", Possible_answer_3.Text);
                cmd.Parameters.AddWithValue("@id", questionId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The question has been updated successfully!");
                    // Indicate to the calling form that the update succeeded
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating question: " + ex.Message, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void GoBachToMain_Click(object sender, EventArgs e)
        {
            // Show the main form, close this form, and close the previous form
            this.main.Show();
            this.Close();
            this.previousForm.Close();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            // Close only this form and return to the caller
            this.Close();
        }
    }
}
