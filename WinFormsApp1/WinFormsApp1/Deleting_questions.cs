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
    public partial class Deleting_questions : Form
    {
        private Form main;
        private Form back_page;
        public Deleting_questions(Form main, Form back_page)
        {
            InitializeComponent();
            this.main = main;
            this.back_page = back_page; // Initialize the back page
        }

        private void Deleting_questions_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;

            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) // Declare and initialize 'connection'
            {
                connection.Open();
                using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table';", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Table: " + reader.GetString(0));
                    }
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Question_new";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewQuestions.DataSource = dt;
                }
            }
            dataGridViewQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!dataGridViewQuestions.Columns.Contains("Delete"))
            {
                // יצירת עמודת כפתור Delete
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                dataGridViewQuestions.Columns.Add(deleteButton);
            }
            if (!dataGridViewQuestions.Columns.Contains("Edit"))
            {
                // יצירת עמודת כפתור Edit
                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "Edit";
                editButton.HeaderText = "";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                dataGridViewQuestions.Columns.Add(editButton);
                dataGridViewQuestions.CellFormatting += dataGridViewQuestions_CellFormatting;
            }
        }

        private void dataGridViewQuestions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewQuestions.Columns[e.ColumnIndex].Name == "Delete")
            {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

            if (dataGridViewQuestions.Columns[e.ColumnIndex].Name == "Edit")
            {
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.BackColor = Color.Blue;
                e.CellStyle.SelectionBackColor = Color.DarkBlue;
            }
        }


        private void dataGridViewQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // התעלם מכותרת

            // אם לחצו על עמודת Delete
            if (dataGridViewQuestions.Columns[e.ColumnIndex].Name == "Delete")
            {
                var id = dataGridViewQuestions.Rows[e.RowIndex].Cells["QuestionID"].Value;
                var result = MessageBox.Show("האם אתה בטוח שברצונך למחוק את השאלה?", "אישור מחיקה",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteQuestionFromDatabase(id);
                    dataGridViewQuestions.Rows.RemoveAt(e.RowIndex);
                }
            }

            // אם לחצו על עמודת Edit
            if (dataGridViewQuestions.Columns[e.ColumnIndex].Name == "Edit")
            {
                var row = dataGridViewQuestions.Rows[e.RowIndex];
                EditQuestion(row);
            }
        }

        private void DeleteQuestionFromDatabase(object id)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Question_new WHERE QuestionID = @id";
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void EditQuestion(DataGridViewRow row)
        {
            // כאן אתה פותח טופס חדש עם הנתונים מהשורה ומאפשר עריכה
            EditQuestionForm editForm = new EditQuestionForm(row, this.main, this);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // טען מחדש את הנתונים מה־DB אחרי עריכה
                Deleting_questions_Load(null, null);
            }
        }

        private void GoBackToMain_Click(object sender, EventArgs e)
        {
            this.main.Show();
            this.Close();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            this.back_page.Show();
            this.Close();
        }
    }
}
