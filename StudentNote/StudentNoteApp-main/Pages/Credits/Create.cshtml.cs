using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Credits
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
        public Credit Credit { get; set; } = default!;

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
                Credit.CreatedDateTime = DateTime.UtcNow;
                Credit.CreatedBy = User.Identity?.Name ?? "System";
                Credit.ModifiedDateTime = DateTime.UtcNow;
                Credit.ModifiedBy = User.Identity?.Name ?? "System";

                _context.Credits.Add(Credit);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Credit created successfully");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating credit");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the credit.");
                return Page();
            }
        }
    }
}