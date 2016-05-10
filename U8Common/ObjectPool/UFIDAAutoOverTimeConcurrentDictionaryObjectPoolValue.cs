using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.Framework.ObjectPool
{
    /// <summary>
    /// 自动失效基于并行字典的对象池的值基类（必须继承此基类，才能正常清理）
    /// </summary>
    [Serializable]
    public abstract class UFIDAAutoOverTimeConcurrentDictionaryObjectPoolValue
    {
        /// <summary>
        /// 对象时间戳
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
