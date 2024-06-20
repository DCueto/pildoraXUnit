using System.ComponentModel.DataAnnotations;

namespace APIApp.Models.DTOs.User;

public class UserDto
{
    [Key]
    public int UserId { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    public string? About { get; set; }
}