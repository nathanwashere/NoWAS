using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Homework
{
    public class Car
    {
        public int ID { get; set; }
        public int Model { get; set; }
        public string Manufactor { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Maintenance { get; set; }
        public Car(int iD, int model, string manufactor, int year, string type, string maintenance)
        {
            ID = iD;
            Model = model;
            Manufactor = manufactor;
            Year = year;
            Type = type;
            Maintenance = maintenance;
        }
        public Car()
        {
            Random rnd = new Random();
            ID = rnd.Next(1, 10001);

            Model = randomModel();

            Manufactor = randomManufactor();

            Year = randomYear();

            Type = randomType();

            Maintenance = randomMaintenance();
        }
        private int randomModel()
        {
            Random rnd = new Random();

            return rnd.Next(1, 11);
        }
        private string randomManufactor()
        {
            string[] manufactors = { "Volvo", "BMW", "Ford", "Mazda", "Suzuki", "Audi" };

            Random rnd = new Random();

            return manufactors[rnd.Next(0, 6)];
        }
        private int randomYear()
        {
            Random rnd = new Random();

            return rnd.Next(2000, 2026);
        }
        private string randomType()
        {
            string[] type = { "Private", "Commercial", "Truck", "Bus" };

            Random rnd = new Random();

            return type[rnd.Next(0, 4   )];
        }
        private string randomMaintenance()
        {
            string[] maintenance = { "Care is required", "Proper" };

            Random rnd = new Random();

            return maintenance[rnd.Next(0, 2)];
        }
        public override string ToString()
        {
            return "Number of car: " + ID + ", Model: " + Model + ", Manufactor: " + Manufactor + ", Year: " + Year +
                ", Type: " + Type + ", Maintenance: " + Maintenance;
        }
    }
    
}
