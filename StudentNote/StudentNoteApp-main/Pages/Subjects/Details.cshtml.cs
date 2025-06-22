using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Constants;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Subjects;

[Authorize(Policy = RoleConstants.Permissions.Subjects.View)]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DetailsModel> _logger;

    public Subject Subject { get; set; } = new();

    public DetailsModel(
        ApplicationDbContext context,
        ILogger<DetailsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var subject = await _context.Subjects
            .Include(s => s.Notes)
                .ThenInclude(n => n.Student)
            .Include(s => s.Notes)
                .ThenInclude(n => n.Description)
            .Include(s => s.Notes)
                .ThenInclude(n => n.Credit)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (subject == null)
        {
            return NotFound();
        }

        Subject = subject;
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        if (!User.IsInRole(RoleConstants.Admin))
        {
            return Forbid();
        }

        var subject = await _context.Subjects
            .Include(s => s.Notes)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (subject == null)
        {
            return NotFound();
        }

        try
        {
            // Remove associated notes first
            if (subject.Notes != null && subject.Notes.Any())
            {
                _context.Notes.RemoveRange(subject.Notes);
            }

            // Then remove the subject
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Subject deleted successfully!";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting subject {SubjectId}", id);
            TempData["ErrorMessage"] = "An error occurred while deleting the subject. Please try again.";
            return RedirectToPage("./Index");
        }
    }
}