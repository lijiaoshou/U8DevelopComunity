using Entity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using U8.Framework.Security;

namespace U8DevelopComunity.Common
{
    public class Identity
    {
        public static bool AutoLogin { get; set; }

        public  string UserId { get; set; }

        public  string UserEmail { get; set; }

        public  string RealName { get; set; }

        public  string Password { get; set; }

        public  string Gender { get; set; }

        public  string Phone { get; set; }

        public  string Company { get; set; }

        public  string Province { get; set; }

        public  string City { get; set; }

        public  string Role { get; set; }

        public  bool IsYonyouEmployee { get; set; }

        public  DateTime CreateTime { get; set; }

        public  DateTime UpdateTime { get; set; }

        public  DateTime LastLoginTime{get;set;}

        public bool IsDelete { get; set; }

        public int ExistingScore { get; set; }

        public string Department { get; set; }

        public int NoticeCount { get; set; }

        public string HeadPicture { get; set; }

        public static void Login(Entity.U8User u8User,bool autoLogin)
        {
            //先获取请求Url
            string RequestUrl = HttpContext.Current.Request.Url.Host.ToString();
            if (!RequestUrl.Contains("http://"))
            {
                RequestUrl = "http://" + RequestUrl;
            }
            //登陆前,先清除所有cookie
            HttpContext.Current.Request.Cookies.Remove(Config.LoginName);
            HttpContext.Current.Request.Cookies.Remove(Config.UserID);
            var cookies = HttpContext.Current.Response.Cookies;
            cookies[Config.LoginName].Value = U8Des.Encrypt(TimeToNum(DateTime.Now.ToString()), "@projec$") + "@" + Verify.Encrypt(u8User.RealName, "channels") + "@89" + U8Des.Encrypt(TimeToNum(DateTime.Now.ToString()), "@projec$");
            //cookies[Config.LoginName].Domain = Config.CookieDomain;

            cookies[Config.UserID].Value = U8Des.Encrypt(TimeToNum(DateTime.Now.ToString()), "@projec$") + "@" + Verify.Encrypt(u8User.UserEmail, "channels") + "@89" + U8Des.Encrypt(TimeToNum(DateTime.Now.ToString()), "@projec$");
            //cookies[Config.UserID].Domain = Config.CookieDomain;

            HttpContext.Current.Response.Cookies.Add(cookies[Config.LoginName]);
            HttpContext.Current.Response.Cookies.Add(cookies[Config.UserID]);

            if (autoLogin)
            {
                HttpContext.Current.Response.Cookies[Config.LoginName].Expires = DateTime.Now.AddDays(7);
                HttpContext.Current.Response.Cookies[Config.UserID].Expires = DateTime.Now.AddDays(7);
            }
            else
            {
                HttpContext.Current.Response.Cookies[Config.LoginName].Expires = DateTime.Now.AddMinutes(60);
                HttpContext.Current.Response.Cookies[Config.UserID].Expires = DateTime.Now.AddMinutes(60);
            }
        }

        #region 时间字符串的处理
        /// <summary>
        /// 时间字符串处理
        /// </summary>
        /// <param name="source">需要转换的字符串</param>
        /// <returns>返回纯数字的字符串</returns>
        public static string TimeToNum(string source)
        {
            DateTime temp = DateTime.Now;
            string middle = temp.ToString("yyyy-MM-dd HH:mm:ss:ffff");
            Regex regex = new Regex(@"\d+");
            string res = null;
            foreach (var item in regex.Matches(middle))
            {
                res += item.ToString();
            }
            return res;
        }
        #endregion

        public static Identity User
        {
            get
            {
                try
                {
                    var cookies = HttpContext.Current.Request.Cookies;
                    if (cookies == null) { return null; }
                    Identity user = new Identity();
                    if (cookies.AllKeys.Contains(Config.UserID))
                    {
                        var value = cookies[Config.UserID].Value;
                        //先获取请求Url
                        string RequestUrl = HttpContext.Current.Request.Url.Host.ToString();
                        if (!RequestUrl.Contains("http://"))
                        {
                            RequestUrl = "http://" + RequestUrl;
                        }
                        string temp = U8.Framework.U8Convert.TryToString(value);
                        if (string.IsNullOrEmpty(temp))
                        {
                            HttpContext.Current.Request.Cookies.Clear();
                            return null;
                        }
                        string loginId = temp.Substring(temp.IndexOf("@") + 1, temp.LastIndexOf("@") - temp.IndexOf("@") - 1);
                        value = Verify.Decrypt(loginId, "channels");
                        user.UserEmail = String.IsNullOrEmpty(value) ? "" : HttpContext.Current.Server.UrlDecode(value);
                    }

                    //存在缓存,则从缓存中拿user
                    string cacheName = "Identity_" + user.UserEmail;
                    object obj =Common.Cache.Instance.Get(cacheName);
                    if (obj != null)
                    {
                        Entity.U8User u8user = obj as Entity.U8User;
                        if (u8user == null)
                        {
                            return null;
                        }
                        user.City = u8user.City;
                        user.Company = u8user.Company;
                        user.CreateTime = u8user.CreateTime;
                        user.Gender = u8user.Gender;
                        user.IsDelete = u8user.IsDelete;
                        user.IsYonyouEmployee = u8user.IsYonyouEmployee;
                        user.LastLoginTime = u8user.LastLoginTime;
                        user.Phone = u8user.Password;
                        user.Province = u8user.Province;
                        user.RealName = u8user.RealName;
                        user.Role = u8user.Role;
                        user.UpdateTime = u8user.UpdateTime;
                        user.UserEmail = u8user.UserEmail;
                        user.UserId = u8user.UserId;
                        user.ExistingScore = u8user.ExistingScore;
                        user.Department = u8user.Department;
                        user.NoticeCount = u8user.NoticeCount;
                        user.HeadPicture = u8user.HeadPicture;

                        return user;
                    }

                    string UserEmail = user.UserEmail;

                    //通过用户的ID获取用户信息
                    U8User userInfo = new Business.U8User().GetByUserID(Config.ConnectionString, UserEmail);
   
                    //user.Password = U8.Framework.U8Convert.TryToString(HttpContext.Current.Session["userPwd"], "");//记住用户的密码
                   
                    if (userInfo != null)
                    {
                        user.City = userInfo.City;
                        user.Company = userInfo.Company;
                        user.CreateTime = userInfo.CreateTime;
                        user.Gender = userInfo.Gender;
                        user.IsDelete = userInfo.IsDelete;
                        user.IsYonyouEmployee = userInfo.IsYonyouEmployee;
                        user.LastLoginTime = userInfo.LastLoginTime;
                        user.Password = userInfo.Password;
                        user.Phone = userInfo.Phone;
                        user.Province = userInfo.Province;
                        user.RealName = userInfo.RealName;
                        user.Role = userInfo.Role;
                        user.UpdateTime = userInfo.UpdateTime;
                        user.UserEmail = userInfo.UserEmail;
                        user.UserId = userInfo.UserId;
                        user.ExistingScore = userInfo.ExistingScore;
                        user.Department = userInfo.Department;
                        user.NoticeCount = userInfo.NoticeCount;
                        user.HeadPicture = userInfo.HeadPicture;
                    }

                    if (Identity.AutoLogin)
                    {
                        //写入缓存
                        Common.Cache.Instance.Add(cacheName, user, 3600*7*24);

                        HttpContext.Current.Response.Cookies[Config.LoginName].Expires = DateTime.Now.AddDays(7);
                        HttpContext.Current.Response.Cookies[Config.UserID].Expires = DateTime.Now.AddDays(7);
                    }
                    else
                    {
                        //写入缓存
                        Common.Cache.Instance.Add(cacheName, user, 3600);

                        HttpContext.Current.Response.Cookies[Config.LoginName].Expires = DateTime.Now.AddMinutes(60);
                        HttpContext.Current.Response.Cookies[Config.UserID].Expires = DateTime.Now.AddMinutes(60);
                    }

                    //Common.Cache.Instance.Add("1111", "abc");
                    //string test_test = Common.Cache.Instance.Get("1111").ToString();
                    return user;
                }
                catch
                {
                    return null;
                }
            }
            set { }
        }

        /// <summary>
        /// 是否验证
        /// </summary>
        public static bool IsAuthenticated
        {
            get
            {
                Identity user = Identity.User;
                try
                {
                    return user != null && !String.IsNullOrEmpty(user.UserEmail);
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}