namespace TDD_Homework
{
    partial class DataGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGrid));
            dataGridView1 = new DataGridView();
            labelAmountOfCars = new Label();
            labelCarYearAverage = new Label();
            labelCareIsRequiredAmount = new Label();
            labelRunningTimeSort = new Label();
            labelRunningTimeAverage = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-2, 298);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1511, 583);
            dataGridView1.TabIndex = 0;
            // 
            // labelAmountOfCars
            // 
            labelAmountOfCars.AutoSize = true;
            labelAmountOfCars.Font = new Font("Segoe UI", 15F);
            labelAmountOfCars.Location = new Point(34, 22);
            labelAmountOfCars.Name = "labelAmountOfCars";
            labelAmountOfCars.Size = new Size(235, 41);
            labelAmountOfCars.TabIndex = 1;
            labelAmountOfCars.Text = "Amount of cars: ";
            // 
            // labelCarYearAverage
            // 
            labelCarYearAverage.AutoSize = true;
            labelCarYearAverage.Font = new Font("Segoe UI", 15F);
            labelCarYearAverage.Location = new Point(34, 76);
            labelCarYearAverage.Name = "labelCarYearAverage";
            labelCarYearAverage.Size = new Size(200, 41);
            labelCarYearAverage.TabIndex = 2;
            labelCarYearAverage.Text = "Year average: ";
            // 
            // labelCareIsRequiredAmount
            // 
            labelCareIsRequiredAmount.AutoSize = true;
            labelCareIsRequiredAmount.Font = new Font("Segoe UI", 15F);
            labelCareIsRequiredAmount.Location = new Point(34, 129);
            labelCareIsRequiredAmount.Name = "labelCareIsRequiredAmount";
            labelCareIsRequiredAmount.Size = new Size(241, 41);
            labelCareIsRequiredAmount.TabIndex = 3;
            labelCareIsRequiredAmount.Text = "Care is required: ";
            // 
            // labelRunningTimeSort
            // 
            labelRunningTimeSort.AutoSize = true;
            labelRunningTimeSort.Font = new Font("Segoe UI", 15F);
            labelRunningTimeSort.Location = new Point(395, 22);
            labelRunningTimeSort.Name = "labelRunningTimeSort";
            labelRunningTimeSort.Size = new Size(305, 41);
            labelRunningTimeSort.TabIndex = 4;
            labelRunningTimeSort.Text = "Running time of sort: ";
            // 
            // labelRunningTimeAverage
            // 
            labelRunningTimeAverage.AutoSize = true;
            labelRunningTimeAverage.Font = new Font("Segoe UI", 15F);
            labelRunningTimeAverage.Location = new Point(395, 76);
            labelRunningTimeAverage.Name = "labelRunningTimeAverage";
            labelRunningTimeAverage.Size = new Size(358, 41);
            labelRunningTimeAverage.TabIndex = 5;
            labelRunningTimeAverage.Text = "Running time of average: ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(912, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(588, 240);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // DataGrid
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1512, 883);
            Controls.Add(pictureBox1);
            Controls.Add(labelRunningTimeAverage);
            Controls.Add(labelRunningTimeSort);
            Controls.Add(labelCareIsRequiredAmount);
            Controls.Add(labelCarYearAverage);
            Controls.Add(labelAmountOfCars);
            Controls.Add(dataGridView1);
            Name = "DataGrid";
            Text = "Table for drifters";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label labelAmountOfCars;
        private Label labelCarYearAverage;
        private Label labelCareIsRequiredAmount;
        private Label labelRunningTimeSort;
        private Label labelRunningTimeAverage;
        private PictureBox pictureBox1;
    }
}