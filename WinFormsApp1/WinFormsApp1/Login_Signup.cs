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
            InitializeComponent();// Initializes all the UI components defined in the Form Designer (.Designer.cs)
            this.AutoScaleMode = AutoScaleMode.Dpi;  // Scales the form's controls based on the screen's DPI (helps with high-DPI displays)

            this.Font = new Font("Segoe UI", 12F); // Sets the default font for the form and its controls
            this.DoubleBuffered = true;    // Reduces flickering by using double buffering (draws off-screen before displaying)
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            // Optimizes drawing to further reduce flicker and control how painting is handled
            this.UpdateStyles();// Applies the above SetStyle changes

   
            pictureBoxLoginTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed);// Sets the login password toggle image to a "closed eye"
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;   // Prevents the error icon from blinking (makes it static when shown)

            using (MemoryStream ms = new MemoryStream(Properties.Resources.ErrorIcon))// Converts the ErrorIcon resource (byte array) to a stream
            {
                using (Bitmap bmp = new Bitmap(ms))    // Creates a bitmap from the memory stream
                {
                    Icon icon = Icon.FromHandle(bmp.GetHicon());  // Creates an Icon from the bitmap handle
                    errorProvider.Icon = icon; // Sets the errorProvider's icon to the custom icon          
                }
            }

            _dbFilePath = dbFilePath
            ?? Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.db"));
            // Sets the database file path. If none is given, uses the default path 3 levels up to 'Database.db'
        }



        private void Login_Signup_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = true; // Show login panel
            panelSignup.Visible = true; // Show signup panel

            panelLogin.BringToFront(); // Bring login panel to front (default view)
            rbStudent.Checked = true; // Select "Student" radio button by default

            RoundButtonCorners(buttonSignupEnter, buttonSignupEnter.Height); // Round signup button
            RoundButtonCorners(buttonLoginEnter, buttonLoginEnter.Height); // Round login button
            RoundButtonCorners(buttonSignupToLogin, buttonSignupToLogin.Height); // Round "Go to Login" button
            RoundButtonCorners(buttonLoginToSignup, buttonLoginToSignup.Height); // Round "Go to Signup" button
        }
        private void buttonSignupToLogin_Click(object sender, EventArgs e)
        {
            showingSignup = false; // Mark that we're showing the login view now
            panelLogin.BringToFront(); // Bring the login panel to the front
            clearInputs(); // Clear all textboxes and reset form state
        }
        private void buttonLoginToSignup_Click(object sender, EventArgs e)
        {
            showingSignup = true; // Mark that we're showing the signup view now
            panelSignup.BringToFront(); // Bring the signup panel to the front
            clearInputs(); // Clear all textboxes and reset form state
        }

        private void RoundButtonCorners(Button btn, int radius) // a visual method to round the corners of a button
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
            string userName = textBoxSignupUsername.Text; // Get username from input
            string password = textBoxSignupPassword.Text; // Get password from input
            string taz = textBoxSignupID.Text; // Get ID (Taz) from input
            string mail = textBoxSignupMail.Text; // Get email from input
            signUp(userName, password, taz, mail); // Call signup function with input values
        }

        private void buttonLoginEnter_Click(object sender, EventArgs e)
        {
            string userName = textBoxLoginUsername.Text; // Get username from input
            string password = textBoxLoginPassword.Text; // Get password from input
            logIn(userName, password); // Call login function with input values
        }

        private void clearInputs() //clearing input for visual improvement
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
            string username = textBoxSignupUsername.Text; // Get username
            string password = textBoxSignupPassword.Text; // Get password
            string id = textBoxSignupID.Text; // Get ID
            string mail = textBoxSignupMail.Text; // Get email

            // Check for empty fields
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(mail))
            {
                errorProvider.SetError(textBoxSignupID, "Please fill in all fields.");
                errorProvider.SetError(textBoxSignupMail, "Please fill in all fields.");
                errorProvider.SetError(textBoxSignupPassword, "Please fill in all fields.");
                errorProvider.SetError(textBoxSignupUsername, "Please fill in all fields.");
                return false;
            }

            // Username must be 6–8 characters
            if (username.Length < 6 || username.Length > 8)
            {
                errorProvider.SetError(textBoxSignupUsername, "Username must be between 6 and 8 characters long.");
                return false;
            }

            // Username validation: max 2 digits, rest letters, all must be English letters or digits
            bool IsEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
            int digitCount = username.Count(char.IsDigit);
            int letterCount = username.Count(IsEnglishLetter);
            bool allValid = username.All(c => char.IsDigit(c) || IsEnglishLetter(c));
            if (!allValid || digitCount > 2 || letterCount != username.Length - digitCount)
            {
                errorProvider.SetError(textBoxSignupUsername, "Username must contain at most 2 digits and at least 4 letters.");
                return false;
            }

            // Password must be 8–10 characters
            if (password.Length < 8 || password.Length > 10)
            {
                errorProvider.SetError(textBoxSignupPassword, "Password must be between 8 and 10 characters long.");
                return false;
            }

            // Password must include letter, digit, and special character
            bool hasLetter = password.Any(IsEnglishLetter);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(c => "!@#$%^&*()-_=+[]{};:'\".,.<>?/|".Contains(c));
            if (!hasLetter || !hasDigit || !hasSpecial)
            {
                errorProvider.SetError(textBoxSignupPassword, "Password must contain at least one letter, one digit, and one special character.");
                return false;
            }

            // ID must be exactly 9 digits
            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                errorProvider.SetError(textBoxSignupID, "ID must be exactly 9 digits long.");
                return false;
            }

            // Email format validation
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(mail, emailPattern))
            {
                errorProvider.SetError(textBoxSignupMail, "Please enter a valid email address.");
                return false;
            }

            return true; // All inputs are valid
        }


        private void signUp(string userName, string password, string taz, string mail)
        {
            if (!checkInputsSignUp()) // Validate all input fields
                return;

            XLWorkbook workbook = null;
            try
            {
                var result = OpenOrCreateExcel(); // Open or create the Excel file
                workbook = result.Item1;
                var worksheet = result.Item2;
                int lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 1; // Get last used row or 1 if empty

                // Check if username already exists in both Excel and database
                if (userNameExistsExcel(worksheet, userName) &&
                    userNameExistsDataBase(userName))
                {
                    errorProvider.SetError(textBoxSignupUsername, "Username already exists");
                    return;
                }

                // Check if ID already exists
                if (tazExistsDataBase(taz))
                {
                    errorProvider.SetError(textBoxSignupID, "ID already exists");
                    return;
                }

                // Check if email already exists
                if (mailExistsDataBase(mail))
                {
                    errorProvider.SetError(textBoxSignupMail, "Email already exists");
                    return;
                }

                // Save user to Excel
                worksheet.Cell(lastRow + 1, 1).Value = userName;
                worksheet.Cell(lastRow + 1, 2).Value = password;
                workbook.SaveAs("Info.xlsx");

                // Add user to DB with role
                addUserToDataBase(
                    userName,
                    rbStudent.Checked ? "Student" : "Professor",
                    taz,
                    mail
                );

                MessageBox.Show("Account was successfully registered!");

                // Auto-login after signup
                if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Student")
                {
                    new mainForm(userName).Show(); // Open student view
                    this.Hide();
                }
                else if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Professor")
                {
                    new mainTeacher(userName).Show(); // Open professor view
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to sign up: {ex.Message}");
            }
            finally
            {
                workbook?.Dispose(); // Dispose workbook to free resources
            }
        }


        private void logIn(string userName, string password) //check login state
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                errorProvider.SetError(textBoxLoginUsername, "Please fill in all fields."); // Show error if fields are empty
                errorProvider.SetError(textBoxLoginPassword, "Please fill in all fields");
                return;
            }

            XLWorkbook workbook = null;
            try
            {
                var result = OpenOrCreateExcel(); // Open or create Excel file
                workbook = result.Item1;
                var worksheet = result.Item2;

                // If login is successful and user is a student
                if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Student")
                {
                    MessageBox.Show("Login successful!");
                    new mainForm(userName).Show(); // Open student form
                    this.Hide();
                }
                // If login is successful and user is a professor
                else if (checkLogin(worksheet, userName, password) && getUserType(userName) == "Professor")
                {
                    MessageBox.Show("Login successful!");
                    new mainTeacher(userName).Show(); // Open professor form
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password."); // Show error if login fails
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to login: {ex.Message}"); // Catch unexpected errors
            }
            finally
            {
                workbook?.Dispose(); // Dispose workbook to release resources
            }
        }


        public SQLiteConnection connectDataBase()
        {
            if (string.IsNullOrEmpty(_dbFilePath) || !File.Exists(_dbFilePath))
            {
                MessageBox.Show("Database file not found!"); // Show error if path is missing or file doesn't exist
                return null;
            }

            try
            {
                var connectString = new SQLiteConnectionStringBuilder
                {
                    DataSource = _dbFilePath, // Set database path
                    Version = 3 // SQLite version
                }.ToString();

                var conn = new SQLiteConnection(connectString); // Create connection object
                conn.Open(); // Open connection
                return conn; // Return open connection
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open database:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Return null on error
            }
        }


        public (XLWorkbook, IXLWorksheet) OpenOrCreateExcel()
        {
            var filePath = "Info.xlsx"; // Excel file name
            XLWorkbook workbook;
            IXLWorksheet worksheet;

            if (File.Exists(filePath)) // If file exists, open it
            {
                workbook = new XLWorkbook(filePath);
                worksheet = workbook.Worksheet(1);
            }
            else // If not, create new file and add header row
            {
                workbook = new XLWorkbook();
                worksheet = workbook.Worksheets.Add("Users");
                worksheet.Cell("A1").Value = "Username"; // Header for username
                worksheet.Cell("B1").Value = "Password"; // Header for password
                workbook.SaveAs(filePath); // Save new file
            }

            return (workbook, worksheet); // Return both workbook and worksheet
        }


        public void addUserToDataBase(string userName, string type, string taz, string mail)
        {
            using (var conn = connectDataBase()) // Open DB connection
            {
                if (conn == null) return; // Exit if connection failed

                string query = @"
            INSERT INTO Person (userName, type, taz, mail)
            VALUES (@userName, @type, @taz, @mail);
        "; // SQL insert query

                using (var cmd = new SQLiteCommand(query, conn)) // Create SQL command
                {
                    // Bind parameters
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@taz", taz);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.ExecuteNonQuery(); // Execute insert
                }
            }
        }


        public bool checkLogin(IXLWorksheet worksheet, string userName, string password)
        {
            foreach (var row in worksheet.RowsUsed().Skip(1)) // Skip header row
            {
                string userNameExcel = row.Cell(1).GetValue<string>(); // Get username from column A
                string passwordExcel = row.Cell(2).GetValue<string>(); // Get password from column B

                if (userNameExcel == userName && passwordExcel == password)
                {
                    return true; // Match found
                }
            }
            return false; // No match found
        }


        public string getUserType(string username)
        {
            using (var conn = connectDataBase()) // Open DB connection
            {
                if (conn == null) return null; // Exit if connection failed

                string query = "SELECT type FROM Person WHERE userName = @username"; // SQL query

                using (var cmd = new SQLiteCommand(query, conn)) // Create SQL command
                {
                    cmd.Parameters.AddWithValue("@username", username); // Bind parameter
                    var result = cmd.ExecuteScalar(); // Execute and get single result
                    return result?.ToString(); // Return result as string (or null)
                }
            }
        }


        public bool userNameExistsExcel(IXLWorksheet worksheet, string userName)//from exel
        {
            foreach (var row in worksheet.RowsUsed().Skip(1)) // Skip header row
            {
                string userNameExcel = row.Cell(1).GetValue<string>(); // Get username from column A
                if (userNameExcel == userName)
                {
                    return true; // Username found
                }
            }
            return false; // Username not found
        }


        public bool userNameExistsDataBase(string username)
        {
            using (var conn = connectDataBase()) // Open DB connection
            {
                if (conn == null) return false; // Exit if connection failed

                string query = "SELECT COUNT(*) FROM Person WHERE userName = @username"; // Query to count matching usernames

                using (var cmd = new SQLiteCommand(query, conn)) // Create SQL command
                {
                    cmd.Parameters.AddWithValue("@username", username); // Bind parameter
                    long count = (long)cmd.ExecuteScalar(); // Execute and get count
                    return count > 0; // Return true if user exists
                }
            }
        }


        public bool mailExistsDataBase(string mail)
        {
            using (var conn = connectDataBase()) // Open DB connection
            {
                if (conn == null) return false; // Exit if connection failed

                string query = "SELECT COUNT(*) FROM Person WHERE mail = @mail"; // Query to count matching emails

                using (var cmd = new SQLiteCommand(query, conn)) // Create SQL command
                {
                    cmd.Parameters.AddWithValue("@mail", mail); // Bind parameter
                    long count = (long)cmd.ExecuteScalar(); // Execute and get count
                    return count > 0; // Return true if email exists
                }
            }
        }


        public bool tazExistsDataBase(string taz)
        {
            using (var conn = connectDataBase()) // Open DB connection
            {
                if (conn == null) return false; // Exit if connection failed

                string query = "SELECT COUNT(*) FROM Person WHERE taz = @taz"; // Query to count matching IDs

                using (var cmd = new SQLiteCommand(query, conn)) // Create SQL command
                {
                    cmd.Parameters.AddWithValue("@taz", taz); // Bind parameter
                    long count = (long)cmd.ExecuteScalar(); // Execute and get count
                    return count > 0; // Return true if ID exists
                }
            }
        }


        private void pictureBoxLoginTogglePassword_Click(object sender, EventArgs e)// visual function to toggle password visibility
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

        private void pictureBoxSignupTogglePassword_Click(object sender, EventArgs e)//visual to set password visibility in signup
        {
            isSignupPasswordVisible = !isSignupPasswordVisible; // Toggle password visibility state

            if (isSignupPasswordVisible)
            {
                textBoxSignupPassword.PasswordChar = '\0'; // Show password
                pictureBoxSignupTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_open); // Show open-eye icon
            }
            else
            {
                textBoxSignupPassword.PasswordChar = '*'; // Hide password
                pictureBoxSignupTogglePassword.Image = ByteArrayToImage(Properties.Resources.eye_closed); // Show closed-eye icon
            }
        }

        public Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes)) // Load image from byte array
                return Image.FromStream(ms); // Return image object
        }

    }
}