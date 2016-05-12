namespace U8.Framework.Text.KeywordMatch
{
    /// <summary>
    /// 匹配结果
    /// </summary>
    public class U8MatchResult
    {
        /// <summary>
        /// 开始索引
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
    }
}