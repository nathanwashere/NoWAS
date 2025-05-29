using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TestSelectionForm : Form
    {
        private string userName;
        public TestSelectionForm(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            LoadTests();
        }

        private void LoadTests()
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();

            string query = "SELECT DISTINCT TestID, TestName, DateCreated FROM TestQuestions";
            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var item = new ListViewItem(reader["TestID"].ToString());
                item.SubItems.Add(reader["TestName"].ToString());
                item.SubItems.Add(reader["DateCreated"].ToString());
                lvAvailableTests.Items.Add(item);
            }
        }

        private void btnTakeSelectedTest_Click(object sender, EventArgs e)
        {
            if (lvAvailableTests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a test.");
                return;
            }

            int testId = int.Parse(lvAvailableTests.SelectedItems[0].Text);
            StudentTestForm testForm = new StudentTestForm(testId,userName);
            testForm.Show();
            this.Close();
        }
    }
}
