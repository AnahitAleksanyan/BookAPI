using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class SQLDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Person> People { get; set; }
        public SQLDBContext(DbContextOptions<SQLDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
