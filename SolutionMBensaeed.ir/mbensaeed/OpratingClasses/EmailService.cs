using mbensaeed.Models;
using mbensaeed.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace mbensaeed.OpratingClasses
{
    public class EmailService
    {
        public Task SendMail(string subject, string message)
        {
            using (var _Context = new ApplicationDbContext())
            {
                var objEntityEmailInfo = new RepositoryPattern<EmailInfo>(_Context);
                var Info = objEntityEmailInfo.SearchFor(x => x.IsActive == "1").ToList().FirstOrDefault();

                SmtpClient smtpClient = new SmtpClient(Info.SMTP);
                MailMessage mailMessage = new MailMessage();


                smtpClient.Host = Info.HostName;
                mailMessage.To.Add(new MailAddress(Info.ToEmail));
                mailMessage.Subject = subject;
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(Info.FromEmail, subject);
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Body = message;
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential networkCredential = (NetworkCredential)(smtpClient.Credentials = new NetworkCredential(Info.FromEmail, Info.Pass));
                smtpClient.Credentials = networkCredential;

                return smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}