namespace WinFormsApp1
{
    partial class QuestionSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private CheckedListBox checkedListBox1;
        private Button btnConfirm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(400, 300);
            this.checkedListBox1.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfirm.Location = new System.Drawing.Point(0, 310);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(400, 40);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm Selection";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // QuestionSelectionForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnConfirm);
            this.Name = "QuestionSelectionForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Select Questions";
            this.ResumeLayout(false);
        }
    }
}
