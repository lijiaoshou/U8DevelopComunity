
namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Json成功结果
    /// </summary>
    public class U8JsonSuccessResult : U8JsonResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public U8JsonSuccessResult()
            : base()
        {
            this.Content = U8Json.ToJson(new { Message = "Success" });
        }
    }
}
