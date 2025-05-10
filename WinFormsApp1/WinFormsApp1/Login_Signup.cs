using System;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class Login_Signup : Form
    {
        public Login_Signup()
        {
            InitializeComponent();
        }

        private SQLiteConnection connectDataBase()
        {
            var dbPath = "DataBase.db";

            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file not found!");
                return null;
            }
            try
            {
                var connectString = new SQLiteConnectionStringBuilder
                {
                    DataSource = dbPath,
                    Version = 3,
                }.ToString();

                var conn = new SQLiteConnection(connectString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open database:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string getUserType(string username)
        {
            using (var conn = connectDataBase())
            {
                if (conn == null) return null;

                string query = "SELECT type FROM Person WHERE userName = @username";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();  
                }
            }
        }

        private (XLWorkbook, IXLWorksheet) OpenOrCreateExcel()
        {
            var filePath = "Info.xlsx";
            XLWorkbook workbook;
            IXLWorksheet worksheet;

            if (File.Exists(filePath))
            {
                workbook = new XLWorkbook(filePath);
                worksheet = workbook.Worksheet(1);
            }
            else
            {
                workbook = new XLWorkbook();
                worksheet = workbook.Worksheets.Add("Users");
                worksheet.Cell("A1").Value = "Username";
                worksheet.Cell("B1").Value = "Password";
                workbook.SaveAs(filePath); // Save initial file
            }

            return (workbook, worksheet);
        }

        private void addUserToDataBase( string userName, string type)
        {

            using (var conn = connectDataBase())
            {
                if (conn == null) return;
                string query = "INSERT INTO Person (userName, type) VALUES (@userName, @type)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void signUp(string userName, string password)
        {
            XLWorkbook workbook = null;
            try
            {
                var result = OpenOrCreateExcel();
                workbook = result.Item1;
                var worksheet = result.Item2;

                int lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 1;

                if (userNameExistsExcel(worksheet, userName) && 
                    userNameExistsDataBase(userName))
                {
                    MessageBox.Show("User already exists");
                }
                else
                {
                    worksheet.Cell(lastRow + 1, 1).Value = userName;
                    worksheet.Cell(lastRow + 1, 2).Value = password;
                    workbook.SaveAs("Info.xlsx");

                    addUserToDataBase(userName, rbStudent.Checked ? "Student" : "Professor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to sign up: {ex.Message}");
            }
            finally
            {
                workbook?.Dispose();
            }
        }

        private void logIn(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            XLWorkbook workbook = null;
            try
            {
                var result = OpenOrCreateExcel();
                workbook = result.Item1;
                var worksheet = result.Item2;

                if (checkLogin(worksheet, userName, password))
                {
                    MessageBox.Show("Login successful!");

                    if (getUserType(userName) == "Student")
                    {
                        new mainForm().Show();
                    }
                    else if (getUserType(userName) == "Professor")
                    {
                        new mainTeacher().Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to login: {ex.Message}");
            }
            finally
            {
                workbook?.Dispose();
            }
        }

        private void clearInputs()
        {
            textBoxLoginUsername.Text = "";
            textBoxLoginPassword.Text = "";
            textBoxSignupUsername.Text = "";
            textBoxSignupPassword.Text = "";
        }

        private bool userNameExistsExcel(IXLWorksheet worksheet, string userName)
        {
            foreach (var row in worksheet.RowsUsed().Skip(1))
            {
                string userNameExcel = row.Cell(1).GetValue<string>();
                if (userNameExcel == userName)
                {
                    return true;
                }
            }

            return false;
        }

        private bool userNameExistsDataBase(string username)
        {
            using (var conn = connectDataBase())
            {
                if (conn == null) return false;
                string query = "SELECT COUNT(*) FROM Person WHERE userName = @username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool checkLogin(IXLWorksheet worksheet, string userName, string password)
        {
            foreach (var row in worksheet.RowsUsed().Skip(1))
            {
                string userNameExcel = row.Cell(1).GetValue<string>();
                string passwordExcel = row.Cell(2).GetValue<string>();
                if (userNameExcel == userName && passwordExcel == password)
                {
                    return true;
                }
            }
            return false;
        }

        private void Login_Signup_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelSignup.Visible = false;
            rbStudent.Checked = true; // default selection
        }

        private void buttonLoginToSignup_Click(object sender, EventArgs e)
        {
            clearInputs();
            panelLogin.Visible = false;
            panelSignup.Visible = true;
        }

        private void buttonSignupToLogin_Click(object sender, EventArgs e)
        {
            panelSignup.Visible = false;
            panelLogin.Visible = true;
            clearInputs();
        }

        private void buttonSignupEnter_Click(object sender, EventArgs e)
        {
            string userName = textBoxSignupUsername.Text;
            string password = textBoxSignupPassword.Text;
            signUp(userName, password);
            clearInputs();
        }

        private void buttonLoginEnter_Click(object sender, EventArgs e)
        {
            string userName = textBoxLoginUsername.Text;
            string password = textBoxLoginPassword.Text;
            logIn(userName, password);
            clearInputs();
        }

        private void panelSignup_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
