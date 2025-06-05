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
            var groupBox = panel.Controls.OfType<GroupBox>().FirstOrDefault();
            if (groupBox == null)
                return false;

            foreach (Control ctrl in groupBox.Controls)
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

            // GroupBox שמכיל את כל התשובות
            GroupBox groupBox = new GroupBox
            {
                Text = "Choose the correct answer:",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Width = panel.Width - 20,
                Height = 60 + (Options.Length * 35),
                Location = new Point(10, lbl.Bottom )
            };

            // יצירת RadioButtons
            for (int i = 0; i < Options.Length; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Text = Options[i],
                    Tag = i,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(40, 40, 40),
                    BackColor = Color.Transparent,
                    Location = new Point(20, 60 + i * 30)
                };
                groupBox.Controls.Add(rb);
            }

            panel.Controls.Add(groupBox);
        }



    }
}
