using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinatoinsystem
{
    internal abstract class Exam
    {
        public DateTime DateTime { get; set; }
        public int NumberOfQuestion { get; set; }
        public int MarkOfExam { get; set; }
        public int Grade { get; set; }

        public Exam(DateTime dateTime, int numberOfQuestion)
        {
            DateTime = dateTime;
            NumberOfQuestion = numberOfQuestion;
            MarkOfExam = 0;
            Grade = 0;
        }

        public abstract void ShowExam(QuestionList questionList);
    }

    internal class practicalExam : Exam
    {
       
        public practicalExam(DateTime dateTime, int numberOfQuestion)
    : base(dateTime, numberOfQuestion) { }

        public override void ShowExam(QuestionList questionList)
        {
            Console.WriteLine("Practical Exam:");
            foreach (var q in questionList.Questions)
            {
                q.Display();
                Console.Write("Your Answer: ");
                string answer = Console.ReadLine();

                if (answer == q.CorrectAnswer)
                {
                    Grade += q.Marks; 
                }
            }

            Console.WriteLine($"Your Grade = {Grade} / {MarkOfExam}");
        }
    }

}


