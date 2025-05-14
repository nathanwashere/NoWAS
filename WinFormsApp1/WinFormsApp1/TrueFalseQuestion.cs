using System.Windows.Forms;

namespace WinFormsApp1
{
    public class TrueFalseQuestion : Question
    {
        private bool correctAnswer;

        public TrueFalseQuestion(string questionText, bool correctAnswer = false)
            : base(questionText)
        {
            this.correctAnswer = correctAnswer;
        }

        public override void Display(Panel panel)
        {
            panel.Controls.Clear();

            Label lbl = new Label { Text = Text, AutoSize = true, Top = 10 };
            panel.Controls.Add(lbl);

            RadioButton trueButton = new RadioButton
            {
                Text = "True",
                Top = 40,
                Left = 10,
                Tag = true
            };
            RadioButton falseButton = new RadioButton
            {
                Text = "False",
                Top = 70,
                Left = 10,
                Tag = false
            };

            panel.Controls.Add(trueButton);
            panel.Controls.Add(falseButton);
        }

        public override bool CheckAnswer(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    return (bool)rb.Tag == correctAnswer;
                }
            }
            return false;
        }
    }
}
