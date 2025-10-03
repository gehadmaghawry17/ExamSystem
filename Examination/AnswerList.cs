using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class AnswerList : List<Answer> // List<T>
    {
        public void ShowAnswers()
        {
            foreach (var ans in this)
            {
                Console.WriteLine($"{ans.Body}");
            }
        }
    }
}
