using System.Media;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TDD_Homework
{
    public partial class Form1 : Form
    {
        private const int MinYear = 2000;
        private const int MaxYear = 2025;
        private const int BatchSize = 10000;
        private int maxId = 0;
        private List<Car> cars = new List<Car>();

        public Form1()
        {
            InitializeComponent();

            byte[] soundBytes = Properties.Resources.Bandoleros;
            using (MemoryStream ms = new MemoryStream(soundBytes))
            {
                SoundPlayer player = new SoundPlayer(ms);
                player.Play();
            }

        }
        private bool checkNumber(int num)
        {
            bool decider = true;

            foreach(Car car in cars)
            {
                if (car.ID == num)
                {
                    decider = false;
                    break;
                }
            }
            return decider;
        }
        private bool validateInput()
        {
            bool decider = true;
            TextBox[] text = { textBoxAddNumberCar , textBoxAddModel,
                             textBoxAddManufactor,textBoxAddYear };

            #region loop in text box
            foreach (TextBox word in text)
            {
                if (word == textBoxAddNumberCar)
                {
                    if (string.IsNullOrWhiteSpace(word.Text) ||
                        !int.TryParse(word.Text, out int number))
                    {
                        labelNumberCarValidation.Text = "Invalid input";
                        labelNumberCarValidation.ForeColor = Color.Red;
                        decider = false;
                    }
                    else
                    {
                        if (!checkNumber(int.Parse(word.Text)))
                        {
                            labelNumberCarValidation.Text = "Invalid input";
                            labelNumberCarValidation.ForeColor = Color.Red;
                            decider = false;
                        }
                        else
                        {
                            labelNumberCarValidation.Text = " ";
                        }                      
                    }
                }
                else if (word == textBoxAddModel)
                {
                    if (string.IsNullOrWhiteSpace(word.Text) ||
                        !int.TryParse(word.Text, out int number))
                    {
                        labelModelCarValidation.Text = "Invalid input";
                        labelModelCarValidation.ForeColor = Color.Red;
                        decider = false;
                    }
                    else
                    {
                        labelModelCarValidation.Text = " ";
                    }
                }
                else if (word == textBoxAddManufactor)
                {
                    if (string.IsNullOrWhiteSpace(word.Text) || int.TryParse(word.Text, out int number)
                        || word.Text.Any(char.IsDigit))
                    {
                        labelManufactorCarValidation.Text = "Invalid input";
                        labelManufactorCarValidation.ForeColor = Color.Red;
                        decider = false;
                    }
                    //else if (int.TryParse(word.Text, out int number))
                    //{
                    //    labelManufactorCarValidation.Text = "Number can not be a model";
                    //    labelManufactorCarValidation.ForeColor = Color.Red;
                    //    decider = false;
                    //}
                    //else if (word.Text.Any(char.IsDigit))
                    //{
                    //    labelManufactorCarValidation.Text = "Manufatcor is without digits";
                    //    labelManufactorCarValidation.ForeColor = Color.Red;
                    //    decider = false;
                    //}
                    else
                    {
                        labelManufactorCarValidation.Text = " ";
                    }
                }
                else if (word == textBoxAddYear)
                {
                    if (string.IsNullOrWhiteSpace(word.Text) || !int.TryParse(word.Text, out int number)
                        || int.Parse(word.Text) < 2000 || int.Parse(word.Text) > 2025)
                    {
                        labelYearCarValidation.Text = "Invalid input";
                        labelYearCarValidation.ForeColor = Color.Red;
                        decider = false;
                    }
                    //else if (!int.TryParse(word.Text, out int number))
                    //{
                    //    labelYearCarValidation.Text = "Word can not be a year";
                    //    labelYearCarValidation.ForeColor = Color.Red;
                    //    decider = false;
                    //}
                    else
                    {
                        labelYearCarValidation.Text = " ";
                    }

                }
            }
            #endregion
            bool temp = false;
            #region loop first group radio
            foreach (Control control in panelGroupRadio1.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        temp = true;
                        break;
                    }
                }
            }
            if (!temp)
            {
                decider = false;
                labelTypeCarValidation.Text = "One is required";
                labelTypeCarValidation.ForeColor = Color.Red;
            }
            else
            {
                labelTypeCarValidation.Text = " ";
            }
            #endregion
            temp = false;
            #region loop second group radio
            foreach (Control control in panelGroupRadio2.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        temp = true;
                        break;
                    }
                }
            }
            if (!temp)
            {
                decider = false;
                labelMaintenanceCarValidation.Text = "One is required";
                labelMaintenanceCarValidation.ForeColor = Color.Red;
            }
            else
            {
                labelMaintenanceCarValidation.Text = " ";
            }
            #endregion
            return decider;
        }
        private void cleanInputBox()
        {
            foreach (Control c in panelManual.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
            foreach (Control c in panelGroupRadio1.Controls)
            {
                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
            }
            foreach (Control c in panelGroupRadio2.Controls)
            {
                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonEnterCarData_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                return;
            }
            // Get text from textboxes
            string idText = textBoxAddNumberCar.Text;
            string modelText = textBoxAddModel.Text;
            string manufactor = textBoxAddManufactor.Text;
            string yearText = textBoxAddYear.Text;

            // Convert to int where needed
            int id = int.TryParse(idText, out int parsedId) ? parsedId : 0;
            int year = int.TryParse(yearText, out int parsedYear) ? parsedYear : 0;
            int model = int.TryParse(modelText, out int parsedModel) ? parsedModel : 0;

            // Determine selected car type
            string type = "";
            if (radioButtonPrivate.Checked)
                type = "Private";
            else if (radioButtonCommercial.Checked)
                type = "Commercial";
            else if (radioButtonTruck.Checked)
                type = "Truck";
            else if (radioButtonBus.Checked)
                type = "Bus";

            // Determine maintenance status
            string maintenance = radioButtonProper.Checked ? "Proper" :
                                 radioButtonCareIsRequired.Checked ? "Care is required" : "";

            // Create Car instance
            Car car = new Car(id, model, manufactor, year, type, maintenance);

            // Adding Car instance to list
            cars.Add(car);

            // Clean all TextBox
            cleanInputBox();

        }
        private void buttonShowCars_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
       
            foreach (Car car in cars)
            {
                sb.Append(car.ToString() + "\n");
            }
            DataGrid form2 = new DataGrid(cars);
            form2.Show();


            sb.Clear();
        }
        private void buttonGoBackToMainFromManual_Click(object sender, EventArgs e)
        {
            panelManual.Visible = false;
            panelHome.Visible = true;
        }
        private void buttonCreateCarManual_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelManual.Visible = true;
        }
        private void buttonCreateRandom_Click(object sender, EventArgs e)
        {
            // Expand the pool
            maxId += BatchSize;     // now maxId = 2000, then 3000, etc.

            var rnd = new Random();
            string[] manufactors = { "Mazda", "Mizubishi", "Fort", "Suzuki", "Audi", "Kia", "BMW" };
            string[] types = { "Private", "Commercial", "Truck", "Bus" };
            string[] maintenanceOpts = { "Proper", "Care is required" };

            for (int i = 0; i < BatchSize; i++)   // loop exactly 1000 times
            {
                int idCar;
                // keep retrying until you find a free ID
                do
                {
                    idCar = rnd.Next(0, maxId);
                }
                while (!checkNumber(idCar));

                int modelCar = rnd.Next(0, 1001);
                string mfr = manufactors[rnd.Next(manufactors.Length)];
                int yearCar = rnd.Next(MinYear, MaxYear + 1);
                string typeCar = types[rnd.Next(types.Length)];
                string maintenance = maintenanceOpts[rnd.Next(maintenanceOpts.Length)];

                cars.Add(new Car(idCar, modelCar, mfr, yearCar, typeCar, maintenance));
            }

            MessageBox.Show("Added 10000 cars!");
        }

    }
}
