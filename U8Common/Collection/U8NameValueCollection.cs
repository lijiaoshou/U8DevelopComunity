using System.Collections.Specialized;

namespace U8.Framework.Collection
{
    /// <summary>
    /// NameValueCollection
    /// </summary>
    public static class U8NameValueCollection
    {
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="nameValueCollection">对象</param>
        /// <returns>结果</returns>
        public static string ToString(NameValueCollection nameValueCollection)
        {
            var result = string.Empty;
            for (int i = 0; i < nameValueCollection.Count; i++)
            {
                var key = nameValueCollection.GetKey(i);
                var value = nameValueCollection.Get(i);
                result = result + string.Format("{0}={1}", key, value) + "&";
            }
            return result.TrimEnd('&');
        }
    }
}
