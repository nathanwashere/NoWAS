namespace WinFormsApp1
{
    partial class InsertingQuestions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            course = new Label();
            level = new Label();
            c_a = new Label();
            type = new Label();
            question = new Label();
            Deleting_questions = new Button();
            SuspendLayout();
            // 
            // course
            // 
            course.AutoSize = true;
            course.Font = new Font("Segoe UI", 20F);
            course.Location = new Point(44, 249);
            course.Name = "course";
            course.Size = new Size(190, 46);
            course.TabIndex = 0;
            course.Text = "The course:";
            course.Click += course_Click;
            // 
            // level
            // 
            level.AutoSize = true;
            level.Font = new Font("Segoe UI", 20F);
            level.Location = new Point(44, 451);
            level.Name = "level";
            level.Size = new Size(237, 46);
            level.TabIndex = 1;
            level.Text = "Difficulty level:";
            level.Click += label2_Click;
            // 
            // c_a
            // 
            c_a.AutoSize = true;
            c_a.Font = new Font("Segoe UI", 20F);
            c_a.Location = new Point(44, 346);
            c_a.Name = "c_a";
            c_a.Size = new Size(252, 46);
            c_a.TabIndex = 2;
            c_a.Text = "Correct answer:";
            c_a.Click += label3_Click;
            // 
            // type
            // 
            type.AutoSize = true;
            type.Font = new Font("Segoe UI", 20F);
            type.Location = new Point(44, 143);
            type.Name = "type";
            type.Size = new Size(238, 46);
            type.TabIndex = 3;
            type.Text = "Question type:";
            type.Click += label1_Click;
            // 
            // question
            // 
            question.AutoSize = true;
            question.Font = new Font("Segoe UI", 20F);
            question.Location = new Point(44, 35);
            question.Name = "question";
            question.Size = new Size(221, 46);
            question.TabIndex = 4;
            question.Text = "The question:";
            question.TextAlign = ContentAlignment.TopCenter;
            // 
            // Deleting_questions
            // 
            Deleting_questions.AutoSize = true;
            Deleting_questions.BackColor = Color.FromArgb(255, 128, 128);
            Deleting_questions.Font = new Font("Segoe UI", 20F);
            Deleting_questions.Location = new Point(799, 521);
            Deleting_questions.Name = "Deleting_questions";
            Deleting_questions.Size = new Size(310, 56);
            Deleting_questions.TabIndex = 5;
            Deleting_questions.Text = "Deleting questions";
            Deleting_questions.UseVisualStyleBackColor = false;
            Deleting_questions.Click += Deleting_questions_Click;
            // 
            // InsertingQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 607);
            Controls.Add(Deleting_questions);
            Controls.Add(question);
            Controls.Add(type);
            Controls.Add(c_a);
            Controls.Add(level);
            Controls.Add(course);
            Name = "InsertingQuestions";
            Text = "InsertingQuestions";
            Load += InsertingQuestions_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label course;
        private Label level;
        private Label c_a;
        private Label type;
        private Label question;
        private Button Deleting_questions;
    }
}