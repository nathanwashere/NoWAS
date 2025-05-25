namespace WinFormsApp1
{
    partial class StudentTestForm
    {
        private System.ComponentModel.IContainer components = null;

        
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            panelQuestion.BackgroundImage = Properties.Resources.bgTestTake;
            panelQuestion.Location = new Point(-3, -2);
            panelQuestion.Margin = new Padding(2, 2, 2, 2);
            panelQuestion.Name = "panelQuestion";
            panelQuestion.Size = new Size(647, 306);
            panelQuestion.TabIndex = 0;
            panelQuestion.Paint += panelQuestion_Paint;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(258, 323);
            btnNext.Margin = new Padding(2, 2, 2, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(136, 27);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next Question";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(54, 323);
            btnPrevious.Margin = new Padding(2, 2, 2, 2);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(136, 27);
            btnPrevious.TabIndex = 2;
            btnPrevious.Text = "Previous Question";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(456, 323);
            btnFinish.Margin = new Padding(2, 2, 2, 2);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(136, 27);
            btnFinish.TabIndex = 3;
            btnFinish.Text = "Finish Test";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // StudentTestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(640, 360);
            Controls.Add(btnFinish);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(panelQuestion);
            Margin = new Padding(2, 2, 2, 2);
            Name = "StudentTestForm";
            Text = "StudentTestForm";
            Load += StudentTestForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panelQuestion;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFinish;
    }
}