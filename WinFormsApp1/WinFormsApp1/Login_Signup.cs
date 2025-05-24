using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace WinFormsApp1
{
    public partial class Login_Signup : Form
    {
        private System.Windows.Forms.Timer slideTimer;
        private int slideSpeed = 20;
        private int targetLeftLogin;
        private int targetLeftSignup;
        private bool showingSignup = false;

        public Login_Signup()
        {
            InitializeComponent();

            // Enable double buffering to prevent flickering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void Login_Signup_Load(object sender, EventArgs e)
        {
            // Initial panel positions
            panelLogin.Left = 0;
            panelSignup.Left = panelLogin.Width;

            slideTimer = new System.Windows.Forms.Timer();
            slideTimer.Interval = 10;
            slideTimer.Tick += SlideTimer_Tick;

            rbStudent.Checked = true;

            RoundButtonCorners(buttonSignupEnter, buttonSignupEnter.Height);
            RoundButtonCorners(buttonLoginEnter, buttonLoginEnter.Height);
            RoundButtonCorners(buttonSignupToLogin, buttonSignupToLogin.Height);
            RoundButtonCorners(buttonLoginToSignup, buttonLoginToSignup.Height);
        }

        private void buttonLoginToSignup_Click(object sender, EventArgs e)
        {
            showingSignup = true;
            targetLeftLogin = -panelLogin.Width;
            targetLeftSignup = 0;
            slideTimer.Start();
            clearInputs();
        }

        private void buttonSignupToLogin_Click(object sender, EventArgs e)
        {
            showingSignup = false;
            targetLeftLogin = 0;
            targetLeftSignup = panelLogin.Width;
            slideTimer.Start();
            clearInputs();
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            bool done = true;

            if (panelLogin.Left != targetLeftLogin)
            {
                int delta = Math.Sign(targetLeftLogin - panelLogin.Left) * slideSpeed;
                panelLogin.Left += delta;

                if (Math.Abs(panelLogin.Left - targetLeftLogin) < slideSpeed)
                    panelLogin.Left = targetLeftLogin;

                done = false;
            }

            if (panelSignup.Left != targetLeftSignup)
            {
                int delta = Math.Sign(targetLeftSignup - panelSignup.Left) * slideSpeed;
                panelSignup.Left += delta;

                if (Math.Abs(panelSignup.Left - targetLeftSignup) < slideSpeed)
                    panelSignup.Left = targetLeftSignup;

                done = false;
            }

            if (done)
                slideTimer.Stop();
        }

        private void RoundButtonCorners(Button btn, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
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

        private void clearInputs()
        {
            textBoxLoginUsername.Text = "";
            textBoxLoginPassword.Text = "";
            textBoxSignupUsername.Text = "";
            textBoxSignupPassword.Text = "";
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
                        new mainForm(userName).Show();
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

        private SQLiteConnection connectDataBase()
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db");
            dbPath = Path.GetFullPath(dbPath);

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
                workbook.SaveAs(filePath);
            }

            return (workbook, worksheet);
        }

        private void addUserToDataBase(string userName, string type)
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
    }
}
