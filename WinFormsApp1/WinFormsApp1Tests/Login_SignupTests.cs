using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsApp1;

namespace WinFormsApp1.Tests
{
    [TestClass]
    public class LoginSignupTests
    {
        private Login_Signup loginSignup;
        private string testDbPath;
        private string testExcelPath;

        [TestInitialize]
        public void Setup()
        {
            loginSignup = new Login_Signup();

            // Setup test database
            testDbPath = Path.Combine(Path.GetTempPath(), "TestDatabase.db");
            CreateTestDatabase();

            // Setup test Excel file
            testExcelPath = Path.Combine(Path.GetTempPath(), "TestInfo.xlsx");
            CreateTestExcelFile();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up test files
            if (File.Exists(testDbPath))
                File.Delete(testDbPath);
            if (File.Exists(testExcelPath))
                File.Delete(testExcelPath);
        }

        private void CreateTestDatabase()
        {
            var connectionString = $"Data Source={testDbPath};Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var createTableCommand = @"
                    CREATE TABLE Person (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        userName TEXT NOT NULL,
                        type TEXT NOT NULL,
                        taz TEXT NOT NULL,
                        mail TEXT NOT NULL
                    );";

                using (var command = new SQLiteCommand(createTableCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateTestExcelFile()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                worksheet.Cell("A1").Value = "Username";
                worksheet.Cell("B1").Value = "Password";
                workbook.SaveAs(testExcelPath);
            }
        }

        #region Input Validation Tests

        //[TestMethod]
        //public void CheckInputsSignUp_ValidInputs_ReturnsTrue()
        //{
        //    // Arrange
        //    SetSignupTextBoxes("user123", "Pass123!", "123456789", "test@email.com");

        //    // Act
        //    bool result = loginSignup.checkInputsSignUp();

        //    // Assert
        //    Assert.IsTrue(result);
        //}

        [TestMethod]
        public void CheckInputsSignUp_EmptyUsername_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("", "Pass123!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_EmptyPassword_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user123", "", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_EmptyID_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user123", "Pass123!", "", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_EmptyEmail_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user123", "Pass123!", "123456789", "");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_UsernameTooShort_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user1", "Pass123!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_UsernameTooLong_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("username123", "Pass123!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_UsernameWithTooManyDigits_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user123", "Pass123!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_UsernameWithSpecialCharacters_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user@#", "Pass123!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_PasswordTooShort_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Pass1!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_PasswordTooLong_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Password123!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_PasswordWithoutLetter_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "12345678!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_PasswordWithoutDigit_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Password!", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_PasswordWithoutSpecialChar_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Password123", "123456789", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_IDNotNineDigits_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Pass123!", "12345678", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_IDWithNonDigits_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Pass123!", "12345678a", "test@email.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_InvalidEmailFormat_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Pass123!", "123456789", "invalid-email");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_EmailWithoutAtSymbol_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Pass123!", "123456789", "testgmail.com");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInputsSignUp_EmailWithoutDomain_ReturnsFalse()
        {
            // Arrange
            SetSignupTextBoxes("user12", "Pass123!", "123456789", "test@");

            // Act
            bool result = loginSignup.checkInputsSignUp();

            // Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region Excel Operations Tests

        [TestMethod]
        public void CheckLogin_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell(2, 1).Value = "testuser";
                worksheet.Cell(2, 2).Value = "testpass";
                workbook.Save();
            }

            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);

                // Act
                bool result = loginSignup.checkLogin(worksheet, "testuser", "testpass");

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void CheckLogin_InvalidUsername_ReturnsFalse()
        {
            // Arrange
            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell(2, 1).Value = "testuser";
                worksheet.Cell(2, 2).Value = "testpass";
                workbook.Save();
            }

            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);

                // Act
                bool result = loginSignup.checkLogin(worksheet, "wronguser", "testpass");

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void CheckLogin_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell(2, 1).Value = "testuser";
                worksheet.Cell(2, 2).Value = "testpass";
                workbook.Save();
            }

            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);

                // Act
                bool result = loginSignup.checkLogin(worksheet, "testuser", "wrongpass");

                // Assert
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void UserNameExistsExcel_ExistingUser_ReturnsTrue()
        {
            // Arrange
            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);
                worksheet.Cell(2, 1).Value = "existinguser";
                worksheet.Cell(2, 2).Value = "password";
                workbook.Save();
            }

            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);

                // Act
                bool result = loginSignup.userNameExistsExcel(worksheet, "existinguser");

                // Assert
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void UserNameExistsExcel_NonExistingUser_ReturnsFalse()
        {
            // Arrange
            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet(1);

                // Act
                bool result = loginSignup.userNameExistsExcel(worksheet, "nonexistinguser");

                // Assert
                Assert.IsFalse(result);
            }
        }

        #endregion

        #region Database Operations Tests

        [TestMethod]
        public void UserNameExistsDataBase_NonExistingUser_ReturnsFalse()
        {
            // Act
            bool result = loginSignup.userNameExistsDataBase("nonexistinguser");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MailExistsDataBase_NonExistingEmail_ReturnsFalse()
        {
            // Act
            bool result = loginSignup.mailExistsDataBase("nonexisting@email.com");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TazExistsDataBase_NonExistingTaz_ReturnsFalse()
        {
            // Act
            bool result = loginSignup.tazExistsDataBase("111111111");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetUserType_NonExistingUser_ReturnsNull()
        {
            // Act
            string result = loginSignup.getUserType("nonexistinguser");

            // Assert
            Assert.IsNull(result);
        }

        #endregion

        #region Helper Methods

        private void SetSignupTextBoxes(string username, string password, string id, string email)
        {
            // Since we can't directly access private textboxes, we'll need to use reflection
            // or modify the class to make these accessible for testing
            var usernameField = typeof(Login_Signup).GetField("textBoxSignupUsername",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var passwordField = typeof(Login_Signup).GetField("textBoxSignupPassword",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var idField = typeof(Login_Signup).GetField("textBoxSignupID",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var emailField = typeof(Login_Signup).GetField("textBoxSignupMail",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (usernameField?.GetValue(loginSignup) is TextBox usernameTextBox)
                usernameTextBox.Text = username;
            if (passwordField?.GetValue(loginSignup) is TextBox passwordTextBox)
                passwordTextBox.Text = password;
            if (idField?.GetValue(loginSignup) is TextBox idTextBox)
                idTextBox.Text = id;
            if (emailField?.GetValue(loginSignup) is TextBox emailTextBox)
                emailTextBox.Text = email;
        }
        #endregion
    }

    // Alternative approach: Create a testable wrapper class
    [TestClass]
    public class LoginSignupLogicTests
    {
        private TestableLoginSignup loginSignup;
        private string testDbPath;
        private string testExcelPath;

        [TestInitialize]
        public void Setup()
        {
            loginSignup = new TestableLoginSignup();

            testDbPath = Path.Combine(Path.GetTempPath(), "TestDatabase.db");
            CreateTestDatabase();

            testExcelPath = Path.Combine(Path.GetTempPath(), "TestInfo.xlsx");
            CreateTestExcelFile();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testDbPath))
                File.Delete(testDbPath);
            if (File.Exists(testExcelPath))
                File.Delete(testExcelPath);
        }

        private void CreateTestDatabase()
        {
            var connectionString = $"Data Source={testDbPath};Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var createTableCommand = @"
                    CREATE TABLE Person (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        userName TEXT NOT NULL,
                        type TEXT NOT NULL,
                        taz TEXT NOT NULL,
                        mail TEXT NOT NULL
                    );";

                using (var command = new SQLiteCommand(createTableCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateTestExcelFile()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                worksheet.Cell("A1").Value = "Username";
                worksheet.Cell("B1").Value = "Password";
                workbook.SaveAs(testExcelPath);
            }
        }

        [TestMethod]
        public void ValidateSignupInputs_AllValidInputs_ReturnsTrue()
        {
            // Act
            bool result = loginSignup.ValidateSignupInputs("user12", "Pass123!", "123456789", "test@email.com");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateSignupInputs_InvalidUsername_ReturnsFalse()
        {
            // Act
            bool result = loginSignup.ValidateSignupInputs("u", "Pass123!", "123456789", "test@email.com");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateSignupInputs_InvalidPassword_ReturnsFalse()
        {
            // Act
            bool result = loginSignup.ValidateSignupInputs("user12", "pass", "123456789", "test@email.com");

            // Assert
            Assert.IsFalse(result);
        }
    }

    // Testable wrapper class that extracts the logic
    public class TestableLoginSignup
    {
        public bool ValidateSignupInputs(string username, string password, string id, string mail)
        {
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(mail))
            {
                return false;
            }

            if (username.Length < 6 || username.Length > 8)
            {
                return false;
            }

            bool IsEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
            int digitCount = username.Count(char.IsDigit);
            int letterCount = username.Count(IsEnglishLetter);
            bool allValid = username.All(c => char.IsDigit(c) || IsEnglishLetter(c));
            if (!allValid || digitCount > 2 || letterCount != username.Length - digitCount)
            {
                return false;
            }

            if (password.Length < 8 || password.Length > 10)
            {
                return false;
            }
            bool hasLetter = password.Any(IsEnglishLetter);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(c => "!@#$%^&*()-_=+[]{};:'\".,.<>?/|".Contains(c));
            if (!hasLetter || !hasDigit || !hasSpecial)
            {
                return false;
            }

            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                return false;
            }

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(mail, emailPattern))
            {
                return false;
            }

            return true;
        }
    }
}