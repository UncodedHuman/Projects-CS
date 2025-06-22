using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentNoteApp.Models;

public class Teachs_Subjs
{
    [Column("teacher_id")]
    public string TeacherId { get; set; }

    [Column("subject_id")]
    public int SubjectId { get; set; }

    public Teacher Teacher { get; set; }
    public Subject Subject { get; set; }
}