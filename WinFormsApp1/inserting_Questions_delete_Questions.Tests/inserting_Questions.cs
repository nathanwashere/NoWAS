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

        //function type_text_SelectedIndexChanged()
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
        public void AreRequiredFieldsFilled_ShouldReturnFalse_IfAnyRequiredFieldIsEmpty()
        {
            var form = new InsertingQuestions();

            // סימולציה של טקסטבוקסים עם טקסט ריק
            form.Controls.Find("question_text", true)[0].Text = "";
            form.Controls.Find("type_text", true)[0].Text = "Multiple Choice";
            form.Controls.Find("course_text", true)[0].Text = "Some Course";
            form.Controls.Find("c_a_text", true)[0].Text = "Answer";
            form.Controls.Find("level_text", true)[0].Text = "Easy";

            form.Controls.Find("Possible_answer_1", true)[0].Text = "Answer 1";
            form.Controls.Find("Possible_answer_2", true)[0].Text = "Answer 2";
            form.Controls.Find("Possible_answer_3", true)[0].Text = "Answer 3";

            bool result = form.AreRequiredFieldsFilled();

            Assert.IsFalse(result);
        }
    }
}

