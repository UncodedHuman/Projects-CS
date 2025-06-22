using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Descriptions
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(ApplicationDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Description Description { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);
            if (description == null)
            {
                return NotFound();
            }

            Description = description;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var description = await _context.Descriptions.FindAsync(Description.Id);
            if (description == null)
            {
                return NotFound();
            }

            try
            {
                _context.Descriptions.Remove(description);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Description {Id} deleted successfully", Description.Id);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting description {Id}", Description.Id);
                throw;
            }
        }
    }
}