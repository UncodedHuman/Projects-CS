using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Constants;
using StudentNoteApp.Models;

namespace StudentNoteApp.Pages.Users;

[Authorize(Roles = RoleConstants.Admin)]
public class IndexModel : PageModel
{
    private readonly UserManager<Teacher> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<IndexModel> _logger;

    public IList<UserViewModel> Users { get; set; } = new List<UserViewModel>();

    public IndexModel(
        UserManager<Teacher> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<IndexModel> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var userViewModels = new List<UserViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userViewModels.Add(new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = roles.FirstOrDefault() ?? "No Role"
            });
        }

        Users = userViewModels.OrderBy(u => u.FullName).ToList();
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
                return RedirectToPage();
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
            return RedirectToPage();
        }
    }
}

public class UserViewModel
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Role { get; set; } = string.Empty;
}