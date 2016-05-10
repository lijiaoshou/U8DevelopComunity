
namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Text错误结果
    /// </summary>
    public class UFIDATextErrorResult : UFIDATextResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDATextErrorResult()
            : base()
        {
            this.Content = "Error";
        }
    }
}
