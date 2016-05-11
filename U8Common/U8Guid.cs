using System;

namespace U8.Framework
{
    /// <summary>
    /// Guid处理类
    /// </summary>
    public static class U8Guid
    {
        /// <summary>
        /// 产生Guid
        /// </summary>
        /// <returns>结果</returns>
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString("N").ToLower();
        }
    }
}
