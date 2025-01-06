public abstract class BaseQuestion
{
    public string Header { get; set; }
    public string Body { get; set; }
    public float Mark { get; set; }
    public QuestionType Type { get; set; }
    public List<Answer> AnswerList { get; set; } = new List<Answer>();
    public int CorrectAnswerId { get; set; }
    protected BaseQuestion()
    {

    }

    public BaseQuestion(string header, string body, float mark, QuestionType type)
    {
        Header = header;
        Body = body;
        Mark = mark;
        Type = type;
    }

}
