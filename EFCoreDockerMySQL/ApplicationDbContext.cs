using Microsoft.EntityFrameworkCore;

namespace EFCoreDockerMySQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : 
            base(dbContextOptions)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
