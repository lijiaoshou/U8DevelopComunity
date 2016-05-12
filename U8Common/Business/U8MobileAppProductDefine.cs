using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Framework.Business
{
    /// <summary>
    /// 产品定义
    /// </summary>
    public static class U8MobileAppProductDefine
    {
        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>结果</returns>
        public static int GetID(string name)
        {
            if (name == "soufun") { return 1; }
            if (name == "soufunbang") { return 2; }
            if (name == "soufunrent") { return 3; }
            if (name == "ipad_soufun") { return 4; }
            if (name == "xfbang") { return 5; }
            if (name == "tudi") { return 6; }
            if (name == "shequ") { return 7; }
            if (name == "pinggu") { return 8; }
            if (name == "ipadhd_soufun") { return 9; }
            if (name == "home") { return 10; }
            if (name == "jiancai") { return 11; }
            if (name == "sfhome") { return 12; }
            //其他
            return 99;
        }
    }
}
