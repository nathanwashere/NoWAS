namespace WinFormsApp1
{
    partial class StudentStatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentStatisticsForm));
            dataGridViewResults = new DataGridView();
            comboFilter = new ComboBox();
            labelFilter = new Label();
            labelStats = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResults
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 248, 255);
            dataGridViewResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewResults.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.BackgroundColor = SystemColors.Window;
            dataGridViewResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewResults.ColumnHeadersHeight = 34;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewResults.EnableHeadersVisualStyles = false;
            dataGridViewResults.Font = new Font("Segoe UI", 10F);
            dataGridViewResults.GridColor = Color.LightGray;
            dataGridViewResults.Location = new Point(50, 60);
            dataGridViewResults.Margin = new Padding(10);
            dataGridViewResults.MultiSelect = false;
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.RowHeadersVisible = false;
            dataGridViewResults.RowHeadersWidth = 62;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(1050, 280);
            dataGridViewResults.TabIndex = 0;
            // 
            // comboFilter
            // 
            comboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFilter.Font = new Font("Segoe UI", 10F);
            comboFilter.Location = new Point(180, 430);
            comboFilter.Name = "comboFilter";
            comboFilter.Size = new Size(200, 36);
            comboFilter.TabIndex = 2;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.BackColor = Color.Transparent;
            labelFilter.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            labelFilter.ForeColor = Color.Black;
            labelFilter.Location = new Point(20, 435);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(153, 28);
            labelFilter.TabIndex = 1;
            labelFilter.Text = "Filter by Grades:";
            // 
            // labelStats
            // 
            labelStats.AutoSize = true;
            labelStats.BackColor = Color.Transparent;
            labelStats.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            labelStats.ForeColor = Color.DarkSlateGray;
            labelStats.Location = new Point(460, 390);
            labelStats.Name = "labelStats";
            labelStats.Size = new Size(323, 28);
            labelStats.TabIndex = 0;
            labelStats.Text = "Statistics summary will appear here.";
            // 
            // StudentStatisticsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1150, 520);
            Controls.Add(labelStats);
            Controls.Add(labelFilter);
            Controls.Add(comboFilter);
            Controls.Add(dataGridViewResults);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentStatisticsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Statistics";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private DataGridView dataGridViewResults;
        private ComboBox comboFilter;
        private Label labelFilter;
        private Label labelStats;
    }
}
