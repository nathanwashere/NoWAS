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
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace WinFormsApp1
{
    public partial class InsertingQuestions : Form
    {
        private Form main;
        public InsertingQuestions(Form main)
        {
            InitializeComponent();
            this.main = main;
            this.FormBorderStyle = FormBorderStyle.Sizable; // שומר על המסגרת הרגילה
            this.WindowState = FormWindowState.Maximized;   // ממלא את כל המסך
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void course_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void InsertingQuestions_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            // 2. קריאה מה־TextBox-ים
            string qText = question_text.Text;
            string tText = type_text.Text;
            string cText = course_text.Text;
            string caText = c_a_text.Text;
            string lvlText = level_text.Text;
            string p_a1Text = Possible_answer_1.Text;
            string p_a2Text = Possible_answer_2.Text;
            string p_a3Text = Possible_answer_3.Text;



            // בדיקת שדות חובה
            if (!AreRequiredFieldsFilled())
            {
                MessageBox.Show("Please fill in all required fields: Question, Question Type, Course, Answer, Difficulty Level, and Possible Answer.",
                                "שגיאת קלט", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // מפסיק את הפעולה אם שדות לא מולאו
            }

            // If question type is "True or False", validate correct answer
            if (type_text.Text.Trim().ToLower() == "true/false")
            {
                string answer = c_a_text.Text.Trim().ToLower();
                if (caText.Trim().ToLower() != "true" && caText.Trim().ToLower() != "false")
                {
                    MessageBox.Show("For 'True or False' questions, the correct answer must be either 'true' or 'false'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            // 3. שאילתת INSERT
            string query = @"
            INSERT INTO Question_new 
                (Body, type, [Course],answer, [Difficulty level],[Possible answer 1],[Possible answer 2],[Possible answer 3]) 
            VALUES 
                (@q, @t, @c, @ca, @lvl,@p_a1,@p_a2,@p_a3);";



            // 4. ביצוע ההכנסה
            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand(query, conn))
            {
                // הוספת פרמטרים (ומניעת SQL Injection)
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
                    MessageBox.Show("השאלה הוכנסה בהצלחה!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ניקוי שדות לאחר ההכנסה
                    question_text.Clear();
                    type_text.SelectedIndex = -1;
                    course_text.SelectedIndex = -1;
                    c_a_text.Clear();
                    level_text.SelectedIndex = -1;

                    Possible_answer_1.Clear();
                    Possible_answer_2.Clear();
                    Possible_answer_3.Clear();

                    // הסתרת שדות של תשובות אפשריות אם לא נדרש
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    Possible_answer_1.Visible = false;
                    Possible_answer_2.Visible = false;
                    Possible_answer_3.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה בהכנסה: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Deleting_questions_Click(object sender, EventArgs e)
        {
            Deleting_questions deleting_Questions = new Deleting_questions(this.main,this);
            deleting_Questions.Show();
            this.Hide();
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

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void question_Click(object sender, EventArgs e)
        {

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
           
        }
    }
}
