
namespace UFIDA.Framework.Text.KeywordMatch
{
    /// <summary>
    /// 失效点
    /// </summary>
    public class UFIDAFailOverNode
    {
        /// <summary>
        /// 偏移量
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 节点
        /// </summary>
        public UFIDAAbstractMatchNode Node { get; set; }
    }
}
