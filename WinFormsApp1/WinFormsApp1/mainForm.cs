using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        private bool isCLosing = false;
        private string userName;
        public mainForm(string USERNAME)
        {
            userName = USERNAME;
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {userName}!";
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            StudentTracking studentTracking = new StudentTracking(userName);
            studentTracking.Show();
            isCLosing = true;
            this.Close();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCLosing)
            {
                Application.Exit();
            }
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            TestSelectionForm selector = new TestSelectionForm(userName);
            selector.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login_Signup loginForm = new Login_Signup();
            loginForm.Show();
            isCLosing = true;
            this.Close();
        }
    }
}