using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class SQLDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> People { get; set; }


        public DbSet<Student>Students { get; set; }

        public DbSet<Course>Courses { get; set; }

                
        public DbSet<CourceStudentPairs> CourceStudentPairs { get; set; }

        public SQLDBContext(DbContextOptions<SQLDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().

                 HasOne(b => b.Author).
                 WithMany(a => a.Books).
                 HasForeignKey(b => b.AuthorId);

                          

            modelBuilder.Entity<Student>().
                HasMany(s => s.Courses).
                WithMany(c => c.Students).

                UsingEntity(j => j.ToTable("StudentToCourse"));
            
        }
    }          
               

          
        
    

}
