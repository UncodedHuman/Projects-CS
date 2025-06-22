// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;
using Microsoft.EntityFrameworkCore;

namespace StudentNoteApp.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Teacher> _signInManager;
        private readonly UserManager<Teacher> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<Teacher> userManager,
            SignInManager<Teacher> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Is External User")]
            public bool IsExternalUser { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string Role { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.FullName = Input.FullName;
                user.Email = Input.Email;
                user.UserName = Input.Email;
                user.EmailConfirmed = Input.IsExternalUser; // Auto confirm for external users

                // Set audit fields
                var currentUser = await _userManager.GetUserAsync(User);
                var currentUserName = currentUser?.Email ?? "System";

                user.CreatedDateTime = DateTime.UtcNow;
                user.CreatedBy = currentUserName;
                user.ModifiedDateTime = DateTime.UtcNow;
                user.ModifiedBy = currentUserName;

                IdentityResult result;
                if (Input.IsExternalUser)
                {
                    // Create user without password for external users
                    result = await _userManager.CreateAsync(user);
                }
                else
                {
                    // Create user with password for regular users
                    if (string.IsNullOrEmpty(Input.Password))
                    {
                        ModelState.AddModelError(string.Empty, "Password is required for non-external users.");
                        return Page();
                    }
                    result = await _userManager.CreateAsync(user, Input.Password);
                }

                if (result.Succeeded)
                {
                    _logger.LogInformation("Created a new user account.");

                    // Add user to selected role
                    await _userManager.AddToRoleAsync(user, Input.Role);

                    if (!Input.IsExternalUser)
                    {
                        // Only send confirmation email for non-external users
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        await _userManager.ConfirmEmailAsync(user, code);
                    }

                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private Teacher CreateUser()
        {
            try
            {
                return new Teacher();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Teacher)}'. " +
                    $"Ensure that '{nameof(Teacher)}' is not an abstract class and has a parameterless constructor.");
            }
        }
    }
}
