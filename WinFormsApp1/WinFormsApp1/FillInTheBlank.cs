using System.Windows.Forms;

namespace WinFormsApp1
{
    public class FillInTheBlank : Question
    {
        private string correctAnswer;

        public FillInTheBlank(string questionText, string correctAnswer)
            : base(questionText)
        {
            this.correctAnswer = correctAnswer.Trim().ToLower();
        }

        public override void Display(Panel panel)
        {
            panel.Controls.Clear();
            Label lbl = new Label { Text = Body, AutoSize = true, Top = 10, Left = 10 }; // תואם למחלקת האב
            TextBox txt = new TextBox { Top = 40, Left = 20, Width = 200 };
            panel.Controls.Add(lbl);
            panel.Controls.Add(txt);
        }

        public override bool CheckAnswer(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    return tb.Text.Trim().ToLower() == correctAnswer;
                }
            }
            return false;
        }
    }
}
