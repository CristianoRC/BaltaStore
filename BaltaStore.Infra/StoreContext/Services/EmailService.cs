using System;
using BaltaStore.Domain.StoreContext.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BaltaStore.Infra.StoreContext.Services
{
    public class EmailService : IEmailService
    {
        public void send(string to, string from, string subject, string body)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(apiKey);

            var fromEmail = new EmailAddress(from, "BaltaStore");
            var toEmail = new EmailAddress(to);
            var message = MailHelper.CreateSingleEmail(fromEmail, toEmail, subject, body, null);

            client.SendEmailAsync(message);
        }
    }
}