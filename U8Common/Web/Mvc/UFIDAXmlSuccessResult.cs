
namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Xml成功结果
    /// </summary>
    public class UFIDAXmlSuccessResult : UFIDAXmlResult
    {
        private const string content = "<?xml version=\"1.0\" ?>\n<Result>Success</Result>";

        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDAXmlSuccessResult()
            : base()
        {
            this.Content = content;
        }
    }
}
