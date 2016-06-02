using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class U8User
    {
        public Entity.U8User GetUserInfo(string databaseConnectionString,string userName, string password)
        {
            //对密码进行md5加密
            password = U8.Framework.Security.U8Md5.HashPassword(password);
            return DataAccess.U8User.GetUserInfo(databaseConnectionString, userName,password);
        }

        public bool RegistUser(string databaseConnectionString,Entity.U8User userInfo)
        {
            //对密码进行md5加密
            userInfo.Password = U8.Framework.Security.U8Md5.HashPassword(userInfo.Password);
            return DataAccess.U8User.RegistUser(databaseConnectionString,userInfo);
        }


        /// <summary>
        /// 发送邮件提醒
        /// </summary>
        /// <param name="Msg">邮件信息</param>
        /// <returns></returns>
        public bool SendEmail(string databaseConnectionString,string userEmail)
        {
            string resultMessage = string.Empty;
            bool isSend = false;
            List<string> mailList = new List<string>();
            mailList.Add(userEmail);

            //获取随机生成的六位数数字密码并加密
            string newRefundPwd = GetNumAndLetter();
            string newRefundPwdMD5 = U8.Framework.Security.U8Md5.HashPassword(newRefundPwd);

            //将重置的密码更新到数据库
            bool updateResult = DataAccess.U8User.UpdatePassword(databaseConnectionString, userEmail, newRefundPwdMD5);
            if (!updateResult)
            {
                return false;
            }

            // 检测邮件是否发送成功
            try
            {
                SendEmail("U8开发者社区申请密码重置", "您的U8开发者社区密码已经重置为："+ newRefundPwd + "<br>请重新登录", mailList);
                isSend = true;
            }
            catch (Exception ex)
            {
            }

            return isSend;
        }

        //随机生成六位密码（数字+字符）
        public static string GetNumAndLetter()
        {
            Random rd = new Random();
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result = "";
            for (int i = 0; i < 6; i++)
            {
                result += str[rd.Next(str.Length)];
            }
            return result;
        }

        /// <summary>
        /// 发送提醒邮件
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Content"></param>
        /// <param name="listEmail"></param>
        /// <returns></returns>
        public bool SendEmail(string Title, string Content, List<string> listEmail)
        {

            bool isPass = false;
            try
            {
                SmtpClient client = new SmtpClient("mail.yonyou.com");
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                NetworkCredential myCredentials = new NetworkCredential("lichaor@yonyou.com", "12312");
                client.Credentials = myCredentials;
                MailMessage message = new MailMessage() { Subject = Title, Body = Content, From = new System.Net.Mail.MailAddress("lichaor@yonyou.com", "U8公共平台"), IsBodyHtml = true };
                for (int i = 0; i < listEmail.Count; i++)
                {
                    if (message.To.Count >= 1)
                    {
                        message.To.RemoveAt(0);
                    }
                    message.To.Add(new System.Net.Mail.MailAddress(listEmail[i]));
                    try
                    {
                        client.Send(message);
                        isPass = true;
                    }
                    catch (Exception ex)
                    {
                        isPass = false;
                    }

                }
            }
            catch (Exception e)
            {
                isPass = false;
            }
            return isPass;
        }

        public Entity.U8User GetByUserID(string databaseConnectionString,string UserEmail)
        {
            return DataAccess.U8User.GetByUserID(databaseConnectionString, UserEmail);
        }


        /// <summary>
        /// 获取当前登录账户有多少条通知信息
        /// </summary>
        /// <param name="databaseConectionString"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetNoticeCount(string databaseConectionString, string userid)
        {
            return DataAccess.U8User.GetNoticeCount(databaseConectionString,userid);
        }

        public bool ClearNoticeCount(string databaseConnectionString, string userid)
        {
            return DataAccess.U8User.ClearNoticeCount(databaseConnectionString,userid);
        }

        public List<Entity.U8NoticeLog>  GetNoticeLog(string databaseConnectionString, string userid)
        {
            return DataAccess.U8User.GetNoticeLog(databaseConnectionString, userid);
        }
    }
}
