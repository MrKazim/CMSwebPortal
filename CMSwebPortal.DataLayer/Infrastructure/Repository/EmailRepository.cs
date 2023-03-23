using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using CMSwebPortal.Models.Authentication.EmailConfigurationModel;
using CMSwebPortal.Models.Response;
using MailKit.Net.Smtp;
using MimeKit;

namespace CMSwebPortal.DataLayer.Infrastructure.Repository
{
    public class EmailRepository:IEmailRepository
    {
        private readonly EmailConfigurationModel _emailConfiguration;

        public EmailRepository(EmailConfigurationModel emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
        private void Send(MimeMessage mailmessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                client.Send(mailmessage);
            }
            catch { throw; }
            finally { client.Disconnect(true); client.Dispose(); }
        }
    }
}
