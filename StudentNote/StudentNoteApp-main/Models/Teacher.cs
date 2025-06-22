using Microsoft.AspNetCore.Identity;
using System;

namespace StudentNoteApp.Models;

public class Teacher : IdentityUser, IAuditableEntity
{
    public string? id { get; set; }
    public string? FullName { get; set; }
    public bool IsAdmin { get; set; }
    public ICollection<Teachs_Subjs> teachers_subjects { get; set; }

    // Audit Properties
    public DateTime CreatedDateTime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public string ModifiedBy { get; set; }
}
