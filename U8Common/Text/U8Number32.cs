using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Framework.Text
{
    /// <summary>
    /// 整数与32进制间的转换
    /// </summary>
    public class U8Number32
    {
        /// <summary>
        /// 0-31 对应32个字符
        /// </summary>
        private const string zipMapWords = "0123456789abcdefghjklmnpqrtuvwxy";

        /// <summary>
        /// 整数与32进制 对照字典
        /// </summary>
        private static readonly Dictionary<string, string> dictNumberTo32 = new Dictionary<string, string>();

        /// <summary>
        /// 32进制与整数 对照字典
        /// </summary>
        private static readonly Dictionary<string, string> dict32ToNumber = new Dictionary<string, string>();

        /// <summary>
        /// 初始化字典
        /// </summary>
        static U8Number32()
        {
            int i = 0;
            string key = "", value = "";
            foreach (var item in zipMapWords)
            {
                key = i.ToString();
                value = item.ToString();
                //压缩\反压缩字典key-value相反,以实现快速查找.
                dictNumberTo32.Add(key, value);
                dict32ToNumber.Add(value, key);
                i++;
            }
        }

        /// <summary>
        /// 整数转为32进制
        /// </summary>
        /// <param name="theNumber">要转换的整数</param>
        /// <returns></returns>
        public static string ConvertTo32(long theNumber)
        {
            string num32 = "";
            convertTo32(theNumber, ref num32);
            return num32;
        }
        private static void convertTo32(long theNumber, ref string num32)
        {
            long temp;
            temp = theNumber % 32;
            num32 = chang(temp) + num32;
            if (0 != theNumber / 32)
            {
                convertTo32(theNumber / 32, ref num32);
            }
        }

        /// <summary>
        /// 32进制转为整数
        /// </summary>
        /// <param name="the32Data">32进制</param>
        /// <returns></returns>
        public static long ConvertToNumber(string the32Data)
        {
            long result = 0;
            try
            {
                the32Data = the32Data.ToLower();
                int i = 0;
                foreach (var item in the32Data)
                {
                    result += int.Parse(dict32ToNumber[item.ToString()]) * (long)Math.Pow(32, the32Data.Length - i - 1);
                    i++;
                }
            }
            catch { }
            return result;
        }


        /// <summary>
        /// 整数对应的32进制值
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string chang(long number)
        {
            try
            {
                return dictNumberTo32[number.ToString()];
            }
            catch { }
            return number.ToString();
        }
    }
}
