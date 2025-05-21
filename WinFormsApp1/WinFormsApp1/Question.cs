using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Question
    {
        private string text;

        public Question(string text)
        {
            this.text = text;
        }

        public int QuestionID { get; set; }
        public string Body { get; set; }
        public string Answer { get; set; }
        public int TestID { get; set; }
        public string DifficultyLevel { get; set; }  // [Difficulty level]
        public string Course { get; set; }           // [The course]
        public string Type { get; set; }             // type

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

        public override string ToString()
        {
            return $"{Body} ({Course}, {DifficultyLevel})";
        }
    }
}
