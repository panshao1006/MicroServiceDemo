using Core.Common;
using System;
using System.Net;
using System.Net.Mail;

namespace Core.Email
{
    public class EmailClient
    {
        private string _host;

        private string _fromName;

        private string _fromEamil;

        private int _port;

        private string _password;

        public EmailClient()
        {
            _host = ConfigurationManager.AppSetting("EmailHost");
            _port = Convert.ToInt32(ConfigurationManager.AppSetting("EmailPort"));
            _fromEamil = ConfigurationManager.AppSetting("FromEmail");
            _fromName = ConfigurationManager.AppSetting("FromName");
            _password = ConfigurationManager.AppSetting("EmailPassword");
        }

        public bool Send(string subject , string toEmail, string content)
        {
            MailMessage mailMsg = new MailMessage();//实例化对象
            mailMsg.From = new MailAddress(_fromEamil, _fromName);//源邮件地址和发件人
            mailMsg.To.Add(new MailAddress(toEmail));//收件人地址
            mailMsg.Subject = subject;
           
            mailMsg.Body = content;//发送邮件的内容
            mailMsg.IsBodyHtml = true;
            //指定smtp服务地址（根据发件人邮箱指定对应SMTP服务器地址）
            SmtpClient client = new SmtpClient()
            {
                Host = _host,
                Port = _port,
                Credentials = new NetworkCredential(_fromEamil, _password)

            };
             
            //发送邮件
            try
            {
                client.Send(mailMsg);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
