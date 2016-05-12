using System;

namespace U8.Framework.Data
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public static class U8DbType
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public static readonly DateTime StartDateTime = DateTime.Parse("1900-01-01 12:00:00");

        /// <summary>
        /// 结束时间
        /// </summary>
        public static readonly DateTime EndDateTime = DateTime.Parse("2099-12-31 11:59:59");

        /// <summary>
        /// 开始日期
        /// </summary>
        public static readonly DateTime StartDate = DateTime.Parse("1900-01-01 00:00:00");

        /// <summary>
        /// 结束日期
        /// </summary>
        public static readonly DateTime EndDate = DateTime.Parse("2099-12-31 00:00:00");

        /// <summary>
        /// 是否合法的时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns>结果</returns>
        public static bool IsLegalDateTime(DateTime dateTime)
        {
            if (dateTime < StartDateTime || dateTime > EndDateTime)
            {
                return false;
            }

            return true;
        }
    }
}
