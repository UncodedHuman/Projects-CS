using System;
using System.ComponentModel.DataAnnotations;

namespace StudentNoteApp.Models;

public class Credit : IAuditableEntity
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Credit Value")]
    public string Value { get; set; }

    [Required]
    [Display(Name = "Display Text")]
    public string DisplayText { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }

    public bool IsNumeric { get; set; }

    // Audit Properties
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; } = string.Empty;
}
