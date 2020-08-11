using Microsoft.EntityFrameworkCore;

namespace PhoneNumberFormatAPI.Models
{
    public class PhoneNumberContext : DbContext
    {
        public PhoneNumberContext(DbContextOptions<PhoneNumberContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneNumberItem> PhoneNumberItems { get; set; }
    }
}