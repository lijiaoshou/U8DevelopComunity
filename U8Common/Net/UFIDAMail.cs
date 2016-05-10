using System.IO;
using System.Net;
using System.Net.Mail;

namespace UFIDA.Framework.Net
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public static class UFIDAMail
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="isBodyHtml">标题</param>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="from">发送者</param>
        /// <param name="to">接收者</param>
        /// <param name="cc">抄送者</param>
        /// <param name="bcc">秘送者</param>
        public static void Send(bool isBodyHtml, string subject, string body, string from, string[] to, string[] cc = null, string[] bcc = null)
        {
            using (var mailMessage = new MailMessage())
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.From = new MailAddress(from);
                mailMessage.IsBodyHtml = isBodyHtml;

                #region 收件者
                if (to != null && to.Length > 0)
                {
                    for (int i = 0; i < to.Length; i++)
                    {
                        mailMessage.To.Add(new MailAddress(to[i]));
                    }
                }

                if (cc != null && cc.Length > 0)
                {
                    for (int i = 0; i < cc.Length; i++)
                    {
                        mailMessage.CC.Add(new MailAddress(cc[i]));
                    }
                }

                if (bcc != null && bcc.Length > 0)
                {
                    for (int i = 0; i < bcc.Length; i++)
                    {
                        mailMessage.Bcc.Add(new MailAddress(bcc[i]));
                    }
                }
                #endregion

                var smtpClient = new SmtpClient("mail.soufun.com");
                smtpClient.Send(mailMessage);
            }
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="isBodyHtml">标题</param>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="attachFile">附件</param>
        /// <param name="from">发送者</param>
        /// <param name="to">接收者</param>
        /// <param name="cc">抄送者</param>
        /// <param name="bcc">秘送者</param>
        public static void SendWithAccessories(bool isBodyHtml, string subject, string body,string[] attachFile, string from, string[] to, string[] cc = null, string[] bcc = null)
        {
            using (var mailMessage = new MailMessage())
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.From = new MailAddress(from);
                mailMessage.IsBodyHtml = isBodyHtml;

                #region 收件者
                if (to != null && to.Length > 0)
                {
                    for (int i = 0; i < to.Length; i++)
                    {
                        mailMessage.To.Add(new MailAddress(to[i]));
                    }
                }

                if (cc != null && cc.Length > 0)
                {
                    for (int i = 0; i < cc.Length; i++)
                    {
                        mailMessage.CC.Add(new MailAddress(cc[i]));
                    }
                }

                if (bcc != null && bcc.Length > 0)
                {
                    for (int i = 0; i < bcc.Length; i++)
                    {
                        mailMessage.Bcc.Add(new MailAddress(bcc[i]));
                    }
                }
                if (attachFile != null && attachFile.Length>0)
                {
                    for (int i = 0; i < attachFile.Length; i++)
                    {
                        if (File.Exists(attachFile[i]))
                        {
                            var attach = new Attachment(attachFile[i]);
                            mailMessage.Attachments.Add(attach);
                        }
                    }
                }
                #endregion

                var smtpClient = new SmtpClient("smtp.soufun.com");
                smtpClient.Send(mailMessage);
            }
        }
    }
}
