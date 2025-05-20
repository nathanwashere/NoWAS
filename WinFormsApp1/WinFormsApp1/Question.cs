using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string Body { get; set; }
        public string Answer { get; set; }
        public int TestID { get; set; }
        public string DifficultyLevel { get; set; }  // [Difficulty level]
        public string Course { get; set; }           // [The course]
        public string Type { get; set; }             // type

        public override string ToString()
        {
            return $"{Body} ({Course}, {DifficultyLevel})";
        }
    }
}
