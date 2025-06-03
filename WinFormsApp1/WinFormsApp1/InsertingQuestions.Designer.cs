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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertingQuestions));
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
            button2 = new Button();
            SuspendLayout();
            // 
            // course
            // 
            course.AutoSize = true;
            course.BackColor = Color.Transparent;
            course.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            course.Location = new Point(29, 199);
            course.Name = "course";
            course.Size = new Size(162, 37);
            course.TabIndex = 0;
            course.Text = "The course:";
            course.Click += course_Click;
            // 
            // level
            // 
            level.AutoSize = true;
            level.BackColor = Color.Transparent;
            level.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            level.ForeColor = Color.Black;
            level.Location = new Point(29, 375);
            level.Name = "level";
            level.Size = new Size(211, 37);
            level.TabIndex = 1;
            level.Text = "Difficulty level:";
            level.Click += label2_Click;
            // 
            // c_a
            // 
            c_a.AutoSize = true;
            c_a.BackColor = Color.Transparent;
            c_a.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            c_a.Location = new Point(20, 288);
            c_a.Name = "c_a";
            c_a.Size = new Size(218, 37);
            c_a.TabIndex = 2;
            c_a.Text = "Correct answer:";
            c_a.Click += label3_Click;
            // 
            // type
            // 
            type.AutoSize = true;
            type.BackColor = Color.Transparent;
            type.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            type.Location = new Point(29, 113);
            type.Name = "type";
            type.Size = new Size(204, 37);
            type.TabIndex = 3;
            type.Text = "Question type:";
            type.Click += label1_Click;
            // 
            // question
            // 
            question.AutoSize = true;
            question.BackColor = Color.Transparent;
            question.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            question.Location = new Point(29, 38);
            question.Name = "question";
            question.Size = new Size(190, 37);
            question.TabIndex = 4;
            question.Text = "The question:";
            question.TextAlign = ContentAlignment.TopCenter;
            question.Click += question_Click;
            // 
            // Deleting_questions
            // 
            Deleting_questions.AutoSize = true;
            Deleting_questions.BackColor = Color.RoyalBlue;
            Deleting_questions.FlatAppearance.BorderSize = 0;
            Deleting_questions.FlatAppearance.MouseOverBackColor = Color.Blue;
            Deleting_questions.FlatStyle = FlatStyle.Flat;
            Deleting_questions.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Deleting_questions.Location = new Point(1047, 717);
            Deleting_questions.Name = "Deleting_questions";
            Deleting_questions.Size = new Size(272, 44);
            Deleting_questions.TabIndex = 5;
            Deleting_questions.Text = "Delete/edit questions";
            Deleting_questions.UseVisualStyleBackColor = false;
            Deleting_questions.Click += Deleting_questions_Click;
            // 
            // type_text
            // 
            type_text.DropDownStyle = ComboBoxStyle.DropDownList;
            type_text.Font = new Font("Segoe UI", 14F);
            type_text.FormattingEnabled = true;
            type_text.Items.AddRange(new object[] { "Multiple Choice", "True/False", "Sentence Completion" });
            type_text.Location = new Point(373, 111);
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
            course_text.Items.AddRange(new object[] { "Calculus", "Physics ", "Introduction to Computer Science" });
            course_text.Location = new Point(373, 197);
            course_text.Name = "course_text";
            course_text.Size = new Size(400, 39);
            course_text.TabIndex = 7;
            course_text.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // c_a_text
            // 
            c_a_text.Font = new Font("Segoe UI", 14F);
            c_a_text.Location = new Point(373, 290);
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
            level_text.Location = new Point(373, 377);
            level_text.Name = "level_text";
            level_text.Size = new Size(400, 39);
            level_text.TabIndex = 9;
            level_text.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // question_text
            // 
            question_text.Font = new Font("Segoe UI", 14F);
            question_text.Location = new Point(373, 36);
            question_text.Name = "question_text";
            question_text.Size = new Size(400, 39);
            question_text.TabIndex = 10;
            question_text.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Lime;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(458, 717);
            button1.Name = "button1";
            button1.Size = new Size(214, 47);
            button1.TabIndex = 11;
            button1.Text = "Creat a question";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(29, 462);
            label1.Name = "label1";
            label1.Size = new Size(250, 37);
            label1.TabIndex = 12;
            label1.Text = "Possible answer 1:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.Location = new Point(29, 555);
            label2.Name = "label2";
            label2.Size = new Size(250, 37);
            label2.TabIndex = 13;
            label2.Text = "Possible answer 2:";
            label2.Visible = false;
            label2.Click += label2_Click_1;
            // 
            // Possible_answer_1
            // 
            Possible_answer_1.Font = new Font("Segoe UI", 14F);
            Possible_answer_1.Location = new Point(373, 464);
            Possible_answer_1.Name = "Possible_answer_1";
            Possible_answer_1.Size = new Size(400, 39);
            Possible_answer_1.TabIndex = 14;
            Possible_answer_1.Visible = false;
            // 
            // Possible_answer_2
            // 
            Possible_answer_2.Font = new Font("Segoe UI", 14F);
            Possible_answer_2.Location = new Point(373, 555);
            Possible_answer_2.Name = "Possible_answer_2";
            Possible_answer_2.Size = new Size(400, 39);
            Possible_answer_2.TabIndex = 15;
            Possible_answer_2.Visible = false;
            Possible_answer_2.TextChanged += textBox2_TextChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.Location = new Point(29, 637);
            label3.Name = "label3";
            label3.Size = new Size(250, 37);
            label3.TabIndex = 16;
            label3.Text = "Possible answer 3:";
            label3.Visible = false;
            // 
            // Possible_answer_3
            // 
            Possible_answer_3.Font = new Font("Segoe UI", 14F);
            Possible_answer_3.Location = new Point(373, 639);
            Possible_answer_3.Name = "Possible_answer_3";
            Possible_answer_3.Size = new Size(400, 39);
            Possible_answer_3.TabIndex = 17;
            Possible_answer_3.Visible = false;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Blue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(1144, 36);
            button2.Name = "button2";
            button2.Size = new Size(153, 39);
            button2.TabIndex = 18;
            button2.Text = "Back to main";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // InsertingQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1348, 776);
            Controls.Add(button2);
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
        private Button button2;
    }
}