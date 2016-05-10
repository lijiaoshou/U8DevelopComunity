
namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Json错误结果
    /// </summary>
    public class UFIDAJsonErrorResult : UFIDAJsonResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDAJsonErrorResult()
            : base()
        {
            this.Content = UFIDAJson.ToJson(new { Message = "Error" });
        }
    }
}
