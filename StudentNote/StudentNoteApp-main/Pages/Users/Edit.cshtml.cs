using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Constants;
using StudentNoteApp.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentNoteApp.Pages.Users;

[Authorize(Roles = RoleConstants.Admin)]
public class EditModel : PageModel
{
    private readonly UserManager<Teacher> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<EditModel> _logger;

    [BindProperty]
    public EditUserViewModel UserViewModel { get; set; } = new();

    public SelectList AvailableRoles { get; set; }

    public EditModel(
        UserManager<Teacher> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<EditModel> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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
        UserViewModel = new EditUserViewModel
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = roles.FirstOrDefault() ?? string.Empty
        };

        await LoadRoles();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadRoles();
            return Page();
        }

        var user = await _userManager.FindByIdAsync(UserViewModel.Id);
        if (user == null)
        {
            return NotFound();
        }

        user.FullName = UserViewModel.FullName;
        user.Email = UserViewModel.Email;
        user.UserName = UserViewModel.Email; // Update username to match email

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            await LoadRoles();
            return Page();
        }

        // Update role if changed
        var currentRoles = await _userManager.GetRolesAsync(user);
        var currentRole = currentRoles.FirstOrDefault();
        if (currentRole != UserViewModel.Role)
        {
            if (currentRole != null)
            {
                await _userManager.RemoveFromRoleAsync(user, currentRole);
            }
            await _userManager.AddToRoleAsync(user, UserViewModel.Role);
        }

        TempData["SuccessMessage"] = "User updated successfully!";
        return RedirectToPage("./Index");
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
            await LoadRoles();
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user {UserId}", id);
            TempData["ErrorMessage"] = "An error occurred while deleting the user. Please try again.";
            return RedirectToPage("./Index");
        }
    }

    private async Task LoadRoles()
    {
        var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        AvailableRoles = new SelectList(roles);
    }
}

public class EditUserViewModel
{
    public string Id { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = string.Empty;
}