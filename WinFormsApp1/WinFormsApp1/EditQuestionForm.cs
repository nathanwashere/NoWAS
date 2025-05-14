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
        private int questionId; // assuming your table has an ID column

        public EditQuestionForm(DataGridViewRow row)
        {
            InitializeComponent();

            // נשלוף את ה-ID של השאלה מהשורה
            questionId = Convert.ToInt32(row.Cells["QuestionID"].Value); 

            // נטען את הנתונים לשדות
            question_text.Text = row.Cells["Body"].Value?.ToString();
            type_text.SelectedItem = row.Cells["type"].Value?.ToString();
            course_text.Text = row.Cells["The course"].Value?.ToString();
            c_a_text.Text = row.Cells["answer"].Value?.ToString();
            level_text.Text = row.Cells["Difficulty level"].Value?.ToString();

            Possible_answer_1.Text = row.Cells["Possible answer 1"].Value?.ToString();
            Possible_answer_2.Text = row.Cells["Possible answer 2"].Value?.ToString();
            Possible_answer_3.Text = row.Cells["Possible answer 3"].Value?.ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            // בדיקה בסיסית
            if (string.IsNullOrWhiteSpace(question_text.Text) ||
                string.IsNullOrWhiteSpace(type_text.Text) ||
                string.IsNullOrWhiteSpace(course_text.Text) ||
            string.IsNullOrWhiteSpace(c_a_text.Text) ||
                string.IsNullOrWhiteSpace(level_text.Text))
            {
                MessageBox.Show("יש למלא את כל השדות החובה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // שמירה למסד הנתונים
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            string query = @"
            UPDATE Question 
            SET 
                Body = @q, 
                type = @t, 
                [The course] = @c, 
                answer = @ca, 
                [Difficulty level] = @lvl, 
                [Possible answer 1] = @p1, 
                [Possible answer 2] = @p2, 
                [Possible answer 3] = @p3 
            WHERE ID = @id";

            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(query, conn))
            {
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

        }

        private void type_text_SelectedIndexChanged(object sender, EventArgs e)
        {
            // בודק אם סוג השאלה הוא "Multiple Choice"
            if (type_text.Text == "Multiple Choice")
            {
                // הצגת תיבות טקסט עבור תשובות אפשריות
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                Possible_answer_1.Visible = true;
                Possible_answer_2.Visible = true;
                Possible_answer_3.Visible = true;
            }
            else
            {
                // הסתרת תיבות טקסט עבור תשובות אפשריות
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

        }
    }
}


