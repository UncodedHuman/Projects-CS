using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentNoteApp.Data;
using StudentNoteApp.Models;
using StudentNoteApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace StudentNoteApp.Pages;

[Authorize(Policy = RoleConstants.Permissions.Notes.Create)]
public class AddNoteModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AddNoteModel> _logger;

    [BindProperty]
    public NoteInputModel Input { get; set; } = new();

    public List<SelectListItem> Subjects { get; private set; } = [];
    public List<SelectListItem> Descriptions { get; private set; } = [];
    public List<SelectListItem> Credits { get; private set; } = [];
    public List<int> Years { get; private set; } = [];

    public AddNoteModel(ApplicationDbContext context, ILogger<AddNoteModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await LoadSelectListsAsync();
        return Page();
    }

    public async Task<IActionResult> OnGetStudentsForYearAsync(int year)
    {
        var students = await _context.Students
            .Where(s => s.Year == year)
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .Select(s => new
            {
                id = s.Id,
                firstName = s.FirstName,
                lastName = s.LastName,
                studentNumber = s.StudentNumber
            })
            .ToListAsync();

        return new JsonResult(students);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadSelectListsAsync();
            return Page();
        }

        var currentTime = DateTime.UtcNow;
        var currentUser = User.Identity?.Name ?? "System";

        try
        {
            // Get the current teacher's ID
            var teacherId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(teacherId))
            {
                ModelState.AddModelError(string.Empty, "Teacher information not found. Please try logging in again.");
                await LoadSelectListsAsync();
                return Page();
            }

            // Validate teacher exists
            var teacherExists = await _context.Users.AnyAsync(t => t.Id == teacherId);
            if (!teacherExists)
            {
                ModelState.AddModelError(string.Empty, "Teacher not found in the database. Please contact administrator.");
                await LoadSelectListsAsync();
                return Page();
            }

            // Validate student exists
            var studentExists = await _context.Students.AnyAsync(s => s.Id == Input.StudentId);
            if (!studentExists)
            {
                ModelState.AddModelError("Input.StudentId", "Selected student does not exist");
                await LoadSelectListsAsync();
                return Page();
            }

            var note = new Note
            {
                StudentId = Input.StudentId,
                SubjectId = Input.SubjectId,
                DescriptionId = Input.DescriptionId,
                CreditId = Input.CreditId,
                Date = Input.Date,
                Comment = Input.Comment,
                TeacherId = teacherId,
                // Set audit fields
                CreatedDateTime = currentTime,
                CreatedBy = currentUser,
                ModifiedDateTime = currentTime,
                ModifiedBy = currentUser
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            // Reset the input model to default values
            Input = new NoteInputModel { Date = DateTime.Today };
            ModelState.Clear();

            // Set success message
            TempData["Message"] = "Note added successfully!";
            TempData["MessageType"] = "success";

            // Reload the select lists
            await LoadSelectListsAsync();
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while saving note. StudentId: {StudentId}, SubjectId: {SubjectId}, DescriptionId: {DescriptionId}, CreditId: {CreditId}",
                Input.StudentId, Input.SubjectId, Input.DescriptionId, Input.CreditId);

            // Log additional context
            _logger.LogError("Current User: {User}, Claims: {@Claims}",
                User.Identity?.Name,
                User.Claims.Select(c => new { c.Type, c.Value }));

            ModelState.AddModelError(string.Empty, "An error occurred while saving the note. Please try again.");
            await LoadSelectListsAsync();
            return Page();
        }
    }

    private async Task LoadSelectListsAsync()
    {
        // Get the logged-in teacher's ID
        var teacherId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(teacherId))
        {
        Subjects = new List<SelectListItem>(); // Empty list if no teacher is found
        }
        else
        {
        // Filter subjects assigned to the logged-in teacher
        Subjects = await _context.Teachers_Subjects
            .Where(ts => ts.TeacherId == teacherId)
            .Select(ts => ts.Subject)
            .OrderBy(s => s.Name)
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            })
            .ToListAsync();
        }

        Years = await _context.Students
            .Select(s => s.Year)
            .Distinct()
            .OrderBy(y => y)
            .ToListAsync();


        var disabledIds = new List<int> { 1, 7, 13, 19, 25, 28 }; // List of ids to disable (titles)
        Descriptions = await _context.Descriptions
            .OrderBy(d => d.Id)
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name,
                Disabled = disabledIds.Contains(d.Id) // disabling the ids
            })
            .ToListAsync();

        Credits = await _context.Credits
            .OrderBy(c => c.Value)
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.DisplayText}|{c.Description}"
            })
            .ToListAsync();
    }
}

public class NoteInputModel
{
    [Required(ErrorMessage = "Please select a year")]
    public int SelectedYear { get; set; }

    [Required(ErrorMessage = "Please select a student")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Please select a subject")]
    public int SubjectId { get; set; }

    [Required(ErrorMessage = "Please select a description")]
    public int DescriptionId { get; set; }

    [Required(ErrorMessage = "Please select a credit")]
    public int CreditId { get; set; }

    [Required(ErrorMessage = "Please select a date")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Today;

    public string? Comment { get; set; }
}

