using System;

namespace UFIDA.Framework.Business
{
    /// <summary>
    /// 用户类型
    /// </summary>
    [Flags]
    public enum UserType
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        General = 1,

        /// <summary>
        /// 通行证
        /// </summary>
        Passport = 2,

        /// <summary>
        /// 搜房帮
        /// </summary>
        Agent = 4,

        /// <summary>
        /// 搜房卡
        /// </summary>
        Card = 8,

        /// <summary>
        /// 内部员工
        /// </summary>
        Soufun = 16
    }
}
