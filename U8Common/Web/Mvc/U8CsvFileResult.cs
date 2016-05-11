using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using U8.Framework.Office;
using System.Data;

namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// Csv文件结果
    /// </summary>
    public class U8CsvFileResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">数据</param>
        /// <param name="fileName">文件名</param>
        public U8CsvFileResult(List<dynamic> rows, string fileName = "Export")
            : base()
        {
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
            this.Content = U8Csv.ToCsv(rows);
            this.ContentType = U8MimeType.Csv;
            this.ContentEncoding = Encoding.Default;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">数据</param>
        /// <param name="fileName">文件名</param>
        public U8CsvFileResult(DataTable rows, string fileName = "Export")
            : base()
        {
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
            this.Content = U8Csv.ToCsv(rows);
            this.ContentType = U8MimeType.Csv;
            this.ContentEncoding = Encoding.Default;
        }
    }
}
