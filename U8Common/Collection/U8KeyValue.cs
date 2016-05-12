
namespace U8.Framework.Collection
{
    /// <summary>
    /// 键值
    /// </summary>
    /// <typeparam name="TKey">键</typeparam>
    /// <typeparam name="TValue">值</typeparam>
    public class U8KeyValue<TKey, TValue>
    {
        /// <summary>
        /// 键
        /// </summary>
        public TKey Key;

        /// <summary>
        /// 值
        /// </summary>
        public TValue Value;

        /// <summary>
        /// 重写Equals
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>结果</returns>
        public override bool Equals(object obj)
        {
            var other = obj as U8KeyValue<TKey, TValue>;
            if (other != null)
            {
                return this.Key.Equals(other.Key);
            }
            return false;
        }

        /// <summary>
        /// 重写GetHashCode
        /// </summary>
        /// <returns>结果</returns>
        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }
    }
}
