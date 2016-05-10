
namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Json成功结果
    /// </summary>
    public class UFIDAJsonSuccessResult : UFIDAJsonResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDAJsonSuccessResult()
            : base()
        {
            this.Content = UFIDAJson.ToJson(new { Message = "Success" });
        }
    }
}
