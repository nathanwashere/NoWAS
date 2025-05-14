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
            panelQuestion.Location = new Point(-4, -2);
            panelQuestion.Name = "panelQuestion";
            panelQuestion.Size = new Size(809, 382);
            panelQuestion.TabIndex = 0;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(322, 404);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(170, 34);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next Question";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(68, 404);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(170, 34);
            btnPrevious.TabIndex = 2;
            btnPrevious.Text = "Previous Question";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(570, 404);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(170, 34);
            btnFinish.TabIndex = 3;
            btnFinish.Text = "Finish Test";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // StudentTestForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFinish);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(panelQuestion);
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