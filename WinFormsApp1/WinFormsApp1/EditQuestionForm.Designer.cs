namespace WinFormsApp1
{
    partial class EditQuestionForm
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
            question = new Label();
            type = new Label();
            course = new Label();
            c_a = new Label();
            level = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            question_text = new TextBox();
            type_text = new ComboBox();
            course_text = new ComboBox();
            c_a_text = new TextBox();
            level_text = new ComboBox();
            Possible_answer_1 = new TextBox();
            Possible_answer_2 = new TextBox();
            Possible_answer_3 = new TextBox();
            save = new Button();
            SuspendLayout();
            // 
            // question
            // 
            question.AutoSize = true;
            question.Font = new Font("Segoe UI", 16F);
            question.Location = new Point(12, 19);
            question.Name = "question";
            question.Size = new Size(176, 37);
            question.TabIndex = 5;
            question.Text = "The question:";
            question.TextAlign = ContentAlignment.TopCenter;
            // 
            // type
            // 
            type.AutoSize = true;
            type.Font = new Font("Segoe UI", 16F);
            type.Location = new Point(12, 102);
            type.Name = "type";
            type.Size = new Size(189, 37);
            type.TabIndex = 6;
            type.Text = "Question type:";
            // 
            // course
            // 
            course.AutoSize = true;
            course.Font = new Font("Segoe UI", 16F);
            course.Location = new Point(12, 181);
            course.Name = "course";
            course.Size = new Size(150, 37);
            course.TabIndex = 7;
            course.Text = "The course:";
            // 
            // c_a
            // 
            c_a.AutoSize = true;
            c_a.Font = new Font("Segoe UI", 16F);
            c_a.Location = new Point(12, 259);
            c_a.Name = "c_a";
            c_a.Size = new Size(199, 37);
            c_a.TabIndex = 8;
            c_a.Text = "Correct answer:";
            c_a.Click += c_a_Click;
            // 
            // level
            // 
            level.AutoSize = true;
            level.Font = new Font("Segoe UI", 16F);
            level.Location = new Point(12, 340);
            level.Name = "level";
            level.Size = new Size(190, 37);
            level.TabIndex = 9;
            level.Text = "Difficulty level:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(12, 423);
            label1.Name = "label1";
            label1.Size = new Size(231, 37);
            label1.TabIndex = 13;
            label1.Text = "Possible answer 1:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(12, 495);
            label2.Name = "label2";
            label2.Size = new Size(231, 37);
            label2.TabIndex = 14;
            label2.Text = "Possible answer 2:";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(12, 574);
            label3.Name = "label3";
            label3.Size = new Size(231, 37);
            label3.TabIndex = 17;
            label3.Text = "Possible answer 3:";
            label3.Visible = false;
            // 
            // question_text
            // 
            question_text.Font = new Font("Segoe UI", 14F);
            question_text.Location = new Point(358, 21);
            question_text.Name = "question_text";
            question_text.Size = new Size(400, 39);
            question_text.TabIndex = 18;
            // 
            // type_text
            // 
            type_text.DropDownStyle = ComboBoxStyle.DropDownList;
            type_text.Font = new Font("Segoe UI", 14F);
            type_text.FormattingEnabled = true;
            type_text.Items.AddRange(new object[] { "Multiple Choice", "True/False", "Sentence Completion" });
            type_text.Location = new Point(358, 100);
            type_text.Name = "type_text";
            type_text.Size = new Size(400, 39);
            type_text.TabIndex = 19;
            type_text.SelectedIndexChanged += type_text_SelectedIndexChanged;
            // 
            // course_text
            // 
            course_text.AutoCompleteCustomSource.AddRange(new string[] { "חדו\"א", "פיזיקה", "תכנות שפת c" });
            course_text.DropDownStyle = ComboBoxStyle.DropDownList;
            course_text.Font = new Font("Segoe UI", 14F);
            course_text.FormattingEnabled = true;
            course_text.Items.AddRange(new object[] { "Calculus", "Physics ", "Introduction to Computer Science" });
            course_text.Location = new Point(358, 179);
            course_text.Name = "course_text";
            course_text.Size = new Size(400, 39);
            course_text.TabIndex = 20;
            // 
            // c_a_text
            // 
            c_a_text.Font = new Font("Segoe UI", 14F);
            c_a_text.Location = new Point(358, 257);
            c_a_text.Name = "c_a_text";
            c_a_text.Size = new Size(400, 39);
            c_a_text.TabIndex = 21;
            // 
            // level_text
            // 
            level_text.DropDownStyle = ComboBoxStyle.DropDownList;
            level_text.Font = new Font("Segoe UI", 14F);
            level_text.FormattingEnabled = true;
            level_text.Items.AddRange(new object[] { "Easy", "Intermediate", "Advanced" });
            level_text.Location = new Point(358, 342);
            level_text.Name = "level_text";
            level_text.Size = new Size(400, 39);
            level_text.TabIndex = 22;
            // 
            // Possible_answer_1
            // 
            Possible_answer_1.Font = new Font("Segoe UI", 14F);
            Possible_answer_1.Location = new Point(358, 421);
            Possible_answer_1.Name = "Possible_answer_1";
            Possible_answer_1.Size = new Size(400, 39);
            Possible_answer_1.TabIndex = 23;
            Possible_answer_1.Visible = false;
            // 
            // Possible_answer_2
            // 
            Possible_answer_2.Font = new Font("Segoe UI", 14F);
            Possible_answer_2.Location = new Point(358, 493);
            Possible_answer_2.Name = "Possible_answer_2";
            Possible_answer_2.Size = new Size(400, 39);
            Possible_answer_2.TabIndex = 24;
            Possible_answer_2.Visible = false;
            // 
            // Possible_answer_3
            // 
            Possible_answer_3.Font = new Font("Segoe UI", 14F);
            Possible_answer_3.Location = new Point(358, 574);
            Possible_answer_3.Name = "Possible_answer_3";
            Possible_answer_3.Size = new Size(400, 39);
            Possible_answer_3.TabIndex = 25;
            Possible_answer_3.Visible = false;
            // 
            // save
            // 
            save.BackColor = Color.RoyalBlue;
            save.Location = new Point(433, 642);
            save.Name = "save";
            save.Size = new Size(176, 57);
            save.TabIndex = 26;
            save.Text = "save";
            save.UseVisualStyleBackColor = false;
            // 
            // EditQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 711);
            Controls.Add(save);
            Controls.Add(Possible_answer_3);
            Controls.Add(Possible_answer_2);
            Controls.Add(Possible_answer_1);
            Controls.Add(level_text);
            Controls.Add(c_a_text);
            Controls.Add(course_text);
            Controls.Add(type_text);
            Controls.Add(question_text);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(level);
            Controls.Add(c_a);
            Controls.Add(course);
            Controls.Add(type);
            Controls.Add(question);
            Name = "EditQuestionForm";
            Text = "EditQuestionForm";
            Load += EditQuestionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label question;
        private Label type;
        private Label course;
        private Label c_a;
        private Label level;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox question_text;
        private ComboBox type_text;
        private ComboBox course_text;
        private TextBox c_a_text;
        private ComboBox level_text;
        private TextBox Possible_answer_1;
        private TextBox Possible_answer_2;
        private TextBox Possible_answer_3;
        private Button save;
    }
}