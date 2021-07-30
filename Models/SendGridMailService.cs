using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlkemyTomas.services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AlkemyTomas.Models
{
    public class SendGridMailService : IEmail
    {
        private IConfiguration _configuration;
        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
           
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tomaselmerg@gmail.com", "Example User");
             subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("tomaselmerg@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
