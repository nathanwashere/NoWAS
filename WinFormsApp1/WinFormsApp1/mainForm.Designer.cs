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
        private System.Windows.Forms.Label lblActiveTestsValue;
        private System.Windows.Forms.Label lblAvgScoreValue;

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
            lblActiveTestsValue = new Label();
            lblAvgScoreValue = new Label();
            pnlStats.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.Transparent;
            pnlStats.BorderStyle = BorderStyle.None;
            pnlStats.Controls.Add(lblActiveTests);
            pnlStats.Controls.Add(lblActiveTestsValue);
            pnlStats.Controls.Add(lblAvgScore);
            pnlStats.Controls.Add(lblAvgScoreValue);
            pnlStats.Location = new Point(247, 101);
            pnlStats.Margin = new Padding(4);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(550, 100);
            pnlStats.TabIndex = 1;
            pnlStats.Paint += (s, e) =>
            {
                // Draw shadow
                using (var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(shadowBrush, 8, 8, pnlStats.Width - 16, pnlStats.Height - 16);
                }
                // Draw rounded rectangle with gradient
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 20;
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(pnlStats.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(pnlStats.Width - radius, pnlStats.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, pnlStats.Height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();
                    using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        pnlStats.ClientRectangle,
                        Color.FromArgb(245, 250, 255),
                        Color.FromArgb(220, 230, 250),
                        System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (var borderPen = new Pen(Color.FromArgb(180, 200, 220), 2))
                    {
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
            };
            // 
            // lblActiveTests
            // 
            lblActiveTests.AutoSize = true;
            lblActiveTests.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActiveTests.ForeColor = Color.FromArgb(70, 130, 180);
            lblActiveTests.Location = new Point(40, 30);
            lblActiveTests.Margin = new Padding(4, 0, 4, 0);
            lblActiveTests.Name = "lblActiveTests";
            lblActiveTests.Size = new Size(110, 25);
            lblActiveTests.TabIndex = 0;
            lblActiveTests.Text = "Tests taken:";
            // 
            // lblActiveTestsValue
            // 
            lblActiveTestsValue = new Label();
            lblActiveTestsValue.AutoSize = true;
            lblActiveTestsValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveTestsValue.ForeColor = Color.FromArgb(40, 80, 140);
            lblActiveTestsValue.Location = new Point(160, 27);
            lblActiveTestsValue.Margin = new Padding(4, 0, 4, 0);
            lblActiveTestsValue.Name = "lblActiveTestsValue";
            lblActiveTestsValue.Size = new Size(30, 28);
            lblActiveTestsValue.TabIndex = 1;
            lblActiveTestsValue.Text = "0";
            // 
            // lblAvgScore
            // 
            lblAvgScore.AutoSize = true;
            lblAvgScore.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvgScore.ForeColor = Color.FromArgb(70, 130, 180);
            lblAvgScore.Location = new Point(260, 30);
            lblAvgScore.Margin = new Padding(4, 0, 4, 0);
            lblAvgScore.Name = "lblAvgScore";
            lblAvgScore.Size = new Size(120, 25);
            lblAvgScore.TabIndex = 2;
            lblAvgScore.Text = "Average score:";
            // 
            // lblAvgScoreValue
            // 
            lblAvgScoreValue = new Label();
            lblAvgScoreValue.AutoSize = true;
            lblAvgScoreValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvgScoreValue.ForeColor = Color.FromArgb(40, 80, 140);
            lblAvgScoreValue.Location = new Point(390, 27);
            lblAvgScoreValue.Margin = new Padding(4, 0, 4, 0);
            lblAvgScoreValue.Name = "lblAvgScoreValue";
            lblAvgScoreValue.Size = new Size(50, 28);
            lblAvgScoreValue.TabIndex = 3;
            lblAvgScoreValue.Text = "0%";
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
            btnTakeTest.Location = new Point(397, 260);
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
            btnGrades.Location = new Point(397, 350);
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
            lblWelcome.Location = new Point(287, 25);
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