using System;
using System.Web;
using System.Text;
using U8.Framework.Web;

namespace U8.Framework
{
    /// <summary>
    /// 发送短信报警
    /// </summary>
    public static class U8Sms
    {
        /// <summary>
        /// 短信接口地址
        /// </summary>
        private const string smsUrl = @"http://smss.interface.light.soufun.com:8080/sendsms.php?mobie={0}&content={1}";

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <param name="message">发送消息（自动截断为70个字符进行分段发送，message支持自动空格转换为下划线）</param>
        public static void Send(string phone, string message)
        {
            message = message.Replace(" ", "_");
            var index = 0;
            while (index < message.Length)
            {
                var current = string.Empty;
                if (index + 70 > message.Length)
                {
                    current = message.Substring(index, message.Length - index);
                }
                else
                {
                    current = message.Substring(index, 70);
                }

                string html = U8Request.GetHtml(string.Format(smsUrl, phone, HttpUtility.UrlEncode(current, Encoding.GetEncoding("GBK")), Encoding.GetEncoding("GBK")));
                if (U8Json.FromJson<SlSmsStatus>(html).status != "0000")
                {
                    throw new Exception("发送失败！");
                }
                index = index + 70;
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phones">手机号码组</param>
        /// <param name="message">发送消息（自动截断为70个字符进行分段发送，message支持自动空格转换为下划线）</param>
        public static void Send(string[] phones, string message)
        {
            foreach (string phone in phones)
            {
                Send(phone, message);
            }
        }

        private class SlSmsStatus
        {
            public string status { get; set; }
        }
    }
}
