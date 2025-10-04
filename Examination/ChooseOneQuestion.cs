using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class ChooseOneQuestion:Question
    {
        public ChooseOneQuestion(string header, string body, int marks)
        : base(header, body, marks) { }

        public override object Clone()
        {
            var clone = (ChooseOneQuestion)this.MemberwiseClone();
            clone.Answers = new List<Answer>();
            foreach (var ans in this.Answers)
                clone.Answers.Add(new Answer(ans.Body, ans.IsCorrect));
            return clone;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} (Choose One)");
        }
    }
}
