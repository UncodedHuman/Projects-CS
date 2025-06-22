using Microsoft.AspNetCore.Identity;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;

namespace StudentNoteApp.Services;

public class RoleInitializationService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<Teacher> _userManager;

    public RoleInitializationService(RoleManager<IdentityRole> roleManager, UserManager<Teacher> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task InitializeAsync()
    {
        // Create roles if they don't exist
        foreach (var roleName in RoleConstants.AllRoles)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);

                // Here you can add claims for permissions when you implement them
                if (RoleConstants.DefaultPermissions.RolePermissions.TryGetValue(roleName, out var permissions))
                {
                    foreach (var permission in permissions)
                    {
                        await _roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", permission));
                    }
                }
            }
        }

        // Create admin users if they don't exist
        var adminConfigs = new[]
        {
            new { Email = "admin@studentnotes.com", Password = "Admin123!" },
            new { Email = "admina@studentnotes.com", Password = "AdminA123!" },
            new { Email = "admins@studentnotes.com", Password = "AdminS123!" },
            new { Email = "adminSS@studentnotes.com", Password = "AdminSS123!" },
        };

        foreach (var config in adminConfigs)
        {
            var adminUser = await _userManager.FindByEmailAsync(config.Email);

            if (adminUser == null)
            {
                var admin = new Teacher
                {
                    UserName = config.Email,
                    Email = config.Email,
                    FullName = $"System Administrator ({config.Email})",
                    IsAdmin = true,
                    EmailConfirmed = true,
                    CreatedBy = "System",
                    CreatedDateTime = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDateTime = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(admin, config.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, RoleConstants.Admin);
                }
            }
        }
    }
}