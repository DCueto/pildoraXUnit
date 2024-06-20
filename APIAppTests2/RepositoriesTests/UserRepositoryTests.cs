using APIApp.Data;
using APIApp.Models.DataModels;
using APIApp.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace APIAppTests2.RepositoriesTests;

public class UserRepositoryTests
{
    private async Task<AppDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new AppDbContext(options);
        databaseContext.Database.EnsureCreated();

        if (await databaseContext.Users.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.Users.Add(
                    new User()
                    {
                        Name = "Pepito De Los Palotes"
                    }
                );
                await databaseContext.SaveChangesAsync();
            }
            
        }
        
        return databaseContext;
    }

    [Fact]
    public async void UserRepository_GetUserById_ReturnUserWithName()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var userRepository = new UserRepository(dbContext);
        string expectedNameValue = "Pepito De Los Palotes";
        int userId = 1;

        // Act
        var user = await userRepository.GetUserById(userId);

        // Assert
        Assert.NotNull(user);
        Assert.IsType<User>(user);
        Assert.Equal(expectedNameValue, user.Name);
    }

    [Fact]
    public async void User_CreateUser_CreatesUserAndReturnsUserWithId()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var userRepository = new UserRepository(dbContext);
        int userId = 12;
        var user = new User { UserId = userId, Name = "Usuario Random" };
        int expectedId = userId;

        // Act
        var userCreated = await userRepository.CreateUser(user);
        await dbContext.SaveChangesAsync();

        // Assert
        Assert.IsType<User>(userCreated);
        Assert.Equal(expectedId, userCreated.UserId);
    }
}