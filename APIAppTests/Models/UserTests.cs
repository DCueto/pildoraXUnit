using APIApp.Data;
using APIApp.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace APIAppTests.Models;

public class UserTests
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
    public async void User_GetUserById_ReturnUserWithName()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        string expectedNameValue = "Pepito De Los Palotes"; 

        // Act
        var user = await dbContext.Users.FindAsync(1);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(expectedNameValue, user.Name);
    }

    [Fact]
    public async void User_CreateUser_CreatesUserWithName()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        int userId = 12;
        var user = new User { UserId = userId, Name = "Usuario Random" };
        string expectedUserName = "Usuario Random";

        // Act
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        var userCreated = await dbContext.Users.FindAsync(userId);

        // Assert
        Assert.NotNull(userCreated);
        Assert.Equal(expectedUserName, userCreated.Name);
    }
    
    
}