using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading.Tasks;

namespace PARC_Web_App.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Username").Value));
            email.To.Add(MailboxAddress.Parse(request.Email));
            email.Subject = request.Subject;
            email.Body = new TextPart(request.returnUrl);


            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("Host").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("Username").Value, _configuration.GetSection("Password").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SendEmail(string email, string v, EmailDto request)
        {
            throw new NotImplementedException();
        }

        public Task SendEmail(string email, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public Task SendEmail()
        {
            throw new NotImplementedException();
        }

        Task IEmailService.SendEmail(EmailDto request)
        {
            throw new NotImplementedException();
        }
    }
 }

