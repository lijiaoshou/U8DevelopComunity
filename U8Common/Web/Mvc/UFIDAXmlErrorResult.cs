
namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Xml错误结果
    /// </summary>
    public class UFIDAXmlErrorResult : UFIDAXmlResult
    {
        private const string content = "<?xml version=\"1.0\" ?>\n<Result>Error</Result>";

        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDAXmlErrorResult()
            : base()
        {
            this.Content = content;
        }
    }
}
