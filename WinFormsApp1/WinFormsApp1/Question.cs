public abstract class Question
{
    public string Body { get; set; }

    public Question(string body)
    {
        Body = body;
    }

    public abstract bool CheckAnswer(Panel panel);

    public abstract void Display(Panel panel);
}
