namespace WinFormsApp1
{
    partial class TestSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvAvailableTests;
        private System.Windows.Forms.ColumnHeader colTestID;
        private System.Windows.Forms.ColumnHeader colTestName;
        private System.Windows.Forms.ColumnHeader colDateCreated;
        private System.Windows.Forms.Button btnTakeSelectedTest;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private CheckedListBox clbCategory;
        private CheckedListBox clbDifficulty;
        private Button btnFilter;
        private void InitializeComponent()
        {
            this.lvAvailableTests = new ListView();
            this.colTestID = new ColumnHeader();
            this.colTestName = new ColumnHeader();
            this.colDateCreated = new ColumnHeader();
            this.btnTakeSelectedTest = new Button();
            this.clbCategory = new CheckedListBox();
            this.clbDifficulty = new CheckedListBox();
            this.btnFilter = new Button();

            // 
            // clbCategory
            // 
            this.clbCategory.Location = new Point(40, 20);
            this.clbCategory.Size = new Size(160, 80);
            this.clbCategory.Font = new Font("Segoe UI", 10F);
            this.clbCategory.BorderStyle = BorderStyle.FixedSingle;
            this.clbCategory.CheckOnClick = true;
            this.clbCategory.Items.AddRange(new object[] {
        "Calculus", "Physics", "Intro to CS"
    });

            // 
            // clbDifficulty
            // 
            this.clbDifficulty.Location = new Point(220, 20);
            this.clbDifficulty.Size = new Size(160, 80);
            this.clbDifficulty.Font = new Font("Segoe UI", 10F);
            this.clbDifficulty.BorderStyle = BorderStyle.FixedSingle;
            this.clbDifficulty.CheckOnClick = true;
            this.clbDifficulty.Items.AddRange(new object[] {
        "Easy", "Intermediate", "Advanced"
    });

            // 
            // btnFilter
            // 
            this.btnFilter.Text = "Apply Filters";
            this.btnFilter.Location = new Point(410, 35);
            this.btnFilter.Size = new Size(150, 35);
            this.btnFilter.BackColor = Color.MediumSeaGreen;
            this.btnFilter.FlatStyle = FlatStyle.Flat;
            this.btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnFilter.ForeColor = Color.White;
            this.btnFilter.Click += new EventHandler(this.btnFilter_Click);

            // 
            // lvAvailableTests
            // 
            this.lvAvailableTests.Columns.AddRange(new ColumnHeader[] {
        this.colTestID,
        this.colTestName,
        this.colDateCreated});
            this.lvAvailableTests.FullRowSelect = true;
            this.lvAvailableTests.GridLines = true;
            this.lvAvailableTests.Location = new Point(40, 120);
            this.lvAvailableTests.MultiSelect = false;
            this.lvAvailableTests.Size = new Size(620, 260);
            this.lvAvailableTests.Font = new Font("Segoe UI", 10F);
            this.lvAvailableTests.View = View.Details;
            this.lvAvailableTests.BorderStyle = BorderStyle.FixedSingle;

            // 
            // colTestID
            // 
            this.colTestID.Text = "Test ID";
            this.colTestID.Width = 80;

            // 
            // colTestName
            // 
            this.colTestName.Text = "Test Name";
            this.colTestName.Width = 220;

            // 
            // colDateCreated
            // 
            this.colDateCreated.Text = "Date Created";
            this.colDateCreated.Width = 180;

            // 
            // btnTakeSelectedTest
            // 
            this.btnTakeSelectedTest.Text = "Take Selected Test";
            this.btnTakeSelectedTest.Location = new Point(240, 400);
            this.btnTakeSelectedTest.Size = new Size(200, 45);
            this.btnTakeSelectedTest.BackColor = Color.SteelBlue;
            this.btnTakeSelectedTest.FlatStyle = FlatStyle.Flat;
            this.btnTakeSelectedTest.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnTakeSelectedTest.ForeColor = Color.White;
            this.btnTakeSelectedTest.Click += new EventHandler(this.btnTakeSelectedTest_Click);
            this.clbCategory.ItemCheck += clbCategory_ItemCheck;
            this.clbDifficulty.ItemCheck += clbDifficulty_ItemCheck;
            // 
            // TestSelectionForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(700, 480);
            this.Controls.Add(this.clbCategory);
            this.Controls.Add(this.clbDifficulty);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnTakeSelectedTest);
            this.Controls.Add(this.lvAvailableTests);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackgroundImage = Properties.Resources.bgCreateTest;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "📚 Select a Test";
            this.ResumeLayout(false);
        }


        #endregion
    }
}
