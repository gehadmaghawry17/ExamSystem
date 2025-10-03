using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class WrittenQuestion :Question
    {
        public string RightAnswer { get; set; }
        public WrittenQuestion(string header , string body , int marks , string rightAnswer):base(header , body , marks)
        {
            RightAnswer = rightAnswer;
        }

        public 
    }
}
