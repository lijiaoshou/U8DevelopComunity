
namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Json错误结果
    /// </summary>
    public class U8JsonErrorResult : U8JsonResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public U8JsonErrorResult()
            : base()
        {
            this.Content = U8Json.ToJson(new { Message = "Error" });
        }
    }
}
