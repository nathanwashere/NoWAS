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
            dataGridViewQuestions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuestions).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewQuestions
            // 
            dataGridViewQuestions.AllowUserToAddRows = false;
            dataGridViewQuestions.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQuestions.Location = new Point(12, 38);
            dataGridViewQuestions.Name = "dataGridViewQuestions";
            dataGridViewQuestions.ReadOnly = true;
            dataGridViewQuestions.RowHeadersWidth = 51;
            dataGridViewQuestions.Size = new Size(1129, 592);
            dataGridViewQuestions.TabIndex = 0;
            dataGridViewQuestions.CellContentClick += dataGridViewQuestions_CellContentClick;
            // 
            // Deleting_questions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.תמונה_שאלות1;
            ClientSize = new Size(1200, 660);
            Controls.Add(dataGridViewQuestions);
            Name = "Deleting_questions";
            Text = "Deleting_questions";
            Load += Deleting_questions_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuestions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewQuestions;
    }
}