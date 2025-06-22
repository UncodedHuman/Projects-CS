using System;
using System.ComponentModel.DataAnnotations;

namespace StudentNoteApp.Models;
public class Subject : IAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Teachs_Subjs> teachers_subjects { get; set; } = new List<Teachs_Subjs>();

    // Navigation property for notes
    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    // Audit Properties - Initialize with default values
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? ModifiedDateTime { get; set; } = DateTime.UtcNow;
    public string ModifiedBy { get; set; } = string.Empty;
}