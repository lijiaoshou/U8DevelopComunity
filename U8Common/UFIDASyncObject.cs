
namespace UFIDA.Framework
{
    /// <summary>
    /// 同步对象
    /// </summary>
    internal static class UFIDASyncObject
    {
        /// <summary>
        /// 管理器锁
        /// </summary>
        internal readonly static object IO_SlLog_Lock = new object();
    }
}
