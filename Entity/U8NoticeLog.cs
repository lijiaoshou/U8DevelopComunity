using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class U8NoticeLog
    {
        public string id { get; set; }

        public string Sender { get; set; }
 
        public string Receiver { get; set; }

        public string NoticeInfo { get; set; }

        public DateTime CreateTime { get; set; }

        public string NoticeCategory { get; set; }

        public string InfoId { get; set; }
    }
}
