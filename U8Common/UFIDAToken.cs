using UFIDA.Framework.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UFIDA.Framework
{
    /// <summary>
    /// 多用于服务端的接口调用验证
    /// </summary>
    public static class UFIDAToken
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
                    UFIDAGuid.NewGuid(),
                    DateTime.Now.ToString(),
                    "Web.SlRequest.UserHostAddress",
                    "HttpContext.Current.Request.UserAgent"
                );
            return UFIDAHex.ToHex(Security.UFIDADes.Encrypt(content, skey), System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// 校验token
        /// </summary>
        /// <param name="token">要校验的token</param>
        /// <param name="timeout">失效期限（秒）</param>
        /// <returns></returns>
        public static bool IsVerifyToken(string token, int timeout)
        {
            token = UFIDAHex.FromHex(token, System.Text.Encoding.UTF8);
            string[] values = Security.UFIDADes.Decrypt(token, skey).Split('^');
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
