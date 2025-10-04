using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal abstract class Question : ICloneable,IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks{ get; set; }
        public List<Answer> Answers { get; set; }

        protected Question(string header , string body , int marks )
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = new List<Answer>();
        }
        public abstract void DisplayQuestion();
        public abstract object Clone();
        public void ShowQuestion()
        {
            Console.WriteLine($"Header: {Header}");
            Console.WriteLine($"Question: {Body}");
            Console.WriteLine($"Marks: {Marks}");

            if (Answers != null && Answers.Count > 0)
            { Console.WriteLine("Answers : "); }
            for(int i =0;i<Answers.Count; i++)
            {
                Console.WriteLine($"{i+1}. {Answers[i].Body}");
            }

        }
        public override int GetHashCode() => return Body.GetHashCode(); 
        public int CompareTo(Question other)=>return this.Marks.CompareTo(other.Marks); // compare to should return int
        public override string ToString() => return $"{Header}: {Body} ({Marks} Marks)";
        public override bool Equals(object obj)
        {
            if (obj is Question q)
                return this.Body.Equals(q.Body); 
            
            return false;
        }
        
    }
}
