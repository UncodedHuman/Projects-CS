using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;

namespace StudentNoteApp.Pages.Students;

[Authorize(Roles = RoleConstants.Admin)]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EditModel> _logger;

    [BindProperty]
    public Student Student { get; set; } = default!;

    public EditModel(ApplicationDbContext context, ILogger<EditModel> logger)
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

        var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
        if (student == null)
        {
            return NotFound();
        }

        Student = student;
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
            var currentTime = DateTime.UtcNow;
            var currentUser = User.Identity?.Name ?? "System";

            // Get the existing student to preserve CreatedBy and CreatedDateTime
            var existingStudent = await _context.Students.FindAsync(Student.Id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            // Update the student properties
            existingStudent.FirstName = Student.FirstName;
            existingStudent.LastName = Student.LastName;
            existingStudent.StudentNumber = Student.StudentNumber;
            existingStudent.Year = Student.Year;

            // Update audit fields
            existingStudent.ModifiedDateTime = currentTime;
            existingStudent.ModifiedBy = currentUser;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Student updated successfully!";
            return RedirectToPage("./Index");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await StudentExists(Student.Id))
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
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting student {StudentId}", id);
            ModelState.AddModelError(string.Empty, "An error occurred while deleting the student. Please try again.");
            return Page();
        }
    }

    private async Task<bool> StudentExists(int id)
    {
        return await _context.Students.AnyAsync(e => e.Id == id);
    }
}