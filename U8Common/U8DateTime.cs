using System;
using System.Collections.Generic;

namespace U8.Framework
{
    /// <summary>
    /// 时间
    /// </summary>
    public static class U8DateTime
    {
        #region 当前
        /// <summary>
        /// 当前时间
        /// </summary>
        public static string NowTime
        {
            get
            {
                return DateTime.Now.ToString("HH:mm:ss.fff");
            }
        }

        /// <summary>
        /// 当前日期时间
        /// </summary>
        public static string Now
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
        }

        /// <summary>
        /// 当前日期
        /// </summary>
        public static string NowDate
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 当前年
        /// </summary>
        public static string NowYear
        {
            get
            {
                return DateTime.Now.ToString("yyyy");
            }
        }

        /// <summary>
        /// 当前月
        /// </summary>
        public static string NowMonth
        {
            get
            {
                return DateTime.Now.ToString("MM");
            }
        }

        /// <summary>
        /// 当前天
        /// </summary>
        public static string NowDay
        {
            get
            {
                return DateTime.Now.ToString("dd");
            }
        }
        #endregion

        /// <summary>
        /// 获得月间隔
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns>结果</returns>
        public static List<DateTime> GetMonthInterval(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new Exception("开始时间必须小于等于结束时间！");
            }
            var result = new List<DateTime>();

            for (var y = int.Parse(start.ToString("yyyy")); y <= int.Parse(end.ToString("yyyy")); y++)
            {
                if (start.Year == end.Year)
                {
                    for (var m = start.Month; m <= end.Month; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
                else if (y == start.Year)
                {
                    for (var m = start.Month; m <= 12; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
                else if (y == end.Year)
                {
                    for (var m = 1; m <= end.Month; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
                else
                {
                    for (var m = 1; m <= 12; m++)
                    {
                        result.Add(DateTime.Parse(y.ToString() + "-" + m.ToString()));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 解析配置
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="regioneSplit">区域分割线</param>
        /// <param name="partSplit">部分分割线</param>
        /// <returns>结果</returns>
        public static DateTime[] ParseConfig(string value, char regioneSplit = '|', char partSplit = '~')
        {
            var regiones = value.Split(regioneSplit);
            var dataDates = new List<DateTime>();
            for (int i = 0; i < regiones.Length; i++)
            {
                var region = regiones[i];
                var parts = region.Split(partSplit);
                if (parts.Length == 2)
                {
                    //说明是范围
                    var left = DateTime.Parse(parts[0]);
                    var right = DateTime.Parse(parts[1]);

                    if (left < right)
                    {
                        for (var now = left; now <= right; now = now.AddDays(1))
                        {
                            if (!dataDates.Contains(now))
                            {
                                dataDates.Add(now);
                            }
                        }
                    }
                    else if (left > right)
                    {
                        for (var now = left; now >= right; now = now.AddDays(-1))
                        {
                            if (!dataDates.Contains(now))
                            {
                                dataDates.Add(now);
                            }
                        }
                    }
                    else
                    {
                        if (!dataDates.Contains(left))
                        {
                            dataDates.Add(left);
                        }
                    }
                }
                else
                {
                    if (!dataDates.Contains(DateTime.Parse(region)))
                    {
                        dataDates.Add(DateTime.Parse(region));
                    }
                }
            }

            return dataDates.ToArray();
        }

        /// <summary>
        /// JavaScript最小时间
        /// </summary>
        public static DateTime JavaScriptMinTime = DateTime.Parse("1970-01-01 08:00:00");

        /// <summary>
        /// 格式化字符串
        /// </summary>
        public const string FormatString = "yyyy-MM-dd HH:mm:ss.fff";

        /// <summary>
        /// 日期格式化字符串
        /// </summary>
        public const string DateFormatString = "yyyy-MM-dd";
    }
}
