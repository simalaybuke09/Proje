using System;
using Microsoft.EntityFrameworkCore;
namespace Proje.Data {
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourseSelection> StudentCourseSelections { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-One Relationship: Students -> Advisors
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Advisor)
                .WithMany(a => a.Students)
                .HasForeignKey(s => s.AdvisorID);

            // Composite Keys and Relationships
            modelBuilder.Entity<StudentCourseSelection>()
                .HasOne(scs => scs.Student)
                .WithMany(s => s.CourseSelections)
                .HasForeignKey(scs => scs.StudentID);

            modelBuilder.Entity<StudentCourseSelection>()
                .HasOne(scs => scs.Course)
                .WithMany(c => c.CourseSelections)
                .HasForeignKey(scs => scs.CourseID);

            modelBuilder.Entity<Transcript>()
                .HasOne(t => t.Student)
                .WithMany(s => s.Transcripts)
                .HasForeignKey(t => t.StudentID);

            modelBuilder.Entity<Transcript>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Transcripts)
                .HasForeignKey(t => t.CourseID);
        }
    }
}

