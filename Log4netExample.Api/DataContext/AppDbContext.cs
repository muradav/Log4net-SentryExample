using Log4netExample.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Log4netExample.Api.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Log> Log { get; set; }
    }
}
