using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Homework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Homework.Tests
{
    [TestClass()]
    public class DataGridTests
    {
        [TestMethod()]
        public void YearAverage_WithCars_ReturnsCorrectAverage()
        {
            var cars = new List<Car>
            {
                new Car(1, 123, "Toyota", 2020, "Private", "Proper"),
                new Car(2, 456, "Honda", 2018, "Commercial", "Care is required"),
                new Car(3, 789, "Ford", 2022, "Truck", "Proper")
            };

            float average = DataGrid.yearAverage(cars);

            Assert.AreEqual(2020f, average);
        }

        [TestMethod()]
        public void YearAverage_WithNoCars_ReturnsZero()
        {
            var cars = new List<Car>();

            float average = DataGrid.yearAverage(cars);

            Assert.AreEqual(0f, average);
        }

        // -------------------------------
        // 📌 Counting Sort Unit Tests
        // -------------------------------

        [TestMethod()]
        public void SortByYear_EmptyList_RemainsEmpty()
        {
            var cars = new List<Car>();

            // Act
            DataGrid.Sort(cars);

            // Assert
            Assert.IsNotNull(cars, "The function should not null-out the list.");
            Assert.AreEqual(0, cars.Count, "Empty list should remain empty after sorting.");
        }

        [TestMethod()]
        public void SortByYear_SameYearCars_RemainUnchanged()
        {
            var cars = Enumerable.Range(1, 5)
                .Select(i => new Car(i, i, "Audi", 2015, "Private", "Proper"))
                .ToList();

            // Act
            DataGrid.Sort(cars);

            // Assert: count unchanged
            Assert.AreEqual(5, cars.Count);
            // Assert: every car still has Year == 2015
            Assert.IsTrue(cars.All(c => c.Year == 2015));
        }

        [TestMethod()]
        public void SortByYear_MixedYears_IsSortedCorrectly()
        {
            var cars = new List<Car>
    {
        new Car(1, 1, "BMW", 2018, "Truck", "Proper"),
        new Car(2, 2, "Toyota", 2002, "Private", "Care is required"),
        new Car(3, 3, "Honda", 2025, "Commercial", "Proper"),
        new Car(4, 4, "Ford", 2000, "Bus", "Proper"),
        new Car(5, 5, "Mazda", 2010, "Private", "Care is required")
    };

            // Act
            DataGrid.Sort(cars);

            // Assert: sorted by Year
            for (int i = 0; i < cars.Count - 1; i++)
            {
                Assert.IsTrue(cars[i].Year <= cars[i + 1].Year,
                    $"List is not sorted at index {i}: {cars[i].Year} > {cars[i + 1].Year}");
            }

            // Assert: no cars lost
            Assert.AreEqual(5, cars.Count);
        }

    }
}
