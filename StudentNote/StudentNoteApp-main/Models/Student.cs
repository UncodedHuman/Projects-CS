using System;

namespace StudentNoteApp.Models;

public class Student : IAuditableEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StudentNumber { get; set; }
    public int Year { get; set; }

    // Navigation property for notes
    public ICollection<Note> Notes { get; set; } = new List<Note>();

    // Audit Properties - Initialize with default values
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime? ModifiedDateTime { get; set; } = DateTime.UtcNow;
    public string ModifiedBy { get; set; } = string.Empty;
}
