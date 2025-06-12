using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
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

            // Round corners for buttons after InitializeComponent
            RoundButtonCorners(btnFilter, btnFilter.Height);
            RoundButtonCorners(btnTakeSelectedTest, btnTakeSelectedTest.Height);
        }

        private void LoadTests(List<string> categories = null, List<string> difficulties = null)
        {
            lvAvailableTests.Items.Clear();

            var dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = System.IO.Path.GetFullPath(dbPath);
            string connectionString = $"Data Source={dbPath};Version=3;";

            using var conn = new SQLiteConnection(connectionString);
            conn.Open();

            string query = @"
                SELECT t.TestID, t.TestName, MAX(tq.DateCreated) AS DateCreated
                FROM Test t
                JOIN TestQuestions tq ON t.TestID = tq.TestID
                WHERE 1=1";

            if (categories != null && categories.Count > 0)
            {
                string categoryClause = string.Join(" OR ", categories.Select(c => $"t.TestName LIKE '%{c}%'"));
                query += $" AND ({categoryClause})";
            }

            if (difficulties != null && difficulties.Count > 0)
            {
                string diffClause = string.Join(" OR ", difficulties.Select(d => $"t.TestName LIKE '%{d}%'"));
                query += $" AND ({diffClause})";
            }

            query += " GROUP BY t.TestID, t.TestName";

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

        private void clbCategory_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < clbCategory.Items.Count; i++)
                {
                    if (i != e.Index)
                        clbCategory.SetItemChecked(i, false);
                }
            }
        }

        private void clbDifficulty_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < clbDifficulty.Items.Count; i++)
                {
                    if (i != e.Index)
                        clbDifficulty.SetItemChecked(i, false);
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var selectedCategories = clbCategory.CheckedItems.Cast<string>().ToList();
            var selectedDifficulties = clbDifficulty.CheckedItems.Cast<string>().ToList();

            LoadTests(selectedCategories, selectedDifficulties);
        }

        private void btnTakeSelectedTest_Click(object sender, EventArgs e)
        {
            if (lvAvailableTests.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a test.");
                return;
            }

            int testId = int.Parse(lvAvailableTests.SelectedItems[0].Text);
            StudentTestForm testForm = new StudentTestForm(testId, userName);
            testForm.Show();
            this.Close();
        }

        // Helper method to round button corners
        private void RoundButtonCorners(Button btn, int radius)
        {
            var bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }
    }
}
