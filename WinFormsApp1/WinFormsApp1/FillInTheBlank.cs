using System.Windows.Forms;

namespace WinFormsApp1
{
    public class FillInTheBlank : Question
    {
        private string correctAnswer;

        public FillInTheBlank(string questionText, string correctAnswer)
     : base(questionText, "FillInTheBlank", correctAnswer)
        {
            this.correctAnswer = correctAnswer.Trim().ToLower();
        }


        public override void Display(Panel panel)
        {
            foreach (Control ctrl in panel.Controls.OfType<Label>().ToList())
                panel.Controls.Remove(ctrl);

            foreach (Control ctrl in panel.Controls.OfType<GroupBox>().ToList())
                panel.Controls.Remove(ctrl);

            // תווית להצגת גוף השאלה
            Label lbl = new Label
            {
                Text = Body,
                AutoSize = false,
                Width = 1000,
                Height = 60,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                BackColor = Color.Transparent,
                Location = new Point(10, 10)
            };
            panel.Controls.Add(lbl);

            // GroupBox להקלדת התשובה
            GroupBox groupBox = new GroupBox
            {
                Text = "Type your answer:",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Width = 1000,
                Height = 150,
                Location = new Point(10, lbl.Bottom + 10)
            };

            TextBox txt = new TextBox
            {
                Width = groupBox.Width - 40,
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 70)
            };

            groupBox.Controls.Add(txt);
            panel.Controls.Add(groupBox);
        }


        public override bool CheckAnswer(Panel panel)
        {
            var groupBox = panel.Controls.OfType<GroupBox>().FirstOrDefault();
            if (groupBox == null)
                return false;

            foreach (Control ctrl in groupBox.Controls)
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
