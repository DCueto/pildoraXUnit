using System.ComponentModel.DataAnnotations;

namespace APIApp.Models.DataModels;

public class Project
{
    [Key]
    public int ProjectId { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    [StringLength(400)]
    public string? Description { get; set; }
}