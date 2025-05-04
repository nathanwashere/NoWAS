namespace WinFormsApp1
{
    partial class mainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblActiveTests;
        private System.Windows.Forms.Label lblAvgScore;
        private System.Windows.Forms.Button btnTakeTest;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Button btnProgress;
        private System.Windows.Forms.Button btnProgress2;
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
            lblActiveTests = new Label();
            lblAvgScore = new Label();
            btnTakeTest = new Button();
            btnGrades = new Button();
            btnProgress = new Button();
            btnProgress2 = new Button();
            btnSettings = new Button();
            btnLogout = new Button();
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
            lblWelcome.Size = new Size(235, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, LizVa";
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.LightSteelBlue;
            pnlStats.BorderStyle = BorderStyle.FixedSingle;
            pnlStats.Controls.Add(lblActiveTests);
            pnlStats.Controls.Add(lblAvgScore);
            pnlStats.Location = new Point(150, 70);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(465, 80);
            pnlStats.TabIndex = 1;
            // 
            // lblActiveTests
            // 
            lblActiveTests.AutoSize = true;
            lblActiveTests.Font = new Font("Segoe UI", 12F);
            lblActiveTests.Location = new Point(20, 25);
            lblActiveTests.Name = "lblActiveTests";
            lblActiveTests.Size = new Size(115, 28);
            lblActiveTests.TabIndex = 0;
            lblActiveTests.Text = "Tests taken: ";
            // 
            // lblAvgScore
            // 
            lblAvgScore.AutoSize = true;
            lblAvgScore.Font = new Font("Segoe UI", 12F);
            lblAvgScore.Location = new Point(300, 25);
            lblAvgScore.Name = "lblAvgScore";
            lblAvgScore.Size = new Size(139, 28);
            lblAvgScore.TabIndex = 1;
            lblAvgScore.Text = "Average score:";
            // 
            // btnTakeTest
            // 
            btnTakeTest.BackColor = Color.SteelBlue;
            btnTakeTest.FlatStyle = FlatStyle.Flat;
            btnTakeTest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTakeTest.ForeColor = Color.White;
            btnTakeTest.Location = new Point(150, 180);
            btnTakeTest.Name = "btnTakeTest";
            btnTakeTest.Size = new Size(200, 50);
            btnTakeTest.TabIndex = 2;
            btnTakeTest.Text = "Take Test";
            btnTakeTest.UseVisualStyleBackColor = false;
            // 
            // btnGrades
            // 
            btnGrades.BackColor = Color.SteelBlue;
            btnGrades.FlatStyle = FlatStyle.Flat;
            btnGrades.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGrades.ForeColor = Color.White;
            btnGrades.Location = new Point(415, 180);
            btnGrades.Name = "btnGrades";
            btnGrades.Size = new Size(200, 50);
            btnGrades.TabIndex = 3;
            btnGrades.Text = "My Grades";
            btnGrades.UseVisualStyleBackColor = false;
            btnGrades.Click += btnGrades_Click;
            // 
            // btnProgress
            // 
            btnProgress.BackColor = Color.SteelBlue;
            btnProgress.FlatStyle = FlatStyle.Flat;
            btnProgress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProgress.ForeColor = Color.White;
            btnProgress.Location = new Point(150, 250);
            btnProgress.Name = "btnProgress";
            btnProgress.Size = new Size(200, 50);
            btnProgress.TabIndex = 4;
            btnProgress.Text = "Progress";
            btnProgress.UseVisualStyleBackColor = false;
            // 
            // btnProgress2
            // 
            btnProgress2.BackColor = Color.SteelBlue;
            btnProgress2.FlatStyle = FlatStyle.Flat;
            btnProgress2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProgress2.ForeColor = Color.White;
            btnProgress2.Location = new Point(415, 250);
            btnProgress2.Name = "btnProgress2";
            btnProgress2.Size = new Size(200, 50);
            btnProgress2.TabIndex = 5;
            btnProgress2.Text = "Progress";
            btnProgress2.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.SteelBlue;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(186, 340);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(100, 40);
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
            btnLogout.Location = new Point(466, 340);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 40);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 500);
            Controls.Add(lblWelcome);
            Controls.Add(pnlStats);
            Controls.Add(btnTakeTest);
            Controls.Add(btnGrades);
            Controls.Add(btnProgress);
            Controls.Add(btnProgress2);
            Controls.Add(btnSettings);
            Controls.Add(btnLogout);
            Name = "mainForm";
            Text = "Main Dashboard";
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
