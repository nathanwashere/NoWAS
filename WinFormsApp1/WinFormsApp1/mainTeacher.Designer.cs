namespace WinFormsApp1
{
    partial class mainTeacher
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTestsCreated;
        private System.Windows.Forms.Label lblAvgScore;
        private System.Windows.Forms.Button btnCreateTest;
        private System.Windows.Forms.Button btnCheckSubmissions;
        private System.Windows.Forms.Button btnProgress;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            pnlStats = new Panel();
            lblTestsCreated = new Label();
            lblAvgScore = new Label();
            btnCreateTest = new Button();
            btnCheckSubmissions = new Button();
            btnProgress = new Button();
            btnSettings = new Button();
            btnLogout = new Button();
            button1 = new Button();
            pnlStats.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Black;
            lblWelcome.Location = new Point(280, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(270, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Teacher";
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.LightSteelBlue;
            pnlStats.BorderStyle = BorderStyle.FixedSingle;
            pnlStats.Controls.Add(lblTestsCreated);
            pnlStats.Controls.Add(lblAvgScore);
            pnlStats.Location = new Point(152, 81);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(465, 80);
            pnlStats.TabIndex = 1;
            // 
            // lblTestsCreated
            // 
            lblTestsCreated.AutoSize = true;
            lblTestsCreated.Font = new Font("Segoe UI", 12F);
            lblTestsCreated.Location = new Point(20, 25);
            lblTestsCreated.Name = "lblTestsCreated";
            lblTestsCreated.Size = new Size(132, 28);
            lblTestsCreated.TabIndex = 0;
            lblTestsCreated.Text = "Tests created: ";
            // 
            // lblAvgScore
            // 
            lblAvgScore.AutoSize = true;
            lblAvgScore.Font = new Font("Segoe UI", 12F);
            lblAvgScore.Location = new Point(257, 25);
            lblAvgScore.Name = "lblAvgScore";
            lblAvgScore.Size = new Size(139, 28);
            lblAvgScore.TabIndex = 1;
            lblAvgScore.Text = "Average score:";
            // 
            // btnCreateTest
            // 
            btnCreateTest.BackColor = Color.SteelBlue;
            btnCreateTest.FlatStyle = FlatStyle.Flat;
            btnCreateTest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateTest.ForeColor = Color.White;
            btnCreateTest.Location = new Point(280, 179);
            btnCreateTest.Name = "btnCreateTest";
            btnCreateTest.Size = new Size(200, 50);
            btnCreateTest.TabIndex = 2;
            btnCreateTest.Text = "Create Test";
            btnCreateTest.UseVisualStyleBackColor = false;
            // 
            // btnCheckSubmissions
            // 
            btnCheckSubmissions.BackColor = Color.SteelBlue;
            btnCheckSubmissions.FlatStyle = FlatStyle.Flat;
            btnCheckSubmissions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckSubmissions.ForeColor = Color.White;
            btnCheckSubmissions.Location = new Point(280, 252);
            btnCheckSubmissions.Name = "btnCheckSubmissions";
            btnCheckSubmissions.Size = new Size(200, 50);
            btnCheckSubmissions.TabIndex = 3;
            btnCheckSubmissions.Text = "Create Questions";
            btnCheckSubmissions.UseVisualStyleBackColor = false;
            btnCheckSubmissions.Click += btnCheckSubmissions_Click;
            // 
            // btnProgress
            // 
            btnProgress.BackColor = Color.SteelBlue;
            btnProgress.FlatStyle = FlatStyle.Flat;
            btnProgress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProgress.ForeColor = Color.White;
            btnProgress.Location = new Point(280, 317);
            btnProgress.Name = "btnProgress";
            btnProgress.Size = new Size(200, 50);
            btnProgress.TabIndex = 4;
            btnProgress.Text = "Student Data";
            btnProgress.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.SteelBlue;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(12, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(154, 40);
            btnSettings.TabIndex = 6;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.SteelBlue;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(620, 421);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(149, 40);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(280, 383);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 8;
            button1.Text = "Statistical Data";
            button1.UseVisualStyleBackColor = false;
            // 
            // mainTeacher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 500);
            Controls.Add(button1);
            Controls.Add(lblWelcome);
            Controls.Add(pnlStats);
            Controls.Add(btnCreateTest);
            Controls.Add(btnCheckSubmissions);
            Controls.Add(btnProgress);
            Controls.Add(btnSettings);
            Controls.Add(btnLogout);
            Name = "mainTeacher";
            Text = "Teacher Dashboard";
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
    }
}
