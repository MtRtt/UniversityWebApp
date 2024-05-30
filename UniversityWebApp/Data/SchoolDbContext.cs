using Microsoft.EntityFrameworkCore;
using UniversityWebApp.Models;

namespace UniversityWebApp.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
       
                 modelBuilder.Entity<Course>()
                .HasMany(e => e.Enrollments)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseID)
                .IsRequired();
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Enrollment>()
                .HasOne(c => c.Course)
                .WithMany(e => e.Enrollments);

            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentID);



            modelBuilder.Entity<Student>().HasData(
            new Student {ID = 1, FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
            new Student {ID = 2, FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
            new Student {ID = 3, FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
            new Student {ID = 4, FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
            new Student {ID = 5, FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
            new Student {ID = 6, FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
            new Student {ID = 7, FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
            new Student {ID = 8, FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
            ); ;


            modelBuilder.Entity<Course>().HasData(
             new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
             new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
             new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 },
             new Course { CourseID = 1045, Title = "Calculus", Credits = 4 },
             new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4 },
             new Course { CourseID = 2021, Title = "Composition", Credits = 3 },
             new Course { CourseID = 2042, Title = "Literature", Credits = 4 }
            );
        
        }
    }
}
