using APIApp.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace APIApp.Data;

public class AppDbContext(DbContextOptions options) : DbContext( options )
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
}