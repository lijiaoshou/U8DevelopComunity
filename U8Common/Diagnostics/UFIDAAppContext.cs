using System;
using System.IO;
using System.Reflection;

namespace UFIDA.Framework.Diagnostics
{
    /// <summary>
    /// App上下文
    /// </summary>
    public static class UFIDAAppContext
    {
        /// <summary>
        /// 启动时间
        /// </summary>
        public readonly static DateTime StartupTime = DateTime.Now;

        /// <summary>
        /// 程序所在目录（有斜线结尾）
        /// </summary>
        public static readonly string Directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).TrimEnd('\\') + "\\";

        /// <summary>
        /// 程序名称
        /// </summary>
        public static readonly string Name = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);

        /// <summary>
        /// 程序集日志文件的路径
        /// </summary>
        public static string LogFilePath = Directory + StartupTime.ToString("yyyyMMddHHmmss") + ".log";
    }
}
