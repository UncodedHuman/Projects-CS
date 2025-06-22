namespace StudentNoteApp.Pages.ClassNotes.ViewModels;

public class StudentNotesViewModel
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public List<NoteViewModel> Notes { get; set; } = [];
    public decimal TotalNumericCredits { get; set; }
}

public class NoteViewModel
{
    public DateTime Date { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Credit { get; set; } = string.Empty;
    public string CreditValue { get; set; } = string.Empty;
    public bool IsNumericCredit { get; set; }
    public string? Comment { get; set; }
}