using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace UFIDA.Framework
{
    /// <summary>
    /// 数学
    /// </summary>
    public static class UFIDAMath
    {
        private static Regex regex = new Regex(@"([\+\-\*])", RegexOptions.Compiled);

        /// <summary>
        /// 计算表达式
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns>结果</returns>
        public static double Eval(string expression)
        {
            var xpath = string.Format("number({0})", regex.Replace(expression, " ${1} ").Replace("/", " div ").Replace("%", " mod "));

            return (double)new XPathDocument(new System.IO.StringReader("<r/>")).CreateNavigator().Evaluate(xpath);
        }
    }
}
