using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinatoinsystem
{
    internal enum QuestionType
    {
        TrueFalseQuestion,
        ChooseOneQuestion,
        ChooseAllQuestion
    }

    public enum Level
    {
        Easy,
        Medium,
        Hard
    }

    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public string level { get; set; }
        public string CorrectAnswer { get; set; } 

        public Question(string header, string body, int marks, string level)
        {
            Header = header;
            Body = body;
            Marks = marks;
            level = level;
        }

        public abstract void Display();
        public abstract bool CheckAnswer(string answer);
    }


    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string header, string body, int marks, string level, bool correctAnswer)
            : base(header, body, marks, level)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void Display()
        {
            Console.WriteLine($"[{level}] {Header} - Marks: {Marks}");
            Console.WriteLine(Body);
            Console.WriteLine("1) True");
            Console.WriteLine("2) False");
        }

        public override bool CheckAnswer(string answer)
        {
            try
            {
                int chosen = Convert.ToInt32(answer);
                if (chosen == 1 && CorrectAnswer == true) return true;
                if (chosen == 2 && CorrectAnswer == false) return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    public class ChooseOneQuestion : Question
    {
        public string[] Options { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public ChooseOneQuestion(string header, string body, int marks, string level, string[] options, int correctAnswerIndex)
            : base(header, body, marks, level)
        {
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        public override void Display()
        {
            Console.WriteLine($"[{level}] {Header} - Marks: {Marks}");
            Console.WriteLine(Body);

            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Options[i]}");
            }
        }

        public override bool CheckAnswer(string answer)
        {
            try
            {
                int chosenIndex = Convert.ToInt32(answer);
                return (chosenIndex - 1) == CorrectAnswerIndex;
            }
            catch
            {
                return false;
            }
        }
    }

    public class ChooseAllQuestion : Question
    {
        public string[] Options { get; set; }
        public int[] CorrectAnswerIndexes { get; set; } 

        public ChooseAllQuestion(string header, string body, int marks, string level, string[] options, int[] correctAnswerIndexes)
            : base(header, body, marks, level)
        {
            Options = options;
            CorrectAnswerIndexes = correctAnswerIndexes;
        }

        public override void Display()
        {
            Console.WriteLine($"[{level}] {Header} - Marks: {Marks}");
            Console.WriteLine(Body);
            Console.WriteLine("(               )");

            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Options[i]}");
            }
        }

        public override bool CheckAnswer(string answer)
        {
            try
            {
                string[] parts = answer.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] chosenIndexes = new int[parts.Length];

                for (int i = 0; i < parts.Length; i++)
                {
                    chosenIndexes[i] = Convert.ToInt32(parts[i]) - 1;
                }

                if (chosenIndexes.Length != CorrectAnswerIndexes.Length)
                    return false;

                Array.Sort(chosenIndexes);
                Array.Sort(CorrectAnswerIndexes);

                for (int i = 0; i < CorrectAnswerIndexes.Length; i++)
                {
                    if (chosenIndexes[i] != CorrectAnswerIndexes[i])
                        return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}   