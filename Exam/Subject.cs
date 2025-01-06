public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public BaseExam Exam { get; set; }

    public void CreateExam(ExamType examType, TimeSpan time, int numberOfQuestions)
    {
        switch (examType)
        {
            case ExamType.Final:
                List<BaseQuestion> Questions = new List<BaseQuestion>()!;
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    Console.WriteLine("Pleas Enter Type Question ( 1 For TrueFalse | 2 for MCQ)");
                    int.TryParse(Console.ReadLine(), out int examId);
                    if (examId == 1)
                    {
                        TrueFalseQuestion trueFalseQuestion = CreateTrueFalseQuestion();
                        Questions.Add(trueFalseQuestion);
                    }
                    else if (examId == 2)
                    {

                        MCQQuestion mCQQuestion = CreateMCQQuestion(); ;
                        Questions.Add(mCQQuestion);

                    }
                    else
                        throw new ArgumentException("Invalid Exam Id");
                }

                Exam = new FinalExam
                {
                    Time = time,
                    NumberOfQuestions = numberOfQuestions,
                    Questions = Questions
                };

                break;

            case ExamType.Practical:
                List<BaseQuestion> mCQQuestions = new List<BaseQuestion>();
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    MCQQuestion mCQQuestion = CreateMCQQuestion();
                    mCQQuestions.Add(mCQQuestion);
                }
                Exam = new PracticalExam { Time = time, NumberOfQuestions = numberOfQuestions, Questions = mCQQuestions };
                break;
            default:
                throw new ArgumentException("Invalid ExamType");

        }
    }


    private MCQQuestion CreateMCQQuestion()
    {
        Console.Clear();
        Console.WriteLine("MCQ Question");

        MCQQuestion mCQQuestion = new MCQQuestion();
        mCQQuestion.Header = "MCQ Question";
        Console.WriteLine("Pleas Enter Question Body");
        mCQQuestion.Body = Console.ReadLine();
        Console.WriteLine("Pleas Enter Question Mark");
        mCQQuestion.Mark = float.Parse(Console.ReadLine());

        Console.WriteLine("Choices Of Question ");
        Console.WriteLine("Pleas Enter Choice Number 1");
        string ans1text = Console.ReadLine();
        mCQQuestion.AnswerList.Add(new Answer(1, ans1text));

        Console.WriteLine("Pleas Enter Choice Number 2");
        string ans2text = Console.ReadLine();
        mCQQuestion.AnswerList.Add(new Answer(2, ans1text));

        Console.WriteLine("Pleas Enter Choice Number 3");
        string ans3text = Console.ReadLine();
        mCQQuestion.AnswerList.Add(new Answer(3, ans1text));

        Console.WriteLine("Pleas Enter Choice Number 4");
        string ans4text = Console.ReadLine();
        mCQQuestion.AnswerList.Add(new Answer(4, ans1text));
        Console.WriteLine("Pleas Enter thr right Answer Id");
        mCQQuestion.CorrectAnswerId = int.Parse(Console.ReadLine());
        mCQQuestion.Type = QuestionType.MCQ;
        return mCQQuestion;

    }
    private TrueFalseQuestion CreateTrueFalseQuestion()
    {
        Console.Clear();

        Console.WriteLine("True Or False Question");
        TrueFalseQuestion trueFalseQuestion = new TrueFalseQuestion("mo", "mo", 3);
        trueFalseQuestion.Header = "TrueFalseQuestion";
        trueFalseQuestion.AnswerList.Add(new Answer(1, "true"));
        trueFalseQuestion.AnswerList.Add(new Answer(2, "false"));

        Console.WriteLine("Pleas Enter Question Body");
        trueFalseQuestion.Body = Console.ReadLine();
        Console.WriteLine("Pleas Enter Question Mark");
        trueFalseQuestion.Mark = float.Parse(Console.ReadLine());
        Console.WriteLine("Pleas Enter thr right Answer Id (1 for true | 2 for false)");
        trueFalseQuestion.CorrectAnswerId = int.Parse(Console.ReadLine());
        trueFalseQuestion.Type = QuestionType.TrueFalse;

        return trueFalseQuestion;
    }
}
