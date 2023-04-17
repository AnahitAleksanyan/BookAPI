using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class SQLDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> People { get; set; }

<<<<<<< HEAD
        public DbSet<Student>Students { get; set; }

        public DbSet<Course>Courses { get; set; }

        

=======
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourceStudentPairs> CourceStudentPairs { get; set; }
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
        public SQLDBContext(DbContextOptions<SQLDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().
<<<<<<< HEAD
                 HasOne(b => b.Author).
                 WithMany(a => a.Books).
                 HasForeignKey(b => b.AuthorId);

=======
                HasOne(b => b.Author).
                WithMany(a => a.Books).
                HasForeignKey(b => b.AuthorId);
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2

            modelBuilder.Entity<Student>().
                HasMany(s => s.Courses).
                WithMany(c => c.Students).
<<<<<<< HEAD
                UsingEntity(j => j.ToTable("StudentToCourse"));


            
        }
    }          
=======
                UsingEntity("CourseStudentPairs");

            modelBuilder.Entity<CourceStudentPairs>().HasKey(c => c.StudentsId);
            modelBuilder.Entity<CourceStudentPairs>().HasKey(c => c.CoursesId);
        }
    }
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
}
