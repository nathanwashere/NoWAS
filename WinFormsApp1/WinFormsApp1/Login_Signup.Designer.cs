namespace WinFormsApp1
{
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
            labelLoginTitleApp = new Label();
            labelLoginUsername = new Label();
            textBoxLoginUsername = new TextBox();
            labelLoginPassword = new Label();
            textBoxLoginPassword = new TextBox();
            panelLogin = new Panel();
            buttonLoginEnter = new Button();
            buttonLoginToSignup = new Button();
            panelSignup = new Panel();
            rbStudent = new RadioButton();
            rbProf = new RadioButton();
            labelSignupTitleApp = new Label();
            labelSignupUsername = new Label();
            textBoxSignupUsername = new TextBox();
            labelSignupPassword = new Label();
            textBoxSignupPassword = new TextBox();
            buttonSignupEnter = new Button();
            buttonSignupToLogin = new Button();
            panelLogin.SuspendLayout();
            panelSignup.SuspendLayout();
            SuspendLayout();
            // 
            // labelLoginTitleApp
            // 
            labelLoginTitleApp.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            labelLoginTitleApp.Location = new Point(468, 32);
            labelLoginTitleApp.Margin = new Padding(4, 0, 4, 0);
            labelLoginTitleApp.Name = "labelLoginTitleApp";
            labelLoginTitleApp.Size = new Size(341, 76);
            labelLoginTitleApp.TabIndex = 0;
            labelLoginTitleApp.Text = "שם של האתר";
            // 
            // labelLoginUsername
            // 
            labelLoginUsername.AutoSize = true;
            labelLoginUsername.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            labelLoginUsername.Location = new Point(921, 162);
            labelLoginUsername.Margin = new Padding(4, 0, 4, 0);
            labelLoginUsername.Name = "labelLoginUsername";
            labelLoginUsername.Size = new Size(181, 41);
            labelLoginUsername.TabIndex = 1;
            labelLoginUsername.Text = "שם משתמש";
            // 
            // textBoxLoginUsername
            // 
            textBoxLoginUsername.Location = new Point(516, 219);
            textBoxLoginUsername.Margin = new Padding(4);
            textBoxLoginUsername.Name = "textBoxLoginUsername";
            textBoxLoginUsername.Size = new Size(586, 31);
            textBoxLoginUsername.TabIndex = 2;
            // 
            // labelLoginPassword
            // 
            labelLoginPassword.AutoSize = true;
            labelLoginPassword.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            labelLoginPassword.Location = new Point(1005, 262);
            labelLoginPassword.Margin = new Padding(4, 0, 4, 0);
            labelLoginPassword.Name = "labelLoginPassword";
            labelLoginPassword.Size = new Size(106, 41);
            labelLoginPassword.TabIndex = 3;
            labelLoginPassword.Text = "סיסמה";
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Location = new Point(516, 308);
            textBoxLoginPassword.Margin = new Padding(4);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.Size = new Size(586, 31);
            textBoxLoginPassword.TabIndex = 4;
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(buttonLoginEnter);
            panelLogin.Controls.Add(buttonLoginToSignup);
            panelLogin.Controls.Add(labelLoginTitleApp);
            panelLogin.Controls.Add(labelLoginUsername);
            panelLogin.Controls.Add(textBoxLoginUsername);
            panelLogin.Controls.Add(labelLoginPassword);
            panelLogin.Controls.Add(textBoxLoginPassword);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(0, 0);
            panelLogin.Margin = new Padding(4);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(1226, 744);
            panelLogin.TabIndex = 2;
            // 
            // buttonLoginEnter
            // 
            buttonLoginEnter.BackColor = Color.FromArgb(235, 63, 33);
            buttonLoginEnter.Font = new Font("Segoe UI", 15F);
            buttonLoginEnter.Location = new Point(516, 376);
            buttonLoginEnter.Margin = new Padding(4);
            buttonLoginEnter.Name = "buttonLoginEnter";
            buttonLoginEnter.Size = new Size(582, 48);
            buttonLoginEnter.TabIndex = 7;
            buttonLoginEnter.Text = "כניסה";
            buttonLoginEnter.UseVisualStyleBackColor = false;
            buttonLoginEnter.Click += buttonLoginEnter_Click;
            // 
            // buttonLoginToSignup
            // 
            buttonLoginToSignup.Font = new Font("Segoe UI", 15F);
            buttonLoginToSignup.Location = new Point(412, 616);
            buttonLoginToSignup.Margin = new Padding(4);
            buttonLoginToSignup.Name = "buttonLoginToSignup";
            buttonLoginToSignup.Size = new Size(395, 44);
            buttonLoginToSignup.TabIndex = 6;
            buttonLoginToSignup.Text = "הרשמה";
            buttonLoginToSignup.UseVisualStyleBackColor = true;
            buttonLoginToSignup.Click += buttonLoginToSignup_Click;
            // 
            // panelSignup
            // 
            panelSignup.Controls.Add(rbStudent);
            panelSignup.Controls.Add(rbProf);
            panelSignup.Controls.Add(labelSignupTitleApp);
            panelSignup.Controls.Add(labelSignupUsername);
            panelSignup.Controls.Add(textBoxSignupUsername);
            panelSignup.Controls.Add(labelSignupPassword);
            panelSignup.Controls.Add(textBoxSignupPassword);
            panelSignup.Controls.Add(buttonSignupEnter);
            panelSignup.Controls.Add(buttonSignupToLogin);
            panelSignup.Dock = DockStyle.Fill;
            panelSignup.Location = new Point(0, 0);
            panelSignup.Margin = new Padding(4);
            panelSignup.Name = "panelSignup";
            panelSignup.Size = new Size(1226, 744);
            panelSignup.TabIndex = 3;
            panelSignup.Paint += panelSignup_Paint;
            // 
            // rbStudent
            // 
            rbStudent.AutoSize = true;
            rbStudent.Location = new Point(516, 436);
            rbStudent.Margin = new Padding(4);
            rbStudent.Name = "rbStudent";
            rbStudent.Size = new Size(98, 29);
            rbStudent.TabIndex = 0;
            rbStudent.TabStop = true;
            rbStudent.Text = "Student";
            rbStudent.UseVisualStyleBackColor = true;
            // 
            // rbProf
            // 
            rbProf.AutoSize = true;
            rbProf.Location = new Point(516, 474);
            rbProf.Margin = new Padding(4);
            rbProf.Name = "rbProf";
            rbProf.Size = new Size(112, 29);
            rbProf.TabIndex = 1;
            rbProf.TabStop = true;
            rbProf.Text = "Professor";
            rbProf.UseVisualStyleBackColor = true;
            // 
            // labelSignupTitleApp
            // 
            labelSignupTitleApp.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            labelSignupTitleApp.Location = new Point(468, 32);
            labelSignupTitleApp.Margin = new Padding(4, 0, 4, 0);
            labelSignupTitleApp.Name = "labelSignupTitleApp";
            labelSignupTitleApp.Size = new Size(341, 76);
            labelSignupTitleApp.TabIndex = 4;
            labelSignupTitleApp.Text = "שם של האתר";
            // 
            // labelSignupUsername
            // 
            labelSignupUsername.AutoSize = true;
            labelSignupUsername.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            labelSignupUsername.Location = new Point(921, 162);
            labelSignupUsername.Margin = new Padding(4, 0, 4, 0);
            labelSignupUsername.Name = "labelSignupUsername";
            labelSignupUsername.Size = new Size(181, 41);
            labelSignupUsername.TabIndex = 2;
            labelSignupUsername.Text = "שם משתמש";
            // 
            // textBoxSignupUsername
            // 
            textBoxSignupUsername.Location = new Point(516, 219);
            textBoxSignupUsername.Margin = new Padding(4);
            textBoxSignupUsername.Name = "textBoxSignupUsername";
            textBoxSignupUsername.Size = new Size(586, 31);
            textBoxSignupUsername.TabIndex = 3;
            // 
            // labelSignupPassword
            // 
            labelSignupPassword.AutoSize = true;
            labelSignupPassword.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            labelSignupPassword.Location = new Point(1005, 262);
            labelSignupPassword.Margin = new Padding(4, 0, 4, 0);
            labelSignupPassword.Name = "labelSignupPassword";
            labelSignupPassword.Size = new Size(106, 41);
            labelSignupPassword.TabIndex = 5;
            labelSignupPassword.Text = "סיסמה";
            // 
            // textBoxSignupPassword
            // 
            textBoxSignupPassword.Location = new Point(516, 308);
            textBoxSignupPassword.Margin = new Padding(4);
            textBoxSignupPassword.Name = "textBoxSignupPassword";
            textBoxSignupPassword.Size = new Size(586, 31);
            textBoxSignupPassword.TabIndex = 6;
            // 
            // buttonSignupEnter
            // 
            buttonSignupEnter.BackColor = Color.FromArgb(235, 63, 33);
            buttonSignupEnter.Font = new Font("Segoe UI", 15F);
            buttonSignupEnter.Location = new Point(516, 376);
            buttonSignupEnter.Margin = new Padding(4);
            buttonSignupEnter.Name = "buttonSignupEnter";
            buttonSignupEnter.Size = new Size(582, 49);
            buttonSignupEnter.TabIndex = 9;
            buttonSignupEnter.Text = "הרשמה";
            buttonSignupEnter.UseVisualStyleBackColor = false;
            buttonSignupEnter.Click += buttonSignupEnter_Click;
            // 
            // buttonSignupToLogin
            // 
            buttonSignupToLogin.Font = new Font("Segoe UI", 15F);
            buttonSignupToLogin.Location = new Point(412, 616);
            buttonSignupToLogin.Margin = new Padding(4);
            buttonSignupToLogin.Name = "buttonSignupToLogin";
            buttonSignupToLogin.Size = new Size(395, 44);
            buttonSignupToLogin.TabIndex = 8;
            buttonSignupToLogin.Text = "כניסה";
            buttonSignupToLogin.UseVisualStyleBackColor = true;
            buttonSignupToLogin.Click += buttonSignupToLogin_Click;
            // 
            // Login_Signup
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 744);
            Controls.Add(panelSignup);
            Controls.Add(panelLogin);
            Margin = new Padding(4);
            Name = "Login_Signup";
            Text = "Login";
            Load += Login_Signup_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelSignup.ResumeLayout(false);
            panelSignup.PerformLayout();
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
        private Label labelSignupTitleApp;
        private Label labelSignupPassword;
        private TextBox textBoxSignupPassword;
        private Button buttonSignupToLogin;
        private Button buttonLoginToSignup;
        private Button buttonSignupEnter;
        private Button buttonLoginEnter;
        private RadioButton rbProf;
        private RadioButton rbStudent;
    }
}
