using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class U8Question
    {
        public int ID { get; set; }

        public string ProcessStatus { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Expert { get; set; }

        public string ProductBelong { get; set; }

        public string Provility { get; set; }

        public DateTime ExpectFixTime { get; set; }

        public DateTime SubmitTime { get; set; }

        public string Project { get; set; }

        public string QuestionContent { get; set; }

        public int OfferReward { get; set; }

        public int Popularity { get; set; }

        public bool InKnowledgeLib { get; set;}

        public string SonCategory { get; set; }
    }
}
