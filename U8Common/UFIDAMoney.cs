using System;
using System.Collections.Generic;
using System.Linq;

namespace UFIDA.Framework
{
    /// <summary>
    /// 金额处理
    /// </summary>
    public class UFIDAMoney
    {
        /// <summary>
        /// 年利率转换为月利率
        /// </summary>
        /// <param name="yearRate">年利率</param>
        /// <returns>结果</returns>
        public static decimal ConvertYearRateToMonthRate(decimal yearRate)
        {
            return yearRate / 12m;
        }

        public class SlMatchingTheRepaymentOfPrincipalAndInterestItem
        {
            /// <summary>
            /// 月份
            /// </summary>
            public int Month { get; set; }

            /// <summary>
            /// 总金额
            /// </summary>
            public decimal Total { get; set; }

            /// <summary>
            /// 本金
            /// </summary>
            public decimal Principal { get; set; }

            /// <summary>
            /// 利息
            /// </summary>
            public decimal Interest { get; set; }

            /// <summary>
            /// 本金余额
            /// </summary>
            public decimal PrincipalBalance { get; set; }
        }

        /// <summary>
        /// 等额本息还款法
        /// </summary>
        /// <param name="yearRate">年利率</param>
        /// <param name="principal">本金</param>
        /// <param name="month">还款月数</param>
        /// <returns>每月还款情况</returns>
        public static List<SlMatchingTheRepaymentOfPrincipalAndInterestItem> MatchingTheRepaymentOfPrincipalAndInterest(decimal yearRate, decimal principal, int month)
        {
            var result = new List<SlMatchingTheRepaymentOfPrincipalAndInterestItem>();

            var principalAll = 0m;

            for (int i = 1; i <= month; i++)
            {
                var t = TotalByMatchingTheRepaymentOfPrincipalAndInterest(yearRate, principal, month);
                var p = PrincipalByMatchingTheRepaymentOfPrincipalAndInterest(yearRate, principal, month, i);
                //舍去
                var e = t - p;//Convert.ToDecimal(Math.Floor(Convert.ToDouble((t - p)) * 100d) / 100d);

                var item = new SlMatchingTheRepaymentOfPrincipalAndInterestItem()
                {
                    Interest = e,
                    Month = i,
                    Principal = p,
                    Total = t
                };
                result.Add(item);

                if (i == month)
                {
                    //最后一个月做平衡
                    item.Principal = principal - principalAll;
                    item.Interest = item.Total - item.Principal;
                }

                principalAll += item.Principal;

                item.PrincipalBalance = principal - result.Sum(one => { return one.Principal; });
            }

            return result;
        }

        /// <summary>
        /// 等额本息还款法（每月还款额）
        /// </summary>
        /// <param name="yearRate">年利率</param>
        /// <param name="principal">本金</param>
        /// <param name="month">还款月数</param>
        /// <returns>每月还款额</returns>
        private static decimal TotalByMatchingTheRepaymentOfPrincipalAndInterest(decimal yearRate, decimal principal, int month)
        {
            double yearRateDouble = Convert.ToDouble(yearRate);
            double principalDouble = Convert.ToDouble(principal);
            double monthDouble = Convert.ToDouble(month);

            var monthRate = ConvertYearRateToMonthRate(yearRate);
            double monthRateDouble = Convert.ToDouble(monthRate);

            var result = principalDouble * (monthRateDouble * Math.Pow(1d + monthRateDouble, monthDouble)) / (Math.Pow(1d + monthRateDouble, monthDouble) - 1d);

            //四舍五入
            return Convert.ToDecimal(result);//Math.Round(Convert.ToDecimal(result), 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 等额本息还款法（每月还款额中本金部分）
        /// </summary>
        /// <param name="yearRate">年利率</param>
        /// <param name="principal">本金</param>
        /// <param name="month">还款月数</param>
        /// <returns>每月还款额中本金部分</returns>
        private static decimal PrincipalByMatchingTheRepaymentOfPrincipalAndInterest(decimal yearRate, decimal principal, int month, int currentMonth)
        {
            double yearRateDouble = Convert.ToDouble(yearRate);
            double principalDouble = Convert.ToDouble(principal);
            double monthDouble = Convert.ToDouble(month);
            double currentMonthDouble = Convert.ToDouble(currentMonth);

            var monthRate = ConvertYearRateToMonthRate(yearRate);
            double monthRateDouble = Convert.ToDouble(monthRate);

            var result = principalDouble * monthRateDouble * Math.Pow(1d + monthRateDouble, currentMonthDouble - 1d) / (Math.Pow(1d + monthRateDouble, monthDouble) - 1d);

            //舍去
            return Convert.ToDecimal(result);//Convert.ToDecimal(Math.Floor(result * 100d) / 100d);
        }
    }
}
