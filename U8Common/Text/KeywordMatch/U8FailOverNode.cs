
namespace U8.Framework.Text.KeywordMatch
{
    /// <summary>
    /// 失效点
    /// </summary>
    public class U8FailOverNode
    {
        /// <summary>
        /// 偏移量
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 节点
        /// </summary>
        public U8AbstractMatchNode Node { get; set; }
    }
}
