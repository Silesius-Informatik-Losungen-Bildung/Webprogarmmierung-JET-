using System;
using System.ComponentModel.DataAnnotations;

public class Feedback
{
    public int Id { get; set; }

    [Required(ErrorMessage = nameof(Name) + " ist erforderlich.")]
    [StringLength(30)]
    public string Name { get; set; }

    [Required(ErrorMessage = nameof(Message) + " ist erforderlich.")]
    [StringLength(200)]
    public string Message { get; set; }

    public DateTime SubmittedAt { get; set; } = DateTime.Now;
}