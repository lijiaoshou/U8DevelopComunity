
namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Xml错误结果
    /// </summary>
    public class U8XmlErrorResult : U8XmlResult
    {
        private const string content = "<?xml version=\"1.0\" ?>\n<Result>Error</Result>";

        /// <summary>
        /// 构造函数
        /// </summary>
        public U8XmlErrorResult()
            : base()
        {
            this.Content = content;
        }
    }
}
