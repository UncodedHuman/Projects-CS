using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Constants;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Subjects;

[Authorize(Policy = RoleConstants.Permissions.Subjects.Edit)]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EditModel> _logger;

    [BindProperty]
    public Subject Subject { get; set; } = new();

    public EditModel(
        ApplicationDbContext context,
        ILogger<EditModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
        {
            return NotFound();
        }

        Subject = subject;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            // Get the existing subject to preserve CreatedBy and CreatedDateTime
            var existingSubject = await _context.Subjects.FindAsync(Subject.Id);
            if (existingSubject == null)
            {
                return NotFound();
            }

            // Update the subject properties
            existingSubject.Name = Subject.Name;
            existingSubject.ModifiedBy = User.Identity?.Name ?? string.Empty;
            existingSubject.ModifiedDateTime = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Subject updated successfully!";
            return RedirectToPage("./Index");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await SubjectExists(Subject.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
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

    private async Task<bool> SubjectExists(int id)
    {
        return await _context.Subjects.AnyAsync(e => e.Id == id);
    }
}