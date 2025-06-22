using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;

namespace StudentNoteApp.Pages;

[Authorize(Policy = RoleConstants.Permissions.Notes.View)]
public class ClassNotesModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ClassNotesModel> _logger;

    public List<int> Years { get; private set; } = [];
    public int? SelectedYear { get; set; }
    public List<StudentNotesViewModel> StudentNotes { get; private set; } = [];

    public ClassNotesModel(ApplicationDbContext context, ILogger<ClassNotesModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(int? year)
    {
        Years = await _context.Students
            .Select(s => s.Year)
            .Distinct()
            .OrderBy(y => y)
            .ToListAsync();

        if (year.HasValue)
        {
            SelectedYear = year;
            await LoadStudentNotes(year.Value);
        }

        return Page();
    }

    private async Task LoadStudentNotes(int year)
    {
        var studentNotes = await _context.Students
            .Where(s => s.Year == year)
            .Select(student => new
            {
                StudentId = student.Id,
                StudentName = $"{student.LastName}, {student.FirstName}",
                StudentNumber = student.StudentNumber,
                Notes = _context.Notes
                    .Where(n => n.StudentId == student.Id)
                    .Select(note => new NoteViewModel
                    {
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

        StudentNotes = studentNotes.Select(s => new StudentNotesViewModel
        {
            StudentId = s.StudentId,
            StudentName = s.StudentName,
            StudentNumber = s.StudentNumber,
            Notes = s.Notes,
            TotalNumericCredits = s.NumericCredits
                .Where(c => decimal.TryParse(c, out decimal _))
                .Sum(c => decimal.Parse(c))
        })
        .OrderByDescending(s => s.TotalNumericCredits)
        .ToList();
    }
}

public class StudentNotesViewModel
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public List<NoteViewModel> Notes { get; set; } = [];
    public decimal TotalNumericCredits { get; set; }
}

public class NoteViewModel
{
    public DateTime Date { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Credit { get; set; } = string.Empty;
    public string CreditValue { get; set; } = string.Empty;
    public bool IsNumericCredit { get; set; }
    public string? Comment { get; set; }
    public int NoteId { get; internal set; }

}