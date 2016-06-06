using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8DevelopComunity.Models
{
    public class U8Answer
    {
        public string Id { get; set; }

        public string QuestionId { get; set; }

        public string AnswerContent { get; set; }

        public string AnswerPeople { get; set; }

        public DateTime AnswerTime { get; set; }

        public bool IsBestAnswer { get; set; }

        public string Receiver { get; set; }

        public string NoticeInfo { get; set; }

        public string InfoId { get; set; }
    }
}