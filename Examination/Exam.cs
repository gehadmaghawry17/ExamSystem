using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Examination
{
    internal abstract class Exam<T>:ICloneable, IComparable<Exam<T>> where T : Question
    {
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }
        public string subject { get; set; }
        public int NumberOfQuestions { get; set; }
        public ExamMode Mode { get; private set; }
        public event Action<Exam<T>> OnExamStarted;
        public event Action<Exam<T>> OnExamFinished;

        public Dictionary<T,AnswerList> QuestionAnswers { get; set; }
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
        public Exam(TimeSpan duration , string subject , int numberOfQuestions)
        {
            Duration = duration;
            this.subject = subject;
            NumberOfQuestions = numberOfQuestions;
            QuestionAnswers = new Dictionary<T, AnswerList>();
        }
        //protected void NotifyExam()
        //{ 

        //}
        public void StartExam()
        {
            Mode = ExamMode.Starting;
            Console.WriteLine("The exam has started!");
        }

        public void FinishExam()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine("The exam has finished!");
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
    }
}
