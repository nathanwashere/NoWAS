namespace WinFormsApp1
{
    partial class QuestionSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnConfirm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            checkedListBox1 = new CheckedListBox();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.IntegralHeight = false;
            checkedListBox1.Location = new Point(11, 13);
            checkedListBox1.Margin = new Padding(3, 4, 3, 4);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(548, 373);
            checkedListBox1.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnConfirm.BackColor = Color.DeepSkyBlue;
            btnConfirm.Location = new Point(11, 400);
            btnConfirm.Margin = new Padding(3, 4, 3, 4);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(434, 47);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm Selection";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // QuestionSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bgCreateTest;
            ClientSize = new Size(571, 467);
            Controls.Add(btnConfirm);
            Controls.Add(checkedListBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuestionSelectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Select Questions";
            ResumeLayout(false);
        }
    }
}
