using AJ_MVC_Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AJ_MVC_Application.Data;

public class ApplicationDbContext : IdentityDbContext<AJ_MVC_ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }
    public DbSet<SubjectPreq> SubjectPreqs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Subject>().HasKey(s => new { s.SubjectCode, s.SubjectCategory, s.SubjectCourseCode });

        
    }
}
