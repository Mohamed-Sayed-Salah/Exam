public abstract class BaseExam
{
    public TimeSpan Time { get; set; }
    public int NumberOfQuestions { get; set; }
    public List<BaseQuestion> Questions { get; set; }

    public abstract void ShowExam();
}
