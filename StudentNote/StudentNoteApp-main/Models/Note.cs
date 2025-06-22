using System;
using System.ComponentModel.DataAnnotations;

namespace StudentNoteApp.Models;

public class Note : IAuditableEntity
{
    public int Id { get; set; }

    [Required]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [Required]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    [Required]
    public int DescriptionId { get; set; }
    public Description Description { get; set; }

    [Required]
    public int CreditId { get; set; }
    public Credit Credit { get; set; }

    [Required]
    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Today;

    [Display(Name = "Comment")]
    public string? Comment { get; set; }

    public string TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    // Audit Properties - Initialize with default values
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? ModifiedDateTime { get; set; } = DateTime.UtcNow;
    public string ModifiedBy { get; set; } = string.Empty;
}
