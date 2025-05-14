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
            dataGridViewResults.Location = new Point(148, 57);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.RowHeadersWidth = 62;
            dataGridViewResults.Size = new Size(944, 225);
            dataGridViewResults.TabIndex = 0;
            dataGridViewResults.CellContentClick += dataGridViewResults_CellContentClick;
            // 
            // comboFilter
            // 
            comboFilter.FormattingEnabled = true;
            comboFilter.Location = new Point(148, 324);
            comboFilter.Name = "comboFilter";
            comboFilter.Size = new Size(182, 33);
            comboFilter.TabIndex = 1;
            // 
            // labelStats
            // 
            labelStats.AutoSize = true;
            labelStats.Location = new Point(148, 408);
            labelStats.Name = "labelStats";
            labelStats.Size = new Size(59, 25);
            labelStats.TabIndex = 2;
            labelStats.Text = "label1";
            // 
            // StudentStatisticsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1441, 815);
            Controls.Add(labelStats);
            Controls.Add(comboFilter);
            Controls.Add(dataGridViewResults);
            Name = "StudentStatisticsForm";
            Text = "StudentStatisticsForm";
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