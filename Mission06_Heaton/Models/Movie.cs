using System.ComponentModel.DataAnnotations;
namespace Mission06_Heaton.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    [Required]
    public string CategoryId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public string Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    [Required]
    public bool? Edited { get; set; }
    [Required]
    public bool CopiedToPlex { get; set; }
    
    //Not Required
    public string? LentTo { get; set; }
    [MaxLength(25)]
    public string? Notes { get; set; }
}