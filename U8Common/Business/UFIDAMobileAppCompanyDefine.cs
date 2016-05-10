using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.Framework.Business
{
    /// <summary>
    /// 渠道定义
    /// </summary>
    public static class UFIDAMobileAppCompanyDefine
    {
        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>结果</returns>
        public static string GetID(string name)
        {
            long result = 0;

            if (long.TryParse(name, out result))
            {
                return name;
            }

            //其他
            return "0";
        }
    }
}
