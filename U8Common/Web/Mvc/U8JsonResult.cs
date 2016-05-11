using System.Web.Mvc;

namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Json结果
    /// </summary>
    public class U8JsonResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public U8JsonResult()
            : base()
        {
            this.ContentType = U8MimeType.Json;
        }
    }
}
