using System.Reflection.Emit;
using System.Reflection.PortableExecutable;

namespace Examinatoinsystem
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("How many Question you want : ");
            int count = Convert.ToInt32(Console.ReadLine());
            Question[] questions = new Question[count];
            Console.WriteLine("Choose Question Type:");
            Console.WriteLine("1- TrueOrFalseQuestione");
            Console.WriteLine("2- ChooseOneQuestion");
            Console.WriteLine("3- MultipleChoiceQuestion ");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Question Body: ");
                    string Body = Console.ReadLine();

                    Console.Write("Enter Question level ");
                    string level = Console.ReadLine();

                    Console.Write("Enter header: ");
                    string header = Console.ReadLine();

                    Console.Write("Enter Mark: ");
                    int Mark = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Answer (true/false): ");
                    bool Answer = Convert.ToBoolean(Console.ReadLine());

                    TrueFalseQuestion TrueOrFalseQuestion = new TrueFalseQuestion(header, Body, Mark, level, Answer);
                    Console.WriteLine("True/False Question Created!");
                    break;

                case 2:
                    Console.Write("Enter Question level ");
                    string clevel = Console.ReadLine();

                    Console.Write("Enter Question Body: ");
                    string cbody = Console.ReadLine();

                    Console.Write("Enter header: ");
                    string cheader = Console.ReadLine();

                    Console.Write("Enter Mark: ");
                    int cmark = Convert.ToInt32(Console.ReadLine());

                    string[] coption = new string[3];
                    for (int i = 0; i < coption.Length; i++)
                    {
                        Console.Write($"Enter Choice {i + 1}: ");
                        coption[i] = Console.ReadLine();
                    }

                    Console.Write("Enter Correct Answer (1-3): ");
                    int canswer = Convert.ToInt32(Console.ReadLine());


                    ChooseOneQuestion ChooseOneQuestion = new ChooseOneQuestion(clevel, cbody, cmark, cheader, coption, canswer);
                    Console.WriteLine("Choose One Question Created!");
                    break;

                case 3:
                    Console.Write("Enter Question Body: ");
                    string CBody = Console.ReadLine();

                    Console.Write("Enter Question level ");
                    string Clevel = Console.ReadLine();

                    Console.Write("Enter header: ");
                    string Cheader = Console.ReadLine();

                    Console.Write("Enter Mark: ");
                    int CMark = Convert.ToInt32(Console.ReadLine());

                    string[] CChoices = new string[3];
                    for (int i = 0; i < CChoices.Length; i++)
                    {
                        Console.Write($"Enter Choice {i + 1}: ");
                        CChoices[i] = Console.ReadLine();
                    }

                    Console.Write("Enter Correct Answer (1-3): ");
                    int CorrectAnswer = Convert.ToInt32(Console.ReadLine());

                    ChooseAllQuestion ChooseAllQuestion = new ChooseAllQuestion(Cheader, CBody, CMark, Clevel, CChoices, new int[] { CorrectAnswer } );
                    Console.WriteLine("Multiple Choice Question Created!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }

            Console.WriteLine("Done!");
        }

    }
}

