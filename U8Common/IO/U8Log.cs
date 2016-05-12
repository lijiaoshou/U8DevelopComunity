using U8.Framework.Diagnostics;
using System;
using System.Text;

namespace U8.Framework.IO
{
    /// <summary>
    /// 日志处理（因为日志操作一般均是对同一个文件的处理，因此实现为线程安全）
    /// </summary>
    public static class U8Log
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="traceType">跟踪类型</param>
        /// <param name="message">消息</param>
        public static void Write(U8TraceType traceType, string message)
        {
            if (traceType.HasFlag(U8TraceType.Log))
            {
                lock (U8SyncObject.IO_SlLog_Lock)
                {
                    U8File.Write(U8AppContext.LogFilePath, message);
                }
            }
            if (traceType.HasFlag(U8TraceType.Console))
            {
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// 新行
        /// </summary>
        /// <param name="traceType">跟踪类型</param>
        public static void NewLine(U8TraceType traceType)
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
        public static void Track(U8TraceType traceType, Action action, string title, string divide)
        {
            var messages = new StringBuilder();
            messages.AppendLine(divide);
            messages.AppendLine(string.Format("{0}：", title));
            messages.AppendLine(string.Format("     StartTime：{0}", U8DateTime.Now));

            var time = U8Stopwatch.Execute(action);

            messages.AppendLine(string.Format("     EndTime：{0}", U8DateTime.Now));
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
        public static void Track(U8TraceType traceType, string title, string divide, string startTime, string endTime, TimeSpan time)
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
