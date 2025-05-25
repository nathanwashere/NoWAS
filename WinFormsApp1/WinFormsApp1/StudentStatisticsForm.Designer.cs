namespace WinFormsApp1
{
    partial class StudentStatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewResults = new DataGridView();
            comboFilter = new ComboBox();
            labelStats = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(118, 46);
            dataGridViewResults.Margin = new Padding(2, 2, 2, 2);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.RowHeadersWidth = 62;
            dataGridViewResults.Size = new Size(755, 180);
            dataGridViewResults.TabIndex = 0;
            dataGridViewResults.CellContentClick += dataGridViewResults_CellContentClick;
            // 
            // comboFilter
            // 
            comboFilter.FormattingEnabled = true;
            comboFilter.Location = new Point(118, 259);
            comboFilter.Margin = new Padding(2, 2, 2, 2);
            comboFilter.Name = "comboFilter";
            comboFilter.Size = new Size(146, 28);
            comboFilter.TabIndex = 1;
            // 
            // labelStats
            // 
            labelStats.AutoSize = true;
            labelStats.Location = new Point(118, 326);
            labelStats.Margin = new Padding(2, 0, 2, 0);
            labelStats.Name = "labelStats";
            labelStats.Size = new Size(50, 20);
            labelStats.TabIndex = 2;
            labelStats.Text = "label1";
            // 
            // StudentStatisticsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bgStatistics;
            ClientSize = new Size(1153, 652);
            Controls.Add(labelStats);
            Controls.Add(comboFilter);
            Controls.Add(dataGridViewResults);
            Margin = new Padding(2, 2, 2, 2);
            Name = "StudentStatisticsForm";
            Text = "StudentStatisticsForm";
            Load += StudentStatisticsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewResults;
        private ComboBox comboFilter;
        private Label labelStats;
    }
}