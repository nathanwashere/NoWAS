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

        private void InitializeComponent()
        {
            this.lvAvailableTests = new System.Windows.Forms.ListView();
            this.colTestID = new System.Windows.Forms.ColumnHeader();
            this.colTestName = new System.Windows.Forms.ColumnHeader();
            this.colDateCreated = new System.Windows.Forms.ColumnHeader();
            this.btnTakeSelectedTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvAvailableTests
            // 
            this.lvAvailableTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTestID,
            this.colTestName,
            this.colDateCreated});
            this.lvAvailableTests.FullRowSelect = true;
            this.lvAvailableTests.GridLines = true;
            this.lvAvailableTests.HideSelection = false;
            this.lvAvailableTests.Location = new System.Drawing.Point(30, 30);
            this.lvAvailableTests.MultiSelect = false;
            this.lvAvailableTests.Name = "lvAvailableTests";
            this.lvAvailableTests.Size = new System.Drawing.Size(600, 300);
            this.lvAvailableTests.TabIndex = 0;
            this.lvAvailableTests.UseCompatibleStateImageBehavior = false;
            this.lvAvailableTests.View = System.Windows.Forms.View.Details;
            // 
            // colTestID
            // 
            this.colTestID.Text = "Test ID";
            this.colTestID.Width = 80;
            // 
            // colTestName
            // 
            this.colTestName.Text = "Test Name";
            this.colTestName.Width = 200;
            // 
            // colDateCreated
            // 
            this.colDateCreated.Text = "Date Created";
            this.colDateCreated.Width = 150;
            // 
            // btnTakeSelectedTest
            // 
            this.btnTakeSelectedTest.Location = new System.Drawing.Point(260, 350);
            this.btnTakeSelectedTest.Name = "btnTakeSelectedTest";
            this.btnTakeSelectedTest.Size = new System.Drawing.Size(150, 40);
            this.btnTakeSelectedTest.TabIndex = 1;
            this.btnTakeSelectedTest.Text = "Take Selected Test";
            this.btnTakeSelectedTest.UseVisualStyleBackColor = true;
            this.btnTakeSelectedTest.Click += new System.EventHandler(this.btnTakeSelectedTest_Click);
            // 
            // TestSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 420);
            this.Controls.Add(this.btnTakeSelectedTest);
            this.Controls.Add(this.lvAvailableTests);
            this.Name = "TestSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select a Test to Take";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
