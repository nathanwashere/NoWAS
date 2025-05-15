using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Windows.Forms;
using WinFormsApp1; // Make sure the namespace matches your project

namespace WinFormsApp1.Tests
{
    [TestClass]
    public class InsertingQuestionsTests
    {
        private InsertingQuestions form;

        [TestInitialize]
        public void Setup()
        {
            form = new InsertingQuestions();
        }

        [TestMethod]
        public void SetMultipleChoiceVisibility_Should_ShowControls_When_True()
        {
            // Arrange
            var form = new InsertingQuestions();

            // Ensure all controls are created (without showing UI)
            form.CreateControl();  // Makes sure controls like Possible_answer_1 exist

            // Find the controls that should become visible
            var answerBox1 = form.Controls.Find("Possible_answer_1", true).FirstOrDefault() as Control;
            var label1 = form.Controls.Find("label1", true).FirstOrDefault() as Control;

            Assert.IsNotNull(answerBox1, "'Possible_answer_1' not found.");
            Assert.IsNotNull(label1, "'label1' not found.");

            // Use reflection to call the private method
            var method = typeof(InsertingQuestions).GetMethod(
                "SetMultipleChoiceVisibility",
                BindingFlags.Instance | BindingFlags.NonPublic
            );

            Assert.IsNotNull(method, "SetMultipleChoiceVisibility method not found.");

            // Act
            method.Invoke(form, new object[] { true });

            // Assert
            Assert.IsTrue(answerBox1.Visible, "Possible_answer_1 should be visible.");
            Assert.IsTrue(label1.Visible, "label1 should be visible.");
        }





        [TestMethod]
        public void TypeText_SelectedIndexChanged_Should_HideMultipleChoiceFields()
        {
            form.Controls.Find("type_text", true)[0].Text = "True/False";
            typeof(InsertingQuestions)
                .GetMethod("type_text_SelectedIndexChanged", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(form, new object[] { null, EventArgs.Empty });

            Assert.IsFalse(form.Controls.Find("Possible_answer_1", true)[0].Visible);
        }

        [TestMethod]
        public void Button1_Click_Should_ClearFieldsOnSuccess()
        {
            // Set valid input values
            form.Controls.Find("question_text", true)[0].Text = "What is 2+2?";
            form.Controls.Find("type_text", true)[0].Text = "True/False";
            form.Controls.Find("course_text", true)[0].Text = "Math";
            form.Controls.Find("c_a_text", true)[0].Text = "4";
            form.Controls.Find("level_text", true)[0].Text = "Easy";

            // Invoke the button click event using reflection
            typeof(InsertingQuestions)
                .GetMethod("button1_Click", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(form, new object[] { null, EventArgs.Empty });

            Assert.AreEqual(string.Empty, form.Controls.Find("question_text", true)[0].Text);
        }
    }
}

