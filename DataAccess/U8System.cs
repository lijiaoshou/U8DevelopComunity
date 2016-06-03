using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U8.Framework.Data;
using U8.Framework;
using System.Data.SqlClient;

namespace DataAccess
{
    public class U8System
    {
        public static bool SubmitSystemNotice(string databaseConnectionString, Entity.U8SystemNotice u8systemNotice,string IsEdit)
        {
            string sqlIsEdit = "";
            string sqlNoticeCount = "";
            string sqlInsertNotice = "";
            //如果编辑情况，就删除以前的记录，然后添加
            if (IsEdit == "1")
            {
                sqlIsEdit = string.Format(@"
                                            DELETE FROM SystemNoticeTable WHERE id='{0}';
                                            DELETE FROM NoticeLog WHERE InfoId='{0}';
                                           ",u8systemNotice.id);
            }

            if (u8systemNotice.UpdateTime.ToString() == "0001/1/1 0:00:00"|| u8systemNotice.UpdateTime.ToString() == "1900-01-01 00:00:00.000")
            {
                u8systemNotice.UpdateTime = null;
            }
            string sqlSubmit = string.Format(@"INSERT INTO SystemNoticeTable
                                        (Title,SystemNoticeContent,CreateTime,UpdateTime,Submiter,Modifiler,Status)
                                        VALUES
                                        ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');",u8systemNotice.Title,u8systemNotice.SystemNoticeContent,u8systemNotice.CreateTime,
                                        u8systemNotice.UpdateTime,u8systemNotice.Submiter,u8systemNotice.Modifiler,u8systemNotice.Status);

            //发布状态要通知除管理员外的所有客户（更新用户表的通知数目+给通知表中插入通知）
            if (u8systemNotice.Status == "1")
            {
                sqlInsertNotice = string.Format(@"
                                                 DECLARE @indent BIGINT;
                                                 select @indent=@@identity;
                                                 INSERT INTO NoticeLog
                                                (Sender,Receiver,NoticeInfo,CreateTime,NoticeCategory,InfoId,IsAskQuestion)
                                                VALUES
                                                ('{0}','{1}','{2}','{3}','{4}',@indent,'{5}');
                                                ", u8systemNotice.Submiter,"",u8systemNotice.Title,DateTime.Now,"1","");
                sqlNoticeCount = string.Format(@"UPDATE dbo.UserTable SET NoticeCount=NoticeCount+1 WHERE Role!='2';");
            }
            string sqlCollect = string.Format(Common.Tran,sqlIsEdit+sqlSubmit+sqlInsertNotice+sqlNoticeCount);

            return U8Database.ExecuteNonQuery(databaseConnectionString, sqlCollect, null)>0;
        }

        public static Entity.U8SystemNotice GetSystemNoticeById(string databaseConnectionString, string id)
        {
            string sql = string.Format(@"
                                        SELECT notice.id,notice.Title,notice.SystemNoticeContent,notice.CreateTime,notice.UpdateTime,
                                        userSubmit.RealName AS Submiter,userModify.RealName AS Modifiler,notice.Status FROM SystemNoticeTable notice
                                        LEFT JOIN dbo.UserTable userSubmit ON userSubmit.id=notice.Submiter
                                        LEFT JOIN dbo.UserTable userModify ON userModify.id=notice.Modifiler
                                        WHERE notice.id='{0}'",id);

            DataTable dt = new DataTable();
            Entity.U8SystemNotice u8systemNotice = new Entity.U8SystemNotice();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                u8systemNotice.id = U8Convert.TryToString(dt.Rows[0]["id"]);
                u8systemNotice.Title = U8Convert.TryToString(dt.Rows[0]["Title"]);
                u8systemNotice.SystemNoticeContent = U8Convert.TryToString(dt.Rows[0]["SystemNoticeContent"]);
                u8systemNotice.CreateTime = U8Convert.TryToDateTime(dt.Rows[0]["CreateTime"]);
                if (U8Convert.TryToString(dt.Rows[0]["UpdateTime"]) == "1900/1/1 0:00:00")
                {
                    u8systemNotice.UpdateTime = null;
                }
                else {
                    u8systemNotice.UpdateTime = U8Convert.TryToDateTime(dt.Rows[0]["UpdateTime"]);
                }
                
                u8systemNotice.Submiter = U8Convert.TryToString(dt.Rows[0]["Submiter"]);
                u8systemNotice.Modifiler = U8Convert.TryToString(dt.Rows[0]["Modifiler"]);
                u8systemNotice.Status= U8Convert.TryToInt32(dt.Rows[0]["Status"])==0?"草稿":"已发布";
            }

            return u8systemNotice;
        }

        public static List<Entity.U8SystemNotice> GetSystemNoticeList(string databaseConnectionString,int currentPage, int pageSize,out int allCount)
        {
            allCount = 0;
            IList<SqlParameter> parameters = new List<SqlParameter>();

            string sql = @"
                            with Virtual_T as (
                            SELECT Row_number() OVER(order by t.CreateTime desc) AS RowNumber,t.*  FROM
                            (
                            SELECT notice.id,notice.Title,notice.SystemNoticeContent,notice.CreateTime,notice.UpdateTime,
                            userSubmit.RealName AS Submiter,userModify.RealName AS Modifiler,notice.Status FROM SystemNoticeTable notice
                            LEFT JOIN dbo.UserTable userSubmit ON userSubmit.id=notice.Submiter
                            LEFT JOIN dbo.UserTable userModify ON userModify.id=notice.Modifiler {0}
                            )AS t)
                            SELECT * FROM Virtual_T 
                            WHERE @PageSize * (@CurrentPage - 1) < RowNumber AND RowNumber <= @PageSize * @CurrentPage ORDER BY RowNumber
                          ";

            string where = " ";
            parameters.Add(new SqlParameter() { ParameterName = "@CurrentPage", Value = currentPage });
            parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = pageSize });

            IList<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters.ToList().ForEach((p) => { parameters2.Add(new SqlParameter(p.ParameterName, p.Value)); });
            allCount = U8Convert.TryToInt32(U8Database.ExecuteScalar(
                databaseConnectionString
                , @" SELECT COUNT(1) FROM dbo.SystemNoticeTable where 1=1 " + where  //select count (*) from MallReturnMoney_Batch as a with(nolock) where 1=1
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
                return dt.AsEnumerable().Select(row => new Entity.U8SystemNotice()
                {
                    XuHao = U8Convert.TryToString(row["RowNumber"]),
                    id = U8Convert.TryToString(row["ID"]),
                    Title = U8Convert.TryToString(row["Title"]),
                    SystemNoticeContent = row["SystemNoticeContent"].ToString(),
                    CreateTime = U8Convert.TryToDateTime(row["CreateTime"]),
                    UpdateTime =U8Convert.TryToDateTime(row["UpdateTime"]),
                    Submiter = U8Convert.TryToString(row["Submiter"]),
                    Modifiler= U8Convert.TryToString(row["Modifiler"]),
                    Status = U8Convert.TryToInt32(row["Status"]) == 0 ? "<span style='color:red'>草稿</span>" : "已发布"
            }).ToList();
            }
            else
            {
                return null;
            }
        }

        public static bool PublishNoticeFromDraft(string databaseConnectionString, string id,string userid)
        {
            //更新用户表中除管理员的所有通知数目+给通知表中加入信息+更新系统通知信息表
            string sqlSystemNotice = string.Format(@"
                                                    UPDATE SystemNoticeTable SET UpdateTime='{0}',Modifiler='{1}',Status='1' WHERE id='{2}'
                                                   ",DateTime.Now,userid,id);
            string sqlNoticeInsert = string.Format(@"
                                                 DECLARE @indent NVARCHAR(30);
                                                 SELECT @indent=(SELECT title FROM SystemNoticeTable where id='{4}');
                                                 INSERT INTO NoticeLog
                                                (Sender,Receiver,NoticeInfo,CreateTime,NoticeCategory,InfoId,IsAskQuestion)
                                                VALUES
                                                ('{0}','{1}',@indent,'{2}','{3}','{4}','{5}');
                                                ", userid, "", DateTime.Now, "1",id, "");

            string sqlNoticeCount = string.Format(@"UPDATE dbo.UserTable SET NoticeCount=NoticeCount+1 WHERE Role!='2';");

            string sqlCollect = string.Format(Common.Tran,sqlSystemNotice+sqlNoticeInsert+sqlNoticeCount);

            return U8Database.ExecuteNonQuery(databaseConnectionString, sqlCollect, null) > 0;

        }

        public static bool DeleteNoticeFromDraft(string databaseConnectionString, string id)
        {
            string sql = string.Format(@"
                                       DELETE FROM SystemNoticeTable WHERE id='{0}';
                                       DELETE FROM NoticeLog WHERE InfoId='{0}';
                                       ",id);
            return U8Database.ExecuteNonQuery(databaseConnectionString, sql, null)>0;
        }
    }
}
