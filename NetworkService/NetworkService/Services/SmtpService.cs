using NetworkService.Models;
using System.Net.Mail;

namespace NetworkService.Services
{
    public class SmtpService
    {
        public async Task SendEmail(SmtpSettings smtpSettings)
        {
            try
            {
                //SmtpClient
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
