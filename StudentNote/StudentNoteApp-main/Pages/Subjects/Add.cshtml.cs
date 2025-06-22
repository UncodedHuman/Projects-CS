using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentNoteApp.Constants;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Subjects;

[Authorize(Policy = RoleConstants.Permissions.Subjects.Create)]
public class AddModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AddModel> _logger;

    [BindProperty]
    public Subject Subject { get; set; } = new();

    public AddModel(
        ApplicationDbContext context,
        ILogger<AddModel> logger)
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

            // Set audit fields - ensure none are null
            Subject.CreatedDateTime = currentTime;
            Subject.CreatedBy = currentUser;
            Subject.ModifiedDateTime = currentTime;  // Note: this is DateTime? so it's okay
            Subject.ModifiedBy = currentUser;

            _context.Subjects.Add(Subject);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Subject added successfully!";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding subject");
            ModelState.AddModelError(string.Empty, "An error occurred while adding the subject. Please try again.");
            return Page();
        }
    }
}