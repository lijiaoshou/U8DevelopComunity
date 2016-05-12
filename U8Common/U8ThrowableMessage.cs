using System;

namespace U8.Framework
{
    /// <summary>
    /// 可抛出消息
    /// </summary>
    [Serializable]
    public class U8ThrowableMessage : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">消息</param>
        public U8ThrowableMessage(string message)
            : base(message)
        { }
    }
}
