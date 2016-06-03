using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class U8SystemNotice
    {
        public string XuHao { get; set; }

        public string id { get; set; }

        public string Title { get; set; }

        public string SystemNoticeContent { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Submiter { get; set; }

        public string Modifiler { get; set; }

        public string Status { get; set; }
    }
}
