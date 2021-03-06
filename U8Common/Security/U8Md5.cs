﻿using System.Web.Security;

namespace U8.Framework.Security
{
    /// <summary>
    /// MD5安全
    /// </summary>
    public static class U8Md5
    {
        /// <summary>
        /// 哈希值
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string HashPassword(string input)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
        }
    }
}
