namespace APIApp.Repositories.Project;

public interface IProjectRepository
{
    Task<List<Models.DataModels.Project>> GetAllProjects();
    Task<Models.DataModels.Project> GetProjectById(int id);
    Task<int> CreateProject(Models.DataModels.Project project);
    Task<int> UpdateProject(int id, Models.DataModels.Project project);
    Task<int> DeleteProject(int id);
}