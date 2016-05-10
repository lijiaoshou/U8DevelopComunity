using System;

namespace UFIDA.Framework.Net
{
    /// <summary>
    /// IPAddress
    /// </summary>
    public static class UFIDAIPAddress
    {
        /// <summary>
        /// IP转换为数字
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns>结果</returns>
        public static long ToNumber(string ip)
        {
            try
            {
                string[] ips = ip.Split('.');
                return Convert.ToInt64(ips[0]) * 256 * 256 * 256 + Convert.ToInt64(ips[1]) * 256 * 256 + Convert.ToInt64(ips[2]) * 256 + Convert.ToInt64(ips[3]);
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// 数字转换为IP
        /// </summary>
        /// <param name="ipValue">ipValue</param>
        /// <returns>结果</returns>
        public static string ToIP(Int64 ipValue)
        {
            try
            {
                string ip = String.Empty;

                for (int i = 4; i > 0; i--)
                {
                    ip = (ipValue % 256).ToString() + "." + ip;
                    ipValue = ipValue / 256;
                }

                return ip.TrimEnd('.');
            }
            catch
            {
                return "";
            }
        }
    }
}
