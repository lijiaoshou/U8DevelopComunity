using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U8.Framework;
using U8.Framework.Data;

namespace DataAccess
{
    public class U8Learn
    {
        public static List<Entity.U8Learn> SearchLearnList(string databaseConnectionString, int currentPage, int pageSize, string category, out int allCount)
        {
            allCount = 0;
            IList<SqlParameter> parameters = new List<SqlParameter>();

            string sql = string.Format(@"                                 
                                         with Virtual_T as (
                                        SELECT Row_number() OVER(order by t.CreateTime desc) AS RowNumber,t.*  FROM
                                        (
	                                    SELECT doc.Id,category.CategoryName AS TechDocCategory,doc.DocName,doc.Author,doc.DownloadCount,
                                        doc.ReadCount,doc.CreateTime,doc.DocPath FROM DocsTable doc
	                                    INNER JOIN TechDocCategory category ON doc.TechDocCategory=category.id
                                        where 1=1 {0}
                                        )AS t)
                                        SELECT * FROM Virtual_T
                                        WHERE @PageSize * (@CurrentPage - 1) < RowNumber AND RowNumber <= @PageSize * @CurrentPage ORDER BY RowNumber
                                       ");

            #region //where
            string where= " ";
            parameters.Add(new SqlParameter() { ParameterName = "@CurrentPage", Value = currentPage });
            parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = pageSize });
            if (!string.IsNullOrEmpty(category))
            {
                where = "  and doc.TechDocCategory='" + category + "'";
            }

            #endregion

            IList<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters.ToList().ForEach((p) => { parameters2.Add(new SqlParameter(p.ParameterName, p.Value)); });
            allCount = U8Convert.TryToInt32(U8Database.ExecuteScalar(
                databaseConnectionString
                , @" SELECT COUNT(1) FROM dbo.DocsTable where 1=1 " + where.Replace("doc.","")
                , parameters2.ToArray()));
            if (allCount == 0) { return null; }

            DataTable dt = new DataTable();
            U8Database.Fill(
                databaseConnectionString,
                String.Format(sql, where),
                dt,
                parameters.ToArray());//查出列表

            if (dt.Rows.Count > 0)
            {
                return dt.AsEnumerable().Select(row => new Entity.U8Learn()
                {
                    XuHao = U8Convert.TryToString(row["RowNumber"]),
                    Id = U8Convert.TryToString(row["Id"]),
                    TechDocCategory = U8Convert.TryToString(row["TechDocCategory"]),
                    DocName = row["DocName"].ToString(),
                    Author = U8Convert.TryToString(row["Author"]),
                    DownloadCount =U8Convert.TryToString(row["DownloadCount"]),
                    ReadCount = U8Convert.TryToString(row["ReadCount"]),
                    CreateTime=U8Convert.TryToDateTime(row["CreateTime"])
                }).ToList();
            }
            else
            {
                return null;
            }
        }

        public static List<Entity.U8TechDocCategory>  GetCategroy(string databaseConnectionString)
        {
            List<Entity.U8TechDocCategory> listCategory = new List<Entity.U8TechDocCategory>();
            string sql = string.Format(@"SELECT id,CategoryName FROM dbo.TechDocCategory");
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8TechDocCategory u8category = new Entity.U8TechDocCategory();
                    u8category.Id = U8Convert.TryToString(dt.Rows[i]["id"]);
                    u8category.CategoryName = U8Convert.TryToString(dt.Rows[i]["CategoryName"]);

                    listCategory.Add(u8category);
                }
                return listCategory;
            }
            else
            {
                return null;
            }
        }

        public static bool UploadDocs(string databaseConnectionString, Entity.U8Learn u8learn)
        {
            string sql = string.Format(@"
                                        INSERT INTO DocsTable
                                        (TechDocCategory,DocName,Author,DownloadCount,ReadCount,CreateTime,DocPath)
                                        VALUES
                                        ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')
                                      ",u8learn.TechDocCategory,u8learn.DocName,u8learn.Author,"0","0",u8learn.CreateTime,u8learn.DocPath);
            return U8Database.ExecuteNonQuery(databaseConnectionString, sql, null)>0;
        }
    }
}
