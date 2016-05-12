using U8.Framework.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace U8.Framework
{
    /// <summary>
    /// 多用于服务端的接口调用验证
    /// </summary>
    public static class U8Token
    {
        private static string skey = "76d027cb";

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            string content = string.Format
                (
                    "{0}^{1}^{2}^{3}",
                    U8Guid.NewGuid(),
                    DateTime.Now.ToString(),
                    "Web.SlRequest.UserHostAddress",
                    "HttpContext.Current.Request.UserAgent"
                );
            return U8Hex.ToHex(Security.U8Des.Encrypt(content, skey), System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// 校验token
        /// </summary>
        /// <param name="token">要校验的token</param>
        /// <param name="timeout">失效期限（秒）</param>
        /// <returns></returns>
        public static bool IsVerifyToken(string token, int timeout)
        {
            token = U8Hex.FromHex(token, System.Text.Encoding.UTF8);
            string[] values = Security.U8Des.Decrypt(token, skey).Split('^');
            if (Convert.ToDateTime(values[1]).AddSeconds(timeout) < DateTime.Now
                || values[2] != "Web.SlRequest.UserHostAddress"
                || values[3] != "HttpContext.Current.Request.UserAgent")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
