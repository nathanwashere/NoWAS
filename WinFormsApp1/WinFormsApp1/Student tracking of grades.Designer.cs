namespace WinFormsApp1

{
    partial class Student_tracking_of_grades
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblTitle = new Label();
            grpHistory = new GroupBox();
            dgvHistory = new DataGridView();
            grpAnalysis = new GroupBox();
            chartImprovement = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblAverage = new Label();
            txtAverage = new TextBox();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            grpAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartImprovement).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1143, 100);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "דף מעקב לסטודנט";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // grpHistory
            // 
            grpHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpHistory.Controls.Add(dgvHistory);
            grpHistory.FlatStyle = FlatStyle.System;
            grpHistory.Location = new Point(17, 120);
            grpHistory.Margin = new Padding(4, 5, 4, 5);
            grpHistory.Name = "grpHistory";
            grpHistory.Padding = new Padding(4, 5, 4, 5);
            grpHistory.Size = new Size(714, 500);
            grpHistory.TabIndex = 1;
            grpHistory.TabStop = false;
            grpHistory.Text = "היסטוריית מבחנים וציונים";
            grpHistory.Enter += grpHistory_Enter;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle4;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.Location = new Point(4, 29);
            dgvHistory.Margin = new Padding(4, 5, 4, 5);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersWidth = 62;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(706, 466);
            dgvHistory.TabIndex = 0;
            dgvHistory.CellContentClick += dgvHistory_CellContentClick;
            // 
            // grpAnalysis
            // 
            grpAnalysis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpAnalysis.Controls.Add(chartImprovement);
            grpAnalysis.Controls.Add(lblAverage);
            grpAnalysis.Controls.Add(txtAverage);
            grpAnalysis.Location = new Point(740, 120);
            grpAnalysis.Margin = new Padding(4, 5, 4, 5);
            grpAnalysis.Name = "grpAnalysis";
            grpAnalysis.Padding = new Padding(4, 5, 4, 5);
            grpAnalysis.Size = new Size(386, 500);
            grpAnalysis.TabIndex = 2;
            grpAnalysis.TabStop = false;
            grpAnalysis.Text = "ניתוח ושיפור לאורך זמן";
            grpAnalysis.UseWaitCursor = true;
            grpAnalysis.Enter += grpAnalysis_Enter;
            // 
            // chartImprovement
            // 
            chartImprovement.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartImprovement.Location = new Point(21, 50);
            chartImprovement.Margin = new Padding(4, 5, 4, 5);
            chartImprovement.Name = "chartImprovement";
            chartImprovement.Size = new Size(343, 300);
            chartImprovement.TabIndex = 0;
            chartImprovement.Text = "chartImprovement";
            chartImprovement.UseWaitCursor = true;
            // 
            // lblAverage
            // 
            lblAverage.AutoSize = true;
            lblAverage.Location = new Point(207, 375);
            lblAverage.Margin = new Padding(4, 0, 4, 0);
            lblAverage.Name = "lblAverage";
            lblAverage.Size = new Size(157, 25);
            lblAverage.TabIndex = 1;
            lblAverage.Text = "ממוצע ציונים אישי:";
            lblAverage.UseWaitCursor = true;
            lblAverage.Click += lblAverage_Click;
            // 
            // txtAverage
            // 
            txtAverage.Location = new Point(21, 372);
            txtAverage.Margin = new Padding(4, 5, 4, 5);
            txtAverage.Name = "txtAverage";
            txtAverage.ReadOnly = true;
            txtAverage.Size = new Size(191, 31);
            txtAverage.TabIndex = 2;
            txtAverage.TextAlign = HorizontalAlignment.Center;
            txtAverage.UseWaitCursor = true;
            txtAverage.TextChanged += txtAverage_TextChanged;
            // 
            // Student_tracking_of_grades
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 667);
            Controls.Add(grpAnalysis);
            Controls.Add(grpHistory);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Student_tracking_of_grades";
            Text = "Student View - Grades Analysis";
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            grpAnalysis.ResumeLayout(false);
            grpAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartImprovement).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.GroupBox grpAnalysis;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartImprovement;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.TextBox txtAverage;
    }
}
