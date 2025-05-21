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
