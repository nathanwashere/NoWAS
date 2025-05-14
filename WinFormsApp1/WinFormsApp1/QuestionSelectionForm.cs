using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class QuestionSelectionForm : Form
    {
        public List<Question> SelectedQuestions { get; private set; } = new List<Question>();
        private List<Question> availableQuestions;

        public QuestionSelectionForm(List<Question> questions)
        {
            InitializeComponent();
            availableQuestions = questions;

            foreach (var q in questions)
            {
                checkedListBox1.Items.Add(q);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                SelectedQuestions.Add((Question)item);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}