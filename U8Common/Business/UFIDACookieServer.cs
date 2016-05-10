using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using UFIDA.Framework.Net;

namespace UFIDA.Framework.Business
{
    /// <summary>
    /// Cookie模型
    /// </summary>
    public struct UFIDACookieModelForCookieServer
    {   
        /// <summary>
        /// 主键
        /// </summary>
        public string Key;
        /// <summary>
        /// 值
        /// </summary>
        public string Value;
        /// <summary>
        /// 超时时间
        /// </summary>
        public UInt32 Expires;
    }

    /// <summary>
    /// CookieServer操作
    /// </summary>
    public class UFIDACookieServer
    {
        /// <summary>
        /// CookieServer服务器IP、端口号
        /// </summary>
        public IPEndPoint IpEndPoint { get; set; }
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="point">CookieServer服务器IP、端口号</param>
        public UFIDACookieServer(IPEndPoint point)
        {
            IpEndPoint = point;
        }

        /// <summary>
        /// 添加cookie
        /// </summary>
        /// <param name="cookielist"></param>
        /// <returns></returns>
        public void AddCookie(UFIDACookieModelForCookieServer[] cookielist)
        {
            if (cookielist.Length == 0 || cookielist.Length > 1024)
            {
                return;
            }
            string sessionid = GetSessionID();
            string data = "AddCookie~" + EncodeString(sessionid) + "~";
            for (int i = 0; i < cookielist.Length; i++)
            {
                data += EncodeString(cookielist[i].Key) + "^";
                data += EncodeString(cookielist[i].Value) + "^";
                data += EncodeString(cookielist[i].Expires.ToString()) + "&";
            }
            data = data.Substring(0, data.Length - 1) + "\n";
            UFIDASocket.Send(IpEndPoint, data, false, Encoding.GetEncoding("GBK"));
        }

        /// <summary>
        /// 更新Cookie
        /// </summary>
        /// <param name="keyname">cookie名称</param>
        /// <param name="value">值</param>
        /// <param name="time">过期时间</param>
        public void SetCookie(string keyname, string value, UInt32 time)
        {
            string sessionID = GetSessionID();
            StringBuilder sb = new StringBuilder("SetCookie~");
            string data = sb.Append(EncodeString(sessionID)).Append("~").Append(EncodeString(keyname)).Append("~").Append(EncodeString(value)).Append("^").Append(EncodeString(time.ToString())).Append("\n").ToString();
            UFIDASocket.Send(IpEndPoint, data, true, Encoding.GetEncoding("GBK"));
        }

        /// <summary>
        /// 修改Cookie
        /// </summary>
        /// <param name="cookielist"></param>
        /// <returns></returns>
        public void UpdateCookie(UFIDACookieModelForCookieServer[] cookielist)
        {
            if (cookielist.Length == 0 || cookielist.Length > 1024)
            {
                return;
            }
            string sessionid = GetSessionID();
            string data = "UpdateCookie~" + EncodeString(sessionid) + "~";
            for (int i = 0; i < cookielist.Length; i++)
            {
                data += EncodeString(cookielist[i].Key) + "^";
                data += EncodeString(cookielist[i].Value) + "^";
                data += EncodeString(cookielist[i].Expires.ToString()) + "&";
            }
            data = data.Substring(0, data.Length - 1) + "\n";
            UFIDASocket.Send(IpEndPoint, data, false, System.Text.Encoding.GetEncoding("GBK"));
        }

        /// <summary>
        /// 查询Cookie
        /// </summary>
        /// <returns></returns>
        public string QueryCookie()
        {
            string sessionid = GetSessionID();
            string data = "QueryCookie~" + EncodeString(sessionid);
            if (!data.EndsWith("\n"))
            {
                data += "\n";
            }
            data = UFIDASocket.Send(IpEndPoint, data, true, System.Text.Encoding.GetEncoding("GBK"));
            if (data.Length >= ("QueryCookie~\n" + EncodeString(sessionid)).Length)
            {
                string[] a_str = data.Substring(EncodeString(sessionid).Length + 13, data.Length - EncodeString(sessionid).Length - 14).Split('&');
                data = "QueryCookie~" + DecodeString(sessionid) + "~";
                for (int i = 0; i < a_str.Length; i++)
                {
                    string[] a_item = a_str[i].Split('^');
                    if (a_item.Length == 3)
                    {
                        data += DecodeString(a_item[0]) + "^";
                        data += DecodeString(a_item[1]) + "^" + DecodeString(a_item[2]) + "&";
                    }
                    else
                    {
                        continue;
                    }
                }
                if (data.EndsWith("&"))
                {
                    data = data.Substring(0, data.Length - 1) + "\n";
                }
                else
                {
                    data += "\n";
                }
                return data;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取Cookie的值
        /// </summary>
        /// <param name="keyname">key</param>
        /// <returns></returns>
        public string GetCookie(string keyname)
        {
            string sessionID = GetSessionID();
            StringBuilder sb = new StringBuilder("GetCookie~");
            string data = sb.Append(EncodeString(sessionID)).Append("~").Append(EncodeString(keyname)).Append("\n").ToString();
            data = UFIDASocket.Send(IpEndPoint, data, true, System.Text.Encoding.GetEncoding("GBK"));
            if (data.Length > 0)
            {
                string dataSource = "GetCookie~" + EncodeString(sessionID) + "~" + EncodeString(keyname) + "~";
                string cookieData = data.Replace(dataSource, "");
                string[] arrData = cookieData.Split('^');
                if (arrData != null && arrData.Length >= 0)
                {
                    return DecodeString(arrData[0]);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 判断Cookie是否存在
        /// </summary>
        public bool SessionIDExistis()
        {
            bool isExists = false;
            if (System.Web.HttpContext.Current.Request.Cookies["SoufunSessionID_Esf"] != null
                && System.Web.HttpContext.Current.Request.Cookies["SoufunSessionID_Esf"].Value != "")
            {
                isExists = true;
            }
            return isExists;
        }

        /// <summary>
        /// 从Cookie Server获取Session ID
        /// </summary>
        public string GetSessionID()
        {
            string SessionID = string.Empty;
            if (System.Web.HttpContext.Current.Request.Cookies["SoufunSessionID_Esf"] == null
                || System.Web.HttpContext.Current.Request.Cookies["SoufunSessionID_Esf"].Value == "")
            {
                string data = "GetSID\n";
                data = UFIDASocket.Send(IpEndPoint, data, true, System.Text.Encoding.GetEncoding("GBK"));
                if (data.Length > 0)
                {
                    SessionID = data.Replace("GetSID~", "").Replace("\n", "");
                    System.Web.HttpCookie sessionid = new System.Web.HttpCookie("SoufunSessionID_Esf");
                    sessionid.Value = SessionID;
                    sessionid.Domain = "soufun.com";
                    sessionid.Path = "/";
                    sessionid.Expires = DateTime.Now.AddDays(30);
                    System.Web.HttpContext.Current.Response.Cookies.Add(sessionid);
                }
            }
            else
            {
                SessionID = System.Web.HttpContext.Current.Request.Cookies["SoufunSessionID_Esf"].Value;
            }

            return SessionID;
        }

        private static string EncodeString(string s)
        {
            s = System.Web.HttpUtility.UrlEncode(s, Encoding.GetEncoding("gb2312"));
            return s.Replace("&", "#*%*#").Replace("^", "#**%#").Replace("~", "#%**#");
        }
        private static string DecodeString(string s)
        {
            s.Replace("#*%*#", "&").Replace("#**%#", "^").Replace("#%**#", "~");
            return System.Web.HttpUtility.UrlDecode(s, Encoding.GetEncoding("gb2312"));
        }
    }
}
