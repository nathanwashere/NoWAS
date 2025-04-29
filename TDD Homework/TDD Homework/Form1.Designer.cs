namespace TDD_Homework
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
        ///  the contents of     method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelHome = new Panel();
            buttonCreateCarRandom = new Button();
            buttonCreateCarManual = new Button();
            buttonShowCars = new Button();
            panelManual = new Panel();
            buttonGoBackToMainFromManual = new Button();
            labelMaintenanceCarValidation = new Label();
            labelTypeCarValidation = new Label();
            labelYearCarValidation = new Label();
            labelManufactorCarValidation = new Label();
            labelModelCarValidation = new Label();
            labelNumberCarValidation = new Label();
            buttonEnterCarData = new Button();
            panelGroupRadio2 = new Panel();
            radioButtonCareIsRequired = new RadioButton();
            radioButtonProper = new RadioButton();
            panelGroupRadio1 = new Panel();
            radioButtonPrivate = new RadioButton();
            radioButtonBus = new RadioButton();
            radioButtonCommercial = new RadioButton();
            radioButtonTruck = new RadioButton();
            labelMaintenanceStatus = new Label();
            labelAddType = new Label();
            textBoxAddYear = new TextBox();
            labelAddYear = new Label();
            textBoxAddManufactor = new TextBox();
            labelAddManufactor = new Label();
            textBoxAddModel = new TextBox();
            labelAddModel = new Label();
            textBoxAddNumberCar = new TextBox();
            labelAddCarsNumer = new Label();
            panelHome.SuspendLayout();
            panelManual.SuspendLayout();
            panelGroupRadio2.SuspendLayout();
            panelGroupRadio1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHome
            // 
            panelHome.BackgroundImage = (Image)resources.GetObject("panelHome.BackgroundImage");
            panelHome.BackgroundImageLayout = ImageLayout.Stretch;
            panelHome.Controls.Add(buttonCreateCarRandom);
            panelHome.Controls.Add(buttonCreateCarManual);
            panelHome.Controls.Add(buttonShowCars);
            panelHome.Dock = DockStyle.Fill;
            panelHome.Location = new Point(0, 0);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(1369, 763);
            panelHome.TabIndex = 2;
            // 
            // buttonCreateCarRandom
            // 
            buttonCreateCarRandom.BackColor = Color.LightSteelBlue;
            buttonCreateCarRandom.Font = new Font("David", 40F, FontStyle.Bold);
            buttonCreateCarRandom.Location = new Point(486, 627);
            buttonCreateCarRandom.Name = "buttonCreateCarRandom";
            buttonCreateCarRandom.Size = new Size(364, 110);
            buttonCreateCarRandom.TabIndex = 28;
            buttonCreateCarRandom.Text = "Random";
            buttonCreateCarRandom.UseVisualStyleBackColor = false;
            buttonCreateCarRandom.Click += buttonCreateRandom_Click;
            // 
            // buttonCreateCarManual
            // 
            buttonCreateCarManual.BackColor = Color.LightSteelBlue;
            buttonCreateCarManual.Font = new Font("David", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCreateCarManual.Location = new Point(49, 626);
            buttonCreateCarManual.Name = "buttonCreateCarManual";
            buttonCreateCarManual.Size = new Size(305, 110);
            buttonCreateCarManual.TabIndex = 27;
            buttonCreateCarManual.Text = "Create";
            buttonCreateCarManual.UseVisualStyleBackColor = false;
            buttonCreateCarManual.Click += buttonCreateCarManual_Click;
            // 
            // buttonShowCars
            // 
            buttonShowCars.BackColor = Color.LightSteelBlue;
            buttonShowCars.Font = new Font("David", 40F, FontStyle.Bold);
            buttonShowCars.Location = new Point(923, 625);
            buttonShowCars.Name = "buttonShowCars";
            buttonShowCars.Size = new Size(409, 111);
            buttonShowCars.TabIndex = 26;
            buttonShowCars.Text = "Show cars";
            buttonShowCars.UseVisualStyleBackColor = false;
            buttonShowCars.Click += buttonShowCars_Click;
            // 
            // panelManual
            // 
            panelManual.BackgroundImage = (Image)resources.GetObject("panelManual.BackgroundImage");
            panelManual.BackgroundImageLayout = ImageLayout.Stretch;
            panelManual.Controls.Add(buttonGoBackToMainFromManual);
            panelManual.Controls.Add(labelMaintenanceCarValidation);
            panelManual.Controls.Add(labelTypeCarValidation);
            panelManual.Controls.Add(labelYearCarValidation);
            panelManual.Controls.Add(labelManufactorCarValidation);
            panelManual.Controls.Add(labelModelCarValidation);
            panelManual.Controls.Add(labelNumberCarValidation);
            panelManual.Controls.Add(buttonEnterCarData);
            panelManual.Controls.Add(panelGroupRadio2);
            panelManual.Controls.Add(panelGroupRadio1);
            panelManual.Controls.Add(labelMaintenanceStatus);
            panelManual.Controls.Add(labelAddType);
            panelManual.Controls.Add(textBoxAddYear);
            panelManual.Controls.Add(labelAddYear);
            panelManual.Controls.Add(textBoxAddManufactor);
            panelManual.Controls.Add(labelAddManufactor);
            panelManual.Controls.Add(textBoxAddModel);
            panelManual.Controls.Add(labelAddModel);
            panelManual.Controls.Add(textBoxAddNumberCar);
            panelManual.Controls.Add(labelAddCarsNumer);
            panelManual.Dock = DockStyle.Fill;
            panelManual.Location = new Point(0, 0);
            panelManual.Name = "panelManual";
            panelManual.Size = new Size(1369, 763);
            panelManual.TabIndex = 2;
            // 
            // buttonGoBackToMainFromManual
            // 
            buttonGoBackToMainFromManual.BackColor = Color.LightSteelBlue;
            buttonGoBackToMainFromManual.Font = new Font("David", 40F, FontStyle.Bold);
            buttonGoBackToMainFromManual.Location = new Point(1011, 40);
            buttonGoBackToMainFromManual.Name = "buttonGoBackToMainFromManual";
            buttonGoBackToMainFromManual.Size = new Size(227, 123);
            buttonGoBackToMainFromManual.TabIndex = 26;
            buttonGoBackToMainFromManual.Text = "Back";
            buttonGoBackToMainFromManual.UseVisualStyleBackColor = false;
            buttonGoBackToMainFromManual.Click += buttonGoBackToMainFromManual_Click;
            // 
            // labelMaintenanceCarValidation
            // 
            labelMaintenanceCarValidation.AutoSize = true;
            labelMaintenanceCarValidation.BackColor = Color.Transparent;
            labelMaintenanceCarValidation.Font = new Font("Segoe UI", 12F);
            labelMaintenanceCarValidation.Location = new Point(951, 590);
            labelMaintenanceCarValidation.Name = "labelMaintenanceCarValidation";
            labelMaintenanceCarValidation.Size = new Size(0, 32);
            labelMaintenanceCarValidation.TabIndex = 25;
            // 
            // labelTypeCarValidation
            // 
            labelTypeCarValidation.AutoSize = true;
            labelTypeCarValidation.BackColor = Color.Transparent;
            labelTypeCarValidation.Font = new Font("Segoe UI", 12F);
            labelTypeCarValidation.Location = new Point(907, 476);
            labelTypeCarValidation.Name = "labelTypeCarValidation";
            labelTypeCarValidation.Size = new Size(0, 32);
            labelTypeCarValidation.TabIndex = 24;
            // 
            // labelYearCarValidation
            // 
            labelYearCarValidation.AutoSize = true;
            labelYearCarValidation.BackColor = Color.Transparent;
            labelYearCarValidation.Font = new Font("Segoe UI", 12F);
            labelYearCarValidation.Location = new Point(818, 381);
            labelYearCarValidation.Name = "labelYearCarValidation";
            labelYearCarValidation.Size = new Size(0, 32);
            labelYearCarValidation.TabIndex = 23;
            // 
            // labelManufactorCarValidation
            // 
            labelManufactorCarValidation.AutoSize = true;
            labelManufactorCarValidation.BackColor = Color.Transparent;
            labelManufactorCarValidation.Font = new Font("Segoe UI", 12F);
            labelManufactorCarValidation.Location = new Point(678, 280);
            labelManufactorCarValidation.Name = "labelManufactorCarValidation";
            labelManufactorCarValidation.Size = new Size(0, 32);
            labelManufactorCarValidation.TabIndex = 22;
            // 
            // labelModelCarValidation
            // 
            labelModelCarValidation.AutoSize = true;
            labelModelCarValidation.BackColor = Color.Transparent;
            labelModelCarValidation.Font = new Font("Segoe UI", 12F);
            labelModelCarValidation.Location = new Point(555, 162);
            labelModelCarValidation.Name = "labelModelCarValidation";
            labelModelCarValidation.Size = new Size(0, 32);
            labelModelCarValidation.TabIndex = 21;
            // 
            // labelNumberCarValidation
            // 
            labelNumberCarValidation.AutoSize = true;
            labelNumberCarValidation.BackColor = Color.Transparent;
            labelNumberCarValidation.Font = new Font("Segoe UI", 12F);
            labelNumberCarValidation.Location = new Point(575, 47);
            labelNumberCarValidation.Name = "labelNumberCarValidation";
            labelNumberCarValidation.Size = new Size(0, 32);
            labelNumberCarValidation.TabIndex = 20;
            // 
            // buttonEnterCarData
            // 
            buttonEnterCarData.BackColor = Color.LightSteelBlue;
            buttonEnterCarData.Font = new Font("David", 40F, FontStyle.Bold);
            buttonEnterCarData.Location = new Point(12, 644);
            buttonEnterCarData.Name = "buttonEnterCarData";
            buttonEnterCarData.Size = new Size(276, 75);
            buttonEnterCarData.TabIndex = 19;
            buttonEnterCarData.Text = "Enter";
            buttonEnterCarData.UseVisualStyleBackColor = false;
            buttonEnterCarData.Click += buttonEnterCarData_Click;
            // 
            // panelGroupRadio2
            // 
            panelGroupRadio2.BackColor = Color.Transparent;
            panelGroupRadio2.Controls.Add(radioButtonCareIsRequired);
            panelGroupRadio2.Controls.Add(radioButtonProper);
            panelGroupRadio2.Location = new Point(480, 548);
            panelGroupRadio2.Name = "panelGroupRadio2";
            panelGroupRadio2.Size = new Size(437, 95);
            panelGroupRadio2.TabIndex = 18;
            // 
            // radioButtonCareIsRequired
            // 
            radioButtonCareIsRequired.AutoSize = true;
            radioButtonCareIsRequired.BackColor = Color.Transparent;
            radioButtonCareIsRequired.Font = new Font("Segoe UI", 15F);
            radioButtonCareIsRequired.ForeColor = Color.Linen;
            radioButtonCareIsRequired.Location = new Point(6, 19);
            radioButtonCareIsRequired.Name = "radioButtonCareIsRequired";
            radioButtonCareIsRequired.Size = new Size(251, 45);
            radioButtonCareIsRequired.TabIndex = 14;
            radioButtonCareIsRequired.TabStop = true;
            radioButtonCareIsRequired.Text = "Care is required";
            radioButtonCareIsRequired.UseVisualStyleBackColor = false;
            // 
            // radioButtonProper
            // 
            radioButtonProper.AutoSize = true;
            radioButtonProper.BackColor = Color.Transparent;
            radioButtonProper.Font = new Font("Segoe UI", 15F);
            radioButtonProper.ForeColor = Color.Linen;
            radioButtonProper.Location = new Point(263, 19);
            radioButtonProper.Name = "radioButtonProper";
            radioButtonProper.Size = new Size(132, 45);
            radioButtonProper.TabIndex = 15;
            radioButtonProper.TabStop = true;
            radioButtonProper.Text = "Proper";
            radioButtonProper.UseVisualStyleBackColor = false;
            // 
            // panelGroupRadio1
            // 
            panelGroupRadio1.BackColor = Color.Transparent;
            panelGroupRadio1.Controls.Add(radioButtonPrivate);
            panelGroupRadio1.Controls.Add(radioButtonBus);
            panelGroupRadio1.Controls.Add(radioButtonCommercial);
            panelGroupRadio1.Controls.Add(radioButtonTruck);
            panelGroupRadio1.Location = new Point(313, 429);
            panelGroupRadio1.Name = "panelGroupRadio1";
            panelGroupRadio1.Size = new Size(562, 104);
            panelGroupRadio1.TabIndex = 17;
            // 
            // radioButtonPrivate
            // 
            radioButtonPrivate.AutoSize = true;
            radioButtonPrivate.BackColor = Color.Transparent;
            radioButtonPrivate.Font = new Font("Segoe UI", 15F);
            radioButtonPrivate.ForeColor = Color.Linen;
            radioButtonPrivate.Location = new Point(3, 40);
            radioButtonPrivate.Name = "radioButtonPrivate";
            radioButtonPrivate.Size = new Size(132, 45);
            radioButtonPrivate.TabIndex = 9;
            radioButtonPrivate.TabStop = true;
            radioButtonPrivate.Text = "Private";
            radioButtonPrivate.UseVisualStyleBackColor = false;
            // 
            // radioButtonBus
            // 
            radioButtonBus.AutoSize = true;
            radioButtonBus.BackColor = Color.Transparent;
            radioButtonBus.Font = new Font("Segoe UI", 15F);
            radioButtonBus.ForeColor = Color.Linen;
            radioButtonBus.Location = new Point(466, 40);
            radioButtonBus.Name = "radioButtonBus";
            radioButtonBus.Size = new Size(90, 45);
            radioButtonBus.TabIndex = 12;
            radioButtonBus.TabStop = true;
            radioButtonBus.Text = "Bus";
            radioButtonBus.UseVisualStyleBackColor = false;
            // 
            // radioButtonCommercial
            // 
            radioButtonCommercial.AutoSize = true;
            radioButtonCommercial.BackColor = Color.Transparent;
            radioButtonCommercial.Font = new Font("Segoe UI", 15F);
            radioButtonCommercial.ForeColor = Color.Linen;
            radioButtonCommercial.Location = new Point(141, 40);
            radioButtonCommercial.Name = "radioButtonCommercial";
            radioButtonCommercial.Size = new Size(201, 45);
            radioButtonCommercial.TabIndex = 10;
            radioButtonCommercial.TabStop = true;
            radioButtonCommercial.Text = "Commercial";
            radioButtonCommercial.UseVisualStyleBackColor = false;
            // 
            // radioButtonTruck
            // 
            radioButtonTruck.AutoSize = true;
            radioButtonTruck.BackColor = Color.Transparent;
            radioButtonTruck.Font = new Font("Segoe UI", 15F);
            radioButtonTruck.ForeColor = Color.Linen;
            radioButtonTruck.Location = new Point(348, 40);
            radioButtonTruck.Name = "radioButtonTruck";
            radioButtonTruck.Size = new Size(112, 45);
            radioButtonTruck.TabIndex = 11;
            radioButtonTruck.TabStop = true;
            radioButtonTruck.Text = "Truck";
            radioButtonTruck.UseVisualStyleBackColor = false;
            // 
            // labelMaintenanceStatus
            // 
            labelMaintenanceStatus.BackColor = Color.Transparent;
            labelMaintenanceStatus.Font = new Font("Segoe UI", 25F);
            labelMaintenanceStatus.ForeColor = Color.Linen;
            labelMaintenanceStatus.Location = new Point(29, 548);
            labelMaintenanceStatus.Name = "labelMaintenanceStatus";
            labelMaintenanceStatus.Size = new Size(472, 76);
            labelMaintenanceStatus.TabIndex = 13;
            labelMaintenanceStatus.Text = "Maintenance status: ";
            // 
            // labelAddType
            // 
            labelAddType.BackColor = Color.Transparent;
            labelAddType.Font = new Font("Segoe UI", 25F);
            labelAddType.ForeColor = Color.Linen;
            labelAddType.Location = new Point(29, 455);
            labelAddType.Name = "labelAddType";
            labelAddType.Size = new Size(304, 91);
            labelAddType.TabIndex = 8;
            labelAddType.Text = "Type of car : ";
            // 
            // textBoxAddYear
            // 
            textBoxAddYear.Font = new Font("Segoe UI", 15F);
            textBoxAddYear.Location = new Point(595, 366);
            textBoxAddYear.Name = "textBoxAddYear";
            textBoxAddYear.Size = new Size(160, 47);
            textBoxAddYear.TabIndex = 7;
            // 
            // labelAddYear
            // 
            labelAddYear.BackColor = Color.Transparent;
            labelAddYear.Font = new Font("Segoe UI", 25F);
            labelAddYear.ForeColor = Color.Linen;
            labelAddYear.Location = new Point(29, 346);
            labelAddYear.Name = "labelAddYear";
            labelAddYear.Size = new Size(560, 76);
            labelAddYear.TabIndex = 6;
            labelAddYear.Text = "Add year (2000-2025) :";
            // 
            // textBoxAddManufactor
            // 
            textBoxAddManufactor.Font = new Font("Segoe UI", 15F);
            textBoxAddManufactor.Location = new Point(495, 264);
            textBoxAddManufactor.Name = "textBoxAddManufactor";
            textBoxAddManufactor.Size = new Size(160, 47);
            textBoxAddManufactor.TabIndex = 5;
            // 
            // labelAddManufactor
            // 
            labelAddManufactor.BackColor = Color.Transparent;
            labelAddManufactor.Font = new Font("Segoe UI", 25F);
            labelAddManufactor.ForeColor = Color.Linen;
            labelAddManufactor.Location = new Point(29, 246);
            labelAddManufactor.Name = "labelAddManufactor";
            labelAddManufactor.Size = new Size(445, 67);
            labelAddManufactor.TabIndex = 4;
            labelAddManufactor.Text = "Manufactor of car : ";
            // 
            // textBoxAddModel
            // 
            textBoxAddModel.Font = new Font("Segoe UI", 15F);
            textBoxAddModel.Location = new Point(389, 152);
            textBoxAddModel.Name = "textBoxAddModel";
            textBoxAddModel.Size = new Size(160, 47);
            textBoxAddModel.TabIndex = 3;
            // 
            // labelAddModel
            // 
            labelAddModel.BackColor = Color.Transparent;
            labelAddModel.Font = new Font("Segoe UI", 25F);
            labelAddModel.ForeColor = Color.Linen;
            labelAddModel.Location = new Point(29, 133);
            labelAddModel.Name = "labelAddModel";
            labelAddModel.Size = new Size(336, 88);
            labelAddModel.TabIndex = 2;
            labelAddModel.Text = "Model of car :";
            // 
            // textBoxAddNumberCar
            // 
            textBoxAddNumberCar.BorderStyle = BorderStyle.None;
            textBoxAddNumberCar.Font = new Font("Segoe UI", 15F);
            textBoxAddNumberCar.ForeColor = Color.Black;
            textBoxAddNumberCar.Location = new Point(409, 42);
            textBoxAddNumberCar.Name = "textBoxAddNumberCar";
            textBoxAddNumberCar.Size = new Size(160, 40);
            textBoxAddNumberCar.TabIndex = 1;
            // 
            // labelAddCarsNumer
            // 
            labelAddCarsNumer.BackColor = Color.Transparent;
            labelAddCarsNumer.Font = new Font("Segoe UI", 25F);
            labelAddCarsNumer.ForeColor = Color.Linen;
            labelAddCarsNumer.Location = new Point(29, 24);
            labelAddCarsNumer.Name = "labelAddCarsNumer";
            labelAddCarsNumer.Size = new Size(384, 90);
            labelAddCarsNumer.TabIndex = 0;
            labelAddCarsNumer.Text = "Number of car : ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1369, 763);
            Controls.Add(panelHome);
            Controls.Add(panelManual);
            Name = "Form1";
            Text = "Need my speedie speedie";
            panelHome.ResumeLayout(false);
            panelManual.ResumeLayout(false);
            panelManual.PerformLayout();
            panelGroupRadio2.ResumeLayout(false);
            panelGroupRadio2.PerformLayout();
            panelGroupRadio1.ResumeLayout(false);
            panelGroupRadio1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelHome;
        private Panel panelManual;
        private Label labelAddCarsNumer;
        private TextBox textBoxAddNumberCar;
        private Label labelAddModel;
        private TextBox textBoxAddModel;
        private Label labelAddManufactor;
        private Label labelAddYear;
        private TextBox textBoxAddManufactor;
        private Label labelAddType;
        private TextBox textBoxAddYear;
        private RadioButton radioButtonBus;
        private RadioButton radioButtonTruck;
        private RadioButton radioButtonCommercial;
        private RadioButton radioButtonPrivate;
        private Label labelMaintenanceStatus;
        private RadioButton radioButtonProper;
        private RadioButton radioButtonCareIsRequired;
        private Panel panelGroupRadio1;
        private Panel panelGroupRadio2;
        private Button buttonEnterCarData;
        private Label labelMaintenanceCarValidation;
        private Label labelTypeCarValidation;
        private Label labelYearCarValidation;
        private Label labelManufactorCarValidation;
        private Label labelModelCarValidation;
        private Label labelNumberCarValidation;
        private Button buttonShowCars;
        private Button buttonGoBackToMainFromManual;
        private Button buttonCreateCarRandom;
        private Button buttonCreateCarManual;
    }
}
