using System.Windows.Forms;

namespace WinFormsApp1
{
    public class TrueFalseQuestion : Question
    {
        private bool correctAnswer;

        public TrueFalseQuestion(string questionText, bool correctAnswer = false)
        : base(questionText, "TrueFalse", correctAnswer.ToString())
        {
            this.correctAnswer = correctAnswer;
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
                Width = panel.Width - 20,
                Height = 60,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                BackColor = Color.Transparent,
                Location = new Point(10, 10)
            };
            panel.Controls.Add(lbl);

            // GroupBox לתשובות
            GroupBox groupBox = new GroupBox
            {
                Text = "Choose True or False:",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Width = panel.Width - 20,
                Height = 150,
                Location = new Point(10, lbl.Bottom + 10)
            };

            // RadioButton - True
            RadioButton trueButton = new RadioButton
            {
                Text = "True",
                Tag = true,
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(40, 40, 40),
                BackColor = Color.Transparent,
                Location = new Point(20, 60)
            };

            // RadioButton - False
            RadioButton falseButton = new RadioButton
            {
                Text = "False",
                Tag = false,
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(40, 40, 40),
                BackColor = Color.Transparent,
                Location = new Point(20, 90)
            };

            groupBox.Controls.Add(trueButton);
            groupBox.Controls.Add(falseButton);
            panel.Controls.Add(groupBox);
        }


        public override bool CheckAnswer(Panel panel)
        {
            var groupBox = panel.Controls.OfType<GroupBox>().FirstOrDefault();
            if (groupBox == null)
                return false;

            foreach (Control ctrl in groupBox.Controls)
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
