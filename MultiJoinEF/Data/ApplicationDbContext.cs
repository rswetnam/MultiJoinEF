using Microsoft.EntityFrameworkCore;
using MultiJoinEF.Models;
using System.Reflection.Emit;

namespace MultiJoinEF.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        CourseProperties(builder);
        EnrollmentProperties(builder);
        StudentProperties(builder);

    }

    //--------------- The Properties -----------------------------
    private void CourseProperties(ModelBuilder builder)
    {
        builder.Entity<Course>().HasData(
            new { Id = 1, Name = "Algebra" },
            new { Id = 2, Name = "Geometry" },
            new { Id = 3, Name = "Calculus" }

            );
    }

    private void EnrollmentProperties(ModelBuilder builder)
    {
        builder.Entity<Enrollment>()
            .HasOne(bc => bc.Student)
            .WithMany(b => b.Enrollments)
            .HasForeignKey(bc => bc.StudentId);

        builder.Entity<Enrollment>()
            .HasOne(bc => bc.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(bc => bc.CourseId);
    }

        private void StudentProperties(ModelBuilder builder)
    {
        builder.Entity<Student>().HasData(
            new { Id = Guid.NewGuid().ToString(), Name = "Miss Muffett" },
            new { Id = Guid.NewGuid().ToString(), Name = "Jack Spratt" }

            );
    }

}
