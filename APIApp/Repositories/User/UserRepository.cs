using APIApp.Data;
using Microsoft.EntityFrameworkCore;

namespace APIApp.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Models.DataModels.User>> GetAllUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<Models.DataModels.User> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user!;
    }

    public async Task<Models.DataModels.User> CreateUser(Models.DataModels.User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<int> UpdateUser(int id, Models.DataModels.User user)
    {
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null)
            return 0;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
      
        return user.UserId;
    }

    public async Task<int> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return 0;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return user.UserId;
    }
}