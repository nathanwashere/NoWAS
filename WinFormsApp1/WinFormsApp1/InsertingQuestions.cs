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
    public partial class InsertingQuestions : Form
    {
        public InsertingQuestions()
        {
            InitializeComponent();
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

            // 3. שאילתת INSERT
            string query = @"
            INSERT INTO Question 
                (Body, type, [The cours], Awnser, [Difficulty level]) 
            VALUES 
                (@q, @t, @c, @ca, @lvl);";

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

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("השאלה הוכנסה בהצלחה!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Deleting_questions deleting_Questions = new Deleting_questions();
            deleting_Questions.Show();
        }

        
    }
}
