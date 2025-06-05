using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class StudentTestForm
    {
        private System.ComponentModel.IContainer components = null;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelQuestion = new Panel();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFinish = new Button();
            SuspendLayout();
            // 
            // panelQuestion
            // 
            panelQuestion.BackColor = Color.Transparent;
            panelQuestion.BackgroundImageLayout = ImageLayout.Stretch;
            panelQuestion.Location = new Point(-4, -2);
            panelQuestion.Margin = new Padding(2);
            panelQuestion.Name = "panelQuestion";
            panelQuestion.Size = new Size(1105, 389);
            panelQuestion.TabIndex = 0;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(510, 404);
            btnNext.Margin = new Padding(2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next Question";
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(174, 404);
            btnPrevious.Margin = new Padding(2);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 2;
            btnPrevious.Text = "Previous Question";
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(818, 404);
            btnFinish.Margin = new Padding(2);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(94, 29);
            btnFinish.TabIndex = 3;
            btnFinish.Text = "Finish Test";
            btnFinish.Click += btnFinish_Click;
            // 
            // StudentTestForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            BackgroundImage = Properties.Resources.bgTestTake;
            ClientSize = new Size(1102, 656);
            Controls.Add(btnFinish);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(panelQuestion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "StudentTestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentTestForm";
            Load += StudentTestForm_Load;
            ResumeLayout(false);
        }

        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.BackColor = Color.LightBlue;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btn.Size = new Size(150, 40); 
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Padding = new Padding(0);
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 20, 20));

        }


        #endregion

        private Panel panelQuestion;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFinish;
    }
}
