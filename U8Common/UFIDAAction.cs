using System;
using System.Threading;

namespace UFIDA.Framework
{
    /// <summary>
    /// 行为
    /// </summary>
    public static class UFIDAAction
    {
        /// <summary>
        /// 尝试
        /// </summary>
        /// <param name="action">行为</param>
        /// <param name="maxTryCount">最大尝试次数</param>
        /// <param name="interval">间隔（毫秒）</param>
        public static void Try(Action action, int maxTryCount = 10, int interval = 60 * 1000)
        {


            bool isSuccess = false;
            var tryCount = 0;
            var outException = default(Exception);

            while (tryCount < maxTryCount)
            {
                try
                {
                    action();
                    isSuccess = true;
                    break;
                }
                catch (Exception exception)
                {
                    outException = exception;
                    tryCount++;
                    Thread.Sleep(interval);
                }
            }

            if (!isSuccess)
            {
                if (outException != null)
                {
                    throw outException;
                }
                else
                {
                    throw new Exception("尝试执行失败！");
                }
            }
        }
    }
}
