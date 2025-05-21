namespace WinFormsApp1
{
    partial class StudentTracking
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProgress;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelHighestScore;
        private System.Windows.Forms.Label lblHighestScore;
        private System.Windows.Forms.Panel panelLowestScore;
        private System.Windows.Forms.Label lblLowestScore;
        private System.Windows.Forms.Panel panelRecentTrend;
        private System.Windows.Forms.Label lblRecentTrend;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbFilterPeriod;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.TabPage tabPageAnalytics;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dgvHistory = new DataGridView();
            chartProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblAverage = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panelHeader = new Panel();
            lblHeaderSubtitle = new Label();
            picLogo = new PictureBox();
            panelStats = new Panel();
            panelHighestScore = new Panel();
            lblHighestScore = new Label();
            panelLowestScore = new Panel();
            lblLowestScore = new Label();
            panelRecentTrend = new Panel();
            lblRecentTrend = new Label();
            btnRefresh = new Button();
            cmbFilterPeriod = new ComboBox();
            tabControlMain = new TabControl();
            tabPageHistory = new TabPage();
            panelSearch = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            tabPageAnalytics = new TabPage();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            progressBar = new ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartProgress).BeginInit();
            panel1.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelStats.SuspendLayout();
            panelHighestScore.SuspendLayout();
            panelLowestScore.SuspendLayout();
            panelRecentTrend.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageHistory.SuspendLayout();
            panelSearch.SuspendLayout();
            tabPageAnalytics.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.BackgroundColor = Color.FromArgb(40, 40, 43);
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(78, 93, 148);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(78, 93, 148);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.ColumnHeadersHeight = 40;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(114, 137, 218);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.GridColor = Color.FromArgb(55, 55, 55);
            dgvHistory.Location = new Point(6, 66);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 30;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(114, 137, 218);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvHistory.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.RowTemplate.Height = 30;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(956, 446);
            dgvHistory.TabIndex = 0;
            // 
            // chartProgress
            // 
            chartProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartProgress.BackColor = Color.FromArgb(45, 45, 48);
            chartArea1.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartArea1.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisX.LineColor = Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64);
            chartArea1.AxisX.Title = "Assessment Date";
            chartArea1.AxisX.TitleFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartArea1.AxisX.TitleForeColor = Color.White;
            chartArea1.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartArea1.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea1.AxisY.LineColor = Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64);
            chartArea1.AxisY.Title = "Score (%)";
            chartArea1.AxisY.TitleFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chartArea1.AxisY.TitleForeColor = Color.White;
            chartArea1.BackColor = Color.FromArgb(45, 45, 48);
            chartArea1.Name = "ChartArea1";
            chartProgress.ChartAreas.Add(chartArea1);
            legend1.BackColor = Color.FromArgb(45, 45, 48);
            legend1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            legend1.ForeColor = Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            chartProgress.Legends.Add(legend1);
            chartProgress.Location = new Point(15, 175);
            chartProgress.Name = "chartProgress";
            series1.BorderColor = Color.FromArgb(114, 137, 218);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Color = Color.FromArgb(114, 137, 218);
            series1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            series1.Legend = "Legend1";
            series1.LegendText = "Individual Scores";
            series1.MarkerBorderColor = Color.White;
            series1.MarkerColor = Color.White;
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Scores";
            series1.ShadowColor = Color.Black;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.FromArgb(255, 193, 7);
            series2.Legend = "Legend1";
            series2.LegendText = "Average Trend";
            series2.Name = "TrendLine";
            chartProgress.Series.Add(series1);
            chartProgress.Series.Add(series2);
            chartProgress.Size = new Size(930, 320);
            chartProgress.TabIndex = 1;
            chartProgress.Text = "Progress Chart";
            // 
            // lblAverage
            // 
            lblAverage.Dock = DockStyle.Fill;
            lblAverage.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAverage.ForeColor = Color.White;
            lblAverage.Location = new Point(0, 0);
            lblAverage.Name = "lblAverage";
            lblAverage.Size = new Size(220, 90);
            lblAverage.TabIndex = 2;
            lblAverage.Text = "Average Score\r\n85.7%";
            lblAverage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(78, 93, 148);
            panel1.Controls.Add(lblAverage);
            panel1.Location = new Point(15, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 90);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(45, 45, 48);
            panel2.Location = new Point(12, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(976, 535);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(60, 0);
            label1.Name = "label1";
            label1.Size = new Size(395, 45);
            label1.TabIndex = 4;
            label1.Text = "Student Progress Tracker";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(78, 93, 148);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(lblHeaderSubtitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 60);
            panelHeader.TabIndex = 6;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeaderSubtitle.ForeColor = Color.WhiteSmoke;
            lblHeaderSubtitle.Location = new Point(62, 37);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(345, 28);
            lblHeaderSubtitle.TabIndex = 5;
            lblHeaderSubtitle.Text = "Monitor and analyze student performance";
            // 
            // panelStats
            // 
            panelStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelStats.BackColor = Color.FromArgb(50, 50, 53);
            panelStats.Controls.Add(panel1);
            panelStats.Controls.Add(panelHighestScore);
            panelStats.Controls.Add(panelLowestScore);
            panelStats.Controls.Add(panelRecentTrend);
            panelStats.Location = new Point(6, 10);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(956, 120);
            panelStats.TabIndex = 2;
            // 
            // panelHighestScore
            // 
            panelHighestScore.BackColor = Color.FromArgb(46, 125, 50);
            panelHighestScore.Controls.Add(lblHighestScore);
            panelHighestScore.Location = new Point(250, 15);
            panelHighestScore.Name = "panelHighestScore";
            panelHighestScore.Size = new Size(220, 90);
            panelHighestScore.TabIndex = 4;
            // 
            // lblHighestScore
            // 
            lblHighestScore.Dock = DockStyle.Fill;
            lblHighestScore.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHighestScore.ForeColor = Color.White;
            lblHighestScore.Location = new Point(0, 0);
            lblHighestScore.Name = "lblHighestScore";
            lblHighestScore.Size = new Size(220, 90);
            lblHighestScore.TabIndex = 2;
            lblHighestScore.Text = "Highest Score\r\n98.0";
            lblHighestScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLowestScore
            // 
            panelLowestScore.BackColor = Color.FromArgb(211, 47, 47);
            panelLowestScore.Controls.Add(lblLowestScore);
            panelLowestScore.Location = new Point(485, 15);
            panelLowestScore.Name = "panelLowestScore";
            panelLowestScore.Size = new Size(220, 90);
            panelLowestScore.TabIndex = 5;
            // 
            // lblLowestScore
            // 
            lblLowestScore.Dock = DockStyle.Fill;
            lblLowestScore.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLowestScore.ForeColor = Color.White;
            lblLowestScore.Location = new Point(0, 0);
            lblLowestScore.Name = "lblLowestScore";
            lblLowestScore.Size = new Size(220, 90);
            lblLowestScore.TabIndex = 2;
            lblLowestScore.Text = "Lowest Score\r\n65.0";
            lblLowestScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelRecentTrend
            // 
            panelRecentTrend.BackColor = Color.FromArgb(121, 85, 163);
            panelRecentTrend.Controls.Add(lblRecentTrend);
            panelRecentTrend.Location = new Point(720, 15);
            panelRecentTrend.Name = "panelRecentTrend";
            panelRecentTrend.Size = new Size(220, 90);
            panelRecentTrend.TabIndex = 6;
            // 
            // lblRecentTrend
            // 
            lblRecentTrend.Dock = DockStyle.Fill;
            lblRecentTrend.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentTrend.ForeColor = Color.White;
            lblRecentTrend.Location = new Point(0, 0);
            lblRecentTrend.Name = "lblRecentTrend";
            lblRecentTrend.Size = new Size(220, 90);
            lblRecentTrend.TabIndex = 2;
            lblRecentTrend.Text = "Recent Trend\r\n↑ 8.5%";
            lblRecentTrend.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(78, 93, 148);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(916, 142);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(30, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "↻";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // cmbFilterPeriod
            // 
            cmbFilterPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilterPeriod.BackColor = Color.FromArgb(30, 33, 36);
            cmbFilterPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPeriod.FlatStyle = FlatStyle.Flat;
            cmbFilterPeriod.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFilterPeriod.ForeColor = Color.White;
            cmbFilterPeriod.FormattingEnabled = true;
            cmbFilterPeriod.Items.AddRange(new object[] { "Last Week", "Last Month", "Last Quarter", "Last Year", "All Time" });
            cmbFilterPeriod.Location = new Point(770, 142);
            cmbFilterPeriod.Name = "cmbFilterPeriod";
            cmbFilterPeriod.Size = new Size(140, 36);
            cmbFilterPeriod.TabIndex = 3;
            // 
            // tabControlMain
            // 
            tabControlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlMain.Controls.Add(tabPageHistory);
            tabControlMain.Controls.Add(tabPageAnalytics);
            tabControlMain.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControlMain.ItemSize = new Size(120, 25);
            tabControlMain.Location = new Point(12, 70);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new Point(10, 3);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(976, 550);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 7;
            // 
            // tabPageHistory
            // 
            tabPageHistory.BackColor = Color.FromArgb(45, 45, 48);
            tabPageHistory.Controls.Add(panelSearch);
            tabPageHistory.Controls.Add(dgvHistory);
            tabPageHistory.Location = new Point(4, 29);
            tabPageHistory.Name = "tabPageHistory";
            tabPageHistory.Padding = new Padding(3);
            tabPageHistory.Size = new Size(968, 517);
            tabPageHistory.TabIndex = 0;
            tabPageHistory.Text = "Score History";
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearch.BackColor = Color.FromArgb(50, 50, 53);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Location = new Point(6, 10);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(5);
            panelSearch.Size = new Size(956, 50);
            panelSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(30, 33, 36);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Silver;
            txtSearch.Location = new Point(10, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(850, 39);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search by test name";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(78, 93, 148);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(866, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(93, 35);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // tabPageAnalytics
            // 
            tabPageAnalytics.BackColor = Color.FromArgb(45, 45, 48);
            tabPageAnalytics.Controls.Add(panelStats);
            tabPageAnalytics.Controls.Add(chartProgress);
            tabPageAnalytics.Controls.Add(cmbFilterPeriod);
            tabPageAnalytics.Controls.Add(btnRefresh);
            tabPageAnalytics.Location = new Point(4, 29);
            tabPageAnalytics.Name = "tabPageAnalytics";
            tabPageAnalytics.Padding = new Padding(3);
            tabPageAnalytics.Size = new Size(968, 517);
            tabPageAnalytics.TabIndex = 1;
            tabPageAnalytics.Text = "Analytics";
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(30, 33, 36);
            statusStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, progressBar });
            statusStrip.Location = new Point(0, 608);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1000, 32);
            statusStrip.TabIndex = 8;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.ForeColor = Color.White;
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(181, 25);
            statusLabel.Text = "Ready | Last updated:";
            // 
            // progressBar
            // 
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 24);
            progressBar.Visible = false;
            // 
            // StudentTracking
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 33, 36);
            ClientSize = new Size(1000, 640);
            Controls.Add(statusStrip);
            Controls.Add(tabControlMain);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(900, 600);
            Name = "StudentTracking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Progress Tracking";
            FormClosed += StudentTracking_FormClosed;
            Load += StudentTracking_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartProgress).EndInit();
            panel1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelStats.ResumeLayout(false);
            panelHighestScore.ResumeLayout(false);
            panelLowestScore.ResumeLayout(false);
            panelRecentTrend.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageHistory.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            tabPageAnalytics.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}