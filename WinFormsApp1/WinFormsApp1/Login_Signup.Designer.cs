namespace WinFormsApp1
{
    partial class Login_Signup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
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
            labelLoginTitleApp.Location = new Point(374, 26);
            labelLoginTitleApp.Margin = new Padding(2, 0, 2, 0);
            labelLoginTitleApp.Name = "labelLoginTitleApp";
            labelLoginTitleApp.Size = new Size(273, 61);
            labelLoginTitleApp.TabIndex = 0;
            labelLoginTitleApp.Text = "שם של האתר";
            // 
            // labelLoginUsername
            // 
            labelLoginUsername.AutoSize = true;
            labelLoginUsername.Font = new Font("Segoe UI", 15F, FontStyle.Underline, GraphicsUnit.Point, 0);
            labelLoginUsername.Location = new Point(737, 130);
            labelLoginUsername.Margin = new Padding(2, 0, 2, 0);
            labelLoginUsername.Name = "labelLoginUsername";
            labelLoginUsername.Size = new Size(151, 35);
            labelLoginUsername.TabIndex = 1;
            labelLoginUsername.Text = "שם משתמש";
            // 
            // textBoxLoginUsername
            // 
            textBoxLoginUsername.Location = new Point(413, 175);
            textBoxLoginUsername.Margin = new Padding(2, 2, 2, 2);
            textBoxLoginUsername.Name = "textBoxLoginUsername";
            textBoxLoginUsername.Size = new Size(470, 27);
            textBoxLoginUsername.TabIndex = 2;
            // 
            // labelLoginPassword
            // 
            labelLoginPassword.AutoSize = true;
            labelLoginPassword.Font = new Font("Segoe UI", 15F, FontStyle.Underline, GraphicsUnit.Point, 0);
            labelLoginPassword.Location = new Point(804, 210);
            labelLoginPassword.Margin = new Padding(2, 0, 2, 0);
            labelLoginPassword.Name = "labelLoginPassword";
            labelLoginPassword.Size = new Size(90, 35);
            labelLoginPassword.TabIndex = 3;
            labelLoginPassword.Text = "סיסמה";
            // 
            // textBoxLoginPassword
            // 
            textBoxLoginPassword.Location = new Point(413, 246);
            textBoxLoginPassword.Margin = new Padding(2, 2, 2, 2);
            textBoxLoginPassword.Name = "textBoxLoginPassword";
            textBoxLoginPassword.Size = new Size(470, 27);
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
            panelLogin.Margin = new Padding(2, 2, 2, 2);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(981, 595);
            panelLogin.TabIndex = 7;
            // 
            // buttonLoginEnter
            // 
            buttonLoginEnter.BackColor = Color.FromArgb(235, 63, 33);
            buttonLoginEnter.Font = new Font("Segoe UI", 15F);
            buttonLoginEnter.Location = new Point(413, 301);
            buttonLoginEnter.Margin = new Padding(2, 2, 2, 2);
            buttonLoginEnter.Name = "buttonLoginEnter";
            buttonLoginEnter.Size = new Size(466, 38);
            buttonLoginEnter.TabIndex = 7;
            buttonLoginEnter.Text = "כניסה";
            buttonLoginEnter.UseVisualStyleBackColor = false;
            buttonLoginEnter.Click += buttonLoginEnter_Click;
            // 
            // buttonLoginToSignup
            // 
            buttonLoginToSignup.Font = new Font("Segoe UI", 15F);
            buttonLoginToSignup.Location = new Point(330, 493);
            buttonLoginToSignup.Margin = new Padding(2, 2, 2, 2);
            buttonLoginToSignup.Name = "buttonLoginToSignup";
            buttonLoginToSignup.Size = new Size(316, 35);
            buttonLoginToSignup.TabIndex = 6;
            buttonLoginToSignup.Text = "הרשמה";
            buttonLoginToSignup.UseVisualStyleBackColor = true;
            buttonLoginToSignup.Click += buttonLoginToSignup_Click;
            // 
            // panelSignup
            // 
            panelSignup.Controls.Add(labelSignupTitleApp);
            panelSignup.Controls.Add(labelSignupUsername);
            panelSignup.Controls.Add(textBoxSignupUsername);
            panelSignup.Controls.Add(labelSignupPassword);
            panelSignup.Controls.Add(textBoxSignupPassword);
            panelSignup.Controls.Add(buttonSignupEnter);
            panelSignup.Controls.Add(buttonSignupToLogin);
            panelSignup.Dock = DockStyle.Fill;
            panelSignup.Location = new Point(0, 0);
            panelSignup.Margin = new Padding(2, 2, 2, 2);
            panelSignup.Name = "panelSignup";
            panelSignup.Size = new Size(981, 595);
            panelSignup.TabIndex = 7;
            // 
            // labelSignupTitleApp
            // 
            labelSignupTitleApp.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            labelSignupTitleApp.Location = new Point(374, 26);
            labelSignupTitleApp.Margin = new Padding(2, 0, 2, 0);
            labelSignupTitleApp.Name = "labelSignupTitleApp";
            labelSignupTitleApp.Size = new Size(273, 61);
            labelSignupTitleApp.TabIndex = 4;
            labelSignupTitleApp.Text = "שם של האתר";
            // 
            // labelSignupUsername
            // 
            labelSignupUsername.AutoSize = true;
            labelSignupUsername.Font = new Font("Segoe UI", 15F, FontStyle.Underline, GraphicsUnit.Point, 0);
            labelSignupUsername.Location = new Point(737, 130);
            labelSignupUsername.Margin = new Padding(2, 0, 2, 0);
            labelSignupUsername.Name = "labelSignupUsername";
            labelSignupUsername.Size = new Size(151, 35);
            labelSignupUsername.TabIndex = 2;
            labelSignupUsername.Text = "שם משתמש";
            // 
            // textBoxSignupUsername
            // 
            textBoxSignupUsername.Location = new Point(413, 175);
            textBoxSignupUsername.Margin = new Padding(2, 2, 2, 2);
            textBoxSignupUsername.Name = "textBoxSignupUsername";
            textBoxSignupUsername.Size = new Size(470, 27);
            textBoxSignupUsername.TabIndex = 3;
            // 
            // labelSignupPassword
            // 
            labelSignupPassword.AutoSize = true;
            labelSignupPassword.Font = new Font("Segoe UI", 15F, FontStyle.Underline, GraphicsUnit.Point, 0);
            labelSignupPassword.Location = new Point(804, 210);
            labelSignupPassword.Margin = new Padding(2, 0, 2, 0);
            labelSignupPassword.Name = "labelSignupPassword";
            labelSignupPassword.Size = new Size(90, 35);
            labelSignupPassword.TabIndex = 5;
            labelSignupPassword.Text = "סיסמה";
            // 
            // textBoxSignupPassword
            // 
            textBoxSignupPassword.Location = new Point(413, 246);
            textBoxSignupPassword.Margin = new Padding(2, 2, 2, 2);
            textBoxSignupPassword.Name = "textBoxSignupPassword";
            textBoxSignupPassword.Size = new Size(470, 27);
            textBoxSignupPassword.TabIndex = 6;
            // 
            // buttonSignupEnter
            // 
            buttonSignupEnter.BackColor = Color.FromArgb(235, 63, 33);
            buttonSignupEnter.Font = new Font("Segoe UI", 15F);
            buttonSignupEnter.Location = new Point(413, 301);
            buttonSignupEnter.Margin = new Padding(2, 2, 2, 2);
            buttonSignupEnter.Name = "buttonSignupEnter";
            buttonSignupEnter.Size = new Size(466, 39);
            buttonSignupEnter.TabIndex = 9;
            buttonSignupEnter.Text = "הרשמה";
            buttonSignupEnter.UseVisualStyleBackColor = false;
            buttonSignupEnter.Click += buttonSignupEnter_Click;
            // 
            // buttonSignupToLogin
            // 
            buttonSignupToLogin.Font = new Font("Segoe UI", 15F);
            buttonSignupToLogin.Location = new Point(330, 493);
            buttonSignupToLogin.Margin = new Padding(2, 2, 2, 2);
            buttonSignupToLogin.Name = "buttonSignupToLogin";
            buttonSignupToLogin.Size = new Size(316, 35);
            buttonSignupToLogin.TabIndex = 8;
            buttonSignupToLogin.Text = "כניסה";
            buttonSignupToLogin.UseVisualStyleBackColor = true;
            buttonSignupToLogin.Click += buttonSignupToLogin_Click;
            // 
            // Login_Signup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 595);
            Controls.Add(panelSignup);
            Controls.Add(panelLogin);
            Margin = new Padding(2, 2, 2, 2);
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
    }
}
