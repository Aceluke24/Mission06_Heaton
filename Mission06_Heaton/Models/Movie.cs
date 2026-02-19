using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Heaton.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    // Foreign key to Category
    [Required]
    public int? CategoryId { get; set; }  
    
    // Navigation property
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    
    [Required]
    public bool Edited { get; set; }
    
    [Required]
    public bool CopiedToPlex { get; set; }
    
    //Not Required
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    public string? LentTo { get; set; }
    
    [MaxLength(25)]
    public string? Notes { get; set; }
    
}