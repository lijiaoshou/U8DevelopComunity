using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UFIDA.Framework.IO;

namespace UFIDA.Framework.ObjectPool
{

    public class UFIDAAutoOverTimeFileConcurrentDictionaryObjectPool<TKey, TValue> : IDisposable where TValue : UFIDAAutoOverTimeConcurrentDictionaryObjectPoolValue
    {
        private ConcurrentDictionary<TKey, TValue> dictionary = new ConcurrentDictionary<TKey, TValue>();

        private System.Timers.Timer timer;

        private double OverTimeInterval;

        private string filePath;

        private UFIDAFileType fileType = UFIDAFileType.Text;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="overTimeInterval">失效间隔，单位为秒（多长时间之前的数据失效，0代表永不自动失效）</param>
        /// <param name="clearInterval">清理时间间隔（建议不太频繁）</param>
        /// <param name="filePath">文件地址</param>
        public UFIDAAutoOverTimeFileConcurrentDictionaryObjectPool(double overTimeInterval, double clearInterval, string filePath, UFIDAFileType fileType = UFIDAFileType.Text)
        {
            if (overTimeInterval > 0)
            {
                this.filePath = filePath;
                this.fileType = fileType;
                this.dictionary = UFIDAFile.BinaryRead<ConcurrentDictionary<TKey, TValue>>(this.filePath, fileType);
                this.OverTimeInterval = overTimeInterval;
                timer = new System.Timers.Timer(clearInterval * 1000);
                timer.Elapsed += time_Elapsed;
                timer.Start();
            }
        }

        private void time_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timestamp = DateTime.Now.AddSeconds(-this.OverTimeInterval);

            this.OverTimeClear(timestamp);
        }

        /// <summary>
        /// 增加一项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Add(TKey key, TValue value)
        {
            this.dictionary.AddOrUpdate(key, value, (newKey, newValue) =>
            {
                return this.dictionary[newKey];
            });
        }

        /// <summary>
        /// 判断存在与否
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>结果</returns>
        public bool Contains(TKey key)
        {
            return this.dictionary.ContainsKey(key);
        }

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns>结果</returns>
        public List<KeyValuePair<TKey, TValue>> GetItems()
        {
            return this.dictionary.ToList();
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            this.dictionary.Clear();
        }

        /// <summary>
        /// 删除一项
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key)
        {
            TValue value = default(TValue);

            this.dictionary.TryRemove(key, out value);
        }

        /// <summary>
        /// 失效清理（将某个时间戳之前的数据全部删除）
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        public void OverTimeClear(DateTime timestamp)
        {
            var list = new List<TKey>();
            foreach (var kv in this.dictionary)
            {
                var value = kv.Value as UFIDAAutoOverTimeConcurrentDictionaryObjectPoolValue;

                if (value.Timestamp <= timestamp)
                {
                    list.Add(kv.Key);
                }
            }

            list.ForEach(key =>
            {
                this.Remove(key);
            });
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Dispose()
        {
            this.timer.Stop();
            this.timer.Dispose();
            UFIDAFile.BinaryWrite(this.dictionary, this.filePath, this.fileType);
        }
    }
}
