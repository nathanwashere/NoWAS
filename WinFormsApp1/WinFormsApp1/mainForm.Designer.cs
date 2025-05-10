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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            lblWelcome = new Label();
            pnlStats = new Panel();
            lblActiveTests = new Label();
            lblAvgScore = new Label();
            btnTakeTest = new Button();
            btnGrades = new Button();
            btnProgress = new Button();
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
            lblWelcome.Location = new Point(350, 25);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(280, 48);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, LizVa";
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.LightSteelBlue;
            pnlStats.BorderStyle = BorderStyle.FixedSingle;
            pnlStats.Controls.Add(lblActiveTests);
            pnlStats.Controls.Add(lblAvgScore);
            pnlStats.Location = new Point(190, 101);
            pnlStats.Margin = new Padding(4);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(581, 100);
            pnlStats.TabIndex = 1;
            // 
            // lblActiveTests
            // 
            lblActiveTests.AutoSize = true;
            lblActiveTests.Font = new Font("Segoe UI", 12F);
            lblActiveTests.Location = new Point(25, 31);
            lblActiveTests.Margin = new Padding(4, 0, 4, 0);
            lblActiveTests.Name = "lblActiveTests";
            lblActiveTests.Size = new Size(144, 32);
            lblActiveTests.TabIndex = 0;
            lblActiveTests.Text = "Tests taken: ";
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
            // btnTakeTest
            // 
            btnTakeTest.BackColor = Color.SteelBlue;
            btnTakeTest.FlatStyle = FlatStyle.Flat;
            btnTakeTest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTakeTest.ForeColor = Color.White;
            btnTakeTest.Image = (Image)resources.GetObject("btnTakeTest.Image");
            btnTakeTest.ImageAlign = ContentAlignment.MiddleLeft;
            btnTakeTest.Location = new Point(350, 224);
            btnTakeTest.Margin = new Padding(4);
            btnTakeTest.Name = "btnTakeTest";
            btnTakeTest.Size = new Size(250, 62);
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
            btnGrades.Image = (Image)resources.GetObject("btnGrades.Image");
            btnGrades.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrades.Location = new Point(350, 320);
            btnGrades.Margin = new Padding(4);
            btnGrades.Name = "btnGrades";
            btnGrades.Size = new Size(250, 62);
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
            btnProgress.Image = (Image)resources.GetObject("btnProgress.Image");
            btnProgress.ImageAlign = ContentAlignment.MiddleLeft;
            btnProgress.Location = new Point(350, 409);
            btnProgress.Margin = new Padding(4);
            btnProgress.Name = "btnProgress";
            btnProgress.Size = new Size(250, 62);
            btnProgress.TabIndex = 4;
            btnProgress.Text = "Progress";
            btnProgress.UseVisualStyleBackColor = false;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.SteelBlue;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSettings.ForeColor = Color.White;
            btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
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
            btnLogout.Image = Properties.Resources.log_out;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(775, 526);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(186, 50);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1000, 625);
            Controls.Add(lblWelcome);
            Controls.Add(pnlStats);
            Controls.Add(btnTakeTest);
            Controls.Add(btnGrades);
            Controls.Add(btnProgress);
            Controls.Add(btnSettings);
            Controls.Add(btnLogout);
            Margin = new Padding(4);
            Name = "mainForm";
            Text = "Main Dashboard";
            FormClosed += mainForm_FormClosed;
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
