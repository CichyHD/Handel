using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handel.Core.Contracts
{
    public interface IEmailService
    {
        void SendEmail(EmailSettings settings);
    }

    public class EmailSettings
    {
        public EmailSettings(string meilToAddress, string subject, string body)
        {
            MeilToAdress = meilToAddress;
            Subject = subject;
            Body = body;

        }

        public string MeilToAdress;
        public string Subject;
        public string Body;
        public string MailFromAdress = "sklep@gmail.com";     //ConfigurationManager.AppSettings["mailUserName"];
        public bool UseSssl = true;
        public string Username = "sklep";//ConfigurationManager.AppSettings["mailAddress"];
        public string Password = "damadama2";//ConfigurationManager.AppSettings["mailPassword"];
        public string ServerPort = "587";
        public string ServerName = "smtp.gmail.com";
    }

}
