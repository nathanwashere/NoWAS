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
            lblWelcome.Location = new Point(350, 25);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(323, 48);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Teacher";
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.LightSteelBlue;
            pnlStats.BorderStyle = BorderStyle.FixedSingle;
            pnlStats.Controls.Add(lblTestsCreated);
            pnlStats.Controls.Add(lblAvgScore);
            pnlStats.Location = new Point(190, 101);
            pnlStats.Margin = new Padding(4);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(581, 100);
            pnlStats.TabIndex = 1;
            // 
            // lblTestsCreated
            // 
            lblTestsCreated.AutoSize = true;
            lblTestsCreated.Font = new Font("Segoe UI", 12F);
            lblTestsCreated.Location = new Point(25, 31);
            lblTestsCreated.Margin = new Padding(4, 0, 4, 0);
            lblTestsCreated.Name = "lblTestsCreated";
            lblTestsCreated.Size = new Size(164, 32);
            lblTestsCreated.TabIndex = 0;
            lblTestsCreated.Text = "Tests created: ";
            // 
            // lblAvgScore
            // 
            lblAvgScore.AutoSize = true;
            lblAvgScore.Font = new Font("Segoe UI", 12F);
            lblAvgScore.Location = new Point(321, 31);
            lblAvgScore.Margin = new Padding(4, 0, 4, 0);
            lblAvgScore.Name = "lblAvgScore";
            lblAvgScore.Size = new Size(169, 32);
            lblAvgScore.TabIndex = 1;
            lblAvgScore.Text = "Average score:";
            // 
            // btnCreateTest
            // 
            btnCreateTest.BackColor = Color.SteelBlue;
            btnCreateTest.FlatStyle = FlatStyle.Flat;
            btnCreateTest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateTest.ForeColor = Color.White;
            btnCreateTest.Location = new Point(350, 224);
            btnCreateTest.Margin = new Padding(4);
            btnCreateTest.Name = "btnCreateTest";
            btnCreateTest.Size = new Size(250, 62);
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
            btnCheckSubmissions.Location = new Point(350, 315);
            btnCheckSubmissions.Margin = new Padding(4);
            btnCheckSubmissions.Name = "btnCheckSubmissions";
            btnCheckSubmissions.Size = new Size(250, 62);
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
            btnProgress.Location = new Point(350, 396);
            btnProgress.Margin = new Padding(4);
            btnProgress.Name = "btnProgress";
            btnProgress.Size = new Size(250, 62);
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
            btnSettings.Location = new Point(15, 15);
            btnSettings.Margin = new Padding(4);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(192, 50);
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
            btnLogout.Location = new Point(775, 526);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(186, 50);
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
            button1.Location = new Point(350, 479);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(250, 62);
            button1.TabIndex = 8;
            button1.Text = "Statistical Data";
            button1.UseVisualStyleBackColor = false;
            // 
            // mainTeacher
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1000, 625);
            Controls.Add(button1);
            Controls.Add(lblWelcome);
            Controls.Add(pnlStats);
            Controls.Add(btnCreateTest);
            Controls.Add(btnCheckSubmissions);
            Controls.Add(btnProgress);
            Controls.Add(btnSettings);
            Controls.Add(btnLogout);
            Margin = new Padding(4);
            Name = "mainTeacher";
            Text = "Teacher Dashboard";
            FormClosed += mainTeacher_FormClosed;
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
    }
}
