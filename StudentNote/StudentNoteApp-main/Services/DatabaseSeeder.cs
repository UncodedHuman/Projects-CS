using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Services;

public class DatabaseSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DatabaseSeeder> _logger;

    public DatabaseSeeder(ApplicationDbContext context, ILogger<DatabaseSeeder> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task SeedAsync()
    {
        try
        {
            // Only seed if the database is empty
            if (!_context.Students.Any() && !_context.Subjects.Any())
            {
                await SeedSubjectsAsync();
                await SeedDescriptionsAsync();
                await SeedCreditsAsync();
                await SeedStudentsAsync();
                await SeedNotesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task SeedSubjectsAsync()
    {
        var subjects = new[]
        {
            new Subject { Name = "Mathematics", CreatedBy = "System", ModifiedBy = "System" },
            new Subject { Name = "Physics", CreatedBy = "System", ModifiedBy = "System" },
            new Subject { Name = "Chemistry", CreatedBy = "System", ModifiedBy = "System" },
            new Subject { Name = "Biology", CreatedBy = "System", ModifiedBy = "System" },
            new Subject { Name = "Computer Science", CreatedBy = "System", ModifiedBy = "System" }
        };

        await _context.Subjects.AddRangeAsync(subjects);
        await _context.SaveChangesAsync();
    }

    private async Task SeedDescriptionsAsync()
    {
        var descriptions = new[]
        {
            new Description { Name = "Homework", CreatedBy = "System", ModifiedBy = "System" },
            new Description { Name = "Quiz", CreatedBy = "System", ModifiedBy = "System" },
            new Description { Name = "Exam", CreatedBy = "System", ModifiedBy = "System" },
            new Description { Name = "Project", CreatedBy = "System", ModifiedBy = "System" },
            new Description { Name = "Lab Work", CreatedBy = "System", ModifiedBy = "System" }
        };

        await _context.Descriptions.AddRangeAsync(descriptions);
        await _context.SaveChangesAsync();
    }

    private async Task SeedCreditsAsync()
    {
        var credits = new[]
        {
            new Credit {
                Value = "100",
                DisplayText = "100 Points",
                Description = "Full Score",
                IsNumeric = true,
                CreatedBy = "System",
                ModifiedBy = "System"
            },
            new Credit {
                Value = "75",
                DisplayText = "75 Points",
                Description = "Good Score",
                IsNumeric = true,
                CreatedBy = "System",
                ModifiedBy = "System"
            },
            new Credit {
                Value = "50",
                DisplayText = "50 Points",
                Description = "Average Score",
                IsNumeric = true,
                CreatedBy = "System",
                ModifiedBy = "System"
            },
            new Credit {
                Value = "A",
                DisplayText = "Excellent",
                Description = "Outstanding Performance",
                IsNumeric = false,
                CreatedBy = "System",
                ModifiedBy = "System"
            },
            new Credit {
                Value = "B",
                DisplayText = "Good",
                Description = "Above Average Performance",
                IsNumeric = false,
                CreatedBy = "System",
                ModifiedBy = "System"
            }
        };

        await _context.Credits.AddRangeAsync(credits);
        await _context.SaveChangesAsync();
    }

    private async Task SeedStudentsAsync()
    {
        var students = new[]
        {
            new Student {
                FirstName = "John",
                LastName = "Doe",
                StudentNumber = "2024001",
                Year = 10,
                CreatedBy = "System",
                ModifiedBy = "System"
            },
            new Student {
                FirstName = "Jane",
                LastName = "Smith",
                StudentNumber = "2024002",
                Year = 11,
                CreatedBy = "System",
                ModifiedBy = "System"
            },
            new Student {
                FirstName = "Michael",
                LastName = "Johnson",
                StudentNumber = "2023001",
                Year = 12,
                CreatedBy = "System",
                ModifiedBy = "System"
            },
            new Student {
                FirstName = "Emily",
                LastName = "Brown",
                StudentNumber = "2023002",
                Year = 12,
                CreatedBy = "System",
                ModifiedBy = "System"
            }
        };

        await _context.Students.AddRangeAsync(students);
        await _context.SaveChangesAsync();
    }

    private async Task SeedNotesAsync()
    {
        // Get existing data
        var students = await _context.Students.ToListAsync();
        var subjects = await _context.Subjects.ToListAsync();
        var descriptions = await _context.Descriptions.ToListAsync();
        var credits = await _context.Credits.ToListAsync();
        var teacher = await _context.Users.FirstOrDefaultAsync(u => u.Email == "admin@studentnotes.com");

        if (teacher == null)
        {
            _logger.LogWarning("Admin user not found. Skipping notes seeding.");
            return;
        }

        var random = new Random();
        var notes = new List<Note>();

        foreach (var student in students)
        {
            // Create 3 random notes for each student
            for (int i = 0; i < 3; i++)
            {
                var note = new Note
                {
                    StudentId = student.Id,
                    SubjectId = subjects[random.Next(subjects.Count)].Id,
                    DescriptionId = descriptions[random.Next(descriptions.Count)].Id,
                    CreditId = credits[random.Next(credits.Count)].Id,
                    Date = DateTime.Today.AddDays(-random.Next(30)),
                    Comment = $"Sample note {i + 1} for {student.FirstName}",
                    TeacherId = teacher.Id,
                    CreatedBy = "System",
                    ModifiedBy = "System"
                };

                notes.Add(note);
            }
        }

        await _context.Notes.AddRangeAsync(notes);
        await _context.SaveChangesAsync();
    }
}