namespace UFIDA.Framework.Text.KeywordMatch
{
    /// <summary>
    /// 匹配节点
    /// </summary>
    public interface UFIDAIMatchNode
    {
        /// <summary>
        /// 增加字符
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        UFIDAAbstractMatchNode AddChar(char c);

        /// <summary>
        /// 重置位置
        /// </summary>
        void ResetPosition();

        /// <summary>
        /// 当前失效点
        /// </summary>
        UFIDAFailOverNode CurrentFailover { get; set; }

        /// <summary>
        /// 父级失效点
        /// </summary>
        UFIDAFailOverNode ParentFailover { get; }

        /// <summary>
        /// 设置位置
        /// </summary>
        /// <param name="position">位置</param>
        void SetPosition(int position);

        /// <summary>
        /// 设置待匹配的关键字到列表
        /// </summary>
        /// <param name="keyword">关键字</param>
        void SetKeyword(string keyword);

        /// <summary>
        /// 移动到下一个位置
        /// </summary>
        /// <returns>结果</returns>
        bool MoveToNextPosition();

        /// <summary>
        /// 判断是否有子节点
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        bool HasChild(char c);

        /// <summary>
        /// 获取子节点
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>结果</returns>
        UFIDAAbstractMatchNode GetChild(char c);

        /// <summary>
        /// 找到失效点
        /// </summary>
        /// <param name="rootNode">根</param>
        void MatchFailOver(UFIDAAbstractMatchNode rootNode);

        /// <summary>
        /// 当前的关键字
        /// </summary>
        string CurrentKeyword { get; }

        /// <summary>
        /// 设置失效点
        /// </summary>
        /// <param name="offset">偏移量</param>
        /// <param name="failOverNode">失效点</param>
        void SetFailover(int offset, UFIDAFailOverNode failOverNode);
    }
}
