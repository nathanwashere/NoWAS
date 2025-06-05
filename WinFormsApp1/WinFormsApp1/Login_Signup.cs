using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace WinFormsApp1
{
    public partial class Login_Signup : Form
    {
        private System.Windows.Forms.Timer slideTimer;
        private int slideSpeed = 50;
        private int targetLeftLogin;
        private int targetLeftSignup;
        private bool showingSignup = false;
        private bool isPasswordVisible = false;
        private bool isSignupPasswordVisible = false;

        private Image loginBackground;
        private Image signupBackground;

        public Login_Signup()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // INITIAL STATE: login

            pictureBoxLoginTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed);

            // INITIAL STATE: signup

            pictureBoxSignupTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed);
        }


        private void Login_Signup_Load(object sender, EventArgs e)
        {
            panelLogin.Left = 0;
            panelSignup.Left = panelLogin.Width;

            slideTimer = new System.Windows.Forms.Timer();
            slideTimer.Interval = 1;
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

            loginBackground = panelLogin.BackgroundImage;
            signupBackground = panelSignup.BackgroundImage;
            panelLogin.BackgroundImage = null;
            panelSignup.BackgroundImage = null;

            slideTimer.Start();

            clearInputs();


        }

        private void buttonSignupToLogin_Click(object sender, EventArgs e)
        {
            showingSignup = false;
            targetLeftLogin = 0;
            targetLeftSignup = panelLogin.Width;

            loginBackground = panelLogin.BackgroundImage;
            signupBackground = panelSignup.BackgroundImage;
            panelLogin.BackgroundImage = null;
            panelSignup.BackgroundImage = null;

            slideTimer.Start();

            clearInputs();

        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            bool done = true;

            if (panelLogin.Left != targetLeftLogin)
            {
                int distance = targetLeftLogin - panelLogin.Left;
                int delta = Math.Min(slideSpeed, Math.Abs(distance)) * Math.Sign(distance);
                panelLogin.Left += delta;
                done = false;
            }

            if (panelSignup.Left != targetLeftSignup)
            {
                int distance = targetLeftSignup - panelSignup.Left;
                int delta = Math.Min(slideSpeed, Math.Abs(distance)) * Math.Sign(distance);
                panelSignup.Left += delta;
                done = false;
            }

            if (done)
            {
                panelLogin.BackgroundImage = loginBackground;
                panelSignup.BackgroundImage = signupBackground;
                slideTimer.Stop();
            }
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
            string taz = textBoxSignupID.Text;
            string mail = textBoxSignupMail.Text;
            signUp(userName, password, taz, mail);

        }


        private void buttonLoginEnter_Click(object sender, EventArgs e)
        {
            string userName = textBoxLoginUsername.Text;
            string password = textBoxLoginPassword.Text;
            logIn(userName, password);

        }

        private void clearInputs()
        {
            textBoxLoginUsername.Text = "";
            textBoxLoginPassword.Text = "";
            textBoxSignupUsername.Text = "";
            textBoxSignupPassword.Text = "";
            textBoxSignupID.Text = "";
            textBoxSignupMail.Text = "";

        }

        public bool checkInputsSignUp()
        {
            string username = textBoxSignupUsername.Text;
            string password = textBoxSignupPassword.Text;
            string id = textBoxSignupID.Text;
            string mail = textBoxSignupMail.Text;

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Please fill in Username, Password, ID and E-mail.");
                return false;
            }

            if (username.Length < 6 || username.Length > 8)
            {
                MessageBox.Show("Username must be between 6 and 8 characters long.");
                return false;
            }
            bool IsEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
            int digitCount = username.Count(char.IsDigit);
            int letterCount = username.Count(IsEnglishLetter);
            bool allValid = username.All(c => char.IsDigit(c) || IsEnglishLetter(c));
            if (!allValid || digitCount > 2 || letterCount != username.Length - digitCount)
            {
                MessageBox.Show("Username must contain only English letters and up to 2 digits.");
                return false;
            }

            if (password.Length < 8 || password.Length > 10)
            {
                MessageBox.Show("Password must be between 8 and 10 characters long.");
                return false;
            }
            bool hasLetter = password.Any(IsEnglishLetter);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(c => "!@#$%^&*()-_=+[]{};:'\".,.<>?/|".Contains(c));
            if (!hasLetter || !hasDigit || !hasSpecial)
            {
                MessageBox.Show("Password must contain at least one English letter, one digit, and one special character (!@#$%^&*...).");
                return false;
            }

            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                MessageBox.Show("ID must be exactly 9 digits.");
                return false;
            }

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(mail, emailPattern))
            {
                MessageBox.Show("Please enter a valid e-mail address.");
                return false;
            }

            return true;
        }

        private void signUp(string userName, string password, string taz, string mail)
        {
            if (!checkInputsSignUp())
                return;

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
                    return;
                }

                if (tazExistsDataBase(taz))
                {
                    MessageBox.Show("ID (taz) already exists");
                    return;
                }

                if (mailExistsDataBase(mail))
                {
                    MessageBox.Show("E-mail already exists");
                    return;
                }

                worksheet.Cell(lastRow + 1, 1).Value = userName;
                worksheet.Cell(lastRow + 1, 2).Value = password;
                workbook.SaveAs("Info.xlsx");

                addUserToDataBase(
                    userName,
                    rbStudent.Checked ? "Student" : "Professor",
                    taz,
                    mail
                );

                MessageBox.Show("Account was successfully registered!");

                if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Student")
                {
                    new mainForm(userName).Show();
                    this.Hide();
                }
                else if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Professor")
                {
                    new mainTeacher().Show();
                    this.Hide();
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

                if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Student")
                {
                    MessageBox.Show("Login successful!");
                    new mainForm(userName).Show();
                    this.Hide();
                }
                else if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Professor")
                {
                    MessageBox.Show("Login successful!");
                    new mainTeacher().Show();
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

        public SQLiteConnection connectDataBase()
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

        public (XLWorkbook, IXLWorksheet) OpenOrCreateExcel()
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

        public void addUserToDataBase(string userName, string type, string taz, string mail)
        {
            using (var conn = connectDataBase())
            {
                if (conn == null) return;

                string query = @"
                    INSERT INTO Person (userName, type, taz, mail)
                    VALUES (@userName, @type, @taz, @mail);
                ";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@taz", taz);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool checkLogin(IXLWorksheet worksheet, string userName, string password)
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

        public string getUserType(string username)
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

        public bool userNameExistsExcel(IXLWorksheet worksheet, string userName)
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

        public bool userNameExistsDataBase(string username)
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

        public bool mailExistsDataBase(string mail)
        {
            using (var conn = connectDataBase())
            {
                if (conn == null) return false;
                string query = "SELECT COUNT(*) FROM Person WHERE mail = @mail";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mail", mail);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool tazExistsDataBase(string taz)
        {
            using (var conn = connectDataBase())
            {
                if (conn == null) return false;
                string query = "SELECT COUNT(*) FROM Person WHERE taz = @taz";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@taz", taz);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void pictureBoxLoginTogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                textBoxLoginPassword.PasswordChar = '\0'; // Show password
                pictureBoxLoginTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_open); // Set this to your "hide password" image
            }
            else
            {
                textBoxLoginPassword.PasswordChar = '*'; // Hide password
                pictureBoxLoginTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed); // Set this to your "show password" image
            }
        }

        private void pictureBoxSignupTogglePassword_Click(object sender, EventArgs e)
        {
            isSignupPasswordVisible = !isSignupPasswordVisible;

            if (isSignupPasswordVisible)
            {
                textBoxSignupPassword.PasswordChar = '\0';
                pictureBoxSignupTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_open);
            }
            else
            {
                textBoxSignupPassword.PasswordChar = '*';
                pictureBoxSignupTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed);
            }
        }

        public Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
                return Image.FromStream(ms);
        }

        private void panelSignup_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}