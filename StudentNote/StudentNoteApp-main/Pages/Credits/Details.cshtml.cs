using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Credits
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
        public Credit Credit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            if (credit == null)
            {
                return NotFound();
            }

            Credit = credit;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var credit = await _context.Credits.FindAsync(Credit.Id);
            if (credit == null)
            {
                return NotFound();
            }

            try
            {
                _context.Credits.Remove(credit);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Credit {Id} deleted successfully", Credit.Id);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting credit {Id}", Credit.Id);
                throw;
            }
        }
    }
}