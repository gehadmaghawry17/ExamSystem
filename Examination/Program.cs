namespace Examination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Ali");
            Exam<Question> mathExam = new PracticeExam<Question>("Math Practice", TimeSpan.FromMinutes(60), 5);
            mathExam.StartExam();

        }
    }
