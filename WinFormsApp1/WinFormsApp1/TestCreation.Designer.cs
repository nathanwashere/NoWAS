namespace WinFormsApp1
{
    partial class TestCreation
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpTestSettings;
        private System.Windows.Forms.GroupBox grpCreatedTests;
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
            AutomaticTest = new Button();
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
            backToMainbtn = new Button();
            grpTestSettings.SuspendLayout();
            grpCreatedTests.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.LightSkyBlue;
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
            grpTestSettings.BackColor = Color.SkyBlue;
            grpTestSettings.Controls.Add(AutomaticTest);
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
            // AutomaticTest
            // 
            AutomaticTest.Location = new Point(20, 221);
            AutomaticTest.Name = "AutomaticTest";
            AutomaticTest.Size = new Size(380, 43);
            AutomaticTest.TabIndex = 6;
            AutomaticTest.Text = "Create Automatic random test";
            AutomaticTest.UseVisualStyleBackColor = true;
            AutomaticTest.Click += AutomaticTest_Click;
            // 
            // chkTopics
            // 
            chkTopics.CheckOnClick = true;
            chkTopics.Items.AddRange(new object[] { "Calculus", "Physics", "Intro to CS" });
            chkTopics.Location = new Point(20, 48);
            chkTopics.Name = "chkTopics";
            chkTopics.Size = new Size(170, 79);
            chkTopics.TabIndex = 1;
            chkTopics.ItemCheck += chkTopics_ItemCheck;
            // 
            // chkDifficulty
            // 
            chkDifficulty.CheckOnClick = true;
            chkDifficulty.Items.AddRange(new object[] { "Easy", "Intermediate", "Advanced" });
            chkDifficulty.Location = new Point(212, 48);
            chkDifficulty.Name = "chkDifficulty";
            chkDifficulty.Size = new Size(170, 79);
            chkDifficulty.TabIndex = 2;
            chkDifficulty.ItemCheck += chkDifficulty_ItemCheck;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(20, 164);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(120, 40);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create Test";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(280, 164);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 40);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnAddQuestion
            // 
            btnAddQuestion.Location = new Point(154, 164);
            btnAddQuestion.Name = "btnAddQuestion";
            btnAddQuestion.Size = new Size(120, 40);
            btnAddQuestion.TabIndex = 5;
            btnAddQuestion.Text = "Add Question";
            btnAddQuestion.UseVisualStyleBackColor = true;
            btnAddQuestion.Click += btnAddQuestion_Click;
            // 
            // grpCreatedTests
            // 
            grpCreatedTests.BackColor = Color.SkyBlue;
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
            btnDeleteTest.Click += BtnDeleteTest_click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Location = new Point(145, 300);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(120, 40);
            btnViewDetails.TabIndex = 2;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = true;
            btnViewDetails.Click += BtnViewDetails_click;
            // 
            // lstSelectedQuestions
            // 
            lstSelectedQuestions.BackColor = Color.LightSkyBlue;
            lstSelectedQuestions.FormattingEnabled = true;
            lstSelectedQuestions.Location = new Point(30, 450);
            lstSelectedQuestions.Name = "lstSelectedQuestions";
            lstSelectedQuestions.Size = new Size(920, 44);
            lstSelectedQuestions.TabIndex = 3;
            // 
            // backToMainbtn
            // 
            backToMainbtn.ForeColor = Color.Black;
            backToMainbtn.Location = new Point(834, 528);
            backToMainbtn.Name = "backToMainbtn";
            backToMainbtn.Size = new Size(120, 40);
            backToMainbtn.TabIndex = 6;
            backToMainbtn.Text = "Back to main";
            backToMainbtn.UseVisualStyleBackColor = true;
            backToMainbtn.Click += btnBackToMain_Click;
            // 
            // TestCreation
            // 
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.bgCreateTest;
            ClientSize = new Size(999, 580);
            Controls.Add(backToMainbtn);
            Controls.Add(lblTitle);
            Controls.Add(grpTestSettings);
            Controls.Add(grpCreatedTests);
            Controls.Add(lstSelectedQuestions);
            Name = "TestCreation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create New Test";
            grpTestSettings.ResumeLayout(false);
            grpCreatedTests.ResumeLayout(false);
            ResumeLayout(false);
        }



        private Button backToMainbtn;
        private Button AutomaticTest;
    }
}
