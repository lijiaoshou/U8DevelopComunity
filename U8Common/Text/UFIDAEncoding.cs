using System.Text;

namespace UFIDA.Framework.Text
{
    /// <summary>
    /// 编码
    /// </summary>
    public static class UFIDAEncoding
    {
        /// <summary>
        /// 默认编码
        /// </summary>
        public static Encoding Default = Encoding.UTF8;

        /// <summary>
        /// 转换Iso8859为GB2312
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string ConvertIso8859ToGB2312(string input)
        {
            var iso8859 = Encoding.GetEncoding("iso8859-1");
            var gb2312 = Encoding.GetEncoding("gb2312");

            var bytes = iso8859.GetBytes(input);
            return gb2312.GetString(bytes);
        }

        /// <summary>
        /// 转换GB2312为Iso8859
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string ConvertGB2312ToIso8859(string input)
        {
            var iso8859 = Encoding.GetEncoding("iso8859-1");
            var gb2312 = Encoding.GetEncoding("gb2312");

            var bytes = gb2312.GetBytes(input);
            return iso8859.GetString(bytes);
        }

        /// <summary>
        /// 转换为无Bom的Utf8编码
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string ConvertUtf8WithOutBom(string input)
        {
            var encoding = new UTF8Encoding(false);
            var bytes = encoding.GetBytes(input);
            return encoding.GetString(bytes);
        }
    }
}
