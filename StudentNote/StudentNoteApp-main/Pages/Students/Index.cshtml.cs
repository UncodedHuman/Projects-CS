using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;

namespace StudentNoteApp.Pages.Students;

[Authorize(Policy = RoleConstants.Permissions.Students.View)]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IList<Student> Students { get; set; } = new List<Student>();

    public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        Students = await _context.Students
            .OrderBy(s => s.Year)
            .ThenBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        if (!User.IsInRole(RoleConstants.Admin))
        {
            return Forbid();
        }

        var student = await _context.Students
            .Include(s => s.Notes)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        try
        {
            // Remove associated notes first
            if (student.Notes != null && student.Notes.Any())
            {
                _context.Notes.RemoveRange(student.Notes);
            }

            // Then remove the student
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Student deleted successfully!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting student {StudentId}", id);
            TempData["ErrorMessage"] = "An error occurred while deleting the student. Please try again.";
            return RedirectToPage();
        }
    }
}