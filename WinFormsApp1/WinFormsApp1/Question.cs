using System.Windows.Forms;

namespace WinFormsApp1
{
    public abstract class Question
    {
        public string Text { get; set; }

        protected Question(string text)
        {
            this.Text = text;
        }

        public abstract void Display(Panel panel);
        public abstract bool CheckAnswer(Panel panel);
    }
}
