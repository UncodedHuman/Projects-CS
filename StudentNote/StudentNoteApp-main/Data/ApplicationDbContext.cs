using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Models;

namespace StudentNoteApp.Data;
public class ApplicationDbContext : IdentityDbContext<Teacher>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Credit> Credits { get; set; }
    public DbSet<Description> Descriptions { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Teachs_Subjs> Teachers_Subjects { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure Student-Notes relationship
        builder.Entity<Student>()
            .HasMany(s => s.Notes)
            .WithOne(n => n.Student)
            .HasForeignKey(n => n.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Define relationships for Note
        builder.Entity<Note>()
            .HasOne(n => n.Teacher)
            .WithMany()
            .HasForeignKey(n => n.TeacherId);

        builder.Entity<Note>()
            .HasOne(n => n.Subject)
            .WithMany(s => s.Notes)
            .HasForeignKey(n => n.SubjectId);

        builder.Entity<Note>()
            .HasOne(n => n.Description)
            .WithMany()
            .HasForeignKey(n => n.DescriptionId);

        builder.Entity<Note>()
            .HasOne(n => n.Credit)
            .WithMany()
            .HasForeignKey(n => n.CreditId);

        builder.Entity<Teachs_Subjs>()
            .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

        builder.Entity<Teachs_Subjs>()
            .HasOne(ts => ts.Teacher)
            .WithMany(t => t.teachers_subjects)
            .HasForeignKey(ts => ts.TeacherId);

        builder.Entity<Teachs_Subjs>()
            .HasOne(ts => ts.Subject)
            .WithMany()  // Or define a navigation collection on Subject if needed
            .HasForeignKey(ts => ts.SubjectId);
    }
}
