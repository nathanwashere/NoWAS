using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            SetupButtons();
            
        }

        private void SetupButtons()
        {
            SetupButton(btnTakeTest, "Take Test", new Point(150, 180));
            SetupButton(btnGrades, "My Grades", new Point(400, 180));
            SetupButton(btnProgress, "Progress", new Point(150, 250));
            SetupButton(btnSettings, "Settings", new Point(200, 340), small: true);
            SetupButton(btnLogout, "Logout", new Point(380, 340), small: true);
        }

        private void SetupButton(Button btn, string text, Point location, bool small = false)
        {
            btn.Text = text;
            btn.Size = small ? new Size(100, 40) : new Size(200, 50);
            btn.Location = location;
            btn.BackColor = Color.SteelBlue;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

      

        private void btnGrades_Click(object sender, EventArgs e)
        {
            StudentTracking studentTracking = new StudentTracking();
            studentTracking.Show();
            this.Close();
        }
    }
}
