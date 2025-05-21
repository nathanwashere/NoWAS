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
            type_text = new ComboBox();
            course_text = new ComboBox();
            c_a_text = new TextBox();
            level_text = new ComboBox();
            question_text = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            Possible_answer_1 = new TextBox();
            Possible_answer_2 = new TextBox();
            label3 = new Label();
            Possible_answer_3 = new TextBox();
            SuspendLayout();
            // 
            // course
            // 
            course.AutoSize = true;
            course.Font = new Font("Segoe UI", 16F);
            course.Location = new Point(29, 195);
            course.Name = "course";
            course.Size = new Size(150, 37);
            course.TabIndex = 0;
            course.Text = "The course:";
            course.Click += course_Click;
            // 
            // level
            // 
            level.AutoSize = true;
            level.Font = new Font("Segoe UI", 16F);
            level.Location = new Point(30, 361);
            level.Name = "level";
            level.Size = new Size(190, 37);
            level.TabIndex = 1;
            level.Text = "Difficulty level:";
            level.Click += label2_Click;
            // 
            // c_a
            // 
            c_a.AutoSize = true;
            c_a.Font = new Font("Segoe UI", 16F);
            c_a.Location = new Point(29, 276);
            c_a.Name = "c_a";
            c_a.Size = new Size(199, 37);
            c_a.TabIndex = 2;
            c_a.Text = "Correct answer:";
            c_a.Click += label3_Click;
            // 
            // type
            // 
            type.AutoSize = true;
            type.Font = new Font("Segoe UI", 16F);
            type.Location = new Point(30, 113);
            type.Name = "type";
            type.Size = new Size(189, 37);
            type.TabIndex = 3;
            type.Text = "Question type:";
            type.Click += label1_Click;
            // 
            // question
            // 
            question.AutoSize = true;
            question.Font = new Font("Segoe UI", 16F);
            question.Location = new Point(30, 32);
            question.Name = "question";
            question.Size = new Size(176, 37);
            question.TabIndex = 4;
            question.Text = "The question:";
            question.TextAlign = ContentAlignment.TopCenter;
            // 
            // Deleting_questions
            // 
            Deleting_questions.AutoSize = true;
            Deleting_questions.BackColor = Color.FromArgb(255, 128, 128);
            Deleting_questions.Font = new Font("Segoe UI", 14F);
            Deleting_questions.Location = new Point(912, 691);
            Deleting_questions.Name = "Deleting_questions";
            Deleting_questions.Size = new Size(225, 42);
            Deleting_questions.TabIndex = 5;
            Deleting_questions.Text = "Deleting questions";
            Deleting_questions.UseVisualStyleBackColor = false;
            Deleting_questions.Click += Deleting_questions_Click;
            // 
            // type_text
            // 
            type_text.DropDownStyle = ComboBoxStyle.DropDownList;
            type_text.Font = new Font("Segoe UI", 14F);
            type_text.FormattingEnabled = true;
<<<<<<< HEAD
            type_text.Items.AddRange(new object[] { "רב-ברירה", "נכון/לא נכון", "השלמת משפטים" });
            type_text.Location = new Point(443, 143);
=======
            type_text.Items.AddRange(new object[] { "Multiple Choice", "True/False", "Sentence Completion" });
            type_text.Location = new Point(373, 115);
>>>>>>> 15053f9de43f0f9e567691b442840c6433b0c39f
            type_text.Name = "type_text";
            type_text.Size = new Size(400, 39);
            type_text.TabIndex = 6;
            type_text.SelectedIndexChanged += type_text_SelectedIndexChanged;
            // 
            // course_text
            // 
            course_text.AutoCompleteCustomSource.AddRange(new string[] { "חדו\"א", "פיזיקה", "תכנות שפת c" });
            course_text.DropDownStyle = ComboBoxStyle.DropDownList;
            course_text.Font = new Font("Segoe UI", 14F);
            course_text.FormattingEnabled = true;
<<<<<<< HEAD
            course_text.Items.AddRange(new object[] { "חדו\"א", "פיזיקה", "מבוא למדמ\"ח" });
            course_text.Location = new Point(443, 249);
=======
            course_text.Items.AddRange(new object[] { "Calculus", "Physics ", "Introduction to Computer Science" });
            course_text.Location = new Point(373, 193);
>>>>>>> 15053f9de43f0f9e567691b442840c6433b0c39f
            course_text.Name = "course_text";
            course_text.Size = new Size(400, 39);
            course_text.TabIndex = 7;
            course_text.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // c_a_text
            // 
            c_a_text.Font = new Font("Segoe UI", 14F);
            c_a_text.Location = new Point(373, 274);
            c_a_text.Name = "c_a_text";
            c_a_text.Size = new Size(400, 39);
            c_a_text.TabIndex = 8;
            c_a_text.TextChanged += textBox1_TextChanged;
            // 
            // level_text
            // 
            level_text.DropDownStyle = ComboBoxStyle.DropDownList;
            level_text.Font = new Font("Segoe UI", 14F);
            level_text.FormattingEnabled = true;
            level_text.Items.AddRange(new object[] { "Easy", "Intermediate", "Advanced" });
            level_text.Location = new Point(373, 361);
            level_text.Name = "level_text";
            level_text.Size = new Size(400, 39);
            level_text.TabIndex = 9;
            level_text.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // question_text
            // 
            question_text.Font = new Font("Segoe UI", 14F);
            question_text.Location = new Point(373, 34);
            question_text.Name = "question_text";
            question_text.Size = new Size(400, 39);
            question_text.TabIndex = 10;
            question_text.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Location = new Point(489, 686);
            button1.Name = "button1";
            button1.Size = new Size(166, 47);
            button1.TabIndex = 11;
            button1.Text = "Creating a question";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(30, 446);
            label1.Name = "label1";
            label1.Size = new Size(231, 37);
            label1.TabIndex = 12;
            label1.Text = "Possible answer 1:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(30, 528);
            label2.Name = "label2";
            label2.Size = new Size(231, 37);
            label2.TabIndex = 13;
            label2.Text = "Possible answer 2:";
            label2.Visible = false;
            label2.Click += label2_Click_1;
            // 
            // Possible_answer_1
            // 
            Possible_answer_1.Font = new Font("Segoe UI", 14F);
            Possible_answer_1.Location = new Point(373, 448);
            Possible_answer_1.Name = "Possible_answer_1";
            Possible_answer_1.Size = new Size(400, 39);
            Possible_answer_1.TabIndex = 14;
            Possible_answer_1.Visible = false;
            Possible_answer_1.TextChanged += Possible_answer_1_TextChanged;
            // 
            // Possible_answer_2
            // 
            Possible_answer_2.Font = new Font("Segoe UI", 14F);
            Possible_answer_2.Location = new Point(373, 530);
            Possible_answer_2.Name = "Possible_answer_2";
            Possible_answer_2.Size = new Size(400, 39);
            Possible_answer_2.TabIndex = 15;
            Possible_answer_2.Visible = false;
            Possible_answer_2.TextChanged += textBox2_TextChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(30, 611);
            label3.Name = "label3";
            label3.Size = new Size(231, 37);
            label3.TabIndex = 16;
            label3.Text = "Possible answer 3:";
            label3.Visible = false;
            // 
            // Possible_answer_3
            // 
            Possible_answer_3.Font = new Font("Segoe UI", 14F);
            Possible_answer_3.Location = new Point(373, 613);
            Possible_answer_3.Name = "Possible_answer_3";
            Possible_answer_3.Size = new Size(400, 39);
            Possible_answer_3.TabIndex = 17;
            Possible_answer_3.Visible = false;
            // 
            // InsertingQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 776);
            Controls.Add(Possible_answer_3);
            Controls.Add(label3);
            Controls.Add(Possible_answer_2);
            Controls.Add(Possible_answer_1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(question_text);
            Controls.Add(level_text);
            Controls.Add(c_a_text);
            Controls.Add(course_text);
            Controls.Add(type_text);
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
        private ComboBox type_text;
        private ComboBox course_text;
        private TextBox c_a_text;
        private ComboBox level_text;
        private TextBox question_text;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox Possible_answer_1;
        private TextBox Possible_answer_2;
        private Label label3;
        private TextBox Possible_answer_3;
    }
}