using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Descriptions
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Description> Descriptions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Descriptions = await _context.Descriptions.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);

            if (description == null)
            {
                return NotFound();
            }

            try
            {
                _context.Descriptions.Remove(description);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Description {Id} was deleted successfully", id);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting description {Id}", id);
                throw;
            }
        }
    }
}