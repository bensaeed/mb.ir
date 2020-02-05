using mbensaeed.Models;
using mbensaeed.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace mbensaeed.OpratingClasses
{
    public class EmailService
    {
        public void SendEmail(string subject, string message)
        {
            using (var _Context = new ApplicationDbContext())
            {
                var objEntityEmailInfo = new RepositoryPattern<EmailInfo>(_Context);
                var Info = objEntityEmailInfo.SearchFor(x=>x.IsActive=="1").ToList().FirstOrDefault();

                var loginInfo = new NetworkCredential(Info.FromEmail, Info.Pass);

                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.mbensaeed.ir", 587);

                msg.From = new MailAddress(Info.FromEmail);
                msg.To.Add(new MailAddress(Info.ToEmail));
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
            }
        }
    }
}