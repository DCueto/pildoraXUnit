using System.ComponentModel.DataAnnotations;

namespace APIApp.Models.DTOs.Project;

public class ProjectUpdateDto
{
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    [StringLength(400)]
    public string? Description { get; set; }
}