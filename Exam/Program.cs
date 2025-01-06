using System.Collections.Generic;
using System.Reflection;

namespace Exam
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Subject math = new Subject { SubjectId = 1, SubjectName = "CS" };

            Console.WriteLine("Please Enter The Type Of Exam ( 1 For Practical | 2 For Final ) ");
            int.TryParse(Console.ReadLine(), out int type);
            ExamType examType;
            if (type == 1)
                examType = ExamType.Practical;
            else if (type == 2)
                examType = ExamType.Final;
            else
                throw new ArgumentException("Invalid ExamType");

            Console.WriteLine("Please Enter The Time Of Exam  From( 30 min to 180 min  ) ");
            int.TryParse(Console.ReadLine(), out int time);

            Console.WriteLine("Please Enter The Number Of Exam Question ");
            int.TryParse(Console.ReadLine(), out int numberOfQuestion);


            Console.Clear();
            math.CreateExam(examType, TimeSpan.FromHours(time / 60.0), numberOfQuestion);

            Console.Clear();
            Console.WriteLine("Do you want to start the Exam (Y|N) ");
            char.TryParse(Console.ReadLine().ToLower(), out char startExam);

            switch (startExam)
            {
                case 'y':
                    Console.Clear();
                    math.Exam.ShowExam();
                    break;
                case 'n':
                    break;
                default:
                    break;
            }

        }
    }
}
