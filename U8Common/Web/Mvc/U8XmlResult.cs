using System.Web.Mvc;

namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Xml结果
    /// </summary>
    public class U8XmlResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public U8XmlResult()
            : base()
        {
            this.ContentType = U8MimeType.Xml;
        }
    }
}
