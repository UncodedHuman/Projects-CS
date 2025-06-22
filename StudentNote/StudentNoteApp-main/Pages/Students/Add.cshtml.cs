using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;

namespace StudentNoteApp.Pages.Students;

[Authorize(Roles = RoleConstants.Admin)]
public class AddModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AddModel> _logger;

    [BindProperty]
    public Student Student { get; set; } = new();

    public AddModel(ApplicationDbContext context, ILogger<AddModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
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

            // Set audit fields
            Student.CreatedDateTime = currentTime;
            Student.CreatedBy = currentUser;
            Student.ModifiedDateTime = currentTime;
            Student.ModifiedBy = currentUser;

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Student added successfully!";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding student");
            ModelState.AddModelError(string.Empty, "An error occurred while adding the student. Please try again.");
            return Page();
        }
    }
}