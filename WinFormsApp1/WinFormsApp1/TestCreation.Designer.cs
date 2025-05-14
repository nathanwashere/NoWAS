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

            // Form
            this.SuspendLayout();
            this.Text = "Create New Test";
            this.ClientSize = new System.Drawing.Size(880, 480);
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Title
            this.lblTitle.Text = "Create New Test";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 50;

            // GroupBox: Test Settings
            this.grpTestSettings.Text = "Test Settings";
            this.grpTestSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTestSettings.Location = new System.Drawing.Point(30, 70);
            this.grpTestSettings.Size = new System.Drawing.Size(380, 300);

            // NumericUpDown: Number of Questions
            this.numQuestions.Location = new System.Drawing.Point(20, 30);
            this.numQuestions.Minimum = 1;
            this.numQuestions.Maximum = 100;
            this.numQuestions.Value = 10;

            // Topics
            this.chkTopics.Items.AddRange(new object[] {
                "Algorithms", "Software Testing", "Databases" });
            this.chkTopics.Location = new System.Drawing.Point(20, 70);
            this.chkTopics.Size = new System.Drawing.Size(160, 60);

            // Difficulty
            this.chkDifficulty.Items.AddRange(new object[] {
                "Easy", "Medium", "Hard" });
            this.chkDifficulty.Location = new System.Drawing.Point(200, 70);
            this.chkDifficulty.Size = new System.Drawing.Size(160, 60);

            // Buttons (left)
            this.btnCreate.Text = "Create Test";
            this.btnCreate.Location = new System.Drawing.Point(20, 220);
            this.btnCreate.Size = new System.Drawing.Size(100, 30);

            this.btnAddQuestion.Text = "Add Question";
            this.btnAddQuestion.Location = new System.Drawing.Point(130, 220);
            this.btnAddQuestion.Size = new System.Drawing.Size(100, 30);

            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(240, 220);
            this.btnClear.Size = new System.Drawing.Size(100, 30);

            this.grpTestSettings.Controls.Add(this.numQuestions);
            this.grpTestSettings.Controls.Add(this.chkTopics);
            this.grpTestSettings.Controls.Add(this.chkDifficulty);
            this.grpTestSettings.Controls.Add(this.btnCreate);
            this.grpTestSettings.Controls.Add(this.btnClear);
            this.grpTestSettings.Controls.Add(this.btnAddQuestion);

            // GroupBox: Created Tests
            this.grpCreatedTests.Text = "Created Tests";
            this.grpCreatedTests.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpCreatedTests.Location = new System.Drawing.Point(460, 70);
            this.grpCreatedTests.Size = new System.Drawing.Size(380, 300);

            // ListView
            this.lvTests.Location = new System.Drawing.Point(15, 30);
            this.lvTests.Size = new System.Drawing.Size(350, 200);
            this.lvTests.View = System.Windows.Forms.View.Details;
            this.lvTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colTestID, this.colDate, this.colQuestionCount, this.colTopics });

            this.colTestID.Text = "Test ID";
            this.colTestID.Width = 60;
            this.colDate.Text = "Date Created";
            this.colDate.Width = 90;
            this.colQuestionCount.Text = "Questions";
            this.colQuestionCount.Width = 80;
            this.colTopics.Text = "Topics";
            this.colTopics.Width = 100;

            // Buttons (right)
            this.btnDeleteTest.Text = "Delete Test";
            this.btnDeleteTest.Location = new System.Drawing.Point(15, 240);
            this.btnDeleteTest.Size = new System.Drawing.Size(100, 30);

            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.Location = new System.Drawing.Point(125, 240);
            this.btnViewDetails.Size = new System.Drawing.Size(100, 30);

            this.grpCreatedTests.Controls.Add(this.lvTests);
            this.grpCreatedTests.Controls.Add(this.btnDeleteTest);
            this.grpCreatedTests.Controls.Add(this.btnViewDetails);

            // Add to Form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpTestSettings);
            this.Controls.Add(this.grpCreatedTests);

            this.ResumeLayout(false);
        }
    }
}