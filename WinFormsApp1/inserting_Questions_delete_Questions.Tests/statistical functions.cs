using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using WinFormsApp1;
using Xunit.Sdk;

namespace WinFormsApp1.Tests
{
    [TestClass]
    public class StatisticalFunctionsTests
    {
        private DataTable CreateTestDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Score", typeof(double));
            return table;
        }

        [TestMethod]
        public void CalculateAverageScore_WithValidData_ReturnsCorrectAverage()
        {
            // Arrange
            var table = CreateTestDataTable();
            table.Rows.Add(80.0);
            table.Rows.Add(90.0);
            table.Rows.Add(70.0);
            table.Rows.Add(85.0);

            // Act
            var studentTracking = new StudentTracking("testUser");
            var result = studentTracking.CalculateAverageScore(table);

            // Assert
            Assert.AreEqual(81.25, result, 0.001);
        }

        [TestMethod]
        public void CalculateHighestScore_WithValidData_ReturnsHighestScore()
        {
            // Arrange
            var table = CreateTestDataTable();
            table.Rows.Add(75.0);
            table.Rows.Add(95.0);
            table.Rows.Add(85.0);
            table.Rows.Add(90.0);

            // Act
            var studentTracking = new StudentTracking("testUser");
            var result = studentTracking.CalculateHighestScore(table);

            // Assert
            Assert.AreEqual(95.0, result, 0.001);
        }

        [TestMethod]
        public void CalculateLowestScore_WithValidData_ReturnsLowestScore()
        {
            // Arrange
            var table = CreateTestDataTable();
            table.Rows.Add(85.0);
            table.Rows.Add(65.0);
            table.Rows.Add(75.0);
            table.Rows.Add(90.0);

            // Act
            var studentTracking = new StudentTracking("testUser");
            var result = studentTracking.CalculateLowestScore(table);

            // Assert
            Assert.AreEqual(65.0, result, 0.001);
        }

        [TestMethod]
        public void CalculateMedianScore_WithValidData_ReturnsCorrectMedian()
        {
            // Arrange
            var table = CreateTestDataTable();
            table.Rows.Add(70.0);
            table.Rows.Add(80.0);
            table.Rows.Add(90.0);
            table.Rows.Add(85.0);
            table.Rows.Add(75.0);

            // Act
            var studentTracking = new StudentTracking("testUser");
            var result = studentTracking.CalculateMedianScore(table);

            // Assert
            Assert.AreEqual(80.0, result, 0.001);
        }
    }
}
