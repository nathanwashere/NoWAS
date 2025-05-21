using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class StudentStatisticsForm : Form
    {
        private string connectionString = $"Data Source={System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db"))};Version=3;";


        private List<Student> students;
        private List<StudentResult> results;
        //var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
        //dbPath = Path.GetFullPath(dbPath);
        //    string connectionString = $"Data Source={dbPath};Version=3;";

        public StudentStatisticsForm()
        {
            InitializeComponent();
            comboFilter.SelectedIndexChanged += comboFilter_SelectedIndexChanged;
            LoadResultsFromDatabase();
            LoadResultsToGrid();
        }

        private void LoadResultsFromDatabase()
        {
            DataTable table = new DataTable();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // שים לב שהשמות בהתאמה לטבלאות שלך
                string query = @"
            SELECT 
                p.username AS StudentName,
                r.Score,
                r.TotalQuestions,
                r.Grade,
                r.TestDate
            FROM StudentResults r
            JOIN Person p ON p.Id = r.StudentId
        ";

                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    adapter.Fill(table);
                }
            }

            // הוספת ממוצע לכל שורה
            if (!table.Columns.Contains("StudentAverage"))
                table.Columns.Add("StudentAverage", typeof(double));

            foreach (DataRow row in table.Rows)
            {
                string studentName = row["StudentName"].ToString();
                var rows = table.AsEnumerable().Where(r => r.Field<string>("StudentName") == studentName);
                double avg = rows.Average(r => Convert.ToDouble(r["Grade"]));
                row["StudentAverage"] = avg;
            }

            dataGridViewResults.DataSource = table;

            comboFilter.Items.Clear();
            comboFilter.Items.AddRange(new[] { "All", "Below 60", "60 - 80", "Above 80" });
            comboFilter.SelectedIndex = 0;

            ShowStatistics(table);
        }


        private void LoadResultsToGrid()
        {
            DataTable table = new DataTable();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                p.username AS StudentName,
                r.Score,
                r.TotalQuestions,
                r.Grade,
                r.TestDate
            FROM StudentResults r
            JOIN Person p ON p.Id = r.StudentId
        ";

                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    adapter.Fill(table);
                }
            }

            // הוסף עמודת ממוצע
            if (!table.Columns.Contains("StudentAverage"))
                table.Columns.Add("StudentAverage", typeof(double));

            foreach (DataRow row in table.Rows)
            {
                string studentName = row["StudentName"].ToString();
                var rows = table.AsEnumerable().Where(r => r.Field<string>("StudentName") == studentName);
                double avg = rows.Average(r => Convert.ToDouble(r["Grade"]));
                row["StudentAverage"] = avg;
            }

            dataGridViewResults.DataSource = table;

            comboFilter.Items.Clear();
            comboFilter.Items.AddRange(new[] { "All", "Below 60", "60 - 80", "Above 80" });
            comboFilter.SelectedIndex = 0;

            ShowStatistics(table);
        }



        private void ShowStatistics(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                labelStats.Text = "No data available.";
                return;
            }

            double avg = dataTable.AsEnumerable().Average(row => Convert.ToDouble(row["Grade"]));
            int totalExams = dataTable.Rows.Count;

            var topStudent = dataTable.AsEnumerable()
                .OrderByDescending(row => Convert.ToDouble(row["Grade"]))
                .First();

            string topName = topStudent.Field<string>("StudentName");
            double topGrade = Convert.ToDouble(topStudent["Grade"]);

            var mostFrequent = dataTable.AsEnumerable()
                .GroupBy(r => r.Field<string>("StudentName"))
                .OrderByDescending(g => g.Count())
                .First();

            labelStats.Text = $"🧮 ממוצע ציונים כולל: {avg:F1}%\n" +
                              $"🎓 ציון גבוה ביותר: {topName} ({topGrade:F1}%)\n" +
                              $"📊 הכי הרבה מבחנים: {mostFrequent.Key} ({mostFrequent.Count()} מבחנים)\n" +
                              $"📄 סך כל מבחנים: {totalExams}";
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboFilter.SelectedItem.ToString();
            string filter = "";

            switch (selected)
            {
                case "Below 60":
                    filter = "Grade < 60";
                    break;
                case "60 - 80":
                    filter = "Grade >= 60 AND Grade <= 80";
                    break;
                case "Above 80":
                    filter = "Grade > 80";
                    break;
                default:
                    filter = "";
                    break;
            }

            (dataGridViewResults.DataSource as DataTable).DefaultView.RowFilter = filter;
        }


        private void LoadResults()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                    s.FirstName + ' ' + s.LastName AS StudentName,
                    r.Score,
                    r.TotalQuestions,
                    r.Grade,
                    r.TestDate
                FROM StudentResults r
                JOIN Student s ON s.StudentID = r.StudentID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dataTable);
            }

            dataGridViewResults.DataSource = dataTable;

            comboFilter.Items.Clear();
            comboFilter.Items.AddRange(new[] { "All", "Below 60", "60 - 80", "Above 80" });
            comboFilter.SelectedIndex = 0;

            ShowStatistics(dataTable);
        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentStatisticsForm_Load(object sender, EventArgs e)
        {

        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentResult
    {
        public int StudentID { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public double Grade { get; set; }
        public DateTime TestDate { get; set; }
    }
}
