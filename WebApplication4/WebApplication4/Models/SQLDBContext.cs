using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class SQLDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        public DbSet<User>Users { get; set; }   

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

            modelBuilder.Entity<Course>().
                HasMany(c => c.Students).
                WithMany(s => s.Courses)
                .UsingEntity<Enrollment>(
                   j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(t => t.Enrollments)
                    .HasForeignKey(pt => pt.StudentId),
                j => j
                    .HasOne(pt => pt.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(pt => pt.CourseId),
                j =>
                {
                    j.HasKey(t => new { t.CourseId, t.StudentId });
                    j.ToTable("Enrollments");
                });
        }
    }
}
