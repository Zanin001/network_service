using NetworkService.Models;
using System.Net;
using System.Net.Mail;

namespace NetworkService.Services
{
    public class SmtpService
    {
        public static async Task<bool> SendEmail(SmtpSettings smtpSettings, Email email)
        {
            bool response = default;

            try
            {
                var password = CryptographyService.Decrypt(smtpSettings.Password);

                using var smtpClient = new SmtpClient(smtpSettings.SMTP)
                {
                    Port = smtpSettings.Port,
                    Credentials = new NetworkCredential(smtpSettings.Email, password),
                    EnableSsl = smtpSettings.SSL
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.Email),
                    Subject = email.Subject,
                    Body = email.Body,
                    IsBodyHtml = true
                };

                foreach (var mail in email.Recipients)
                    mailMessage.To.Add(mail);

                smtpClient.Send(mailMessage);

                response = true;

            }
            catch (Exception ex)
            {
                response = false;
                Console.WriteLine(ex);
            }   

            return response;
        }
    }
}
