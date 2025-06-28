using System;
using System.Data.SQLite;
using System.Drawing;
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
            // Setup database
            testDbPath = Path.Combine(Path.GetTempPath(), "TestDatabase.db");
            if (File.Exists(testDbPath))
                File.Delete(testDbPath);
            CreateTestDatabase();

            loginSignup = new Login_Signup(testDbPath);

            // Setup Excel
            testExcelPath = Path.Combine(Path.GetTempPath(), "TestInfo.xlsx");
            if (File.Exists(testExcelPath))
                File.Delete(testExcelPath);
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

        // 1. Test userNameExistsDataBase
        [TestMethod]
        public void UserNameExistsDataBase_ReturnsTrueIfUserExists()
        {
            InsertPersonIntoDatabase("TestUser", "Student", "123456789", "test@mail.com");

            bool exists = loginSignup.userNameExistsDataBase("TestUser");

            Assert.IsTrue(exists);
        }

        // 2. Test mailExistsDataBase
        [TestMethod]
        public void MailExistsDataBase_ReturnsTrueIfMailExists()
        {
            InsertPersonIntoDatabase("AnotherUser", "Professor", "987654321", "exists@mail.com");

            bool exists = loginSignup.mailExistsDataBase("exists@mail.com");

            Assert.IsTrue(exists);
        }

        // 3. Test tazExistsDataBase
        [TestMethod]
        public void TazExistsDataBase_ReturnsTrueIfTazExists()
        {
            InsertPersonIntoDatabase("UserTaz", "Student", "555555555", "taz@mail.com");

            bool exists = loginSignup.tazExistsDataBase("555555555");

            Assert.IsTrue(exists);
        }

        // 4. Test getUserType
        [TestMethod]
        public void GetUserType_ReturnsCorrectType()
        {
            InsertPersonIntoDatabase("UserType", "Admin", "111222333", "admin@mail.com");

            string userType = loginSignup.getUserType("UserType");

            Assert.AreEqual("Admin", userType);
        }

        // 5. Test userNameExistsExcel
        [TestMethod]
        public void UserNameExistsExcel_ReturnsTrueIfUserExists()
        {
            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet("Users");
                worksheet.Cell(2, 1).Value = "ExcelUser";
                workbook.Save();

                bool exists = loginSignup.userNameExistsExcel(worksheet, "ExcelUser");

                Assert.IsTrue(exists);
            }
        }

        // 6. Test checkLogin
        [TestMethod]
        public void CheckLogin_ReturnsTrueForValidCredentials()
        {
            using (var workbook = new XLWorkbook(testExcelPath))
            {
                var worksheet = workbook.Worksheet("Users");
                worksheet.Cell(2, 1).Value = "LoginUser";
                worksheet.Cell(2, 2).Value = "Password123!";
                workbook.Save();

                bool result = loginSignup.checkLogin(worksheet, "LoginUser", "Password123!");

                Assert.IsTrue(result);
            }
        }

        // 7. Test ByteArrayToImage
        [TestMethod]
        public void ByteArrayToImage_ReturnsValidImage()
        {
            using (var bmp = new Bitmap(10, 10))
            {
                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] bytes = ms.ToArray();

                    Image img = loginSignup.ByteArrayToImage(bytes);

                    Assert.IsNotNull(img);
                    Assert.AreEqual(10, img.Width);
                    Assert.AreEqual(10, img.Height);
                }
            }
        }

        // Helper to insert user into DB
        private void InsertPersonIntoDatabase(string userName, string type, string taz, string mail)
        {
            var connectionString = $"Data Source={testDbPath};Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertCmd = "INSERT INTO Person (userName, type, taz, mail) VALUES (@userName, @type, @taz, @mail)";
                using (var cmd = new SQLiteCommand(insertCmd, connection))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@taz", taz);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SetSignupTextBoxes(string username, string password, string id, string email)
        {
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
    }
}