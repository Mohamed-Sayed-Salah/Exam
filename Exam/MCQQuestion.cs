public class MCQQuestion : BaseQuestion
{
    public MCQQuestion()
    {

    }
    public MCQQuestion(string header, string body, float mark)
        : base(header, body, mark, QuestionType.MCQ) { }

    public override string ToString()
    {
        string answers = "";
        for (int i = 0; i < AnswerList.Count; i++)
        {
            answers += i + AnswerList[i].AnswerText + "\n";
        }
        return $"{Header}\t{Mark}\n{Body}\n{answers}";
    }

}
