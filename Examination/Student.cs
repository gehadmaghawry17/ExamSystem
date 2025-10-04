using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class Student
    {
        public string Name { get; set; } = "Default Student";

        public Student() { }
        public Student(string name) { Name = name; }

        public void NotifyExamStarted(Exam<Question> exam)
        {
            Console.WriteLine($"{Name}, the exam '{exam.Name}' has started! Get ready!");
        }
        public void NotifyExamFinished(Exam<Question> exam)
        {
            Console.WriteLine($"{Name}, the exam '{exam.Name}' has finished!");
        }
    }
}
