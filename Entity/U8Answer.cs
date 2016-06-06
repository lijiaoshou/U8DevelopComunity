using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class U8Answer
    {
        public string Id { get; set; }

        public string QuestionId { get; set; }

        public string AnswerContent { get; set; }

        public string AnswerPeople { get; set; }

        public DateTime AnswerTime { get; set; }

        public bool IsBestAnswer { get; set; }
    }
}
