public abstract class Question
{
    public string Body { get; set; }
    public string Type { get; set; }
    public string Answer { get; set; }
    public string DifficultyLevel { get; set; }
    public string Course { get; set; }

    public Question(string body, string type, string answer, string level = null, string course = null)
    {
        Body = body;
        Type = type;
        Answer = answer;
        DifficultyLevel = level;
        Course = course;
    }

    public abstract void Display(Panel panel);
    public abstract bool CheckAnswer(Panel panel);
}
