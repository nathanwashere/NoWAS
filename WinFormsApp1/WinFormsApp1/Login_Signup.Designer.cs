using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Login_Signup : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Signup));
            panelLogin = new Panel();
            pictureBoxLoginTogglePassword = new PictureBox();
            label1 = new Label();
            labelLoginUsername = new Label();
            labelLoginPassword = new Label();
            textBoxLoginUsername = new TextBox();
            textBoxLoginPassword = new TextBox();
            buttonLoginEnter = new Button();
            buttonLoginToSignup = new Button();
            panelSignup = new Panel();
            pictureBoxSignupTogglePassword = new PictureBox();
            labelTitleSignup = new Label();
            labelSignupUsername = new Label();
            textBoxSignupUsername = new TextBox();
            labelSignupPassword = new Label();
            textBoxSignupPassword = new TextBox();
            labelID = new Label();
            textBoxSignupID = new TextBox();
            labelMail = new Label();
            textBoxSignupMail = new TextBox();
            rbStudent = new RadioButton();
            rbProf = new RadioButton();
            buttonSignupEnter = new Button();
            buttonSignupToLogin = new Button();
            labelPasswordInfo = new Label();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoginTogglePassword).BeginInit();
            panelSignup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSignupTogglePassword).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.FromArgb(245, 245, 255);
            panelLogin.BackgroundImage = (Image)resources.GetObject("panelLogin.BackgroundImage");
            panelLogin.Controls.Add(pictureBoxLoginTogglePassword);
            panelLogin.Controls.Add(label1);
            panelLogin.Controls.Add(labelLoginUsername);
            panelLogin.Controls.Add(labelLoginPassword);
            panelLogin.Controls.Add(textBoxLoginUsername);
            panelLogin.Controls.Add(textBoxLoginPassword);
            panelLogin.Controls.Add(buttonLoginEnter);
            panelLogin.Controls.Add(buttonLoginToSignup);
            panelLogin.Location = new Point(0, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(1022, 573);
            panelLogin.TabIndex = 1;
            // 
            // pictureBoxLoginTogglePassword
            // 
            pictureBoxLoginTogglePassword.BackColor = Color.Transparent;
            pictureBoxLoginTogglePassword.Location = new Point(652, 210);
            pictureBoxLoginTogglePassword.Name = "pictureBoxLoginTogglePassword";
            pictureBoxLoginTogglePassword.Size = new Size(97, 32);
            pictureBoxLoginTogglePassword.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLoginTogglePassword.TabIndex = 7;
            pictureBoxLoginTogglePassword.TabStop = false;
            pictureBoxLoginTogglePassword.Click += pictureBoxLoginTogglePassword_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(102, 0, 204);
            label1.Location = new Point(360, 30);
            label1.Name = "label1";
            label1.Size = new Size(464, 54);
            label1.TabIndex = 0;
            label1.Text = "Welcome to TestMania!";
            // 
            // labelLoginUsername
            // 
            labelLoginUsername.AutoSize = true;
            labelLoginUsername.BackColor = Color.Transparent;
            labelLoginUsername.Font = new Font("Segoe UI", 12F);
            labelLoginUsername.ForeColor = Color.FromArgb(54, 0, 102);
            labelLoginUsername.Location = new Point(290, 150);
            labelLoginUsername.Name = "labelLoginUsername";
            labelLoginUsername.Size = new Size(126, 32);
            labelLoginUsername.TabIndex = 1;
            labelLoginUsername.Text = "Username:";
            // 
            // labelLoginPassword
            // 
            labelLoginPassword.AutoSize = true;
            labelLoginPassword.BackColor = Color.Transparent;
            labelLoginPassword.Font = new Font("Segoe UI", 12F);
            labelLoginPassword.ForeColor = Color.FromArgb(54, 0, 102);
            labelLoginPassword.Location = new Point(290, 213);
            labelLoginPassword.Name = "labelLoginPassword";
            labelLoginPassword.Size = new Size(116, 32);
            labelLoginPassword.TabIndex = 2;
            labelLoginPassword.Text = "Password:";
            // 
            // textBoxLoginUsername
            // 
            textBoxLoginUsername.Font = new Font("Segoe UI", 12F);
            textBoxLoginUsername.Location = new Point(430, 150);
            textBoxLoginUsername.Name = "textBoxLoginUsername";
            textBoxLoginUsername.Size = new Size(200, 39);
            textBoxLoginUsername.TabIndex = 3;
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Font = new Font("Segoe UI", 12F);
            textBoxLoginPassword.Location = new Point(430, 210);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PasswordChar = '*';
            textBoxLoginPassword.Size = new Size(200, 39);
            textBoxLoginPassword.TabIndex = 4;
            // 
            // buttonLoginEnter
            // 
            buttonLoginEnter.BackColor = Color.FromArgb(102, 0, 204);
            buttonLoginEnter.FlatStyle = FlatStyle.Flat;
            buttonLoginEnter.Font = new Font("Segoe UI", 12F);
            buttonLoginEnter.ForeColor = Color.White;
            buttonLoginEnter.Location = new Point(430, 295);
            buttonLoginEnter.Name = "buttonLoginEnter";
            buttonLoginEnter.Size = new Size(200, 40);
            buttonLoginEnter.TabIndex = 5;
            buttonLoginEnter.Text = "Login";
            buttonLoginEnter.UseVisualStyleBackColor = false;
            buttonLoginEnter.Click += buttonLoginEnter_Click;
            // 
            // buttonLoginToSignup
            // 
            buttonLoginToSignup.BackColor = Color.White;
            buttonLoginToSignup.FlatStyle = FlatStyle.Flat;
            buttonLoginToSignup.Font = new Font("Segoe UI", 10F);
            buttonLoginToSignup.ForeColor = Color.FromArgb(102, 0, 204);
            buttonLoginToSignup.Location = new Point(380, 367);
            buttonLoginToSignup.Name = "buttonLoginToSignup";
            buttonLoginToSignup.Size = new Size(300, 35);
            buttonLoginToSignup.TabIndex = 6;
            buttonLoginToSignup.Text = "Don't have an account? Sign Up";
            buttonLoginToSignup.UseVisualStyleBackColor = false;
            buttonLoginToSignup.Click += buttonLoginToSignup_Click;
            // 
            // panelSignup
            // 
            panelSignup.BackColor = Color.FromArgb(245, 245, 255);
            panelSignup.BackgroundImage = (Image)resources.GetObject("panelSignup.BackgroundImage");
            panelSignup.Controls.Add(pictureBoxSignupTogglePassword);
            panelSignup.Controls.Add(labelTitleSignup);
            panelSignup.Controls.Add(labelSignupUsername);
            panelSignup.Controls.Add(textBoxSignupUsername);
            panelSignup.Controls.Add(labelSignupPassword);
            panelSignup.Controls.Add(textBoxSignupPassword);
            panelSignup.Controls.Add(labelID);
            panelSignup.Controls.Add(textBoxSignupID);
            panelSignup.Controls.Add(labelMail);
            panelSignup.Controls.Add(textBoxSignupMail);
            panelSignup.Controls.Add(rbStudent);
            panelSignup.Controls.Add(rbProf);
            panelSignup.Controls.Add(buttonSignupEnter);
            panelSignup.Controls.Add(buttonSignupToLogin);
            panelSignup.Controls.Add(labelPasswordInfo);
            panelSignup.Location = new Point(0, 0);
            panelSignup.Name = "panelSignup";
            panelSignup.Size = new Size(1022, 573);
            panelSignup.TabIndex = 0;
            // 
            // pictureBoxSignupTogglePassword
            // 
            pictureBoxSignupTogglePassword.BackColor = Color.Transparent;
            pictureBoxSignupTogglePassword.Location = new Point(652, 156); // or adjust as needed
            pictureBoxSignupTogglePassword.Name = "pictureBoxSignupTogglePassword";
            pictureBoxSignupTogglePassword.Size = new Size(97, 32); // Match login size
            pictureBoxSignupTogglePassword.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSignupTogglePassword.TabIndex = 14;
            pictureBoxSignupTogglePassword.TabStop = false;
            pictureBoxSignupTogglePassword.Click += pictureBoxSignupTogglePassword_Click;

            // 
            // labelTitleSignup
            // 
            labelTitleSignup.AutoSize = true;
            labelTitleSignup.BackColor = Color.Transparent;
            labelTitleSignup.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitleSignup.ForeColor = Color.FromArgb(102, 0, 204);
            labelTitleSignup.Location = new Point(360, 30);
            labelTitleSignup.Name = "labelTitleSignup";
            labelTitleSignup.Size = new Size(464, 54);
            labelTitleSignup.TabIndex = 0;
            labelTitleSignup.Text = "Welcome to TestMania!";
            // 
            // labelSignupUsername
            // 
            labelSignupUsername.AutoSize = true;
            labelSignupUsername.BackColor = Color.Transparent;
            labelSignupUsername.Font = new Font("Segoe UI", 12F);
            labelSignupUsername.ForeColor = Color.FromArgb(54, 0, 102);
            labelSignupUsername.Location = new Point(290, 100);
            labelSignupUsername.Name = "labelSignupUsername";
            labelSignupUsername.Size = new Size(126, 32);
            labelSignupUsername.TabIndex = 1;
            labelSignupUsername.Text = "Username:";
            // 
            // textBoxSignupUsername
            // 
            textBoxSignupUsername.Font = new Font("Segoe UI", 12F);
            textBoxSignupUsername.Location = new Point(430, 100);
            textBoxSignupUsername.Name = "textBoxSignupUsername";
            textBoxSignupUsername.Size = new Size(200, 39);
            textBoxSignupUsername.TabIndex = 2;
            // 
            // labelSignupPassword
            // 
            labelSignupPassword.AutoSize = true;
            labelSignupPassword.BackColor = Color.Transparent;
            labelSignupPassword.Font = new Font("Segoe UI", 12F);
            labelSignupPassword.ForeColor = Color.FromArgb(54, 0, 102);
            labelSignupPassword.Location = new Point(290, 150);
            labelSignupPassword.Name = "labelSignupPassword";
            labelSignupPassword.Size = new Size(116, 32);
            labelSignupPassword.TabIndex = 3;
            labelSignupPassword.Text = "Password:";
            // 
            // textBoxSignupPassword
            // 
            textBoxSignupPassword.Font = new Font("Segoe UI", 12F);
            textBoxSignupPassword.Location = new Point(430, 150);
            textBoxSignupPassword.Name = "textBoxSignupPassword";
            textBoxSignupPassword.PasswordChar = '*';
            textBoxSignupPassword.Size = new Size(200, 39);
            textBoxSignupPassword.TabIndex = 4;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.BackColor = Color.Transparent;
            labelID.Font = new Font("Segoe UI", 12F);
            labelID.ForeColor = Color.FromArgb(54, 0, 102);
            labelID.Location = new Point(290, 200);
            labelID.Name = "labelID";
            labelID.Size = new Size(42, 32);
            labelID.TabIndex = 5;
            labelID.Text = "ID:";
            // 
            // textBoxSignupID
            // 
            textBoxSignupID.Font = new Font("Segoe UI", 12F);
            textBoxSignupID.Location = new Point(430, 200);
            textBoxSignupID.Name = "textBoxSignupID";
            textBoxSignupID.Size = new Size(200, 39);
            textBoxSignupID.TabIndex = 6;
            // 
            // labelMail
            // 
            labelMail.AutoSize = true;
            labelMail.BackColor = Color.Transparent;
            labelMail.Font = new Font("Segoe UI", 12F);
            labelMail.ForeColor = Color.FromArgb(54, 0, 102);
            labelMail.Location = new Point(290, 250);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(76, 32);
            labelMail.TabIndex = 7;
            labelMail.Text = "Email:";
            // 
            // textBoxSignupMail
            // 
            textBoxSignupMail.Font = new Font("Segoe UI", 12F);
            textBoxSignupMail.Location = new Point(430, 250);
            textBoxSignupMail.Name = "textBoxSignupMail";
            textBoxSignupMail.Size = new Size(200, 39);
            textBoxSignupMail.TabIndex = 8;
            // 
            // rbStudent
            // 
            rbStudent.AutoSize = true;
            rbStudent.BackColor = Color.Transparent;
            rbStudent.Checked = true;
            rbStudent.Font = new Font("Segoe UI", 12F);
            rbStudent.ForeColor = Color.FromArgb(54, 0, 102);
            rbStudent.Location = new Point(411, 303);
            rbStudent.Name = "rbStudent";
            rbStudent.Size = new Size(122, 36);
            rbStudent.TabIndex = 9;
            rbStudent.TabStop = true;
            rbStudent.Text = "Student";
            rbStudent.UseVisualStyleBackColor = false;
            // 
            // rbProf
            // 
            rbProf.AutoSize = true;
            rbProf.BackColor = Color.Transparent;
            rbProf.Font = new Font("Segoe UI", 12F);
            rbProf.ForeColor = Color.FromArgb(54, 0, 102);
            rbProf.Location = new Point(526, 303);
            rbProf.Name = "rbProf";
            rbProf.Size = new Size(137, 36);
            rbProf.TabIndex = 10;
            rbProf.Text = "Professor";
            rbProf.UseVisualStyleBackColor = false;
            // 
            // buttonSignupEnter
            // 
            buttonSignupEnter.BackColor = Color.FromArgb(102, 0, 204);
            buttonSignupEnter.FlatStyle = FlatStyle.Flat;
            buttonSignupEnter.Font = new Font("Segoe UI", 12F);
            buttonSignupEnter.ForeColor = Color.White;
            buttonSignupEnter.Location = new Point(430, 382);
            buttonSignupEnter.Name = "buttonSignupEnter";
            buttonSignupEnter.Size = new Size(200, 40);
            buttonSignupEnter.TabIndex = 11;
            buttonSignupEnter.Text = "Sign Up";
            buttonSignupEnter.UseVisualStyleBackColor = false;
            buttonSignupEnter.Click += buttonSignupEnter_Click;
            // 
            // buttonSignupToLogin
            // 
            buttonSignupToLogin.BackColor = Color.White;
            buttonSignupToLogin.FlatStyle = FlatStyle.Flat;
            buttonSignupToLogin.Font = new Font("Segoe UI", 10F);
            buttonSignupToLogin.ForeColor = Color.FromArgb(102, 0, 204);
            buttonSignupToLogin.Location = new Point(380, 450);
            buttonSignupToLogin.Name = "buttonSignupToLogin";
            buttonSignupToLogin.Size = new Size(300, 35);
            buttonSignupToLogin.TabIndex = 12;
            buttonSignupToLogin.Text = "Already have an account? Login";
            buttonSignupToLogin.UseVisualStyleBackColor = false;
            buttonSignupToLogin.Click += buttonSignupToLogin_Click;
            // 
            // labelPasswordInfo
            // 
            labelPasswordInfo.BackColor = Color.Transparent;
            labelPasswordInfo.BackgroundImageLayout = ImageLayout.Stretch;
            labelPasswordInfo.Font = new Font("Segoe UI", 10F);
            labelPasswordInfo.ForeColor = Color.FromArgb(54, 0, 102);
            labelPasswordInfo.ImageAlign = ContentAlignment.TopLeft;
            labelPasswordInfo.Location = new Point(686, 100);
            labelPasswordInfo.Name = "labelPasswordInfo";
            labelPasswordInfo.Padding = new Padding(10, 50, 20, 10);
            labelPasswordInfo.Size = new Size(290, 276);
            labelPasswordInfo.TabIndex = 13;
            labelPasswordInfo.Text = resources.GetString("labelPasswordInfo.Text");
            // 
            // Login_Signup
            // 
            BackColor = Color.FromArgb(245, 245, 255);
            ClientSize = new Size(1022, 573);
            Controls.Add(panelSignup);
            Controls.Add(panelLogin);
            Font = new Font("Segoe UI", 12F);
            Name = "Login_Signup";
            Text = "Login";
            Load += Login_Signup_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoginTogglePassword).EndInit();
            panelSignup.ResumeLayout(false);
            panelSignup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSignupTogglePassword).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLogin;
        private Panel panelSignup;
        private Label labelLoginUsername;
        private Label labelLoginPassword;
        private TextBox textBoxLoginUsername;
        private TextBox textBoxLoginPassword;
        private Button buttonLoginEnter;
        private Button buttonLoginToSignup;
        private Label labelSignupUsername;
        private Label labelSignupPassword;
        public TextBox textBoxSignupUsername;
        public TextBox textBoxSignupPassword;
        public TextBox textBoxSignupID;
        public TextBox textBoxSignupMail;
        private Label labelID;
        private Label labelMail;
        private RadioButton rbStudent;
        private RadioButton rbProf;
        private Button buttonSignupEnter;
        private Button buttonSignupToLogin;
        private Label label1;
        private Label labelTitleSignup;
        private Label labelPasswordInfo;
        private PictureBox pictureBoxLoginTogglePassword;
        private PictureBox pictureBoxSignupTogglePassword;
    }
}