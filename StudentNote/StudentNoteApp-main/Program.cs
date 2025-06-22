using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using StudentNoteApp.Services;
using StudentNoteApp.Authorization;
using StudentNoteApp.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure Entity Framework Core and SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity services
builder.Services.AddIdentity<Teacher, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure cookie policy
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => false;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

// Configure authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    options.CorrelationCookie.SameSite = SameSiteMode.Lax;
    options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
});

// Configure cookie authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
});

// Register the IEmailSender service
builder.Services.AddTransient<IEmailSender, EmailSender>();

// Add role initialization service
builder.Services.AddScoped<RoleInitializationService>();

// Add Authorization handler
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

// Configure authorization policies
builder.Services.AddAuthorization(options =>
{
    // Add policies for each permission
    foreach (var prop in typeof(RoleConstants.Permissions).GetNestedTypes())
    {
        foreach (var permission in prop.GetFields())
        {
            var permissionName = permission.GetValue(null) as string;
            if (permissionName != null)
            {
                options.AddPolicy(permissionName, policy =>
                    policy.Requirements.Add(new PermissionRequirement(permissionName)));
            }
        }
    }
});

// Add database seeder service
builder.Services.AddScoped<DatabaseSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

// Initialize roles and admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleInitializer = services.GetRequiredService<RoleInitializationService>();
        await roleInitializer.InitializeAsync();

        // Seed demo data
        var databaseSeeder = services.GetRequiredService<DatabaseSeeder>();
        await databaseSeeder.SeedAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
    }
}

app.Run();