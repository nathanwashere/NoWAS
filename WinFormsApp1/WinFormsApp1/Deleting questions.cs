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
        public Deleting_questions()
        {
            InitializeComponent();
        }

        private void Deleting_questions_Load(object sender, EventArgs e)
        {
            //if (!File.Exists(@"C:\Users\zecha\Documents\GitHub\NoWAS\WinFormsApp1\WinFormsApp1\DataBase.db"))
            //{
            //    MessageBox.Show("Database file not found!");
            //    return;
            //}
            string dbPath = Path.Combine(Application.StartupPath, "DataBase.db");
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

                string query = "SELECT * FROM Question";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewQuestions.DataSource = dt;
                }
            }
            dataGridViewQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
