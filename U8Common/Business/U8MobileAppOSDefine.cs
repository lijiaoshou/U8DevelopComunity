
namespace U8.Framework.Business
{
    /// <summary>
    /// 移动的操作系统定义
    /// </summary>
    public static class U8MobileAppOSDefine
    {
        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>结果</returns>
        public static int GetID(string name)
        {
            if (name.Contains("android"))
            {
                return 1;
            }
            else if (name.Contains("ios") || name.Contains("ipad") || name.Contains("iphone"))
            {
                return 2;
            }
            else if (name.Contains("wp"))
            {
                return 3;
            }
            else if (name.Contains("symbian"))
            {
                return 4;
            }
            else
            {
                //其他
                return 99;
            }
        }
    }
}
