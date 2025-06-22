using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentNoteApp.Constants;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Users;

[Authorize(Roles = RoleConstants.Admin)]
public class DetailsModel : PageModel
{
    private readonly UserManager<Teacher> _userManager;
    private readonly ILogger<DetailsModel> _logger;

    public UserViewModel User { get; set; } = new();

    public DetailsModel(
        UserManager<Teacher> userManager,
        ILogger<DetailsModel> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var roles = await _userManager.GetRolesAsync(user);
        User = new UserViewModel
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = roles.FirstOrDefault() ?? "No Role"
        };

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        try
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "User deleted successfully!";
                return RedirectToPage("./Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user {UserId}", id);
            TempData["ErrorMessage"] = "An error occurred while deleting the user. Please try again.";
            return RedirectToPage("./Index");
        }
    }
}