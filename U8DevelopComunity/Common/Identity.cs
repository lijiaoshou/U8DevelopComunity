using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8DevelopComunity.Common
{
    public static class Identity
    {
        public static string UserEmail { get; set; }

        public static string Password { get; set; }

        public static string Gender { get; set; }

        public static string Phone { get; set; }

        public static string Company { get; set; }

        public static string Province { get; set; }

        public static string City { get; set; }

        public static string Role { get; set; }

        public static bool IsYonyouEmployee { get; set; }
    }
}