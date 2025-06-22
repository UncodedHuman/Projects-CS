using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Students;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DetailsModel> _logger;

    public Student Student { get; set; } = default!;
    public IList<Note> Notes { get; set; } = new List<Note>();

    public DetailsModel(ApplicationDbContext context, ILogger<DetailsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        var notes = await _context.Notes
            .Include(n => n.Subject)
            .Include(n => n.Description)
            .Include(n => n.Credit)
            .Where(n => n.StudentId == id)
            .OrderByDescending(n => n.Date)
            .ToListAsync();

        Student = student;
        Notes = notes;

        return Page();
    }
}