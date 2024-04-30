using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data
{
    public class SenderDatabaseContext : DbContext
    {
        public SenderDatabaseContext(DbContextOptions<SenderDatabaseContext> options) : base(options)
        {

        }

        // Table Name
        public DbSet<Senders> AllSenders { get; set; }
    }
}
