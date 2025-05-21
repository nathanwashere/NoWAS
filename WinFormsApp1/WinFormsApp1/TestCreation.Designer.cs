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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpTestSettings = new System.Windows.Forms.GroupBox();
            this.numQuestions = new System.Windows.Forms.NumericUpDown();
            this.chkTopics = new System.Windows.Forms.CheckedListBox();
            this.chkDifficulty = new System.Windows.Forms.CheckedListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.grpCreatedTests = new System.Windows.Forms.GroupBox();
            this.lvTests = new System.Windows.Forms.ListView();
            this.colTestID = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colQuestionCount = new System.Windows.Forms.ColumnHeader();
            this.colTopics = new System.Windows.Forms.ColumnHeader();
            this.btnDeleteTest = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.lstSelectedQuestions = new System.Windows.Forms.ListBox();

            this.grpTestSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).BeginInit();
            this.grpCreatedTests.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(999, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create New Test";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // grpTestSettings
            this.grpTestSettings.Controls.Add(this.numQuestions);
            this.grpTestSettings.Controls.Add(this.chkTopics);
            this.grpTestSettings.Controls.Add(this.chkDifficulty);
            this.grpTestSettings.Controls.Add(this.btnCreate);
            this.grpTestSettings.Controls.Add(this.btnClear);
            this.grpTestSettings.Controls.Add(this.btnAddQuestion);
            this.grpTestSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTestSettings.Location = new System.Drawing.Point(30, 70);
            this.grpTestSettings.Name = "grpTestSettings";
            this.grpTestSettings.Size = new System.Drawing.Size(420, 360);
            this.grpTestSettings.TabIndex = 1;
            this.grpTestSettings.TabStop = false;
            this.grpTestSettings.Text = "Test Settings";

            // numQuestions
            this.numQuestions.Location = new System.Drawing.Point(20, 30);
            this.numQuestions.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuestions.Name = "numQuestions";
            this.numQuestions.Size = new System.Drawing.Size(120, 30);
            this.numQuestions.TabIndex = 0;
            this.numQuestions.Value = new decimal(new int[] { 10, 0, 0, 0 });

            // chkTopics
            this.chkTopics.Items.AddRange(new object[] { "Algorithms", "Software Testing", "Databases" });
            this.chkTopics.Location = new System.Drawing.Point(20, 80);
            this.chkTopics.Name = "chkTopics";
            this.chkTopics.Size = new System.Drawing.Size(170, 100);
            this.chkTopics.TabIndex = 1;

            // chkDifficulty
            this.chkDifficulty.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            this.chkDifficulty.Location = new System.Drawing.Point(210, 80);
            this.chkDifficulty.Name = "chkDifficulty";
            this.chkDifficulty.Size = new System.Drawing.Size(170, 100);
            this.chkDifficulty.TabIndex = 2;

            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(20, 200);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(120, 40);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create Test";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // btnAddQuestion
            this.btnAddQuestion.Location = new System.Drawing.Point(150, 200);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(120, 40);
            this.btnAddQuestion.TabIndex = 5;
            this.btnAddQuestion.Text = "Add Question";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(280, 200);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;

            // grpCreatedTests
            this.grpCreatedTests.Controls.Add(this.lvTests);
            this.grpCreatedTests.Controls.Add(this.btnDeleteTest);
            this.grpCreatedTests.Controls.Add(this.btnViewDetails);
            this.grpCreatedTests.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpCreatedTests.Location = new System.Drawing.Point(470, 70);
            this.grpCreatedTests.Name = "grpCreatedTests";
            this.grpCreatedTests.Size = new System.Drawing.Size(484, 360);
            this.grpCreatedTests.TabIndex = 2;
            this.grpCreatedTests.TabStop = false;
            this.grpCreatedTests.Text = "Created Tests";

            // lvTests
            this.lvTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colTestID, this.colDate, this.colQuestionCount, this.colTopics });
            this.lvTests.Location = new System.Drawing.Point(15, 30);
            this.lvTests.Name = "lvTests";
            this.lvTests.Size = new System.Drawing.Size(448, 250);
            this.lvTests.TabIndex = 0;
            this.lvTests.UseCompatibleStateImageBehavior = false;
            this.lvTests.View = System.Windows.Forms.View.Details;
            this.lvTests.FullRowSelect = true;

            // colTestID
            this.colTestID.Text = "Test ID";
            this.colTestID.Width = 80;

            // colDate
            this.colDate.Text = "Date Created";
            this.colDate.Width = 120;

            // colQuestionCount
            this.colQuestionCount.Text = "Questions";
            this.colQuestionCount.Width = 80;

            // colTopics
            this.colTopics.Text = "Topics";
            this.colTopics.Width = 120;

            // btnDeleteTest
            this.btnDeleteTest.Location = new System.Drawing.Point(15, 300);
            this.btnDeleteTest.Name = "btnDeleteTest";
            this.btnDeleteTest.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteTest.TabIndex = 1;
            this.btnDeleteTest.Text = "Delete Test";
            this.btnDeleteTest.UseVisualStyleBackColor = true;

            // btnViewDetails
            this.btnViewDetails.Location = new System.Drawing.Point(145, 300);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 40);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;

            // lstSelectedQuestions
            this.lstSelectedQuestions.FormattingEnabled = true;
            this.lstSelectedQuestions.Location = new System.Drawing.Point(30, 450);
            this.lstSelectedQuestions.Name = "lstSelectedQuestions";
            this.lstSelectedQuestions.Size = new System.Drawing.Size(920, 100);
            this.lstSelectedQuestions.TabIndex = 3;

            // TestCreation
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 580);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpTestSettings);
            this.Controls.Add(this.grpCreatedTests);
            this.Controls.Add(this.lstSelectedQuestions);
            this.Name = "TestCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Test";

            this.grpTestSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).EndInit();
            this.grpCreatedTests.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
