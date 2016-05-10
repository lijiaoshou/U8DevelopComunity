using System.Web.Mvc;

namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Text结果
    /// </summary>
    public class UFIDATextResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDATextResult()
            : base()
        {
            this.ContentType = UFIDAMimeType.Text;
        }
    }
}
