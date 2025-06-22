using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Descriptions
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ApplicationDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Description Description { get; set; } = default!;

        public IActionResult OnGet()
        {
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
                // Set audit fields
                Description.CreatedDateTime = DateTime.UtcNow;
                Description.CreatedBy = User.Identity?.Name ?? "System";
                Description.ModifiedDateTime = DateTime.UtcNow;
                Description.ModifiedBy = User.Identity?.Name ?? "System";

                _context.Descriptions.Add(Description);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Description created successfully");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating description");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the description.");
                return Page();
            }
        }
    }
}