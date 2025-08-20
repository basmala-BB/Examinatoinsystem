using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examinatoinsystem
{
    
    internal class QuestionList
    {
        public List<Question> Questions { get; set; }

        public QuestionList()
        {
            Questions = new List<Question>();
        }

        public void AddQuestion(Question q)
        {
            Questions.Add(q);
        }
    }
}

