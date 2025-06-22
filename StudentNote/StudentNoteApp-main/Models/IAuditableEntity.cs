using System;

namespace StudentNoteApp.Models;

public interface IAuditableEntity
{
    DateTime CreatedDateTime { get; set; }
    string CreatedBy { get; set; }
    DateTime? ModifiedDateTime { get; set; }
    string ModifiedBy { get; set; }
}