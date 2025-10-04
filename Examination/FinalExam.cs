using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal class FinalExam : Exam<T> where T : Question
    {
        public FinalExam(TimeSpan duration, string subject, int numberOfQuestions)
            : base(duration, subject, numberOfQuestions) { }

        public override void ShowExam()
        {
            int totalScore = 0;
            Dictionary<T, int[]> studentAnswers = new Dictionary<T, int[]>();


            Console.WriteLine($"Final Exam for {subject}");
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
            Console.WriteLine($"Duration: {Duration}\n");


            foreach (var q in QuestionAnswers)
            {
                T question = q.Key;
                AnswerList answers = q.Value;
                question.ShowQuestion();

                int[] userChoices = ReadAnswers(answers.Count);
                studentAnswers.Add(question, userChoices);
                Console.WriteLine();

            }

            foreach(var ans in studentAnswers)
            {
                T question = ans.Key;
                // answers_of_that_question|| question dic[0] , dic[key] => question itself
                AnswerList answers = QuestionAnswers[question];
                int [] answered_input = ans.Value;
                bool correct = true;

                if (question is TrueFalseQuestion || question is ChooseOneQuestion)
                {
                    // ensure that only one answer here 
                    if (answered_input.Length == 1 && answers[answered_input[0] - 1].IsCorrect)
                    {
                        totalScore += question.Marks;
                    }
                }
                else if (question is ChooseAllQuestion)
                {
                    totalScore += CalculateChooseAllScore(answers, answered_input, question.Marks);
                    
                }
                Console.WriteLine();

            }
            Console.WriteLine($"Total Score is : {totalScore}");

        }
    }
