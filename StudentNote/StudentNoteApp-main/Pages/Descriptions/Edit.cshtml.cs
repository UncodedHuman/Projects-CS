using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Descriptions
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Update audit fields
                _context.Attach(Description).Property(x => x.ModifiedDateTime).CurrentValue = DateTime.UtcNow;
                _context.Attach(Description).Property(x => x.ModifiedBy).CurrentValue = User.Identity?.Name ?? "System";

                _context.Attach(Description).State = EntityState.Modified;
                // Don't modify creation fields
                _context.Entry(Description).Property(x => x.CreatedDateTime).IsModified = false;
                _context.Entry(Description).Property(x => x.CreatedBy).IsModified = false;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Description {Id} updated successfully", Description.Id);
                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error updating description {Id}", Description.Id);
                if (!await DescriptionExists(Description.Id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating description {Id}", Description.Id);
                ModelState.AddModelError(string.Empty, "An error occurred while updating the description.");
                return Page();
            }
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

        private async Task<bool> DescriptionExists(int id)
        {
            return await _context.Descriptions.AnyAsync(e => e.Id == id);
        }
    }
}