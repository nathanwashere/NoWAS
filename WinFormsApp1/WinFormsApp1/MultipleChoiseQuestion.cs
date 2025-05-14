using System.Windows.Forms;

namespace WinFormsApp1
{
    public class MultipleChoiseQuestion : Question
    {
        private string[] options;
        private int correctIndex;

        public MultipleChoiseQuestion(string text, string[] options, int correctIndex)
            : base(text)
        {
            this.options = options;
            this.correctIndex = correctIndex;
        }

        public override void Display(Panel panel)
        {
            panel.Controls.Clear();

            Label lbl = new Label { Text = Text, AutoSize = true, Top = 10 };
            panel.Controls.Add(lbl);

            int y = 40;
            for (int i = 0; i < options.Length; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Text = options[i],
                    Top = y,
                    Left = 10,
                    Tag = i
                };
                panel.Controls.Add(rb);
                y += 30;
            }
        }

        public override bool CheckAnswer(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    return (int)rb.Tag == correctIndex;
                }
            }
            return false;
        }
    }
}
