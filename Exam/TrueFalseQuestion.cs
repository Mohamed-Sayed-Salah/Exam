public class TrueFalseQuestion : BaseQuestion
{
    public TrueFalseQuestion()
    {

    }
    public TrueFalseQuestion(string header, string body, float mark)
        : base(header, body, mark, QuestionType.TrueFalse) { }

    public override string ToString()
    {
        return $"{Header}\t{Mark}\n{Body}\n1- True\n2- False";
    }
}
