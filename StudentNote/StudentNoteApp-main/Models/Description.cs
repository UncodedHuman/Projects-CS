using System;
using System.ComponentModel.DataAnnotations;

namespace StudentNoteApp.Models;

public class Description : IAuditableEntity
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Description")]
    public string Name { get; set; }

    // Audit Properties
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; } = string.Empty;
}