using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using U8.Framework.Configuration;

namespace U8DevelopComunity.Common
{
    public static class Config
    {
        public readonly static string LoginName = U8Config.GetValue<string>("LoginName");

        public readonly static string LoginUrl = U8Config.GetValue<string>("LoginUrl");

        public readonly static string UserID = U8Config.GetValue<string>("UserID");

        private readonly static string connectionString =U8Config.GetValue<string>("ConnectionString");//后期可加入加密解密功能

        public readonly static string CookieDomain = U8Config.GetValue<string>("CookieDomain");

        public static string ConnectionString
        {
            get
            {
                //Connect_Log("ConnectionString");//后期可加入连接日志功能
                return connectionString;
            }
        }
    }
}