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
        public Entity.U8User GetUserInfo(string userName, string password)
        {
            return DataAccess.U8User.GetUserInfo(userName,password);
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
        public bool SendEmailToAdmin(string userEmail)
        {
            string resultMessage = string.Empty;
            bool isSend = false;
            List<string> mailList = new List<string>();
            mailList.Add("lichaor@yonyou.com");


            // 检测邮件是否发送成功
            try
            {
                SendEmail("U8开发者社区申请密码重置", "有客户需要重置密码:" + "<br/>"+"需要重置密码的用户账户："+userEmail, mailList);
                isSend = true;
            }
            catch (Exception ex)
            {
            }

            return isSend;
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
    }
}
