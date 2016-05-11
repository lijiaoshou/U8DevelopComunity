using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using U8.Framework.Configuration;
using U8.Framework.Security;
using U8.Framework.Web;
using U8.Framework.Xml;

namespace U8.Framework.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class U8PassportUserModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 是否手机用户
        /// </summary>
        public bool IsMobileUser { get; set; }
    }
    /// <summary>
    /// 通行证相关操作
    /// </summary>
    public class Passport
    {
        /// <summary>
        /// 退出
        /// </summary>
        public static void Logout()
        {
            ////清除新版的通信证cookies
            //U8PassportCookies.ClearCookie("new_loginCookieName");
            //U8PassportCookies.ClearCookie("new_loginid");
            //U8PassportCookies.ClearCookie("new_loginpwd");
            //U8PassportCookies.ClearCookie("new_validation");
            //U8PassportCookies.ClearCookie("new_isvalid");
            //U8PassportCookies.ClearCookie("new_loginpwd");
            //U8PassportCookies.ClearCookie("ask_isvalid");
            //U8PassportCookies.ClearCookie("UserCookieName_isvalid");
            ////旧版手机用户cookie
            //U8PassportCookies.ClearCookie("UserCookieName_isvalid");
            //U8PassportCookies.ClearCookie("mobile_loginCookieName");
            //U8PassportCookies.ClearCookie("mobile_loginpwd");
            //U8PassportCookies.ClearCookie("mobile_loginid");
            //U8PassportCookies.ClearCookie("mobile_validation");
            //U8PassportCookies.ClearCookie("ask_userCookieName");
            //U8PassportCookies.ClearCookie("ask_userID");
            //U8PassportCookies.ClearCookie("ask_userVaild");
            //U8PassportCookies.ClearCookie("ask_userPsw");

            ////清除新版的通信证cookies
            //U8PassportCookies.ClearCookie();
        }

        /// <summary>
        /// 获取当天登录用户
        /// </summary>
        public static U8PassportUserModel CurrentUser
        {
            get
            {
                long userId = 0;// long.Parse(U8PassportCookies.GetUserID());
                string userName = "";// U8PassportCookies.GetUserName();
                string password = "";// U8PassportCookies.GetPassword();
                string validation = "";// U8PassportCookies.GetValidation();

                if (userId > 0 && !string.IsNullOrWhiteSpace(password))
                {
                    if (validation == userId + "," + userName || validation == userName + userId)
                    {
                        return new U8PassportUserModel() { UserId = userId, UserName = userName };
                    }
                }
                return default(U8PassportUserModel);
            }
        }
        /// <summary>
        /// 是否登录状态
        /// </summary>
        public static bool IsAuthenticated
        {
            get
            {
                //return CurrentUser != default(U8PassportUserModel) && CurrentUser.UserId > 0;
                return true;
            }
        }


        /// <summary>
        /// 通行证登陆
        /// </summary>
        /// <param CookieName="userCookieName">通行证用户名</param>
        /// <param CookieName="password">通行证明文密码</param>
        /// <param CookieName="service">服务名（通行证分配）</param>
        /// <param CookieName="host">站点域名</param>
        /// <param CookieName="port">站点端口</param>
        /// <param CookieName="vcode">验证码</param>
        /// <param CookieName="successAction">成功回调</param>
        /// <param CookieName="errorAction">失败回调</param>
        /// <returns>是否登陆成功</returns>
        public static bool Login(string username, string password, string service, string host, string vcode, Action<string> successAction = null, Action<string> errorAction = null)
        {
            if (U8String.IsNullOrWhiteSpaceAny(new string[] { username, password, service, host }))
            {
                return false;
            }
            string ip = U8Request.UserHostAddress;
            string port = U8Request.UserHostPort;
            string interfaceUrl = @"http://interfacepassport.soufun.com/interface/interface_user_login_2011.aspx";
            password = U8Md5.HashPassword(Encoding.Default.GetString(Convert.FromBase64String(password)));
            string loginUrl = string.Format(
                 interfaceUrl + "?service={0}&codetype=1&userCookieName={1}&password={2}&v={3}&ip={4}&host={5}&port={6}",
                 service,
                 HttpUtility.UrlEncode(username.Trim(), Encoding.GetEncoding("gb2312")),
                 password,
                 U8Md5.HashPassword(vcode),
                 ip,
                 host,
                 port
                );
            XElement loginInfo = XElement.Load(loginUrl).Element("common");
            //发送请求并读取值
            string userCookieName = U8XmlDocument.GetValue(loginInfo, "userCookieName");
            string strUserType = U8XmlDocument.GetValue(loginInfo, "usertype");
            string isemailvalid = U8XmlDocument.GetValue(loginInfo, "isemailvalid");
            string ismobilevalid = U8XmlDocument.GetValue(loginInfo, "ismobilevalid");
            string isvalid = U8XmlDocument.GetValue(loginInfo, "isvalid");

            string result = U8XmlDocument.GetValue(loginInfo, "return_result");
            long userId = U8Convert.TryToInt64(U8XmlDocument.GetValue(loginInfo, "userid"));


            string mobileID = U8XmlDocument.GetValue(loginInfo, "cookie_mobile_loginid");
            string mobileCookieName = U8XmlDocument.GetValue(loginInfo, "cookie_mobile_loginCookieName");
            string mobilePsw = U8XmlDocument.GetValue(loginInfo, "cookie_mobile_loginpwd");

            string mobileVaild = U8XmlDocument.GetValue(loginInfo, "cookie_mobile_validation");
            string email = U8XmlDocument.GetValue(loginInfo, "email");

            //判断返回的值
            switch (result)
            {
                case "100":
                    //普通用户 登陆成功, 记录用户信息到Cookie
                    if (strUserType == "1")
                    {
                        //保存新版本的通信证cookies
                        //U8PassportCookies.SetCookies(strUserType, userId.ToString(), userCookieName, password, isvalid, userId.ToString() + "," + userCookieName);
                    }
                    //纯手机用户 登陆成功, 记录用户信息到Cookie
                    if (strUserType == "2")
                    {
                        //保存新版本的通信证cookies
                        //U8PassportCookies.SetCookies(strUserType, mobileID, mobileCookieName, mobilePsw, mobileID + "1", mobileID + "," + mobileCookieName);
                    }
                    if (successAction != null)
                    {
                        successAction(email);
                    }
                    return true;
                case "000":
                    string message = loginInfo.Element("error_reason") == null ? "" : loginInfo.Element("error_reason").Value;
                    if (errorAction != null)
                    {
                        errorAction(message);
                    }
                    return false;
                default:
                    return false;
            }
        }
    }

    /// <summary>
    /// 获取、设置通行证Cookie
    /// </summary>
    public class PassportCookies
    {
        /// <summary>
        /// 新版cookie的加密Key
        /// </summary>
        private const string Key = "w8f3k9c2";

        /// <summary>
        /// 新版cookie的名称
        /// </summary>
        private const string CookieName = "passport";

        /// <summary>
        /// 新版cookie作用域
        /// </summary>
        private const string Domain = "soufun.com";

        /// <summary>
        /// 新版cookie编码方式
        /// </summary>
        private static Encoding encoding = Encoding.GetEncoding("GBK");

        /// <summary>
        /// 记录通行证的所有cookis
        /// </summary>
        /// <param CookieName="usertype">用户类型(1普通用户 2纯手机用户 3纯邮箱用户)</param>
        /// <param CookieName="userid">普通用户保存用户ID，纯手机用户保存手机表ID，纯邮箱用户保存邮箱表ID</param>
        /// <param CookieName="userCookieName">普通用户保存用户名，纯手机用户保存手机号，纯邮箱用户保存邮箱地址</param>
        /// <param CookieName="password">普通用户保存用户密码，纯手机用户保存手机验证码，纯邮箱用户保存邮箱密码</param>
        /// <param CookieName="isvalid">保存userid和isvalid字段的加密值...</param>
        /// <param CookieName="validation">保存userid和userCookieName字段的加密值</param>
        public static void SetCookies(string usertype, string userid, string userCookieName, string password, string isvalid, string validation)
        {
            password = U8Md5.HashPassword(password);
            HttpContext.Current.Response.Cookies[CookieName]["usertype"] = usertype;
            HttpContext.Current.Response.Cookies[CookieName]["userid"] = userid;
            HttpContext.Current.Response.Cookies[CookieName]["userCookieName"] = HttpContext.Current.Server.UrlEncode(userCookieName.Trim());
            HttpContext.Current.Response.Cookies[CookieName]["password"] = password;
            HttpContext.Current.Response.Cookies[CookieName]["isvalid"] = U8Des.EncryptForPassport(isvalid, Key, encoding);
            HttpContext.Current.Response.Cookies[CookieName]["validation"] = U8Des.EncryptForPassport(validation, Key, encoding);
            HttpContext.Current.Response.Cookies[CookieName].Domain = Domain;
            HttpContext.Current.Response.Cookies[CookieName].Expires = DateTime.Now.AddMonths(1);
        }

        /// <summary>
        /// 清空通行证的cookie
        /// </summary>
        public static void ClearCookie()
        {
            ClearCookie(CookieName);
        }

        /// <summary>
        /// 清空通行证的cookie
        /// </summary>
        /// <param name="CookieName">cookie名称</param>
        public static void ClearCookie(string CookieName)
        {
            HttpContext.Current.Response.Cookies[CookieName].Value = "";
            HttpContext.Current.Response.Cookies[CookieName].Domain = Domain;
            HttpContext.Current.Response.Cookies[CookieName].Expires = DateTime.Now.AddMonths(-1);
        }

        /// <summary>
        /// 设置单个cookie
        /// </summary>
        /// <param CookieName="key">cookie名</param>
        /// <param CookieName="value">cookie值</param>
        /// <param CookieName="needEncrypt">是否需要加密</param>
        public static void SetCookie(string key, string value, bool needEncrypt)
        {
            if (needEncrypt)
            {
                value = U8Des.EncryptForPassport(value, Key, encoding);
            }
            HttpContext.Current.Response.Cookies[CookieName][key] = value;
            HttpContext.Current.Response.Cookies[CookieName].Domain = Domain;
            HttpContext.Current.Response.Cookies[CookieName].Expires = DateTime.Now.AddMonths(1);
        }

        /// <summary>
        /// 获取通行证cookie的值
        /// </summary>
        /// <param CookieName="key">cookie名</param>
        /// <returns>cookie值</returns>
        public static string GetCookieValue(string key)
        {
            if (HttpContext.Current.Request.Cookies[CookieName] != null && HttpContext.Current.Request.Cookies[CookieName][key] != null)
            {
                return HttpContext.Current.Request.Cookies[CookieName][key];
            }
            return "";
        }

        /// <summary>
        /// 获取通行证解密后的cookie值
        /// </summary>
        /// <param CookieName="key">cookie名</param>
        /// <returns>cookie值</returns>
        public static string GetDecryptCookieValue(string key)
        {
            string value = GetCookieValue(key);
            if (!string.IsNullOrEmpty(value))
            {
                value = U8Des.DecryptForPassport(value, Key, encoding);
            }
            return value;
        }

        /// <summary>
        /// 获取已登陆的通行证用户名
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            string username = GetCookieValue("username");
            if (!string.IsNullOrEmpty(username))
            {
                username = HttpUtility.UrlDecode(username, Encoding.GetEncoding("gb2312"));
            }
            return username.Trim();
        }

        /// <summary>
        /// 获取已登录的通行证用户编号
        /// </summary>
        /// <returns></returns>
        public static string GetUserID()
        {
            return GetCookieValue("userid");
        }

        /// <summary>
        /// 获取已登录的通行证用户密码
        /// </summary>
        /// <returns></returns>
        public static string GetPassword()
        {
            return GetCookieValue("password");
        }

        /// <summary>
        /// 获取已登录通行证用户的有效信息
        /// </summary>
        /// <returns></returns>
        public static string GetVerifyInfo()
        {
            return GetDecryptCookieValue("isvalid");
        }

        /// <summary>
        /// 获取已登录通行证用户的授权信息
        /// </summary>
        /// <returns></returns>
        public static string GetValidation()
        {
            return GetDecryptCookieValue("validation");
        }
    }
}
