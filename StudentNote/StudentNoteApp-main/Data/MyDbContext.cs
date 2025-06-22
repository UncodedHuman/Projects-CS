using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Models;

public class MyDbContext : DbContext
{
    public DbSet<Teacher> teachers { get; set; }
    public DbSet<Teachs_Subjs> teachers_subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teachs_Subjs>()
            .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

        modelBuilder.Entity<Teachs_Subjs>()
            .HasOne(ts => ts.Teacher)
            .WithMany(t => t.teachers_subjects)
            .HasForeignKey(ts => ts.TeacherId);

        modelBuilder.Entity<Teachs_Subjs>()
            .HasOne(ts => ts.Subject)
            .WithMany()
            .HasForeignKey(ts => ts.SubjectId);
    }
}