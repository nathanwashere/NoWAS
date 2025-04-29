using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDD_Homework
{
    public partial class DataGrid : Form
    {
        private List<Car> cars = new List<Car>();
        public DataGrid(List<Car> cars)
        {
            InitializeComponent();
            this.cars = cars;
        }
        public static float yearAverage(List<Car> cars)
        {
            float sum = 0;
            foreach (Car car in cars)
            {
                sum += car.Year;
            }
            if (cars.Count == 0)
            {
                return 0;
            }
            return sum / cars.Count;
        }
        private int careIsNeededCount()
        {
            int sum = 0;
            foreach (Car car in cars)
            {
                if (car.Maintenance == "Care is required")
                {
                    sum++;
                }
            }
            return sum;
        }
        public static void Sort(List<Car> cars)
        {
            //if (cars == null || cars.Count <= 1)
            //    return; // No need to sort

            //bool swapped;
            //int n = cars.Count;

            //for (int i = 0; i < n - 1; i++)
            //{
            //    swapped = false;
            //    for (int j = 0; j < n - i - 1; j++)
            //    {
            //        if (cars[j].Year > cars[j + 1].Year)
            //        {
            //            // Swap cars[j] and cars[j + 1]
            //            (cars[j], cars[j + 1]) = (cars[j + 1], cars[j]);
            //            swapped = true;
            //        }
            //    }

            //    // If no two elements were swapped in the inner loop, break early
            //    if (!swapped)
            //        break;
            //}

            ////Counting Sort
            int minYear = 2000;
            int maxYear = 2025;
            int range = maxYear - minYear + 1;

            // Create buckets for each year
            List<Car>[] buckets = new List<Car>[range];
            for (int i = 0; i < range; i++)
            {
                buckets[i] = new List<Car>();
            }

            // Put each car into its bucket
            foreach (Car car in cars)
            {
                buckets[car.Year - minYear].Add(car);
            }

            // Reconstruct the list
            int index = 0;
            foreach (var bucket in buckets)
            {
                foreach (var car in bucket)
                {
                    cars[index++] = car;
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {   
            DateTime start2 = DateTime.Now;
            Sort(this.cars);
            DateTime end2 = DateTime.Now;
            TimeSpan total2 = end2 - start2;
            MessageBox.Show("Bubblesort took " + total2.TotalMilliseconds.ToString() + " milliseconds to sort the cars.");
            labelRunningTimeSort.Text += total2.TotalMilliseconds.ToString()+" ms";


            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = this.cars;
            labelAmountOfCars.Text += cars.Count.ToString();

            DateTime start1 = DateTime.Now;
            labelCarYearAverage.Text += DataGrid.yearAverage(this.cars).ToString();
            DateTime end1 = DateTime.Now;
            TimeSpan total1 = end1 - start1;
            labelRunningTimeAverage.Text += total1.TotalMilliseconds.ToString() + " ms";


            MessageBox.Show(Text + " took " + total1.TotalMilliseconds.ToString() + " milliseconds to calculate the average year.");

            labelCareIsRequiredAmount.Text += careIsNeededCount().ToString();

        }
    }
}
