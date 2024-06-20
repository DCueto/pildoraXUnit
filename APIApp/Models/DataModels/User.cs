using System.ComponentModel.DataAnnotations;

namespace APIApp.Models.DataModels;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    public string? About { get; set; }
}