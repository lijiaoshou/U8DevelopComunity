using UFIDA.Framework.Diagnostics;
using System;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UFIDA.Framework.Configuration
{
    /// <summary>
    /// 配置
    /// </summary>
    public static class UFIDAConfig
    {
        /// <summary>
        /// 解析变量
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>结果</returns>
        public static string ParseVariable(string value)
        {
            var result = value;
            result = result.Replace("@(SlDateTime.NowTime)", UFIDADateTime.NowTime);
            result = result.Replace("@(SlDateTime.NowDate)", UFIDADateTime.NowDate);
            result = result.Replace("@(SlDateTime.Now)", UFIDADateTime.Now);
            result = result.Replace("@(SlDateTime.NowYear)", UFIDADateTime.NowYear);
            result = result.Replace("@(SlDateTime.NowMonth)", UFIDADateTime.NowMonth);
            result = result.Replace("@(SlDateTime.NowDay)", UFIDADateTime.NowDay);
            result = result.Replace("@(SlAppContext.StartupTime)", UFIDAAppContext.StartupTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            result = result.Replace("@(SlAppContext.Name)", UFIDAAppContext.Name);
            result = result.Replace("@(SlAppContext.Directory)", UFIDAAppContext.Directory);
            result = result.Replace("@(SlAppContext.LogFilePath)", UFIDAAppContext.LogFilePath);
            result = result.Replace("@(SlGuid.NewGuid())", UFIDAGuid.NewGuid());
            return result;
        }

        /// <summary>
        /// 解析为数组
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="value">值</param>
        /// <param name="split">分割符</param>
        /// <param name="isDecode">是否解码</param>
        /// <returns>结果</returns>
        public static T[] ParseArray<T>(string value, char split = '|', bool isDecode = true)
        {
            var type = typeof(T);
            if (type == typeof(string) && isDecode)
            {
                value = HttpUtility.HtmlDecode(value);
            }
            T[] array = null;
            if (!string.IsNullOrEmpty(value))
            {
                array = value.Split(split).Select(item => 
                {
                    if (type.IsEnum)
                    {
                        return (T)Enum.Parse(type, item, true);
                    }
                    else
                    {
                        return (T)Convert.ChangeType(item, typeof(T));
                    }
                }).ToArray();
            }
            return array;
        }

        /// <summary>
        /// 获得值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="isDecode">是否解码</param>
        /// <returns>结果</returns>
        public static T GetValue<T>(string key, bool isDecode = true)
        {
            var value = ConfigurationManager.AppSettings[key];
            var type = typeof(T);
            if (type == typeof(string) && isDecode)
            {
                value = HttpUtility.HtmlDecode(value);
            }
            if (type.IsEnum)
            {
                return (T)Enum.Parse(type, value, true);
            }
            else
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }

        /// <summary>
        /// 获得值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="split">分割符</param>
        /// <param name="isDecode">是否解码</param>
        /// <returns>结果</returns>
        public static T[] GetValues<T>(string key, char split = '|', bool isDecode = true)
        {
            var value = ConfigurationManager.AppSettings[key];
            return ParseArray<T>(value, split, isDecode);
        }

        /// <summary>
        /// 刷新配置
        /// </summary>
        public static void Refresh()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
