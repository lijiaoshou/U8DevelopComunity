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
        public static List<Entity.U8Learn> SearchLearnList(string databaseConnectionString, int currentPage, int pageSize, string category,string docSort, out int allCount)
        {
            allCount = 0;
            IList<SqlParameter> parameters = new List<SqlParameter>();

            string sql = @"                                 
                        with Virtual_T as (
                        SELECT Row_number() OVER(order by t.CreateTime desc) AS RowNumber,t.*  FROM
                        (
	                    SELECT doc.Id,category.CategoryName AS TechDocCategory,doc.DocName,usertable.RealName as Author,doc.DownloadCount,
                        doc.ReadCount,doc.CreateTime,doc.DocPath FROM DocsTable doc
	                    INNER JOIN TechDocCategory category ON doc.TechDocCategory=category.id
                        INNER JOIN UserTable usertable on doc.Author=usertable.id
                        where 1=1 {0}
                        )AS t)
                        SELECT * FROM Virtual_T
                        WHERE @PageSize * (@CurrentPage - 1) < RowNumber AND RowNumber <= @PageSize * @CurrentPage ORDER BY RowNumber
                        ";

            #region //where
            string where= " ";
            parameters.Add(new SqlParameter() { ParameterName = "@CurrentPage", Value = currentPage });
            parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = pageSize });
            if (!string.IsNullOrEmpty(category))
            {
                where = "  and doc.TechDocCategory='" + category + "'";
            }
            if (docSort == "1")
            {
                sql=sql.Replace("t.CreateTime", "t.DownloadCount");
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
                                        (TechDocCategory,DocName,Author,DownloadCount,ReadCount,CreateTime,DocPath,Summary)
                                        VALUES
                                        ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')
                                      ",u8learn.TechDocCategory,u8learn.DocName,u8learn.Author,"0","0",u8learn.CreateTime,u8learn.DocPath,u8learn.Summary);
            return U8Database.ExecuteNonQuery(databaseConnectionString, sql, null)>0;
        }

        public static Entity.U8Learn DocDetails(string databaseConnectionString, string id)
        {
            string sql = string.Format(@"
                                        SELECT docs.id,category.CategoryName as TechDocCategory,docs.DocName,usertable.RealName as Author,docs.DownloadCount,
                                        docs.ReadCount,docs.CreateTime,docs.DocPath,docs.Summary  FROM dbo.DocsTable docs 
                                        INNER JOIN dbo.TechDocCategory category ON docs.TechDocCategory=category.id 
                                        INNER JOIN dbo.UserTable usertable ON docs.Author=usertable.id 
                                        where docs.id='{0}';
                                       ",id);
            DataTable dt = new DataTable();
            Entity.U8Learn u8learn = new Entity.U8Learn();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                u8learn.Author =U8Convert.TryToString(dt.Rows[0]["Author"]);
                u8learn.CreateTime = U8Convert.TryToDateTime(dt.Rows[0]["CreateTime"]);
                u8learn.DocName = U8Convert.TryToString(dt.Rows[0]["DocName"]);
                u8learn.DocPath = U8Convert.TryToString(dt.Rows[0]["DocPath"]);
                u8learn.DownloadCount = U8Convert.TryToString(dt.Rows[0]["DownloadCount"]);
                u8learn.Id = U8Convert.TryToString(dt.Rows[0]["Id"]);
                u8learn.ReadCount = U8Convert.TryToString(dt.Rows[0]["ReadCount"]);
                u8learn.TechDocCategory = U8Convert.TryToString(dt.Rows[0]["TechDocCategory"]);
                u8learn.Summary = U8Convert.TryToString(dt.Rows[0]["Summary"]);
            }

            return u8learn;
        }

        public static bool IncreaseReadCount(string databaseConnectionString, string id,string userid)
        {
            string sqlInc = string.Format(@"UPDATE dbo.DocsTable SET ReadCount=ReadCount+1 WHERE id='{0}';",id);

            string sqlInsert = string.Format(@"INSERT INTO dbo.DocVisitHistoryTable ([User], VisitTime, DocId ) VALUES  ( '{0}','{1}','{2}' );",userid,DateTime.Now,id);

            string sqlCollect = string.Format(Common.Tran,sqlInc+sqlInsert);
            return U8Database.ExecuteNonQuery(databaseConnectionString, sqlCollect, null)>0;
        }

        public static bool IncDownloadCount(string databaseConnectionString, string id)
        {
            string sql = string.Format(@"UPDATE dbo.DocsTable SET DownloadCount=DownloadCount+1 WHERE id='{0}'", id);

            return U8Database.ExecuteNonQuery(databaseConnectionString, sql, null) > 0;
        }

        public static bool SubmitComment(string databaseConnectionString, Entity.U8DocComment u8DocComment)
        {
            string sql = string.Format(@"INSERT INTO dbo.DocCommentTable( [User] , DocId ,Comment , CommentTime) VALUES  
                                       ( '{0}' , '{1}' , '{2}' , '{3}' )",u8DocComment.User,u8DocComment.DocId,u8DocComment.Comment,u8DocComment.CommentTime);

            return U8Database.ExecuteNonQuery(databaseConnectionString, sql, null) > 0;

        }

        public static List<Entity.U8DocVisitHistory> GetVisitHistory(string databaseConnectionString, string docId)
        {
            string sql = string.Format(@"SELECT visit.id,visit.[User] AS userid,usertable.RealName AS UserName,visit.VisitTime,visit.DocId FROM dbo.DocVisitHistoryTable visit
                                        INNER JOIN dbo.UserTable usertable ON usertable.id=visit.[User]
                                        WHERE visit.DocId='{0}' order by visit.VisitTime desc",docId);
            DataTable dt = new DataTable();
            List<Entity.U8DocVisitHistory> list = new List<Entity.U8DocVisitHistory>();
            U8Database.Fill(databaseConnectionString,sql,dt,null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8DocVisitHistory history = new Entity.U8DocVisitHistory();

                    history.DocId = U8Convert.TryToString(dt.Rows[i]["DocId"]);
                    history.id = U8Convert.TryToString(dt.Rows[i]["id"]);
                    history.User = U8Convert.TryToString(dt.Rows[i]["UserName"]);
                    history.UserId = U8Convert.TryToString(dt.Rows[i]["userid"]);
                    history.VisitTime = U8Convert.TryToDateTime(dt.Rows[i]["VisitTime"]);

                    list.Add(history);
                }
            }

            return list;
        }

        public static List<Entity.U8DocComment> GetComments(string databaseConenctionString, string docId)
        {
            string sql = string.Format(@"SELECT com.id,com.[User] AS userid,usertable.RealName AS UserName,com.DocId,com.Comment,com.CommentTime FROM dbo.DocCommentTable com
                                        INNER JOIN dbo.UserTable usertable ON usertable.id=com.[User]
                                        WHERE com.DocId='{0}' order by com.CommentTime desc", docId);
            DataTable dt = new DataTable();
            List<Entity.U8DocComment> list = new List<Entity.U8DocComment>();
            U8Database.Fill(databaseConenctionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8DocComment com = new Entity.U8DocComment();

                    com.Comment = U8Convert.TryToString(dt.Rows[i]["Comment"]);
                    com.CommentTime = U8Convert.TryToDateTime(dt.Rows[i]["CommentTime"]);
                    com.DocId = U8Convert.TryToString(dt.Rows[i]["DocId"]);
                    com.id = U8Convert.TryToString(dt.Rows[i]["id"]);
                    com.User = U8Convert.TryToString(dt.Rows[i]["UserName"]);
                    com.UserId = U8Convert.TryToString(dt.Rows[i]["userid"]);

                    list.Add(com);
                }
            }

            return list;
        }
    }
}
