public class PracticalExam : BaseExam
{
    public override void ShowExam()
    {
        float grade = 0;
        float totalGrade = 0;
        List<string> userAnswer = new List<string>();
        DateTime startTime = DateTime.Now;

        foreach (var question in Questions)
        {
            Console.WriteLine(question.Body);
            Console.WriteLine("Please Enter The Answer Id (1 For True | 2 For False)");
            int.TryParse(Console.ReadLine(), out int AnswerId);
            userAnswer.Add(question.AnswerList.Find(x => x.AnswerId == AnswerId).AnswerText);
            if (question.CorrectAnswerId == AnswerId)
                grade += question.Mark;

            totalGrade += question.Mark;
        }

        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        Console.Clear();

        for (int i = 0; i < Questions.Count; i++)
        {
            var question = Questions[i];
            Console.WriteLine($"Question {i + 1} : {question.Body}");
            Console.WriteLine($"Your Answer => {userAnswer[i]}");
            Console.WriteLine($"Right Answer => {question.AnswerList.Find(x => x.AnswerId == question.CorrectAnswerId).AnswerText}");
        }

        Console.WriteLine($"Your Grade is {grade} from {totalGrade}");
        Console.WriteLine($"Time = {duration}");
        Console.WriteLine("Thank You");
    }
}
