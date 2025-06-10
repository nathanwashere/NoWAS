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
        private string _dbFilePath;

        private Image loginBackground;
        private Image signupBackground;

        public Login_Signup(string dbFilePath = null)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // INITIAL STATE: login

            pictureBoxLoginTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed);

            // INITIAL STATE: signup

            pictureBoxSignupTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed);
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            using (MemoryStream ms = new MemoryStream(Properties.Resources.ErrorIcon))
            {
                using (Bitmap bmp = new Bitmap(ms))
                {
                    Icon icon = Icon.FromHandle(bmp.GetHicon());
                    errorProvider.Icon = icon;
                }
            }

            _dbFilePath = dbFilePath
            ?? Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db"));
        }


        private void Login_Signup_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelSignup.Visible = false;

            rbStudent.Checked = true;

            RoundButtonCorners(buttonSignupEnter, buttonSignupEnter.Height);
            RoundButtonCorners(buttonLoginEnter, buttonLoginEnter.Height);
            RoundButtonCorners(buttonSignupToLogin, buttonSignupToLogin.Height);
            RoundButtonCorners(buttonLoginToSignup, buttonLoginToSignup.Height);
        }




        private void buttonSignupToLogin_Click(object sender, EventArgs e)
        {
            showingSignup = false;

            panelSignup.Visible = false;
            panelLogin.Visible = true;
            panelLogin.BringToFront(); // Optional
            clearInputs();
        }




        private void buttonLoginToSignup_Click(object sender, EventArgs e)
        {
            showingSignup = true;

            panelLogin.Visible = false;
            panelSignup.Visible = true;
            panelSignup.BringToFront(); // Optional: keep order consistent
            clearInputs();
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
            // 1) Clear any old errors
            errorProvider.Clear();

            bool isValid = true;

            string username = textBoxSignupUsername.Text.Trim();
            string password = textBoxSignupPassword.Text;
            string id = textBoxSignupID.Text.Trim();
            string mail = textBoxSignupMail.Text.Trim();

            // 2) Check for empty
            if (string.IsNullOrEmpty(username))
            {
                errorProvider.SetError(textBoxSignupUsername, "Please fill in your username.");
                isValid = false;
            }
            if (string.IsNullOrEmpty(password))
            {
                errorProvider.SetError(textBoxSignupPassword, "Please fill in your password.");
                isValid = false;
            }
            if (string.IsNullOrEmpty(id))
            {
                errorProvider.SetError(textBoxSignupID, "Please fill in your ID.");
                isValid = false;
            }
            if (string.IsNullOrEmpty(mail))
            {
                errorProvider.SetError(textBoxSignupMail, "Please fill in your email.");
                isValid = false;
            }

            // 3) Username rules (only if non-empty)
            if (!string.IsNullOrEmpty(username))
            {
                if (username.Length < 6 || username.Length > 8)
                {
                    errorProvider.SetError(textBoxSignupUsername, "Username must be between 6 and 8 characters long.");
                    isValid = false;
                }
                else
                {
                    bool IsEnglishLetter(char c) =>
                        (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');

                    int digitCount = username.Count(char.IsDigit);
                    int letterCount = username.Count(IsEnglishLetter);
                    bool allValid = username.All(c => char.IsDigit(c) || IsEnglishLetter(c));

                    if (!allValid || digitCount > 2 || letterCount < 4)
                    {
                        errorProvider.SetError(textBoxSignupUsername,
                            "Username must use only English letters, have at most 2 digits and at least 4 letters.");
                        isValid = false;
                    }
                }
            }

            // Original:
            // // 4) Password rules (only if non-empty)
            // if (!string.IsNullOrEmpty(password))
            // {
            //     if (password.Length < 8 || password.Length > 10)
            //     {
            //         errorProvider.SetError(textBoxSignupPassword,
            //             "Password must be between 8 and 10 characters long.");
            //         isValid = false;
            //     }
            //     else
            //     {
            //         bool IsEnglishLetter(char c) =>
            //             (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
            //
            //         bool hasLetter = password.Any(IsEnglishLetter);
            //         bool hasDigit = password.Any(char.IsDigit);
            //         bool hasSpecial = password.Any(c => "!@#$%^&*()-_=+[]{};:'\".,.<>?/|".Contains(c));
            //
            //         if (!hasLetter || !hasDigit || !hasSpecial)
            //         {
            //             errorProvider.SetError(textBoxSignupPassword,
            //                 "Password must contain at least one letter, one digit, and one special character.");
            //             isValid = false;
            //         }
            //     }
            // }

          // 4) Password rules (only if non-empty)
if (!string.IsNullOrEmpty(password))
{
    const int MinLength = 8;
    const int MaxLength = 10;
    const string AllowedSpecials = "!@#$%^&*()-_=+[]{};:'\".,.<>?/|";

    // 4a) Length check
    if (password.Length < MinLength || password.Length > MaxLength)
    {
        errorProvider.SetError(
            textBoxSignupPassword,
            $"Password must be between {MinLength} and {MaxLength} characters long."
        );
        isValid = false;
    }
    else
    {
        // 4b) Composition checks
        bool hasLetter = password.Any(c =>
            (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')
        );
        bool hasDigit = password.Any(char.IsDigit);
        bool hasSpecial = password.Any(c => AllowedSpecials.Contains(c));
        bool allValid = password.All(c =>
            ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
            || char.IsDigit(c)
            || AllowedSpecials.Contains(c)
        );

        if (!hasLetter || !hasDigit || !hasSpecial || !allValid)
        {
            errorProvider.SetError(
                textBoxSignupPassword,
                 "Password must include at least one letter, one digit, and one special character, " +
                $"and be {MinLength}–{MaxLength} characters long."
            );
            isValid = false;
        }
    }
}


            // 5) ID rules (only if non-empty)
            if (!string.IsNullOrEmpty(id))
            {
                if (id.Length != 9 || !id.All(char.IsDigit))
                {
                    errorProvider.SetError(textBoxSignupID, "ID must be exactly 9 digits long.");
                    isValid = false;
                }
            }

            // 6) Email rules (only if non-empty)
            if (!string.IsNullOrEmpty(mail))
            {
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(mail, emailPattern))
                {
                    errorProvider.SetError(textBoxSignupMail, "Please enter a valid email address.");
                    isValid = false;
                }
            }

            return isValid;
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
                    errorProvider.SetError(textBoxSignupUsername, "Username already exists");
                    return;
                }

                if (tazExistsDataBase(taz))
                {
                    errorProvider.SetError(textBoxSignupID, "ID already exists");
                    return;
                }

                if (mailExistsDataBase(mail))
                {
                    errorProvider.SetError(textBoxSignupMail, "Email already exists");
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
                    new mainTeacher(userName).Show();
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
                errorProvider.SetError(textBoxLoginUsername, "Please fill in all fields.");
                errorProvider.SetError(textBoxLoginPassword, "Please fill in all fields");
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
                    new mainTeacher(userName).Show();
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
            if (string.IsNullOrEmpty(_dbFilePath) || !File.Exists(_dbFilePath))
            {
                MessageBox.Show("Database file not found!");
                return null;
            }

            try
            {
                var connectString = new SQLiteConnectionStringBuilder
                {
                    DataSource = _dbFilePath,
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
    }
}