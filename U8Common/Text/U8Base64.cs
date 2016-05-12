using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace U8.Framework.Text
{
    /// <summary>
    /// SlBase64处理
    /// </summary>
    public static class U8Base64
    {
        /// <summary>
        /// 转换为Base64
        /// </summary>
        /// <param name="datas">数据</param>
        /// <returns>转换的结果</returns>
        public static byte[] ToBase64Byte(byte[] datas)
        {
            return U8Encoding.Default.GetBytes(Convert.ToBase64String(datas));
        }

        /// <summary>
        /// 转换为Base64
        /// </summary>
        /// <param name="datas">数据</param>
        /// <returns>转换的结果</returns>
        public static byte[] ToBase64Byte(byte[] datas, Encoding encoding = null)
        {
            encoding = encoding ?? U8Encoding.Default;
            return encoding.GetBytes(Convert.ToBase64String(datas));
        }

        /// <summary>
        /// 转换为Base64
        /// </summary>
        /// <param name="datas">数据</param>
        /// <returns>转换的结果</returns>
        public static string ToBase64String(byte[] datas)
        {
            return Convert.ToBase64String(datas);
        }

        /// <summary>
        /// 转换为Base64
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>转换的结果</returns>
        public static string ToBase64String(string input, Encoding encoding = null)
        {
            encoding = encoding ?? U8Encoding.Default;
            byte[] bytes = encoding.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 由Base64数据转换为原形式
        /// </summary>
        /// <param name="Base64Data">Base64数据</param>
        /// <returns>原形式</returns>
        public static byte[] FromBase64Byte(byte[] Base64Data)
        {
            string input = U8Encoding.Default.GetString(Base64Data);
            return Convert.FromBase64String(input);
        }
    /// <summary>
        /// 由Base64数据转换为原形式
    /// </summary>
        /// <param name="Base64Data">Base64数据</param>
    /// <param name="encoding">编码方式</param>
    /// <returns>原形式</returns>
        public static byte[] FromBase64Byte(byte[] Base64Data, Encoding encoding = null)
        {
            encoding = encoding ?? U8Encoding.Default;
            string input = encoding.GetString(Base64Data);
            return Convert.FromBase64String(input);
        }
        /// <summary>
        /// 由Base64数据转换为原形式
        /// </summary>
        /// <param name="Base64Data">Base64数据</param>
        /// <returns>原形式</returns>
        public static string FromBase64String(byte[] Base64Data)
        {
            string input = U8Encoding.Default.GetString(Base64Data);
            byte[] outputb = Convert.FromBase64String(input);
            return U8Encoding.Default.GetString(outputb);
        }
        /// <summary>
        /// 由Base64数据转换为原形式
        /// </summary>
        /// <param name="Base64Data">Base64数据</param>
      /// <param name="encoding">编码方式</param>
        /// <returns>原形式</returns>
        public static string FromBase64String(byte[] Base64Data, Encoding encoding = null)
        {
            encoding = encoding ?? U8Encoding.Default;
            string input = encoding.GetString(Base64Data);
            byte[] outputb = Convert.FromBase64String(input);
            return encoding.GetString(outputb);
        }
        /// <summary>
        /// 转换回原形式
        /// </summary>
        /// <param name="input">待转换的字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>原形式</returns>
        public static string FromBase64String(string input, Encoding encoding = null)
        {
            encoding = encoding ?? U8Encoding.Default;
            byte[] outputb = Convert.FromBase64String(input);
            return encoding.GetString(outputb);
        }
    }
}
