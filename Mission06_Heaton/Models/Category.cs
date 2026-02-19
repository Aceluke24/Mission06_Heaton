namespace Mission06_Heaton.Models;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    [Required]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}