using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkService.Models
{
    [Table(nameof(SmtpSettings))]
    public class SmtpSettings
    {
        [Column(nameof(SmtpSettingsId)), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int? SmtpSettingsId { get; set; }

        [Column(nameof(Email))]
        public string Email { get; set; }

        [Column(nameof(Password))]
        public string Password { get; set; }

        [Column(nameof(SMTP))]
        public string SMTP { get; set; }

        [Column(nameof(Port))]
        public int Port { get; set; }

        [Column(nameof(SSL))]
        public  bool SSL {  get; set; }
    }
}
