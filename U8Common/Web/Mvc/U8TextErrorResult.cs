
namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Text错误结果
    /// </summary>
    public class U8TextErrorResult : U8TextResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public U8TextErrorResult()
            : base()
        {
            this.Content = "Error";
        }
    }
}
