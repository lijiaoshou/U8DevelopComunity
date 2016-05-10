using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using UFIDA.Framework.Configuration;
using UFIDA.Framework.Security;
using UFIDA.Framework.Web;
using UFIDA.Framework.Xml;

namespace UFIDA.Framework.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class UFIDAPassportUserModel
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
            //UFIDAPassportCookies.ClearCookie("new_loginCookieName");
            //UFIDAPassportCookies.ClearCookie("new_loginid");
            //UFIDAPassportCookies.ClearCookie("new_loginpwd");
            //UFIDAPassportCookies.ClearCookie("new_validation");
            //UFIDAPassportCookies.ClearCookie("new_isvalid");
            //UFIDAPassportCookies.ClearCookie("new_loginpwd");
            //UFIDAPassportCookies.ClearCookie("ask_isvalid");
            //UFIDAPassportCookies.ClearCookie("UserCookieName_isvalid");
            ////旧版手机用户cookie
            //UFIDAPassportCookies.ClearCookie("UserCookieName_isvalid");
            //UFIDAPassportCookies.ClearCookie("mobile_loginCookieName");
            //UFIDAPassportCookies.ClearCookie("mobile_loginpwd");
            //UFIDAPassportCookies.ClearCookie("mobile_loginid");
            //UFIDAPassportCookies.ClearCookie("mobile_validation");
            //UFIDAPassportCookies.ClearCookie("ask_userCookieName");
            //UFIDAPassportCookies.ClearCookie("ask_userID");
            //UFIDAPassportCookies.ClearCookie("ask_userVaild");
            //UFIDAPassportCookies.ClearCookie("ask_userPsw");

            ////清除新版的通信证cookies
            //UFIDAPassportCookies.ClearCookie();
        }

        /// <summary>
        /// 获取当天登录用户
        /// </summary>
        public static UFIDAPassportUserModel CurrentUser
        {
            get
            {
                long userId = 0;// long.Parse(UFIDAPassportCookies.GetUserID());
                string userName = "";// UFIDAPassportCookies.GetUserName();
                string password = "";// UFIDAPassportCookies.GetPassword();
                string validation = "";// UFIDAPassportCookies.GetValidation();

                if (userId > 0 && !string.IsNullOrWhiteSpace(password))
                {
                    if (validation == userId + "," + userName || validation == userName + userId)
                    {
                        return new UFIDAPassportUserModel() { UserId = userId, UserName = userName };
                    }
                }
                return default(UFIDAPassportUserModel);
            }
        }
        /// <summary>
        /// 是否登录状态
        /// </summary>
        public static bool IsAuthenticated
        {
            get
            {
                //return CurrentUser != default(UFIDAPassportUserModel) && CurrentUser.UserId > 0;
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
            if (UFIDAString.IsNullOrWhiteSpaceAny(new string[] { username, password, service, host }))
            {
                return false;
            }
            string ip = UFIDARequest.UserHostAddress;
            string port = UFIDARequest.UserHostPort;
            string interfaceUrl = @"http://interfacepassport.soufun.com/interface/interface_user_login_2011.aspx";
            password = UFIDAMd5.HashPassword(Encoding.Default.GetString(Convert.FromBase64String(password)));
            string loginUrl = string.Format(
                 interfaceUrl + "?service={0}&codetype=1&userCookieName={1}&password={2}&v={3}&ip={4}&host={5}&port={6}",
                 service,
                 HttpUtility.UrlEncode(username.Trim(), Encoding.GetEncoding("gb2312")),
                 password,
                 UFIDAMd5.HashPassword(vcode),
                 ip,
                 host,
                 port
                );
            XElement loginInfo = XElement.Load(loginUrl).Element("common");
            //发送请求并读取值
            string userCookieName = UFIDAXmlDocument.GetValue(loginInfo, "userCookieName");
            string strUserType = UFIDAXmlDocument.GetValue(loginInfo, "usertype");
            string isemailvalid = UFIDAXmlDocument.GetValue(loginInfo, "isemailvalid");
            string ismobilevalid = UFIDAXmlDocument.GetValue(loginInfo, "ismobilevalid");
            string isvalid = UFIDAXmlDocument.GetValue(loginInfo, "isvalid");

            string result = UFIDAXmlDocument.GetValue(loginInfo, "return_result");
            long userId = UFIDAConvert.TryToInt64(UFIDAXmlDocument.GetValue(loginInfo, "userid"));


            string mobileID = UFIDAXmlDocument.GetValue(loginInfo, "cookie_mobile_loginid");
            string mobileCookieName = UFIDAXmlDocument.GetValue(loginInfo, "cookie_mobile_loginCookieName");
            string mobilePsw = UFIDAXmlDocument.GetValue(loginInfo, "cookie_mobile_loginpwd");

            string mobileVaild = UFIDAXmlDocument.GetValue(loginInfo, "cookie_mobile_validation");
            string email = UFIDAXmlDocument.GetValue(loginInfo, "email");

            //判断返回的值
            switch (result)
            {
                case "100":
                    //普通用户 登陆成功, 记录用户信息到Cookie
                    if (strUserType == "1")
                    {
                        //保存新版本的通信证cookies
                        //UFIDAPassportCookies.SetCookies(strUserType, userId.ToString(), userCookieName, password, isvalid, userId.ToString() + "," + userCookieName);
                    }
                    //纯手机用户 登陆成功, 记录用户信息到Cookie
                    if (strUserType == "2")
                    {
                        //保存新版本的通信证cookies
                        //UFIDAPassportCookies.SetCookies(strUserType, mobileID, mobileCookieName, mobilePsw, mobileID + "1", mobileID + "," + mobileCookieName);
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
            password = UFIDAMd5.HashPassword(password);
            HttpContext.Current.Response.Cookies[CookieName]["usertype"] = usertype;
            HttpContext.Current.Response.Cookies[CookieName]["userid"] = userid;
            HttpContext.Current.Response.Cookies[CookieName]["userCookieName"] = HttpContext.Current.Server.UrlEncode(userCookieName.Trim());
            HttpContext.Current.Response.Cookies[CookieName]["password"] = password;
            HttpContext.Current.Response.Cookies[CookieName]["isvalid"] = UFIDADes.EncryptForPassport(isvalid, Key, encoding);
            HttpContext.Current.Response.Cookies[CookieName]["validation"] = UFIDADes.EncryptForPassport(validation, Key, encoding);
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
                value = UFIDADes.EncryptForPassport(value, Key, encoding);
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
                value = UFIDADes.DecryptForPassport(value, Key, encoding);
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
