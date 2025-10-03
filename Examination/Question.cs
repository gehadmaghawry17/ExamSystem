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

        public void ShowQuestion()
        { 
        
        }

        public object Clone()
        {
            Question clone = (Question)this.MemberwiseClone();
            clone 
            return clone;
        }
        public int CompareTo(Question other)
        {
           
        }
    }
}
