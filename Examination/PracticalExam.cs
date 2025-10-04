using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class PracticalExam : Exam<T> where T : Question
    {
        public PracticalExam(TimeSpan duration, string subject, int numberOfQuestions)
        : base(duration, subject, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine($"Practice Exam for {subject}");
            Console.WriteLine($"Number of Ques: {NumberOfQuestions}");
            Console.WriteLine($"Duration: {Duration}\n");

            foreach(var q in QuestionAnswers) //Dictionary in Exam class
            {
                T question = q.Key;
                AnswerList answers = q.Value;

                question.ShowQuestion();//T =>Question || Dict (Question,anserlist)key = Question object

                int[] userChoices = ReadAnswers(answers.Count);

                if (question is TrueFalseQuestion || question is ChooseOneQuestion)
                {
                    Console.Write("choose Your answer: ");
                    string usrAnswr = Console.ReadLine();
                    bool correct = answers[userChoices[0] - 1].IsCorrect;
                    Console.WriteLine(correct?" Correct ": " Wrong ");

                }
                else if (question is ChooseAllQuestion)
                {
                    int score = CalculateChooseAllScore(answers, userChoices, question.Marks);
                    Console.WriteLine($"You scored: {score} / {question.Marks}");
                }

                Console.WriteLine();

            }
        }
    }
}
