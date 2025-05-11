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
            Deleting_questions.Location = new Point(840, 605);
            Deleting_questions.Name = "Deleting_questions";
            Deleting_questions.Size = new Size(310, 56);
            Deleting_questions.TabIndex = 5;
            Deleting_questions.Text = "Deleting questions";
            Deleting_questions.UseVisualStyleBackColor = false;
            Deleting_questions.Click += Deleting_questions_Click;
            // 
            // type_text
            // 
            type_text.DropDownStyle = ComboBoxStyle.DropDownList;
            type_text.Font = new Font("Segoe UI", 18F);
            type_text.FormattingEnabled = true;
            type_text.Items.AddRange(new object[] { "רב-ברירה", "נכון/לא נכון", "השלמת משפטים" });
            type_text.Location = new Point(443, 143);
            type_text.Name = "type_text";
            type_text.Size = new Size(400, 49);
            type_text.TabIndex = 6;
            type_text.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // course_text
            // 
            course_text.AutoCompleteCustomSource.AddRange(new string[] { "חדו\"א", "פיזיקה", "תכנות שפת c" });
            course_text.DropDownStyle = ComboBoxStyle.DropDownList;
            course_text.Font = new Font("Segoe UI", 18F);
            course_text.FormattingEnabled = true;
            course_text.Items.AddRange(new object[] { "חדו\"א", "פיזיקה", "מבוא למדמ\"ח" });
            course_text.Location = new Point(443, 249);
            course_text.Name = "course_text";
            course_text.Size = new Size(400, 49);
            course_text.TabIndex = 7;
            course_text.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // c_a_text
            // 
            c_a_text.Font = new Font("Segoe UI", 18F);
            c_a_text.Location = new Point(443, 346);
            c_a_text.Name = "c_a_text";
            c_a_text.Size = new Size(400, 47);
            c_a_text.TabIndex = 8;
            c_a_text.TextChanged += textBox1_TextChanged;
            // 
            // level_text
            // 
            level_text.DropDownStyle = ComboBoxStyle.DropDownList;
            level_text.Font = new Font("Segoe UI", 18F);
            level_text.FormattingEnabled = true;
            level_text.Items.AddRange(new object[] { "קל", "בינוני", "קשה" });
            level_text.Location = new Point(443, 451);
            level_text.Name = "level_text";
            level_text.Size = new Size(400, 49);
            level_text.TabIndex = 9;
            level_text.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // question_text
            // 
            question_text.Font = new Font("Segoe UI", 18F);
            question_text.Location = new Point(443, 45);
            question_text.Name = "question_text";
            question_text.Size = new Size(400, 47);
            question_text.TabIndex = 10;
            question_text.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Location = new Point(567, 541);
            button1.Name = "button1";
            button1.Size = new Size(166, 47);
            button1.TabIndex = 11;
            button1.Text = "יצירת שאלה";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // InsertingQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 686);
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
    }
}