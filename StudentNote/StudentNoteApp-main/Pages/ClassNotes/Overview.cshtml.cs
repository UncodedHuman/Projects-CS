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
public class OverviewModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<OverviewModel> _logger;

    public List<int> Years { get; private set; } = [];
    public int? SelectedYear { get; set; }
    public List<StudentNotesViewModel> StudentNotes { get; private set; } = [];

    public OverviewModel(ApplicationDbContext context, ILogger<OverviewModel> logger)
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
                TotalNumericCredits = s.NumericCredits
                    .Where(c => decimal.TryParse(c, out decimal _))
                    .Sum(c => decimal.Parse(c))
            })
            .OrderByDescending(s => s.TotalNumericCredits)
            .ToList();
    }
}