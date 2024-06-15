using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Avia.Database;

namespace Avia
{
    public class Emailer
    {
        private string senderEmail = "testmeilbox0028@mail.ru";
        private string senderPassword = "XFehgm1UpW7TWcLwxtmH";

        public Emailer() {}

        private SmtpClient smtpCreate()
        {
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            return smtpClient;
        }

        public bool sendCode(string receiverMail, int code)
        {
            if (DBDefaultInfoChecker.isEmailRegistered(receiverMail))
                return false;
            MailMessage mail = new MailMessage(senderEmail, receiverMail);
            mail.Subject = "Код подтверждения";
            mail.Body = $"Ваш код подтверждения: {code}";

            using (SmtpClient smtp = smtpCreate())
            {
                try
                {
                    smtp.Send(mail);
                    return true;
                }
                catch (SmtpException ex)
                {
                    return false;
                }
            }
        }

        public bool sendPassword(string receiverMail, string password)
        {          
            MailMessage mail = new MailMessage(senderEmail, receiverMail);
            mail.Subject = "Пароль для входа в C++ обучение";
            mail.Body = $"Ваш пароль: {password}";

            using (SmtpClient smtp = smtpCreate())
            {                
                smtp.Send(mail);
                return true;
            }
        }
    }
}
