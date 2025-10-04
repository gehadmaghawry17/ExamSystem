using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Examination
{
    internal abstract class Exam<T>:ICloneable, IComparable<Exam<T>> where T : Question
    {   public string Name { get; set; }
            public TimeSpan Duration { get; set; }
            public string Subject { get; set; }
            public int NumberOfQuestions { get; set; }
            public ExamMode Mode { get; private set; }
            public event Action<Exam<T>> OnExamStarted;
            public event Action<Exam<T>> OnExamFinished;

        public Dictionary<T,AnswerList> QuestionAnswers { get; set; }
        public Exam(TimeSpan duration, string subject, int numberOfQuestions)
        {
            Duration = duration;
            Subject = subject;   
            NumberOfQuestions = numberOfQuestions;
            QuestionAnswers = new Dictionary<T, AnswerList>();

        }
        public Exam(string name) : this(TimeSpan.Zero, "Unknown", 0)
        {
            Name = name;
            Mode = ExamMode.Queued;
        }
        public void StartExam()
        {
            Mode = ExamMode.Starting;
            Console.WriteLine($"Exam '{Name}' has started!");
            OnExamStarted?.Invoke(this);
            ShowExam();
        }
        public void FinishExam()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine($"Exam '{Name}' has finished!");
            OnExamFinished?.Invoke(this);
        }
       
        public object Clone() => this.MemberwiseClone();
        public int CompareTo(Exam<T> other)
        {
            return this.NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }

        public abstract void ShowExam();

        //
        protected int[] ReadAnswers(int maxChoice)
        {
            string input = Console.ReadLine();
            return input
                .Split(',')
                .Select(s => int.TryParse(s.Trim(), out int n) && n >= 1 && n <= maxChoice ? n : -1)
                .Where(n => n != -1)
                .ToArray();
        }

        protected int CalculateChooseAllScore(AnswerList answers, int[] selectedIndices, int totalMarks)
        {
            int score = 0;
            int totalCorrect = answers.Count(a => a.IsCorrect);
            int marksPerCorrect = totalMarks / totalCorrect;

            for (int i = 0; i < answers.Count; i++)
            {
                if (selectedIndices.Contains(i + 1) && answers[i].IsCorrect)
                    score += marksPerCorrect;
            }

            return score;
        }

        protected bool ValidateAndCheckAnswer(AnswerList answers, int[] userChoices)
        {
            if (userChoices.Length == 0)
            {
                Console.WriteLine("You must choose at least one answer!");
                return false; 
            }

            int choice = userChoices[0]; 
            if (choice < 1 || choice > answers.Count)
            {
                Console.WriteLine("Invalid choice! Try again.");
                return false;
            }

            bool correct = answers[choice - 1].IsCorrect;
            return correct;
        }

    }
}
