using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class AnswerList : List<Answer> , ICloneable// List<T>
    {
        public void ShowAnswers()
        {
            foreach (var ans in this)
            {
                Console.WriteLine($"{ans.Body}");
            }
        }

        public object Clone()
        {
            AnswerList copy = new AnswerList();
            foreach (var ans in this)
                copy.Add(new Answer(ans.Body, ans.IsCorrect));
            return copy;
        }
    }
}
