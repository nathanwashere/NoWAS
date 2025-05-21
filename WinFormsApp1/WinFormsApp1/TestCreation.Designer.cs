namespace WinFormsApp1
{
    partial class TestCreation
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpTestSettings;
        private System.Windows.Forms.GroupBox grpCreatedTests;

        private System.Windows.Forms.NumericUpDown numQuestions;
        private System.Windows.Forms.CheckedListBox chkTopics;
        private System.Windows.Forms.CheckedListBox chkDifficulty;

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddQuestion;

        private System.Windows.Forms.ListView lvTests;
        private System.Windows.Forms.ColumnHeader colTestID;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colQuestionCount;
        private System.Windows.Forms.ColumnHeader colTopics;

        private System.Windows.Forms.Button btnDeleteTest;
        private System.Windows.Forms.Button btnViewDetails;

        private System.Windows.Forms.ListBox lstSelectedQuestions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            grpTestSettings = new GroupBox();
            numQuestions = new NumericUpDown();
            chkTopics = new CheckedListBox();
            chkDifficulty = new CheckedListBox();
            btnCreate = new Button();
            btnClear = new Button();
            btnAddQuestion = new Button();
            grpCreatedTests = new GroupBox();
            lvTests = new ListView();
            colTestID = new ColumnHeader();
            colDate = new ColumnHeader();
            colQuestionCount = new ColumnHeader();
            colTopics = new ColumnHeader();
            btnDeleteTest = new Button();
            btnViewDetails = new Button();
            lstSelectedQuestions = new ListBox();
            button1 = new Button();
            grpTestSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuestions).BeginInit();
            grpCreatedTests.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(999, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create New Test";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpTestSettings
            // 
            grpTestSettings.Controls.Add(button1);
            grpTestSettings.Controls.Add(numQuestions);
            grpTestSettings.Controls.Add(chkTopics);
            grpTestSettings.Controls.Add(chkDifficulty);
            grpTestSettings.Controls.Add(btnCreate);
            grpTestSettings.Controls.Add(btnClear);
            grpTestSettings.Controls.Add(btnAddQuestion);
            grpTestSettings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpTestSettings.Location = new Point(30, 70);
            grpTestSettings.Name = "grpTestSettings";
            grpTestSettings.Size = new Size(420, 360);
            grpTestSettings.TabIndex = 1;
            grpTestSettings.TabStop = false;
            grpTestSettings.Text = "Test Settings";
            // 
            // numQuestions
            // 
            numQuestions.Location = new Point(20, 30);
            numQuestions.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuestions.Name = "numQuestions";
            numQuestions.Size = new Size(120, 34);
            numQuestions.TabIndex = 0;
            numQuestions.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // chkTopics
            // 
            chkTopics.Items.AddRange(new object[] { "Algorithms", "Software Testing", "Databases" });
            chkTopics.Location = new Point(20, 80);
            chkTopics.Name = "chkTopics";
            chkTopics.Size = new Size(170, 97);
            chkTopics.TabIndex = 1;
            // 
            // chkDifficulty
            // 
            chkDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            chkDifficulty.Location = new Point(210, 80);
            chkDifficulty.Name = "chkDifficulty";
            chkDifficulty.Size = new Size(170, 97);
            chkDifficulty.TabIndex = 2;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(20, 200);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(120, 40);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create Test";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(280, 200);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 40);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Location = new Point(150, 200);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(120, 40);
            btnAddQuestion.TabIndex = 5;
            btnAddQuestion.Text = "Add Question";
            btnAddQuestion.UseVisualStyleBackColor = true;
            btnAddQuestion.Click += btnAddQuestion_Click;
            // 
            // grpCreatedTests
            // 
            grpCreatedTests.Controls.Add(lvTests);
            grpCreatedTests.Controls.Add(btnDeleteTest);
            grpCreatedTests.Controls.Add(btnViewDetails);
            grpCreatedTests.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpCreatedTests.Location = new Point(470, 70);
            grpCreatedTests.Name = "grpCreatedTests";
            grpCreatedTests.Size = new Size(484, 360);
            grpCreatedTests.TabIndex = 2;
            grpCreatedTests.TabStop = false;
            grpCreatedTests.Text = "Created Tests";
            // 
            // lvTests
            // 
            lvTests.Columns.AddRange(new ColumnHeader[] { colTestID, colDate, colQuestionCount, colTopics });
            lvTests.FullRowSelect = true;
            lvTests.Location = new Point(15, 30);
            lvTests.Name = "lvTests";
            lvTests.Size = new Size(448, 250);
            lvTests.TabIndex = 0;
            lvTests.UseCompatibleStateImageBehavior = false;
            lvTests.View = View.Details;
            // 
            // colTestID
            // 
            colTestID.Text = "Test ID";
            colTestID.Width = 80;
            // 
            // colDate
            // 
            colDate.Text = "Date Created";
            colDate.Width = 120;
            // 
            // colQuestionCount
            // 
            colQuestionCount.Text = "Questions";
            colQuestionCount.Width = 80;
            // 
            // colTopics
            // 
            colTopics.Text = "Topics";
            colTopics.Width = 120;
            // 
            // btnDeleteTest
            // 
            btnDeleteTest.Location = new Point(15, 300);
            btnDeleteTest.Name = "btnDeleteTest";
            btnDeleteTest.Size = new Size(120, 40);
            btnDeleteTest.TabIndex = 1;
            btnDeleteTest.Text = "Delete Test";
            btnDeleteTest.UseVisualStyleBackColor = true;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Location = new Point(145, 300);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(120, 40);
            btnViewDetails.TabIndex = 2;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = true;
            // 
            // lstSelectedQuestions
            // 
            lstSelectedQuestions.FormattingEnabled = true;
            lstSelectedQuestions.ItemHeight = 25;
            lstSelectedQuestions.Location = new Point(30, 450);
            lstSelectedQuestions.Name = "lstSelectedQuestions";
            lstSelectedQuestions.Size = new Size(920, 79);
            lstSelectedQuestions.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(20, 266);
            button1.Name = "button1";
            button1.Size = new Size(120, 36);
            button1.TabIndex = 6;
            button1.Text = "Take Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TestCreation
            // 
            BackColor = Color.White;
            ClientSize = new Size(999, 580);
            Controls.Add(lblTitle);
            Controls.Add(grpTestSettings);
            Controls.Add(grpCreatedTests);
            Controls.Add(lstSelectedQuestions);
            Name = "TestCreation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create New Test";
            grpTestSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuestions).EndInit();
            grpCreatedTests.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Button button1;
    }
}
