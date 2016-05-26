using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U8DevelopComunity.Common
{
    public class CacheNameMgr
    {
        /// <summary>
        /// 生成搜房卡公共缓存名
        /// </summary>
        public static string CardCommonCacheName(string str)
        {
            return String.Format("CardCommon_{0}", str);
        }
    }
}