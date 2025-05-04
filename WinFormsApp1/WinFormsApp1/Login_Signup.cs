using System;
using System.Windows.Forms;

using ClosedXML.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class Login_Signup : Form
    {
        public Login_Signup()
        {
            InitializeComponent();
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
        private void signUp(string userName, string password)
        {
            XLWorkbook workbook = null; // Declare workbook in the correct scope
            try
            {
                var result = OpenOrCreateExcel();
                workbook = result.Item1; // Assign workbook
                var worksheet = result.Item2;

                // the "?. " means if worksheet.LastRowUsed() == null it will return 1
                // it will never be null because we have headers
                int lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 1;

                if (userNameExists(worksheet, userName)) // Only looking for name
                {
                    MessageBox.Show("User already exists");
                }
                else
                {
                    worksheet.Cell(lastRow + 1, 1).Value = userName;
                    worksheet.Cell(lastRow + 1, 2).Value = password;
                    workbook.SaveAs("Info.xlsx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to sign up: {ex.Message}");
            }
            finally
            {
                workbook?.Dispose(); // Ensure resources are released
            }
        }
        private void logIn(string userName,string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                // Fill here validation
                return;
            }
            // Open the Excel file and ensure proper disposal
            XLWorkbook workbook = null; // Declare workbook in the correct scope
            try
            {
                var result = OpenOrCreateExcel();
                workbook = result.Item1; // Assign workbook
                var worksheet = result.Item2;

                if (checkLogin(worksheet, userName, password))
                {
                    MessageBox.Show("Login successful!");
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
                workbook?.Dispose(); // Ensure resources are released
            }
        }
        private void clearInputs()
        {
            textBoxLoginUsername.Text = "";
            textBoxLoginPassword.Text = "";
            textBoxSignupUsername.Text = "";
            textBoxSignupPassword.Text = "";
        }
        private bool userNameExists(IXLWorksheet worksheet, string userName) // For signup
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
            string userName = textBoxSignupUsername.Text.ToString();
            string password = textBoxSignupPassword.Text.ToString();
            signUp(userName, password);
            clearInputs();
        }
        private void buttonLoginEnter_Click(object sender, EventArgs e)
        {
            string userName = textBoxLoginUsername.Text;
            string password = textBoxLoginPassword.Text;

            // Log in attempt
            var result = OpenOrCreateExcel();
            var worksheet = result.Item2;

            if (checkLogin(worksheet, userName, password))
            {
                MessageBox.Show("Login successful!");
                mainForm mainForm = new mainForm();
                mainForm.Show();
                this.Hide(); // hide current form
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

            result.Item1.Dispose(); // Dispose workbook
            clearInputs();
        }
    }
}
