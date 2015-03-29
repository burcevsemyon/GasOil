using System.Net;
using System.Net.Mail;

namespace GasOil.BL.MailService
{
    public interface IMailSender
    {
        void SendMail(string recipient, string subject, string body);
    }

    public class MailSender : IMailSender
    {
        private readonly string _server;
        private readonly int _port;
        private readonly string _from;
        private readonly bool _enableSsl;
        private readonly string _senderDisplayName;
        private readonly string _userName;
        private readonly string _password;

        public MailSender(
            string server,
            int port,
            bool enableSsl,
            string from,
            string senderDisplayName,
            string userName,
            string password)
        {
            _server = server;
            _port = port;
            _from = from;
            _enableSsl = enableSsl;
            _senderDisplayName = senderDisplayName;
            _userName = userName;
            _password = password;
        }

        #region IMailSender Members

        public void SendMail(string recipient, string subject, string body)
        {
            using (var smtpClient = new SmtpClient(_server, _port))
            {
                var from = new MailAddress(_from, _senderDisplayName);
                var to = new MailAddress(recipient);

                var message = new MailMessage(from, to);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                smtpClient.EnableSsl = _enableSsl;
                smtpClient.Credentials = new NetworkCredential(_userName, _password);
                smtpClient.Send(message);
            }
        }

        #endregion
    }
}
