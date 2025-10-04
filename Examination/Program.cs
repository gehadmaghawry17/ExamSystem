namespace Examination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Farida");
            Exam<Question> OOPExam = new PracticalExam<Question>("Math Practice Exam",TimeSpan.FromMinutes(60),
                "Math",
                5
            );
            var q1 = new TrueFalseQuestion("OOP","Could interface implement another interface ?", 2);
            var q2 = new TrueFalseQuestion("Gereral", "does developer sleep ?", 2);
            var q3 = new TrueFalseQuestion("OOP", "Is 'int' in C# a reference type?", 2);

            var answers1 = new AnswerList
            {
                new Answer("True", true),
                new Answer("False", false)
            };
            var answers2 = new AnswerList
            {
                new Answer("True", false),
                new Answer("False", true)
            };
            var answers3 = new AnswerList
            {
                new Answer("True", false),
                new Answer("False", true)
            };
            OOPExam.QuestionAnswers.Add(q1,answers1);
            OOPExam.QuestionAnswers.Add(q2, answers2);
            OOPExam.QuestionAnswers.Add(q3, answers3);

            //OOPExam.StartExam();
            //Console.ReadLine();
            Exam<Question> finalExam = new FinalExam<Question>(
                    "Final Practical Exam",       
                    TimeSpan.FromMinutes(60),    
                    "Mixed Subjects",            
                    3                            
                );
            finalExam.QuestionAnswers.Add(q1, answers1);
            finalExam.QuestionAnswers.Add(q2, answers2);
            finalExam.QuestionAnswers.Add(q3, answers3);

            finalExam.StartExam();
            Console.ReadLine();







            //Exam<Question> mathExam = new PracticalExam<Question>(
            //TimeSpan.FromMinutes(60), "Math", 5);

            //mathExam.Name = "Math Practice Exam";  
            //mathExam.StartExam();


        }
    }
}