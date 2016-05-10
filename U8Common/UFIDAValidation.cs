using System;
using System.Text.RegularExpressions;

namespace UFIDA.Framework
{
    /// <summary>
    /// 验证
    /// </summary>
    public static class UFIDAValidation
    {
        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static bool IsDecimal(string input)
        {
            try
            {
                Convert.ToDecimal(input);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsInt32(string input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsInt16(string input)
        {
            try
            {
                Convert.ToInt16(input);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsInt64(string input)
        {
            try
            {
                Convert.ToInt64(input);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsDouble(string input) 
        {
            try
            {
                Convert.ToDouble(input);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsChar(string input)
        {
            try
            {
                Convert.ToChar(input);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsDateTime(string input)
        {
            try
            {
                Convert.ToDateTime(input);
                return true;
            }
            catch { }

            return false;
        }

        public static bool IsSingle(string input)
        {
            try
            {
                Convert.ToSingle(input);
                return true;
            }
            catch { }

            return false;
        }

        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static bool IsEmail(string input)
        {
            return Regex.IsMatch(input, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
        }
    }
}
