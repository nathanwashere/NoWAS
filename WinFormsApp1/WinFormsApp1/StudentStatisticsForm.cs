using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class StudentStatisticsForm : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=QuizDB;Integrated Security=True;";

        private List<Student> students;
        private List<StudentResult> results;

        public StudentStatisticsForm()
        {
            InitializeComponent();
            comboFilter.SelectedIndexChanged += comboFilter_SelectedIndexChanged;
            LoadFakeData();
            LoadResultsToGrid();
        }

        private void LoadFakeData()
        {
            students = new List<Student>
            {
                new Student { StudentID = 1, FirstName = "Alice", LastName = "Levi" },
                new Student { StudentID = 2, FirstName = "Bob", LastName = "Cohen" },
                new Student { StudentID = 3, FirstName = "Charlie", LastName = "Dayan" }
            };

            results = new List<StudentResult>
            {
                new StudentResult { StudentID = 1, Score = 8, TotalQuestions = 10, Grade = 80, TestDate = DateTime.Today.AddDays(-1) },
                new StudentResult { StudentID = 1, Score = 9, TotalQuestions = 10, Grade = 90, TestDate = DateTime.Today.AddDays(-5) },
                new StudentResult { StudentID = 2, Score = 5, TotalQuestions = 10, Grade = 50, TestDate = DateTime.Today.AddDays(-3) },
                new StudentResult { StudentID = 3, Score = 7, TotalQuestions = 10, Grade = 70, TestDate = DateTime.Today }
            };
        }

        private void LoadResultsToGrid()
        {
            var table = new DataTable();
            table.Columns.Add("StudentName", typeof(string));
            table.Columns.Add("Score", typeof(int));
            table.Columns.Add("TotalQuestions", typeof(int));
            table.Columns.Add("Grade", typeof(double));
            table.Columns.Add("TestDate", typeof(DateTime));
            table.Columns.Add("StudentAverage", typeof(double)); 

            foreach (var result in results)
            {
                var student = students.FirstOrDefault(s => s.StudentID == result.StudentID);
                if (student != null)
                {
                    string fullName = $"{student.FirstName} {student.LastName}";

                    
                    double average = results
                        .Where(r => r.StudentID == student.StudentID)
                        .Average(r => r.Grade);

                    table.Rows.Add(
                        fullName,
                        result.Score,
                        result.TotalQuestions,
                        result.Grade,
                        result.TestDate,
                        average
                    );
                }
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
