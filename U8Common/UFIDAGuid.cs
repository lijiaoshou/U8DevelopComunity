using System;

namespace UFIDA.Framework
{
    /// <summary>
    /// Guid处理类
    /// </summary>
    public static class UFIDAGuid
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
