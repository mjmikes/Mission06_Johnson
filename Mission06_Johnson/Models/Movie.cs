using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Johnson.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [Required(ErrorMessage = "Title is required")] // ✅ Enforces required Title
    public string? Title { get; set; }

    public string? Director { get; set; }

    [Required(ErrorMessage = "Year is required")] // ✅ Year is required
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")] // ✅ Year validation
    public int? Year { get; set; }

    public string? Rating { get; set; }

    [Required(ErrorMessage = "Edited field is required")] // ✅ Edited is required
    public bool? Edited { get; set; }

    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "CopiedToPlex is required")] // ✅ CopiedToPlex is required
    public bool? CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    
}