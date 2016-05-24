using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Framework.Data;

namespace DataAccess
{
    public class U8User
    {
        public static Entity.U8User GetUserInfo(string userName,string password)
        {
            Entity.U8User user = new Entity.U8User();
            return user;
        }

        public static bool RegistUser(string databaseConnectionString,Entity.U8User userInfo)
        {
            if (userInfo==null) return false;

            string sql = "";

            sql=string.Format(@"INSERT INTO dbo.UserTable
                              ( UserEmail ,
                                Password ,
                                Gender ,
                                Phone ,
                                Company ,
                                Province ,
                                City ,
                                Role ,
                                IsYonyouEmployee
                               )
                               VALUES  
                              ( '{0}' , -- UserEmail - nvarchar(50)
                                '{1]' , -- Password - nvarchar(50)
                                '{2}' , -- Gender - char(1)
                                '{3}' , -- Phone - nvarchar(18)
                                '{4}' , -- Company - nvarchar(50)
                                '{5}' , -- Province - nvarchar(20)
                                '{6}' , -- City - nvarchar(20)
                                '{7}' , -- Role - char(1)
                                '{8}'  -- IsYonyouEmployee - char(1)
                            )",userInfo.UserEmail,userInfo.Password,userInfo.Gender,userInfo.Phone,userInfo.Company,userInfo.Province,userInfo.City,
                            "0",userInfo.IsYonyouEmployee?"1":"0");
            int i =U8Database.ExecuteNonQuery(databaseConnectionString, sql,null);

            return i > 0;
        }
    }
}
