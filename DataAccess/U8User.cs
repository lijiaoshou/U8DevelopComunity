using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using U8.Framework;
using U8.Framework.Data;

namespace DataAccess
{
    public class U8User
    {
        public static Entity.U8User GetUserInfo(string databaseConnectionString, string userName, string password)
        {
            Entity.U8User user = new Entity.U8User();

            string sql = string.Format(@"SELECT TOP 1 usertable.Id,usertable.UserEmail,usertable.RealName,usertable.Gender,usertable.Phone,usertable.Company,
                                    usertable.Province,usertable.City,roletable.RoleName,
                                    CASE usertable.IsYonyouEmployee
                                    WHEN '0' THEN '否'
                                    WHEN '1' THEN '是'
                                    ELSE '' END  AS IsYonyouEmployee
                                    ,usertable.CreateTime,usertable.UpdateTime,usertable.LastLoginTime,usertable.IsDelete,usertable.ExistingScore,usertable.Department,
                                    usertable.NoticeCount,usertable.HeadPicture FROM dbo.UserTable usertable INNER JOIN dbo.UserToRoleTable roletable
                                    ON usertable.Role = roletable.id WHERE usertable.UserEmail='{0}' AND usertable.Password='{1}' ", userName, password);
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                user.UserId = U8Convert.TryToString(dt.Rows[0]["Id"]);
                user.City = U8Convert.TryToString(dt.Rows[0]["City"]);
                user.RealName = U8Convert.TryToString(dt.Rows[0]["RealName"]);
                user.Company = U8Convert.TryToString(dt.Rows[0]["Company"]);
                user.CreateTime = U8Convert.TryToDateTime(dt.Rows[0]["CreateTime"]);
                user.Gender = U8Convert.TryToString(dt.Rows[0]["Gender"]);
                user.IsYonyouEmployee = U8Convert.TryToString(dt.Rows[0]["IsYonyouEmployee"]) == "是" ? true : false;
                user.Phone = U8Convert.TryToString(dt.Rows[0]["Phone"]);
                user.Province = U8Convert.TryToString(dt.Rows[0]["Province"]);
                user.Role = U8Convert.TryToString(dt.Rows[0]["RoleName"]);
                user.UpdateTime = U8Convert.TryToDateTime(dt.Rows[0]["UpdateTime"]);
                user.UserEmail = U8Convert.TryToString(dt.Rows[0]["UserEmail"]);
                user.LastLoginTime = U8Convert.TryToDateTime(dt.Rows[0]["LastLoginTime"]);
                user.IsDelete = U8Convert.TryToInt32(dt.Rows[0]["IsDelete"]) == 0 ? false : true;
                user.ExistingScore = U8Convert.TryToInt32(dt.Rows[0]["ExistingScore"]);
                user.Department = U8Convert.TryToString(dt.Rows[0]["Department"]);
                user.NoticeCount = U8Convert.TryToInt32(dt.Rows[0]["NoticeCount"]);
                user.HeadPicture = U8Convert.TryToString(dt.Rows[0]["HeadPicture"]);
            }

            return user;
        }

        public static bool RegistUser(string databaseConnectionString, Entity.U8User userInfo)
        {
            if (userInfo == null) return false;

            string IsYonyouEmployee = userInfo.IsYonyouEmployee ? "1" : "0";
            DateTime now = DateTime.Now;

            string sql = string.Format(@"insert into UserTable(UserEmail,Password,Gender,Phone,Company,Province,City,Role,IsYonyouEmployee,CreateTime,UpdateTime,IsDelete) 
                                       values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", userInfo.UserEmail, userInfo.Password,
                                       userInfo.Gender, userInfo.Phone, userInfo.Company, userInfo.Province, userInfo.City, "0", IsYonyouEmployee, now, now, "0");
            int i = U8Database.ExecuteNonQuery(databaseConnectionString, sql, null);

            return i > 0;
        }

        public static Entity.U8User GetByUserID(string databaseConnectionString, string userEmail)
        {
            Entity.U8User user = new Entity.U8User();

            string sql = string.Format(@"SELECT TOP 1 usertable.Id,usertable.UserEmail,usertable.RealName,usertable.Gender,usertable.Phone,usertable.Company,
                                    usertable.Province,usertable.City,roletable.RoleName,
                                    CASE usertable.IsYonyouEmployee
                                    WHEN '0' THEN '否'
                                    WHEN '1' THEN '是'
                                    ELSE '' END  AS IsYonyouEmployee
                                    ,usertable.CreateTime,usertable.UpdateTime,usertable.LastLoginTime,usertable.IsDelete,usertable.HeadPicture FROM dbo.UserTable usertable INNER JOIN dbo.UserToRoleTable roletable
                                    ON usertable.Role = roletable.id WHERE usertable.UserEmail='{0}' ", userEmail);
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                user.UserId = U8Convert.TryToString(dt.Rows[0]["Id"]);
                user.City = U8Convert.TryToString(dt.Rows[0]["City"]);
                user.RealName = U8Convert.TryToString(dt.Rows[0]["RealName"]);
                user.Company = U8Convert.TryToString(dt.Rows[0]["Company"]);
                user.CreateTime = U8Convert.TryToDateTime(dt.Rows[0]["CreateTime"]);
                user.Gender = U8Convert.TryToString(dt.Rows[0]["Gender"]);
                user.IsYonyouEmployee = U8Convert.TryToString(dt.Rows[0]["IsYonyouEmployee"]) == "是" ? true : false;
                user.Phone = U8Convert.TryToString(dt.Rows[0]["Phone"]);
                user.Province = U8Convert.TryToString(dt.Rows[0]["Province"]);
                user.Role = U8Convert.TryToString(dt.Rows[0]["RoleName"]);
                user.UpdateTime = U8Convert.TryToDateTime(dt.Rows[0]["UpdateTime"]);
                user.UserEmail = U8Convert.TryToString(dt.Rows[0]["UserEmail"]);
                user.LastLoginTime = U8Convert.TryToDateTime(dt.Rows[0]["LastLoginTime"]);
                user.IsDelete = U8Convert.TryToString(dt.Rows[0]["IsDelete"]) == "0" ? false : true;
                user.HeadPicture = U8Convert.TryToString(dt.Rows[0]["HeadPicture"]);
            }

            return user;
        }

        public static bool UpdatePassword(string databaseConnectionString, string userEmail, string Password)
        {
            string sql = string.Format(@"update UserTable set Password='{0}' where UserEmail='{1}'", Password, userEmail);

            int i = U8Database.ExecuteNonQuery(databaseConnectionString, sql, null);

            return i > 0;
        }

        public static int GetNoticeCount(string databaseConnectionString, string userid)
        {
            string sql = string.Format(@"SELECT NoticeCount FROM dbo.UserTable WHERE id='{0}'",userid);
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                return U8Convert.TryToInt32(dt.Rows[0]["NoticeCount"]);
            }
            else
            {
                return 0;
            }
        }

        public static bool ClearNoticeCount(string databaseConnectionString, string userid)
        {
            string sql = string.Format(@"UPDATE dbo.UserTable SET NoticeCount='0' WHERE id='{0}' ",userid);
            return U8Database.ExecuteNonQuery(databaseConnectionString, sql, null) > 0;
        }

        public static List<Entity.U8NoticeLog> GetNoticeLog(string databaseConnectionString, string userid)
        {
            string sql = string.Format(@"SELECT notice.id,notice.Sender as Senderid,usersender.realname as Sendername, notice.Receiver as Receiverid,
                                        userreceiver.realname as Receivername,notice.NoticeInfo,notice.CreateTime,noticecate.NoticeName as NoticeCategory,notice.InfoId,notice.IsAskQuestion
                                        FROM NoticeLog as notice
                                        INNER JOIN NoticeCategoryTable as noticecate ON noticecate.id=notice.NoticeCategory 
                                        LEFT JOIN UserTable as usersender on notice.sender=usersender.id
                                        LEFT JOIN UserTable as userreceiver on notice.Receiver=userreceiver.id
                                        where notice.Receiver='{0}' or notice.Receiver='0' order by notice.CreateTime desc", userid); //notice.Sender='{0}' or 
            DataTable dt = new DataTable();
            List<Entity.U8NoticeLog> listNoticeLog = new List<Entity.U8NoticeLog>();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entity.U8NoticeLog noticeLog = new Entity.U8NoticeLog();
                    noticeLog.id = U8Convert.TryToString(dt.Rows[i]["id"]);
                    noticeLog.Sender = "<a href='/U8System/PersonalPage?userid="+ U8Convert.TryToString(dt.Rows[i]["Senderid"])+ "'>"+ U8Convert.TryToString(dt.Rows[i]["Sendername"]) +"</a>";
                    noticeLog.Receiver = "<a href='/U8System/PersonalPage?userid="+ U8Convert.TryToString(dt.Rows[i]["Receiverid"]) + "'>"+ U8Convert.TryToString(dt.Rows[i]["Receivername"])+"</a>";
                    noticeLog.NoticeInfo = GetNoticeInfo(U8Convert.TryToString(dt.Rows[i]["NoticeCategory"]), U8Convert.TryToString(dt.Rows[i]["NoticeInfo"]),U8Convert.TryToString(dt.Rows[i]["InfoId"]));
                    noticeLog.CreateTime = U8Convert.TryToDateTime(dt.Rows[i]["CreateTime"]);
                    noticeLog.NoticeCategory = U8Convert.TryToString(dt.Rows[i]["NoticeCategory"]);
                    noticeLog.InfoId = U8Convert.TryToString(dt.Rows[i]["InfoId"]);
                    noticeLog.IsAskQuestion = U8Convert.TryToInt32(dt.Rows[i]["IsAskQuestion"]) == 0?true:false;

                    listNoticeLog.Add(noticeLog);
                }

            }
            return listNoticeLog;
        }

        private static string GetNoticeInfo(string category,string notice,string id)
        {
            if (category == "系统通知")
            {
                return "<a href='/U8System/SystemNotice?id="+id+"'>"+ notice+"</a>";
            }
            else if (category == "知识问答")
            {
                return "<a href='/U8Question/QuestionDetails?id="+id+"'> " + notice+"</a>" ;
            }
            return "";
        }
    }
}
