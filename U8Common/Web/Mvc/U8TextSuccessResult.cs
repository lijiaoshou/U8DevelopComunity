
namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Text成功结果
    /// </summary>
    public class U8TextSuccessResult : U8TextResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public U8TextSuccessResult()
            : base()
        {
            this.Content = "Success";
        }
    }
}
