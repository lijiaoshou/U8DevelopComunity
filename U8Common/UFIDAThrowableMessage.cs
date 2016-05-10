using System;

namespace UFIDA.Framework
{
    /// <summary>
    /// 可抛出消息
    /// </summary>
    [Serializable]
    public class UFIDAThrowableMessage : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">消息</param>
        public UFIDAThrowableMessage(string message)
            : base(message)
        { }
    }
}
