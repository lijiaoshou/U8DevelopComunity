using System.Web.Script.Serialization;

namespace UFIDA.Framework.Web
{
    /// <summary>
    /// Json格式数据处理
    /// </summary>
    public static class UFIDAJson
    {
        /// <summary>
        /// 序列化器
        /// </summary>
        private static readonly JavaScriptSerializer serializer;

        /// <summary>
        /// 构造函数
        /// </summary>
        static UFIDAJson()
        {
            serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = int.MaxValue;
            serializer.RecursionLimit = int.MaxValue;
        }

        /// <summary>
        /// 将对象序列化为Json格式的字符串
        /// </summary>
        /// <param name="source">源类型对象</param>
        /// <returns>Json格式的字符串</returns>
        public static string ToJson(object source)
        {
            return serializer.Serialize(source);
        }

        /// <summary>
        /// 将Json格式的数据转换为对象
        /// </summary>
        /// <typeparam name="T">源类型</typeparam>
        /// <param name="json">json格式的字符串</param>
        /// <returns>序列化之后的格式</returns>
        public static T FromJson<T>(string json)
        {
            return serializer.Deserialize<T>(json);
        }

        /// <summary>
        /// 判断是否相等
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <returns>结果</returns>
        public static bool JsonEquals(object a, object b)
        {
            return ToJson(a) == ToJson(b);
        }

        /// <summary>
        /// 获得安全字符串
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string GetSafeJson(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            return UFIDAJson.ToJson(input).TrimStart('"').TrimEnd('"');
        }
    }
}
