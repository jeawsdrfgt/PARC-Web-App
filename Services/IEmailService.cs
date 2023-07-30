using PARC_Web_App.Models;

namespace PARC_Web_App.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
        
    }
}
