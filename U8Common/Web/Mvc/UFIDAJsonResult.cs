using System.Web.Mvc;

namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Json结果
    /// </summary>
    public class UFIDAJsonResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDAJsonResult()
            : base()
        {
            this.ContentType = UFIDAMimeType.Json;
        }
    }
}
