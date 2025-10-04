using Examination;
using System.Xml.Linq;

internal class FinalExam<T> : Exam<T> where T : Question
{
    public FinalExam(string name, TimeSpan duration, string subject, int numberOfQuestions)
        : base(duration, subject, numberOfQuestions)
    {
        Name = name;
    }

    // 🛡 الميثود للتحقق من الإجابة
    protected bool ValidateAndCheckAnswer(AnswerList answers, int[] userChoices)
    {
        if (userChoices.Length == 0)
        {
            Console.WriteLine("⚠️ You must choose at least one answer!");
            return false;
        }

        int choice = userChoices[0];
        if (choice < 1 || choice > answers.Count)
        {
            Console.WriteLine("⚠️ Invalid choice! Try again.");
            return false;
        }

        return answers[choice - 1].IsCorrect;
    }

    public override void ShowExam()
    {
        Console.WriteLine($"Final Exam for {Subject}");
        Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
        Console.WriteLine($"Duration: {Duration}\n");

        int totalScore = 0;

        foreach (var entry in QuestionAnswers)
        {
            T question = entry.Key;
            AnswerList answers = entry.Value;

            question.ShowQuestion();

            
            for (int i = 0; i < answers.Count; i++)
                Console.WriteLine($"{i + 1}. {answers[i].Body}");

            int[] userChoices;
            bool correct;

            if (question is TrueFalseQuestion || question is ChooseOneQuestion)
            {
              
                do
                {
                    userChoices = ReadAnswers(answers.Count);
                    correct = ValidateAndCheckAnswer(answers, userChoices);
                } while (userChoices.Length == 0 || (userChoices[0] < 1 || userChoices[0] > answers.Count));

                if (correct)
                    totalScore += question.Marks;

            }
            else if (question is ChooseAllQuestion)
            {
                userChoices = ReadAnswers(answers.Count);
                int score = CalculateChooseAllScore(answers, userChoices, question.Marks);
                totalScore += score;
                Console.WriteLine($"You scored: {score} / {question.Marks}");
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Total Score: {totalScore} / {QuestionAnswers.Sum(q => q.Key.Marks)}");
    }
}
