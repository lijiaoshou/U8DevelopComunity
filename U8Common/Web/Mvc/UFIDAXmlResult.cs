using System.Web.Mvc;

namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Xml结果
    /// </summary>
    public class UFIDAXmlResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDAXmlResult()
            : base()
        {
            this.ContentType = UFIDAMimeType.Xml;
        }
    }
}
