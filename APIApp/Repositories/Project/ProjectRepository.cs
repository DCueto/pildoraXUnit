using APIApp.Data;
using Microsoft.EntityFrameworkCore;

namespace APIApp.Repositories.Project;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Models.DataModels.Project>> GetAllProjects()
    {
        var projects = await _context.Projects.ToListAsync();
        return projects;
    }

    public async Task<Models.DataModels.Project> GetProjectById(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        return project!;
    }

    public async Task<int> CreateProject(Models.DataModels.Project project)
    {
        _context.Add(project);
        await _context.SaveChangesAsync();

        return project.ProjectId;
    }

    public async Task<int> UpdateProject(int id, Models.DataModels.Project project)
    {
        var existingProject = await _context.Projects.FindAsync(id);
        if (existingProject == null)
            return 0;

        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
      
        return project.ProjectId;
    }

    public async Task<int> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
            return 0;

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return project.ProjectId;
    }
}