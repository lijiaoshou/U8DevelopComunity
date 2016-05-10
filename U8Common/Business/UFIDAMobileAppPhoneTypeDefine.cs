using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.Framework.Business
{
    /// <summary>
    /// 电话类型定义
    /// </summary>
    public static class UFIDAMobileAppPhoneTypeDefine
    {
        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>结果</returns>
        public static int GetID(string name)
        {
            int result = 0;

            if (int.TryParse(name, out result))
            {
                return result;
            }

            //其他
            return -1;
        }
    }
}
