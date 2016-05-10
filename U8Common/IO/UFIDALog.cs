using UFIDA.Framework.Diagnostics;
using System;
using System.Text;

namespace UFIDA.Framework.IO
{
    /// <summary>
    /// 日志处理（因为日志操作一般均是对同一个文件的处理，因此实现为线程安全）
    /// </summary>
    public static class UFIDALog
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="traceType">跟踪类型</param>
        /// <param name="message">消息</param>
        public static void Write(UFIDATraceType traceType, string message)
        {
            if (traceType.HasFlag(UFIDATraceType.Log))
            {
                lock (UFIDASyncObject.IO_SlLog_Lock)
                {
                    UFIDAFile.Write(UFIDAAppContext.LogFilePath, message);
                }
            }
            if (traceType.HasFlag(UFIDATraceType.Console))
            {
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// 新行
        /// </summary>
        /// <param name="traceType">跟踪类型</param>
        public static void NewLine(UFIDATraceType traceType)
        {
            Write(traceType, string.Empty);
        }

        /// <summary>
        /// 追踪
        /// </summary>
        /// <param name="traceType">跟踪类型</param>
        /// <param name="action">动作</param>
        /// <param name="title">标题</param>
        /// <param name="divide">分割线</param>
        public static void Track(UFIDATraceType traceType, Action action, string title, string divide)
        {
            var messages = new StringBuilder();
            messages.AppendLine(divide);
            messages.AppendLine(string.Format("{0}：", title));
            messages.AppendLine(string.Format("     StartTime：{0}", UFIDADateTime.Now));

            var time = UFIDAStopwatch.Execute(action);

            messages.AppendLine(string.Format("     EndTime：{0}", UFIDADateTime.Now));
            messages.Append(string.Format("     TotalSeconds：{0}", time.TotalSeconds.ToString("F8")));

            Write(traceType, messages.ToString());
        }

        /// <summary>
        /// 追踪
        /// </summary>
        /// <param name="traceType">跟踪类型</param>
        /// <param name="title">标题</param>
        /// <param name="divide">分割线</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="time">耗时</param>
        public static void Track(UFIDATraceType traceType, string title, string divide, string startTime, string endTime, TimeSpan time)
        {
            var messages = new StringBuilder();
            messages.AppendLine(divide);
            messages.AppendLine(string.Format("{0}：", title));
            messages.AppendLine(string.Format("     StartTime：{0}", startTime));
            messages.AppendLine(string.Format("     EndTime：{0}", endTime));
            messages.Append(string.Format("     TotalSeconds：{0}", time.TotalSeconds.ToString("F8")));

            Write(traceType, messages.ToString());
        }
    }
}
