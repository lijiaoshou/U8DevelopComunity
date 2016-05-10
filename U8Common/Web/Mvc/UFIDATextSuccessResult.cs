
namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Text成功结果
    /// </summary>
    public class UFIDATextSuccessResult : UFIDATextResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UFIDATextSuccessResult()
            : base()
        {
            this.Content = "Success";
        }
    }
}
