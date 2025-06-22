using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Credits
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(ApplicationDbContext context, ILogger<EditModel> logger)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Update audit fields
                _context.Attach(Credit).Property(x => x.ModifiedDateTime).CurrentValue = DateTime.UtcNow;
                _context.Attach(Credit).Property(x => x.ModifiedBy).CurrentValue = User.Identity?.Name ?? "System";

                _context.Attach(Credit).State = EntityState.Modified;
                // Don't modify creation fields
                _context.Entry(Credit).Property(x => x.CreatedDateTime).IsModified = false;
                _context.Entry(Credit).Property(x => x.CreatedBy).IsModified = false;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Credit {Id} updated successfully", Credit.Id);
                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error updating credit {Id}", Credit.Id);
                if (!await CreditExists(Credit.Id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating credit {Id}", Credit.Id);
                ModelState.AddModelError(string.Empty, "An error occurred while updating the credit.");
                return Page();
            }
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

        private async Task<bool> CreditExists(int id)
        {
            return await _context.Credits.AnyAsync(e => e.Id == id);
        }
    }
}