using Microsoft.EntityFrameworkCore;
using NetworkService.Models;

namespace NetworkService.Data
{
    public class NetworkServiceDbContext : DbContext
    {
        public NetworkServiceDbContext(DbContextOptions<NetworkServiceDbContext> options) : base(options) 
        {
        }

        public DbSet<SmtpSettings> SmtpSettings { get; set; }
    }
}
