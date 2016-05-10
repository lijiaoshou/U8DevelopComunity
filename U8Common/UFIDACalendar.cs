using System;
using System.Globalization;

namespace UFIDA.Framework
{
    /// <summary>
    /// 日历
    /// </summary>
    public static class UFIDACalendar
    {
        /// <summary>
        /// 获得一项
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>结果</returns>
        public static UFIDACalendarItem GetItem(DateTime dateTime)
        {
            var dataTime = DateTime.Parse(dateTime.ToString("yyyy-MM-dd"));

            var currentYearStartTime = DateTime.Parse(dataTime.ToString("yyyy-01-01"));

            //周定义：周五（1）、周六（2）、周日（3）、周一（4）、周二（5）、周三（6）、周四（7）
            var dayOfKpiWeek = 1;
            switch (dataTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    dayOfKpiWeek = 1;
                    break;
                case DayOfWeek.Saturday:
                    dayOfKpiWeek = 2;
                    break;
                case DayOfWeek.Sunday:
                    dayOfKpiWeek = 3;
                    break;
                case DayOfWeek.Monday:
                    dayOfKpiWeek = 4;
                    break;
                case DayOfWeek.Tuesday:
                    dayOfKpiWeek = 5;
                    break;
                case DayOfWeek.Wednesday:
                    dayOfKpiWeek = 6;
                    break;
                case DayOfWeek.Thursday:
                    dayOfKpiWeek = 7;
                    break;
            }

            var currentDayOfKpiWeek = 1;
            switch (currentYearStartTime.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    currentDayOfKpiWeek = 1;
                    break;
                case DayOfWeek.Saturday:
                    currentDayOfKpiWeek = 2;
                    break;
                case DayOfWeek.Sunday:
                    currentDayOfKpiWeek = 3;
                    break;
                case DayOfWeek.Monday:
                    currentDayOfKpiWeek = 4;
                    break;
                case DayOfWeek.Tuesday:
                    currentDayOfKpiWeek = 5;
                    break;
                case DayOfWeek.Wednesday:
                    currentDayOfKpiWeek = 6;
                    break;
                case DayOfWeek.Thursday:
                    currentDayOfKpiWeek = 7;
                    break;
            }

            currentYearStartTime = currentYearStartTime.AddDays(-(currentDayOfKpiWeek - 1));

            if (currentYearStartTime.Year == dataTime.Year - 1)
            {
                currentYearStartTime = currentYearStartTime.AddDays(7);
            }

            //最后一周如果跨年，算上一年的最后一周
            int currentKpiWeek = Convert.ToInt32(Math.Floor((dataTime - currentYearStartTime).TotalDays / 7d)) + 1;
            var yearKpiWeek = 0;

            if (currentKpiWeek == 0)
            {
                var lastYearEndTime = DateTime.Parse(dataTime.ToString("yyyy-01-01")).AddDays(-1);
                yearKpiWeek = GetItem(lastYearEndTime).KpiYearWeek;
            }
            else
            {
                yearKpiWeek = Convert.ToInt32(dataTime.Year.ToString() + currentKpiWeek.ToString("00"));
            }

            var yearQuarter = 0;
            var dayOfQuarter = 0;

            if (dataTime.Month == 1 || dataTime.Month == 2 || dataTime.Month == 3)
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "01");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-01-01"))).TotalDays + 1);
            }
            else if (dataTime.Month == 4 || dataTime.Month == 5 || dataTime.Month == 6)
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "02");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-04-01"))).TotalDays + 1);
            }
            else if (dataTime.Month == 7 || dataTime.Month == 8 || dataTime.Month == 9)
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "03");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-07-01"))).TotalDays + 1);
            }
            else
            {
                yearQuarter = Convert.ToInt32(dataTime.Year.ToString() + "04");
                dayOfQuarter = Convert.ToInt32((dataTime - DateTime.Parse(dataTime.ToString("yyyy-10-01"))).TotalDays + 1);
            }

            var gregorianCalendar = new GregorianCalendar();

            var result = new UFIDACalendarItem
            {
                Date = dataTime,
                Year = dataTime.Year,
                YearMonth = Convert.ToInt32(dataTime.ToString("yyyyMM")),
                YearMonthDay = Convert.ToInt32(dataTime.ToString("yyyyMMdd")),
                KpiYearWeek = yearKpiWeek,
                KpiYearWeekDay = Convert.ToInt32(yearKpiWeek.ToString() + dayOfKpiWeek.ToString("00")),
                YearWeek = Convert.ToInt32(dateTime.Year.ToString() + gregorianCalendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString("00")),
                YearWeekDay = Convert.ToInt32(dateTime.Year.ToString() + gregorianCalendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString("00") + (Convert.ToInt32(gregorianCalendar.GetDayOfWeek(dataTime)) + 1).ToString("00")),
                YearQuarter = yearQuarter,
                YearQuarterDay = Convert.ToInt32(yearQuarter.ToString() + dayOfQuarter.ToString("00"))
            };

            return result;
        }
    }
}
