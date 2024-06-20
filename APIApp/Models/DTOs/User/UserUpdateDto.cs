using System.ComponentModel.DataAnnotations;

namespace APIApp.Models.DTOs.User;

public class UserUpdateDto
{
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    public string? About { get; set; }
}