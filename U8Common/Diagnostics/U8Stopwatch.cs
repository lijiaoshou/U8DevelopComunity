using System;
using System.Diagnostics;

namespace U8.Framework.Diagnostics
{
    /// <summary>
    /// 秒表
    /// </summary>
    public static class U8Stopwatch
    {
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="action">行为</param>
        /// <returns>结果</returns>
        public static TimeSpan Execute(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            action();

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
