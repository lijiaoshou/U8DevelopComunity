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
        public static Entity.U8User GetUserInfo(string databaseConnectionString,string userName,string password)
        {
            Entity.U8User user = new Entity.U8User();

            string sql = string.Format(@"SELECT TOP 1 usertable.Id,usertable.UserEmail,usertable.RealName,usertable.Gender,usertable.Phone,usertable.Company,
                                    usertable.Province,usertable.City,roletable.RoleName,
                                    CASE usertable.IsYonyouEmployee
                                    WHEN '0' THEN '否'
                                    WHEN '1' THEN '是'
                                    ELSE '' END  AS IsYonyouEmployee
                                    ,usertable.CreateTime,usertable.UpdateTime,usertable.LastLoginTime,usertable.IsDelete FROM dbo.UserTable usertable INNER JOIN dbo.UserToRoleTable roletable
                                    ON usertable.Role = roletable.id WHERE usertable.UserEmail='{0}' AND usertable.Password='{1}' ", userName, password);
            DataTable dt = new DataTable();
            U8Database.Fill(databaseConnectionString, sql, dt, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                user.UserId = U8Convert.TryToString(dt.Rows[0]["Id"]);
                user.City =U8Convert.TryToString(dt.Rows[0]["City"]);
                user.RealName = U8Convert.TryToString(dt.Rows[0]["RealName"]);
                user.Company= U8Convert.TryToString(dt.Rows[0]["Company"]);
                user.CreateTime = U8Convert.TryToDateTime(dt.Rows[0]["CreateTime"]);
                user.Gender = U8Convert.TryToString(dt.Rows[0]["Gender"]);
                user.IsYonyouEmployee = U8Convert.TryToString(dt.Rows[0]["IsYonyouEmployee"]) == "是" ? true : false;
                user.Phone = U8Convert.TryToString(dt.Rows[0]["Phone"]);
                user.Province = U8Convert.TryToString(dt.Rows[0]["Province"]);
                user.Role = U8Convert.TryToString(dt.Rows[0]["RoleName"]);
                user.UpdateTime = U8Convert.TryToDateTime(dt.Rows[0]["UpdateTime"]);
                user.UserEmail = U8Convert.TryToString(dt.Rows[0]["UserEmail"]);
                user.LastLoginTime = U8Convert.TryToDateTime(dt.Rows[0]["LastLoginTime"]);
                user.IsDelete = U8Convert.TryToString(dt.Rows[0]["IsDelete"]) == "0" ?false:true;
            }

            return user;
        }

        public static bool RegistUser(string databaseConnectionString,Entity.U8User userInfo)
        {
            if (userInfo==null) return false;
        
            string IsYonyouEmployee = userInfo.IsYonyouEmployee ? "1" : "0";
            DateTime now = DateTime.Now;
        
            string sql = string.Format(@"insert into UserTable(UserEmail,Password,Gender,Phone,Company,Province,City,Role,IsYonyouEmployee,CreateTime,UpdateTime,IsDelete) 
                                       values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", userInfo.UserEmail, userInfo.Password,
                                       userInfo.Gender, userInfo.Phone, userInfo.Company, userInfo.Province, userInfo.City, "0", IsYonyouEmployee,now,now,"0");
            int i =U8Database.ExecuteNonQuery(databaseConnectionString, sql,null);

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
                                    ,usertable.CreateTime,usertable.UpdateTime,usertable.LastLoginTime,usertable.IsDelete FROM dbo.UserTable usertable INNER JOIN dbo.UserToRoleTable roletable
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
            }

            return user;
        }

        public static bool UpdatePassword(string databaseConnectionString, string userEmail, string Password)
        {
            string sql = string.Format(@"update UserTable set Password='{0}' where UserEmail='{1}'",Password,userEmail);

            int i = U8Database.ExecuteNonQuery(databaseConnectionString, sql, null);

            return i > 0;
        }
    }
}
