// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using StudentNoteApp.Models;

namespace StudentNoteApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<Teacher> _signInManager;
        private readonly UserManager<Teacher> _userManager;
        private readonly IUserStore<Teacher> _userStore;
        private readonly IUserEmailStore<Teacher> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<Teacher> signInManager,
            UserManager<Teacher> userManager,
            IUserStore<Teacher> userStore,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public IActionResult OnGet() => RedirectToPage("./Login");

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                // Check if the email exists in our system
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (email != null)
                {
                    var existingUser = await _userManager.FindByEmailAsync(email);
                    if (existingUser != null)
                    {
                        // Check if this user was registered as an external user
                        if (string.IsNullOrEmpty(existingUser.PasswordHash))
                        {
                            // This is an external user, add the external login and sign them in
                            var addLoginResult = await _userManager.AddLoginAsync(existingUser, info);
                            if (addLoginResult.Succeeded)
                            {
                                await _signInManager.SignInAsync(existingUser, isPersistent: false);
                                return LocalRedirect(returnUrl);
                            }
                        }
                        else
                        {
                            // This user was registered with a password, they should use password login
                            ModelState.AddModelError(string.Empty, "This email is registered with a password. Please use the password login.");
                            return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                        }
                    }
                    else
                    {
                        // User not found in our system
                        ModelState.AddModelError(string.Empty, "You must be registered by an administrator before using Google Sign-in.");
                        return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                    }
                }

                // If we get here, something went wrong
                ModelState.AddModelError(string.Empty, "Error during external login. Please contact administrator.");
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                // Get the email from Google login
                var googleEmail = info.Principal.FindFirstValue(ClaimTypes.Email);

                // Check if this email matches the registered external user
                var existingUser = await _userManager.FindByEmailAsync(googleEmail);

                if (existingUser == null)
                {
                    ModelState.AddModelError(string.Empty, "You must be registered by an administrator before using Google Sign-in.");
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }

                // Verify this is an external user (no password)
                if (!string.IsNullOrEmpty(existingUser.PasswordHash))
                {
                    ModelState.AddModelError(string.Empty, "This email is registered with a password. Please use the password login.");
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }

                // Link the Google account to the existing user
                var result = await _userManager.AddLoginAsync(existingUser, info);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User {Email} linked their account with {Name} provider.", existingUser.Email, info.LoginProvider);

                    // Sign in the user
                    await _signInManager.SignInAsync(existingUser, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ProviderDisplayName = info.ProviderDisplayName;
            ReturnUrl = returnUrl;
            return Page();
        }

        private Teacher CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Teacher>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Teacher)}'. " +
                    $"Ensure that '{nameof(Teacher)}' is not an abstract class and has a parameterless constructor.");
            }
        }

        private IUserEmailStore<Teacher> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Teacher>)_userStore;
        }
    }
}
