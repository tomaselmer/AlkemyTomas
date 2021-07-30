using AlkemyTomas.services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace AlkemyTomas.services
{
    public interface IEmail
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}

