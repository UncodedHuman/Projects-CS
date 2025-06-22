using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Credits
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

        public IList<Credit> Credits { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Credits = await _context.Credits.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var credit = await _context.Credits.FindAsync(id);

            if (credit == null)
            {
                return NotFound();
            }

            try
            {
                _context.Credits.Remove(credit);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Credit {Id} was deleted successfully", id);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting credit {Id}", id);
                throw;
            }
        }
    }
}