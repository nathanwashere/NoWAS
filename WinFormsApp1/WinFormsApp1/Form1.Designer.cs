namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelUsername = new Label();
            loginLabel = new Label();
            textBoxUsername = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.Font = new Font("Segoe UI", 15F);
            labelUsername.Location = new Point(113, 139);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(372, 67);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username";
            labelUsername.TextAlign = ContentAlignment.MiddleCenter;
            labelUsername.Click += label1_Click_1;
            // 
            // loginLabel
            // 
            loginLabel.Font = new Font("Segoe UI", 40F);
            loginLabel.Location = new Point(58, 33);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(527, 106);
            loginLabel.TabIndex = 1;
            loginLabel.Text = "Login";
            loginLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(228, 217);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(728, 31);
            textBoxUsername.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 284);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 744);
            Controls.Add(label1);
            Controls.Add(textBoxUsername);
            Controls.Add(loginLabel);
            Controls.Add(labelUsername);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private Label loginLabel;
        private TextBox textBoxUsername;
        private Label label1;
    }
}
