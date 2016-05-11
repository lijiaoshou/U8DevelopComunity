using U8.Framework.Security;
using U8.Framework.Web;
using U8.Framework.Xml;
using System;
using System.Linq;
using System.Web;

namespace U8.Framework
{
    /// <summary>
    /// 单点登录
    /// </summary>
    public static class U8Sso
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="ssoApiUrl">SsoApiUrl</param>
        /// <param name="ssoServiceID">SsoServiceID</param>
        /// <param name="email">邮箱</param>
        /// <param name="password">密码</param>
        /// <param name="successAction">成功</param>
        /// <param name="errorAction">失败</param>
        /// <returns>结果</returns>
        public static bool Login(string ssoApiUrl, string ssoServiceID, string email, string password, Action<string> successAction = null, Action<string> errorAction = null)
        {
            string url = ssoApiUrl + "?act=lgn&login=" + email + "&passwd=" + U8Md5.HashPassword(password) + "&service=" + ssoServiceID + "&ip=" + U8Request.UserHostAddress + "&userinfo=" + email + "&guid=" + U8Guid.NewGuid();

            var xml = U8Request.GetHtml(url);

            var xmlNode = U8XmlDocument.Select(xml, "/isso/code");

            if (xmlNode.InnerText == "0")
            {
                if (successAction != null)
                {
                    successAction(email);
                }
                return true;
            }
            else
            {
                //失败
                var error = U8XmlDocument.Select(xml, "/isso/msg").InnerText;
                if (errorAction != null)
                {
                    errorAction(email);
                }
                return false;
            }
        }

        /// <summary>
        /// 用户自动登录
        /// </summary>
        /// <param name="ssoApiUrl">SsoApiUrl</param>
        /// <param name="ssoServiceID">SsoServiceID</param>
        /// <param name="successAction">成功</param>
        /// <param name="errorAction">失败</param>
        /// <returns>结果</returns>
        public static bool AutoLogin(string ssoApiUrl, string ssoServiceID, Action<string> successAction = null, Action<string> errorAction = null)
        {
            var cookies = HttpContext.Current.Request.Cookies;

            if (cookies != null && cookies.AllKeys.Contains("isso_uuid") && cookies.AllKeys.Contains("isso_login") && cookies.AllKeys.Contains("isso_passwd") && cookies.AllKeys.Contains("isso_ticket"))
            {
                string uuid = cookies["isso_uuid"].Value;
                string email = HttpContext.Current.Server.UrlDecode(cookies["isso_login"].Value);
                string password = cookies["isso_passwd"].Value;
                string ticket = cookies["isso_ticket"].Value;

                string url = ssoApiUrl + "?act=chk&uuid=" + uuid + "&login=" + email + "&passwd=" + password + "&service=" + ssoServiceID + "&ticket=" + ticket + "&ip=" + U8Request.UserHostAddress + "&userinfo=" + "&guid=" + U8Guid.NewGuid();

                var xml = U8Request.GetHtml(url);

                var xmlNode = U8XmlDocument.Select(xml, "/isso/code");

                if (xmlNode.InnerText == "0")
                {
                    if (successAction != null)
                    {
                        successAction(email);
                    }
                    return true;
                }
                else
                {
                    //失败
                    var error = U8XmlDocument.Select(xml, "/isso/msg").InnerText;
                    if (errorAction != null)
                    {
                        errorAction(email);
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 用户激活
        /// </summary>
        /// <param name="ssoApiUrl">SsoApiUrl</param>
        /// <param name="ssoServiceID">SsoServiceID</param>
        /// <param name="email">邮箱</param>
        /// <param name="successAction">成功</param>
        /// <param name="errorAction">失败</param>
        /// <returns>结果</returns>
        public static bool Active(string ssoApiUrl, string ssoServiceID, string email, Action<string> successAction = null, Action<string> errorAction = null)
        {
            string url = ssoApiUrl + "?act=actv&login=" + email + "&service=" + ssoServiceID + "&ip=" + U8Request.UserHostAddress + "&userinfo=" + email + "&guid=" + U8Guid.NewGuid();

            var xml = U8Request.GetHtml(url);

            var xmlNode = U8XmlDocument.Select(xml, "/isso/code");

            if (xmlNode.InnerText == "0")
            {
                if (successAction != null)
                {
                    successAction(email);
                }
                return true;
            }
            else
            {
                //失败
                var error = U8XmlDocument.Select(xml, "/isso/msg").InnerText;
                if (errorAction != null)
                {
                    errorAction(email);
                }
                return false;
            }
        }

        /// <summary>
        /// 用户取消激活
        /// </summary>
        /// <param name="ssoApiUrl">SsoApiUrl</param>
        /// <param name="ssoServiceID">SsoServiceID</param>
        /// <param name="email">邮箱</param>
        /// <param name="successAction">成功</param>
        /// <param name="errorAction">失败</param>
        /// <returns>结果</returns>
        public static bool DeActive(string ssoApiUrl, string ssoServiceID, string email, Action<string> successAction = null, Action<string> errorAction = null)
        {
            string url = ssoApiUrl + "?act=deactv&login=" + email + "&service=" + ssoServiceID + "&ip=" + U8Request.UserHostAddress + "&userinfo=" + email + "&guid=" + U8Guid.NewGuid();

            var xml = U8Request.GetHtml(url);

            var xmlNode = U8XmlDocument.Select(xml, "/isso/code");

            if (xmlNode.InnerText == "0")
            {
                if (successAction != null)
                {
                    successAction(email);
                }
                return true;
            }
            else
            {
                //失败
                var error = U8XmlDocument.Select(xml, "/isso/msg").InnerText;
                if (errorAction != null)
                {
                    errorAction(email);
                }
                return false;
            }
        }
    }
}
