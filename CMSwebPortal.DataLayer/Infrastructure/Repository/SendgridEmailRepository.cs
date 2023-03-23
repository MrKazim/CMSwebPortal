using CMSwebPortal.DataLayer.Infrastructure.IRepository;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CMSwebPortal.DataLayer.Infrastructure.Repository
{
    public class SendgridEmailRepository:ISendgridEmailRepository
    {
        private IConfiguration _configuration;

        public SendgridEmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(string name, string email, string message)
        {
            string SENDGRIDFROM = "muhammadnazim020@gmail.com";
            string SENDGRIDKEY = _configuration["SendGridApiKey"];

            var client = new SendGridClient(SENDGRIDKEY);
          //  string fromEmail = "mailto:muhammadnazim020@gmail.com";
            string fromEmail = "muhammadnazim020@gmail.com";
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(SENDGRIDFROM, "DevSpot"),
                Subject = "Support",
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(fromEmail));
            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var result = await client.SendEmailAsync(msg);
            if (result.IsSuccessStatusCode)
                return true;
            return false;

            //2nd way to implement sendgrid email

            //var apiKey = _configuration["SendGridApiKey"];
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("test@example.com", "Example User");
            //var subject = "Sending with SendGrid is Fun";
            //var to = new EmailAddress(email);
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);
        }

    }
}
