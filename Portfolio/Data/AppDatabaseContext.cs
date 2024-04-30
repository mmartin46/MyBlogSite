// John 3:5
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {

        }

        // Table Name
        public DbSet<Apps> AllApps { get; set; }
    }
}
