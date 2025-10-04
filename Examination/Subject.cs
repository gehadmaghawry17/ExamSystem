using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class Subject
    {
        public string Name { get; set; }
        public List<Exam<Question>> Exams { get; set; }

        public Subject(string name) => Name = name;

        public Subject(string name)
        {
            Name = name;
            Exams = new List<Exam<Question>>(); 
        }
        public void AddExam(Exam<Question> exam)
        {
            Exams.Add(exam);
            Console.WriteLine($"Exam '{exam.Name}' added to Subject '{Name}'");
        }
    }
}
