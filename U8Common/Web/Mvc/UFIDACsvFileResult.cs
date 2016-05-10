using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UFIDA.Framework.Office;
using System.Data;

namespace UFIDA.Framework.Web.Mvc
{
    /// <summary>
    /// Csv文件结果
    /// </summary>
    public class UFIDACsvFileResult : ContentResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">数据</param>
        /// <param name="fileName">文件名</param>
        public UFIDACsvFileResult(List<dynamic> rows, string fileName = "Export")
            : base()
        {
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
            this.Content = UFIDACsv.ToCsv(rows);
            this.ContentType = UFIDAMimeType.Csv;
            this.ContentEncoding = Encoding.Default;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">数据</param>
        /// <param name="fileName">文件名</param>
        public UFIDACsvFileResult(DataTable rows, string fileName = "Export")
            : base()
        {
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName + ".csv");
            this.Content = UFIDACsv.ToCsv(rows);
            this.ContentType = UFIDAMimeType.Csv;
            this.ContentEncoding = Encoding.Default;
        }
    }
}
