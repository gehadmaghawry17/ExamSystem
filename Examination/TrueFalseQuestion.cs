using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class TrueFalseQuestion:Question
    {
        public TrueFalseQuestion(string header, string body, int marks): base(header, body, marks) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} (True/False)");
        }

        public override object Clone()
        {
            var clone = (TrueFalseQuestion)this.MemberwiseClone();
            clone.Answers = new List<Answer>();
            foreach (var ans in this.Answers)
                clone.Answers.Add(new Answer(ans.Body, ans.IsCorrect));
            return clone;
        }
    }

}

