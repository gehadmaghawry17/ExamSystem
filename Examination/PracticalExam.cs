using Examination;
using System.Xml.Linq;

internal class PracticalExam<T> : Exam<T> where T : Question
{
    public PracticalExam(string name, TimeSpan duration, string subject, int numberOfQuestions)
        : base(duration, subject, numberOfQuestions)
    {
        Name = name;
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

        return answers[choice - 1].IsCorrect;
    }

    public override void ShowExam()
    {
        Console.WriteLine($"Practice Exam for {Subject}");
        Console.WriteLine($"Number of Ques: {NumberOfQuestions}");
        Console.WriteLine($"Duration: {Duration}\n");

        foreach (var entry in QuestionAnswers)
        {
            T question = entry.Key;
            AnswerList answers = entry.Value;

            question.ShowQuestion();

            for (int i = 0; i < answers.Count; i++)
                Console.WriteLine($"{i + 1}. {answers[i].Body}");

            int[] userChoices;
            bool correct;

            do
            {
                userChoices = ReadAnswers(answers.Count);
                correct = ValidateAndCheckAnswer(answers, userChoices);
            }
            while (userChoices.Length == 0 || (userChoices[0] < 1 || userChoices[0] > answers.Count));

            Console.WriteLine(correct ? "Correct!" : "Wrong!");
            Console.WriteLine();
        }
    }
}
