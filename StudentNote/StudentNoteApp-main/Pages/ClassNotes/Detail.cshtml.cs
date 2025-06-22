using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;
using StudentNoteApp.Pages.ClassNotes.ViewModels;

namespace StudentNoteApp.Pages.ClassNotes;

[Authorize(Policy = RoleConstants.Permissions.Notes.View)]
public class DetailModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DetailModel> _logger;

    public List<int> Years { get; private set; } = [];
    public int? SelectedYear { get; set; }
    public List<StudentNotesViewModel> StudentNotes { get; private set; } = [];

    public DetailModel(ApplicationDbContext context, ILogger<DetailModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(int? year, int? studentId)
    {
        Years = await _context.Students
            .Select(s => s.Year)
            .Distinct()
            .OrderBy(y => y)
            .ToListAsync();

        if (year.HasValue)
        {
            SelectedYear = year;
            await LoadStudentNotes(year.Value, studentId);
        }

        return Page();
    }

    private async Task LoadStudentNotes(int year, int? studentId)
    {
        var query = _context.Students.Where(s => s.Year == year);

        if (studentId.HasValue)
        {
            query = query.Where(s => s.Id == studentId.Value);
        }

        var studentNotes = await query
            .Select(student => new
            {
                StudentId = student.Id,
                StudentName = $"{student.LastName}, {student.FirstName}",
                StudentNumber = student.StudentNumber,
                Notes = _context.Notes
                    .Where(n => n.StudentId == student.Id)
                    .Select(note => new
                    {
                        NoteId = note.Id,
                        Date = note.Date,
                        Subject = note.Subject.Name,
                        Description = note.Description.Name,
                        Credit = note.Credit.DisplayText,
                        CreditValue = note.Credit.Value,
                        IsNumericCredit = note.Credit.IsNumeric,
                        Comment = note.Comment
                    })
                    .ToList(),
                NumericCredits = _context.Notes
                    .Where(n => n.StudentId == student.Id && n.Credit.IsNumeric)
                    .Select(n => n.Credit.Value)
                    .ToList()
            })
            .ToListAsync();

        StudentNotes = studentNotes
            .Select(s => new StudentNotesViewModel
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
                StudentNumber = s.StudentNumber,
                Notes = s.Notes.Select(n => new NoteViewModel
                {
                    NoteId = n.NoteId,
                    Date = n.Date,
                    Subject = n.Subject,
                    Description = n.Description,
                    Credit = n.Credit,
                    CreditValue = n.CreditValue,
                    IsNumericCredit = n.IsNumericCredit,
                    Comment = n.Comment
                }).ToList(),
                TotalNumericCredits = s.NumericCredits
                    .Where(c => decimal.TryParse(c, out decimal _))
                    .Sum(c => decimal.Parse(c))
            })
            .OrderByDescending(s => s.TotalNumericCredits)
            .ToList();
    }
    public async Task<IActionResult> OnPostDeleteNoteAsync(int noteId, int? year, int? studentId)
    {
    var note = await _context.Notes
        .Include(n => n.Credit) // Include credit if it's a separate entity
        .FirstOrDefaultAsync(n => n.Id == noteId);

    if (note != null)
    {
        _context.Notes.Remove(note);
        // If Credit is a separate entity:
        _context.Credits.Remove(note.Credit);
        await _context.SaveChangesAsync();
    }

    // Preserve filter parameters
    return RedirectToPage(new { year, studentId });
    }
}