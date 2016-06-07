using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8DevelopComunity.Common
{
    public class PermissionHelper
    {
        /// <summary>
        /// 判断用户是否有权限
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool HasAdminLimit(string userid)
        {
            Business.U8System business = new Business.U8System();
            return business.HasAdminLimit(Config.ConnectionString, userid);
        }
    }
}