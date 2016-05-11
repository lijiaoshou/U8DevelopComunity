using System.Web.Mvc;

namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Text结果
    /// </summary>
    public class U8TextResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public U8TextResult()
            : base()
        {
            this.ContentType = U8MimeType.Text;
        }
    }
}
