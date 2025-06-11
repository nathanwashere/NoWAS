namespace WinFormsApp1
{
    partial class Deleting_questions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deleting_questions));
            dataGridViewQuestions = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuestions).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewQuestions
            // 
            dataGridViewQuestions.AllowUserToAddRows = false;
            dataGridViewQuestions.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQuestions.Location = new Point(0, 2);
            dataGridViewQuestions.Name = "dataGridViewQuestions";
            dataGridViewQuestions.ReadOnly = true;
            dataGridViewQuestions.RowHeadersWidth = 51;
            dataGridViewQuestions.Size = new Size(982, 658);
            dataGridViewQuestions.TabIndex = 0;
            dataGridViewQuestions.CellContentClick += dataGridViewQuestions_CellContentClick;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Blue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            button1.Location = new Point(988, 121);
            button1.Name = "button1";
            button1.Size = new Size(147, 38);
            button1.TabIndex = 1;
            button1.Text = "Back to main";
            button1.UseVisualStyleBackColor = false;
            button1.Click += GoBackToMain_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.Blue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Sitka Text", 9F, FontStyle.Bold);
            button2.Location = new Point(988, 47);
            button2.Name = "button2";
            button2.Size = new Size(147, 36);
            button2.TabIndex = 2;
            button2.Text = "Go Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += GoBack_Click;
            // 
            // Deleting_questions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1247, 685);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewQuestions);
            Name = "Deleting_questions";
            Text = "Deleting_questions";
            Load += Deleting_questions_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuestions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewQuestions;
        private Button button1;
        private Button button2;
    }
}