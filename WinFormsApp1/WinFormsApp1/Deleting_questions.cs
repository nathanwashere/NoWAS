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
using System.Windows.Forms.DataVisualization.Charting;

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
            this.back_page = back_page;

            // Enable DPI scaling (helps with display on high-resolution screens)
            /*this.AutoScaleMode = AutoScaleMode.Dpi;

            // Preferred window size
            int preferredWidth = 800;
            int preferredHeight = 800;

            // Use WorkingArea instead of Bounds to avoid overlap with taskbar
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            // Adjust window size to not exceed screen working area
            int width = Math.Min(preferredWidth, workingArea.Width - 50);  // add margin
            int height = Math.Min(preferredHeight, workingArea.Height - 50);
            this.Size = new Size(width, height);

            // Center the form within the working area
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                workingArea.X + (workingArea.Width - this.Width) / 2,
                workingArea.Y + (workingArea.Height - this.Height) / 2
            );*/

            this.StartPosition = FormStartPosition.Manual;
            // Place the form at coordinates (100, 100) on the screen
            this.Location = new System.Drawing.Point(100, 100);
            // Fixed window style: non-resizable, but minimizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }




        private void Deleting_questions_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Exit the entire application when this form is closed
            Application.Exit();
        }

        private void Deleting_questions_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Build database path
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            // Optional: print all table names in the database to console
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
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

            // Load questions into DataGridView
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Question_new";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a new column for row numbering (No)
                    dt.Columns.Add("No", typeof(int));

                    // Populate row numbers from 1 to N
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["No"] = i + 1;
                    }

                    // Move the "No" column to the first position
                    dt.Columns["No"].SetOrdinal(0);

                    dataGridViewQuestions.DataSource = dt;
                }
            }

            // Hide TestID and QuestionID columns
            if (dataGridViewQuestions.Columns.Contains("TestID"))
                dataGridViewQuestions.Columns["TestID"].Visible = false;

            if (dataGridViewQuestions.Columns.Contains("QuestionID"))
                dataGridViewQuestions.Columns["QuestionID"].Visible = false;

            dataGridViewQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add Delete button column if not already added
            if (!dataGridViewQuestions.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                dataGridViewQuestions.Columns.Add(deleteButton);
            }

            // Add Edit button column if not already added
            if (!dataGridViewQuestions.Columns.Contains("Edit"))
            {
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
            if (e.RowIndex < 0) return; // Ignore header row

            // If Delete button clicked
            if (dataGridViewQuestions.Columns[e.ColumnIndex].Name == "Delete")
            {
                var id = dataGridViewQuestions.Rows[e.RowIndex].Cells["QuestionID"].Value;
                var result = MessageBox.Show("Are you sure you want to delete this question?", "Delete Confirmation",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteQuestionFromDatabase(id);
                    dataGridViewQuestions.Rows.RemoveAt(e.RowIndex);
                }
            }

            // If Edit button clicked
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
            // Open a new form to edit the selected question
            EditQuestionForm editForm = new EditQuestionForm(row, this.main, this);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Reload data from DB after editing
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
