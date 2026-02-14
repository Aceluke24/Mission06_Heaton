using System.ComponentModel.DataAnnotations;
namespace Mission06_Heaton.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string DirFirstName { get; set; }
    [Required]
    public string DirLastName { get; set; }
    [Required]
    public string Rating { get; set; }
    
    //Not Required
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    [MaxLength(25)]
    public string? Notes { get; set; }
}