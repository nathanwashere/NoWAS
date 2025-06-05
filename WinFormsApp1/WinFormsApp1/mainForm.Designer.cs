namespace WinFormsApp1
{
    partial class mainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblActiveTests;
        private System.Windows.Forms.Label lblAvgScore;
        private System.Windows.Forms.Button btnTakeTest;
        private System.Windows.Forms.Button btnGrades;
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
            pnlStats = new Panel();
            lblActiveTests = new Label();
            lblAvgScore = new Label();
            btnTakeTest = new Button();
            btnGrades = new Button();
            btnLogout = new Button();
            lblWelcome = new Label();
            pnlStats.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.FromArgb(240, 240, 245);
            pnlStats.BorderStyle = BorderStyle.None;
            pnlStats.Controls.Add(lblActiveTests);
            pnlStats.Controls.Add(lblAvgScore);
            pnlStats.Location = new Point(247, 101);
            pnlStats.Margin = new Padding(4);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(500, 120);
            pnlStats.TabIndex = 1;
            pnlStats.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, pnlStats.ClientRectangle,
                    Color.FromArgb(200, 200, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(200, 200, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(200, 200, 220), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(200, 200, 220), 1, ButtonBorderStyle.Solid);
            };
            // 
            // lblActiveTests
            // 
            lblActiveTests.AutoSize = true;
            lblActiveTests.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActiveTests.ForeColor = Color.FromArgb(64, 64, 64);
            lblActiveTests.Location = new Point(40, 40);
            lblActiveTests.Margin = new Padding(4, 0, 4, 0);
            lblActiveTests.Name = "lblActiveTests";
            lblActiveTests.Size = new Size(144, 32);
            lblActiveTests.TabIndex = 0;
            lblActiveTests.Text = "Tests taken: ";
            // 
            // lblAvgScore
            // 
            lblAvgScore.AutoSize = true;
            lblAvgScore.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvgScore.ForeColor = Color.FromArgb(64, 64, 64);
            lblAvgScore.Location = new Point(280, 40);
            lblAvgScore.Margin = new Padding(4, 0, 4, 0);
            lblAvgScore.Name = "lblAvgScore";
            lblAvgScore.Size = new Size(169, 32);
            lblAvgScore.TabIndex = 1;
            lblAvgScore.Text = "Average score:";
            // 
            // btnTakeTest
            // 
            btnTakeTest.BackColor = Color.FromArgb(70, 130, 180);
            btnTakeTest.FlatAppearance.BorderSize = 0;
            btnTakeTest.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 120, 170);
            btnTakeTest.FlatStyle = FlatStyle.Flat;
            btnTakeTest.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTakeTest.ForeColor = Color.White;
            btnTakeTest.Image = (Image)resources.GetObject("btnTakeTest.Image");
            btnTakeTest.ImageAlign = ContentAlignment.MiddleLeft;
            btnTakeTest.Location = new Point(367, 260);
            btnTakeTest.Margin = new Padding(4);
            btnTakeTest.Name = "btnTakeTest";
            btnTakeTest.Size = new Size(200, 65);
            btnTakeTest.TabIndex = 2;
            btnTakeTest.Text = "Take Test";
            btnTakeTest.TextAlign = ContentAlignment.MiddleRight;
            btnTakeTest.UseVisualStyleBackColor = false;
            btnTakeTest.Click += btnTakeTest_Click;
            // 
            // btnGrades
            // 
            btnGrades.BackColor = Color.FromArgb(70, 130, 180);
            btnGrades.FlatAppearance.BorderSize = 0;
            btnGrades.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 120, 170);
            btnGrades.FlatStyle = FlatStyle.Flat;
            btnGrades.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGrades.ForeColor = Color.White;
            btnGrades.Image = (Image)resources.GetObject("btnGrades.Image");
            btnGrades.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrades.Location = new Point(367, 350);
            btnGrades.Margin = new Padding(4);
            btnGrades.Name = "btnGrades";
            btnGrades.Size = new Size(200, 65);
            btnGrades.TabIndex = 3;
            btnGrades.Text = "My Grades";
            btnGrades.TextAlign = ContentAlignment.MiddleRight;
            btnGrades.UseVisualStyleBackColor = false;
            btnGrades.Click += btnGrades_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(70, 130, 180);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 120, 170);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = Properties.Resources.log_out;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(747, 526);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(186, 50);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleRight;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(70, 130, 180);
            lblWelcome.Location = new Point(247, 25);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(442, 65);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Student!";
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.bgMain;
            ClientSize = new Size(994, 617);
            Controls.Add(lblWelcome);
            Controls.Add(pnlStats);
            Controls.Add(btnTakeTest);
            Controls.Add(btnGrades);
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

        private Label lblWelcome;
    }
}