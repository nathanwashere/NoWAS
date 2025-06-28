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
            course.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            course.AutoSize = true;
            course.BackColor = Color.Transparent;
            course.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            course.Location = new Point(27, 156);
            course.Name = "course";
            course.Size = new Size(173, 39);
            course.TabIndex = 0;
            course.Text = "The course:";
            course.Click += course_Click;
            // 
            // level
            // 
            level.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            level.AutoSize = true;
            level.BackColor = Color.Transparent;
            level.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            level.ForeColor = Color.Black;
            level.Location = new Point(27, 305);
            level.Name = "level";
            level.Size = new Size(224, 39);
            level.TabIndex = 1;
            level.Text = "Difficulty level:";
            level.Click += label2_Click;
            // 
            // c_a
            // 
            c_a.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            c_a.AutoSize = true;
            c_a.BackColor = Color.Transparent;
            c_a.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            c_a.Location = new Point(27, 229);
            c_a.Name = "c_a";
            c_a.Size = new Size(230, 39);
            c_a.TabIndex = 2;
            c_a.Text = "Correct answer:";
            c_a.Click += label3_Click;
            // 
            // type
            // 
            type.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            type.AutoSize = true;
            type.BackColor = Color.Transparent;
            type.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            type.Location = new Point(27, 84);
            type.Name = "type";
            type.Size = new Size(213, 39);
            type.TabIndex = 3;
            type.Text = "Question type:";
            type.Click += label1_Click;
            // 
            // question
            // 
            question.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            question.AutoSize = true;
            question.BackColor = Color.Transparent;
            question.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            question.Location = new Point(27, 9);
            question.Name = "question";
            question.Size = new Size(201, 39);
            question.TabIndex = 4;
            question.Text = "The question:";
            question.TextAlign = ContentAlignment.TopCenter;
            question.Click += question_Click;
            // 
            // Deleting_questions
            // 
            Deleting_questions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Deleting_questions.AutoSize = true;
            Deleting_questions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Deleting_questions.BackColor = Color.RoyalBlue;
            Deleting_questions.FlatAppearance.BorderSize = 0;
            Deleting_questions.FlatAppearance.MouseOverBackColor = Color.Blue;
            Deleting_questions.FlatStyle = FlatStyle.Flat;
            Deleting_questions.Font = new Font("Sitka Text", 14F, FontStyle.Bold);
            Deleting_questions.Location = new Point(27, 603);
            Deleting_questions.Name = "Deleting_questions";
            Deleting_questions.Size = new Size(281, 45);
            Deleting_questions.TabIndex = 5;
            Deleting_questions.Text = "Delete/edit questions";
            Deleting_questions.UseVisualStyleBackColor = false;
            Deleting_questions.Click += Deleting_questions_Click;
            Deleting_questions.Resize += Deleting_questions_Resize;
            // 
            // type_text
            // 
            type_text.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            type_text.DropDownStyle = ComboBoxStyle.DropDownList;
            type_text.Font = new Font("Sitka Text", 14F);
            type_text.FormattingEnabled = true;
            type_text.Items.AddRange(new object[] { "Multiple Choice", "True/False", "Sentence Completion" });
            type_text.Location = new Point(371, 82);
            type_text.MinimumSize = new Size(400, 0);
            type_text.Name = "type_text";
            type_text.Size = new Size(400, 41);
            type_text.TabIndex = 6;
            type_text.SelectedIndexChanged += type_text_SelectedIndexChanged;
            // 
            // course_text
            // 
            course_text.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            course_text.AutoCompleteCustomSource.AddRange(new string[] { "חדו\"א", "פיזיקה", "תכנות שפת c" });
            course_text.DropDownStyle = ComboBoxStyle.DropDownList;
            course_text.Font = new Font("Sitka Text", 14F);
            course_text.FormattingEnabled = true;
            course_text.Items.AddRange(new object[] { "Calculus", "Physics ", "Introduction to Computer Science" });
            course_text.Location = new Point(371, 154);
            course_text.MinimumSize = new Size(400, 0);
            course_text.Name = "course_text";
            course_text.Size = new Size(400, 41);
            course_text.TabIndex = 7;
            course_text.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // c_a_text
            // 
            c_a_text.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            c_a_text.Font = new Font("Sitka Text", 14F);
            c_a_text.Location = new Point(371, 231);
            c_a_text.MinimumSize = new Size(400, 37);
            c_a_text.Name = "c_a_text";
            c_a_text.Size = new Size(400, 37);
            c_a_text.TabIndex = 8;
            c_a_text.TextChanged += textBox1_TextChanged;
            // 
            // level_text
            // 
            level_text.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            level_text.DropDownStyle = ComboBoxStyle.DropDownList;
            level_text.Font = new Font("Sitka Text", 14F);
            level_text.FormattingEnabled = true;
            level_text.Items.AddRange(new object[] { "Easy", "Intermediate", "Advanced" });
            level_text.Location = new Point(371, 303);
            level_text.MinimumSize = new Size(400, 0);
            level_text.Name = "level_text";
            level_text.Size = new Size(400, 41);
            level_text.TabIndex = 9;
            level_text.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // question_text
            // 
            question_text.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            question_text.Font = new Font("Sitka Text", 14F);
            question_text.Location = new Point(371, 11);
            question_text.MinimumSize = new Size(400, 37);
            question_text.Name = "question_text";
            question_text.Size = new Size(400, 37);
            question_text.TabIndex = 10;
            question_text.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.PaleGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Lime;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            button1.Location = new Point(451, 602);
            button1.Name = "button1";
            button1.Size = new Size(174, 46);
            button1.TabIndex = 11;
            button1.Text = "Creat question";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.Resize += button1_Resize;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            label1.Location = new Point(27, 372);
            label1.Name = "label1";
            label1.Size = new Size(264, 39);
            label1.TabIndex = 12;
            label1.Text = "Possible answer 1:";
            label1.Visible = false;
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            label2.Location = new Point(27, 439);
            label2.Name = "label2";
            label2.Size = new Size(267, 39);
            label2.TabIndex = 13;
            label2.Text = "Possible answer 2:";
            label2.Visible = false;
            label2.Click += label2_Click_1;
            // 
            // Possible_answer_1
            // 
            Possible_answer_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Possible_answer_1.Font = new Font("Sitka Text", 14F);
            Possible_answer_1.Location = new Point(371, 372);
            Possible_answer_1.MinimumSize = new Size(400, 37);
            Possible_answer_1.Name = "Possible_answer_1";
            Possible_answer_1.Size = new Size(400, 37);
            Possible_answer_1.TabIndex = 14;
            Possible_answer_1.Visible = false;
            Possible_answer_1.TextChanged += Possible_answer_1_TextChanged;
            // 
            // Possible_answer_2
            // 
            Possible_answer_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Possible_answer_2.Font = new Font("Sitka Text", 14F);
            Possible_answer_2.Location = new Point(371, 441);
            Possible_answer_2.MinimumSize = new Size(400, 37);
            Possible_answer_2.Name = "Possible_answer_2";
            Possible_answer_2.Size = new Size(400, 37);
            Possible_answer_2.TabIndex = 15;
            Possible_answer_2.Visible = false;
            Possible_answer_2.TextChanged += textBox2_TextChanged_1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Sitka Text", 16F, FontStyle.Bold);
            label3.Location = new Point(18, 519);
            label3.Name = "label3";
            label3.Size = new Size(267, 39);
            label3.TabIndex = 16;
            label3.Text = "Possible answer 3:";
            label3.Visible = false;
            label3.Click += label3_Click_1;
            // 
            // Possible_answer_3
            // 
            Possible_answer_3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Possible_answer_3.Font = new Font("Sitka Text", 14F);
            Possible_answer_3.Location = new Point(371, 519);
            Possible_answer_3.MinimumSize = new Size(400, 37);
            Possible_answer_3.Name = "Possible_answer_3";
            Possible_answer_3.Size = new Size(400, 37);
            Possible_answer_3.TabIndex = 17;
            Possible_answer_3.Visible = false;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.BackColor = Color.RoyalBlue;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Blue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            button2.Location = new Point(862, 15);
            button2.Name = "button2";
            button2.Size = new Size(116, 45);
            button2.TabIndex = 18;
            button2.Text = "Back to main";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.Resize += button2_Resize;
            // 
            // InsertingQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1015, 659);
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