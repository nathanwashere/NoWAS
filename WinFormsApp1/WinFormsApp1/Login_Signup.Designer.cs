namespace WinFormsApp1
{
    using System.Drawing.Drawing2D;
    partial class Login_Signup
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
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            labelLoginTitleApp = new Label();
            labelLoginUsername = new Label();
            textBoxLoginUsername = new TextBox();
            labelLoginPassword = new Label();
            textBoxLoginPassword = new TextBox();
            panelLoginUsername = new Panel();
            panelLoginPassword = new Panel();
            panelLogin = new Panel();
            buttonLoginEnter = new Button();
            buttonLoginToSignup = new Button();
            panelSignup = new Panel();
            labelSignupUsername = new Label();
            panelSignupUsername = new Panel();
            textBoxSignupUsername = new TextBox();
            labelSignupPassword = new Label();
            panelSignupPassword = new Panel();
            textBoxSignupPassword = new TextBox();
            rbStudent = new RadioButton();
            rbProf = new RadioButton();
            buttonSignupEnter = new Button();
            buttonSignupToLogin = new Button();
            panelLoginUsername.SuspendLayout();
            panelLoginPassword.SuspendLayout();
            panelLogin.SuspendLayout();
            panelSignup.SuspendLayout();
            panelSignupUsername.SuspendLayout();
            panelSignupPassword.SuspendLayout();
            SuspendLayout();
            // 
            // labelLoginTitleApp
            // 
            labelLoginTitleApp.Location = new Point(0, 0);
            labelLoginTitleApp.Name = "labelLoginTitleApp";
            labelLoginTitleApp.Size = new Size(100, 23);
            labelLoginTitleApp.TabIndex = 0;
            // 
            // labelLoginUsername
            // 
            labelLoginUsername.AutoSize = true;
            labelLoginUsername.BackColor = Color.Transparent;
            labelLoginUsername.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelLoginUsername.ForeColor = Color.SlateBlue;

            labelLoginUsername.Location = new Point(296, 253);
            labelLoginUsername.Name = "labelLoginUsername";
            labelLoginUsername.Size = new Size(128, 32);
            labelLoginUsername.TabIndex = 1;
            labelLoginUsername.Text = "Username";
            // 
            // textBoxLoginUsername
            // 
            textBoxLoginUsername.BorderStyle = BorderStyle.None;
            textBoxLoginUsername.Dock = DockStyle.Fill;
            textBoxLoginUsername.Font = new Font("Segoe UI", 12F);
            textBoxLoginUsername.Location = new Point(5, 5);
            textBoxLoginUsername.Name = "textBoxLoginUsername";
            textBoxLoginUsername.Size = new Size(209, 27);
            textBoxLoginUsername.TabIndex = 0;
            // 
            // labelLoginPassword
            // 
            labelLoginPassword.AutoSize = true;
            labelLoginPassword.BackColor = Color.Transparent;
            labelLoginPassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelLoginPassword.ForeColor = Color.SlateBlue;
            labelLoginPassword.Location = new Point(296, 315);
            labelLoginPassword.Name = "labelLoginPassword";
            labelLoginPassword.Size = new Size(122, 32);
            labelLoginPassword.TabIndex = 3;
            labelLoginPassword.Text = "Password";
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.BorderStyle = BorderStyle.None;
            textBoxLoginPassword.Dock = DockStyle.Fill;
            textBoxLoginPassword.Font = new Font("Segoe UI", 12F);
            textBoxLoginPassword.Location = new Point(5, 5);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.PasswordChar = '*';
            textBoxLoginPassword.Size = new Size(209, 27);
            textBoxLoginPassword.TabIndex = 0;
            // 
            // panelLoginUsername
            // 
            panelLoginUsername.BackColor = Color.White;
            panelLoginUsername.BorderStyle = BorderStyle.FixedSingle;
            panelLoginUsername.Controls.Add(textBoxLoginUsername);
            panelLoginUsername.Location = new Point(439, 257);
            panelLoginUsername.Name = "panelLoginUsername";
            panelLoginUsername.Padding = new Padding(5);
            panelLoginUsername.Size = new Size(221, 40);
            panelLoginUsername.TabIndex = 2;
            // 
            // panelLoginPassword
            // 
            panelLoginPassword.BackColor = Color.White;
            panelLoginPassword.BorderStyle = BorderStyle.FixedSingle;
            panelLoginPassword.Controls.Add(textBoxLoginPassword);
            panelLoginPassword.Location = new Point(439, 315);
            panelLoginPassword.Name = "panelLoginPassword";
            panelLoginPassword.Padding = new Padding(5);
            panelLoginPassword.Size = new Size(221, 40);
            panelLoginPassword.TabIndex = 4;
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.FromArgb(230, 240, 255);
            panelLogin.BackgroundImage = Properties.Resources.background1;
            panelLogin.BackgroundImageLayout = ImageLayout.Center;
            panelLogin.Controls.Add(labelLoginTitleApp);
            panelLogin.Controls.Add(labelLoginUsername);
            panelLogin.Controls.Add(panelLoginUsername);
            panelLogin.Controls.Add(labelLoginPassword);
            panelLogin.Controls.Add(panelLoginPassword);
            panelLogin.Controls.Add(buttonLoginEnter);
            panelLogin.Controls.Add(buttonLoginToSignup);
            panelLogin.Location = new Point(0, 0); // important
            panelLogin.Size = new Size(1022, 554); // important
            panelLogin.Dock = DockStyle.None;      // important
            panelLogin.Name = "panelLogin";
            panelLogin.TabIndex = 1;
            // 
            // buttonLoginEnter
            // 
            buttonLoginEnter.BackColor = Color.FromArgb(0, 122, 204);
            buttonLoginEnter.FlatStyle = FlatStyle.Flat;
            buttonLoginEnter.Font = new Font("Segoe UI", 14F);
            buttonLoginEnter.ForeColor = Color.White;
            buttonLoginEnter.Location = new Point(369, 414);
            buttonLoginEnter.Name = "buttonLoginEnter";
            buttonLoginEnter.Size = new Size(231, 52);
            buttonLoginEnter.TabIndex = 5;
            buttonLoginEnter.Text = "Login";
            buttonLoginEnter.UseVisualStyleBackColor = false;
            buttonLoginEnter.Click += buttonLoginEnter_Click;
            // 
            // buttonLoginToSignup
            // 
            buttonLoginToSignup.BackColor = Color.White;
            buttonLoginToSignup.FlatStyle = FlatStyle.Flat;
            buttonLoginToSignup.Font = new Font("Segoe UI", 12F);
            buttonLoginToSignup.ForeColor = Color.FromArgb(0, 122, 204);
            buttonLoginToSignup.Location = new Point(263, 483);
            buttonLoginToSignup.Name = "buttonLoginToSignup";
            buttonLoginToSignup.Size = new Size(444, 46);
            buttonLoginToSignup.TabIndex = 6;
            buttonLoginToSignup.Text = "Don't have an account? Sign Up";
            buttonLoginToSignup.UseVisualStyleBackColor = false;
            buttonLoginToSignup.Click += buttonLoginToSignup_Click;
            // 
            // panelSignup
            // 
            panelSignup.BackgroundImage = Properties.Resources.background1;
            panelSignup.BackgroundImageLayout = ImageLayout.Center;
            panelSignup.Controls.Add(labelSignupUsername);
            panelSignup.Controls.Add(panelSignupUsername);
            panelSignup.Controls.Add(panelSignupUsername);
            panelSignup.Controls.Add(panelSignupPassword);

            panelSignup.Controls.Add(labelSignupPassword);
            panelSignup.Controls.Add(panelSignupPassword);
            panelSignup.Controls.Add(rbStudent);
            panelSignup.Controls.Add(rbProf);
            panelSignup.Controls.Add(buttonSignupEnter);
            panelSignup.Controls.Add(buttonSignupToLogin);
            panelSignup.Location = new Point(1022, 0); // important
            panelSignup.Size = new Size(1022, 554);   // important
            panelSignup.Dock = DockStyle.None;       // important
            panelSignup.Name = "panelSignup";
            panelSignup.TabIndex = 0;
            // 
            // labelSignupUsername
            // 
            labelSignupUsername.AutoSize = true;
            labelSignupUsername.BackColor = Color.Transparent;
            labelSignupUsername.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelSignupUsername.ForeColor = Color.SlateBlue;
            labelSignupUsername.Location = new Point(296, 253);
            labelSignupUsername.Name = "labelSignupUsername";
            labelSignupUsername.Size = new Size(135, 32);
            labelSignupUsername.TabIndex = 0;
            labelSignupUsername.Text = "Username:";
            // 
            // panelSignupUsername
            // 
            panelSignupUsername.BackColor = Color.White;
            panelSignupUsername.BorderStyle = BorderStyle.FixedSingle;
            panelSignupUsername.Controls.Add(textBoxSignupUsername);
            panelSignupUsername.Location = new Point(439, 257);
            panelSignupUsername.Name = "panelSignupUsername";
            panelSignupUsername.Padding = new Padding(5);
            panelSignupUsername.Size = new Size(221, 40);
            panelSignupUsername.TabIndex = 1;
            // 
            // textBoxSignupUsername
            // 
            textBoxSignupUsername.BorderStyle = BorderStyle.None;
            textBoxSignupUsername.Dock = DockStyle.Fill;
            textBoxSignupUsername.Font = new Font("Segoe UI", 12F);
            textBoxSignupUsername.Location = new Point(5, 5);
            textBoxSignupUsername.Name = "textBoxSignupUsername";
            textBoxSignupUsername.Size = new Size(209, 27);
            textBoxSignupUsername.TabIndex = 0;
            // 
            // labelSignupPassword
            // 
            labelSignupPassword.AutoSize = true;
            labelSignupPassword.BackColor = Color.Transparent;
            labelSignupPassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelSignupPassword.ForeColor = Color.SlateBlue;
            labelSignupPassword.Location = new Point(296, 315);
            labelSignupPassword.Name = "labelSignupPassword";
            labelSignupPassword.Size = new Size(129, 32);
            labelSignupPassword.TabIndex = 2;
            labelSignupPassword.Text = "Password:";
            // 
            // panelSignupPassword
            // 
            panelSignupPassword.BackColor = Color.White;
            panelSignupPassword.BorderStyle = BorderStyle.FixedSingle;
            panelSignupPassword.Controls.Add(textBoxSignupPassword);
            panelSignupPassword.Location = new Point(439, 315);
            panelSignupPassword.Name = "panelSignupPassword";
            panelSignupPassword.Padding = new Padding(5);
            panelSignupPassword.Size = new Size(221, 40);
            panelSignupPassword.TabIndex = 3;
            // 
            // textBoxSignupPassword
            // 
            textBoxSignupPassword.BorderStyle = BorderStyle.None;
            textBoxSignupPassword.Dock = DockStyle.Fill;
            textBoxSignupPassword.Font = new Font("Segoe UI", 12F);
            textBoxSignupPassword.Location = new Point(5, 5);
            textBoxSignupPassword.Name = "textBoxSignupPassword";
            textBoxSignupPassword.PasswordChar = '*';
            textBoxSignupPassword.Size = new Size(209, 27);
            textBoxSignupPassword.TabIndex = 0;
            // 
            // rbStudent
            // 
            rbStudent.AutoSize = true;
            rbStudent.BackColor = Color.Transparent;
            rbStudent.ForeColor = Color.DarkSlateBlue;
            rbStudent.Location = new Point(439, 372);
            rbStudent.Name = "rbStudent";
            rbStudent.Size = new Size(90, 27);
            rbStudent.TabIndex = 4;
            rbStudent.Text = "Student";
            rbStudent.UseVisualStyleBackColor = false;
            // 
            // rbProf
            // 
            rbProf.AutoSize = true;
            rbProf.BackColor = Color.Transparent;
            rbProf.ForeColor = Color.DarkSlateBlue;
            rbProf.Location = new Point(559, 372);
            rbProf.Name = "rbProf";
            rbProf.Size = new Size(101, 27);
            rbProf.TabIndex = 5;
            rbProf.Text = "Professor";
            rbProf.UseVisualStyleBackColor = false;
            // 
            // buttonSignupEnter
            // 
            buttonSignupEnter.BackColor = Color.FromArgb(0, 122, 204);
            buttonSignupEnter.FlatStyle = FlatStyle.Flat;
            buttonSignupEnter.Font = new Font("Segoe UI", 14F);
            buttonSignupEnter.ForeColor = Color.White;
            buttonSignupEnter.Location = new Point(369, 414);
            buttonSignupEnter.Name = "buttonSignupEnter";
            buttonSignupEnter.Size = new Size(231, 52);
            buttonSignupEnter.TabIndex = 6;
            buttonSignupEnter.Text = "Sign Up";
            buttonSignupEnter.UseVisualStyleBackColor = false;
            buttonSignupEnter.Click += buttonSignupEnter_Click;
            // 
            // buttonSignupToLogin
            // 
            buttonSignupToLogin.BackColor = Color.White;
            buttonSignupToLogin.FlatStyle = FlatStyle.Flat;
            buttonSignupToLogin.Font = new Font("Segoe UI", 12F);
            buttonSignupToLogin.ForeColor = Color.FromArgb(0, 122, 204);
            buttonSignupToLogin.Location = new Point(263, 483);
            buttonSignupToLogin.Name = "buttonSignupToLogin";
            buttonSignupToLogin.Size = new Size(444, 46); ;
            buttonSignupToLogin.TabIndex = 7;
            buttonSignupToLogin.Text = "Already have an account? Login";
            buttonSignupToLogin.UseVisualStyleBackColor = false;
            buttonSignupToLogin.Click += buttonSignupToLogin_Click;
            // 
            // Login_Signup
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.background1;
            ClientSize = new Size(1022, 554);
            Controls.Add(panelSignup);
            Controls.Add(panelLogin);
            Font = new Font("Segoe UI", 10F);
            Name = "Login_Signup";
            Text = "Login";
            Load += Login_Signup_Load;
            panelLoginUsername.ResumeLayout(false);
            panelLoginUsername.PerformLayout();
            panelLoginPassword.ResumeLayout(false);
            panelLoginPassword.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelSignup.ResumeLayout(false);
            panelSignup.PerformLayout();
            panelSignupUsername.ResumeLayout(false);
            panelSignupUsername.PerformLayout();
            panelSignupPassword.ResumeLayout(false);
            panelSignupPassword.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private Label labelLoginTitleApp;
        private Label labelLoginUsername;
        private TextBox textBoxLoginUsername;
        private Label labelLoginPassword;
        private TextBox textBoxLoginPassword;
        private Panel panelLogin;
        private Panel panelSignup;
        private Label labelSignupUsername;
        private TextBox textBoxSignupUsername;
        private Label labelSignupPassword;
        private TextBox textBoxSignupPassword;
        private Button buttonSignupToLogin;
        private Button buttonLoginToSignup;
        private Button buttonSignupEnter;
        private Button buttonLoginEnter;
        private RadioButton rbProf;
        private RadioButton rbStudent;
        private Panel panelLoginUsername;
        private Panel panelLoginPassword;
        private Panel panelSignupUsername;
        private Panel panelSignupPassword;
    }
}
