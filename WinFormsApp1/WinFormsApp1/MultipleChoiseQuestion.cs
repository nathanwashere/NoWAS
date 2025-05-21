using System.Windows.Forms;

namespace WinFormsApp1
{
    public class MultipleChoiceQuestion : Question
    {
        public string[] Options { get; }
        public int CorrectIndex { get; }

        public MultipleChoiceQuestion(string body, string[] options, int correctIndex)
     : base(body, "Multiple Choice", (correctIndex >= 0 && correctIndex < options.Length) ? options[correctIndex] : "")
        {
            this.Options = options;
            this.CorrectIndex = correctIndex;
        }


        public override bool CheckAnswer(Panel panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    return rb.Tag != null && (int)rb.Tag == CorrectIndex;
                }
            }
            return false;
        }

        public override void Display(Panel panel)
        {
            panel.Controls.Clear();
            Label lbl = new Label { Text = Body, AutoSize = true, Top = 10, Left = 10 };
            panel.Controls.Add(lbl);
            for (int i = 0; i < Options.Length; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Text = Options[i],
                    Tag = i,
                    Top = 40 + i * 30,
                    Left = 20,
                    AutoSize = true
                };
                panel.Controls.Add(rb);
            }
        }

    }
}
