namespace APIApp.Repositories.User;

public interface IUserRepository
{
    Task<List<Models.DataModels.User>> GetAllUsers();
    Task<Models.DataModels.User> GetUserById(int id);
    Task<Models.DataModels.User> CreateUser(Models.DataModels.User user);
    Task<int> UpdateUser(int id, Models.DataModels.User user);
    Task<int> DeleteUser(int id);
}