using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class U8User
    {
        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public string RealName { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Role { get; set; }

        public bool IsYonyouEmployee { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        public bool IsDelete { get; set; }

        public int ExistingScore { get; set; }

        public string Department { get; set; }

        public int NoticeCount { get; set; }

        public string HeadPicture { get; set; }
    }
}
