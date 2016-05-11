
namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Xml成功结果
    /// </summary>
    public class U8XmlSuccessResult : U8XmlResult
    {
        private const string content = "<?xml version=\"1.0\" ?>\n<Result>Success</Result>";

        /// <summary>
        /// 构造函数
        /// </summary>
        public U8XmlSuccessResult()
            : base()
        {
            this.Content = content;
        }
    }
}
