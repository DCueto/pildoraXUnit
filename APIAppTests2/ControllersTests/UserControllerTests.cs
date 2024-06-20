using APIApp.Controllers;
using APIApp.Models.DataModels;
using APIApp.Models.DTOs.User;
using APIApp.Repositories.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace APIAppTests2.ControllersTests;

public class UserControllerTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly IMapper _mapper;
    private readonly UserController _userController;
    
    public UserControllerTests()
    {
        // Repository mock
        _mockUserRepository = new Mock<IUserRepository>();
        
        // Config Automapper for tests
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<UserCreateDto, User>();
        });
        _mapper = config.CreateMapper();
        
        // Controller Instance
        _userController = new UserController(_mockUserRepository.Object, _mapper);
    }

    [Fact]
    public async Task UserController_GetAllUsers_ReturnsOkResultWithListOfUserDto()
    {
        // Arrange
        var users = new List<User>
        {
            new User { UserId = 1, Name = "User1" },
            new User { UserId = 2, Name = "User2" }
        };
        _mockUserRepository.Setup(repo => repo.GetAllUsers()).ReturnsAsync(users);
        
        // Act
        var result = await _userController.GetAllUsers();
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnUsers = Assert.IsType<List<UserDto>>(okResult.Value);
        
        Assert.Equal(2, returnUsers.Count);
    }

    [Fact]
    public async Task UserController_GetUserById_ReturnsOkResultWithUserDto()
    {
        // Arrange
        int userId = 1;
        var user = new User { UserId = userId, Name = "User1" };
        _mockUserRepository.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(user);
        int expectedId = userId;
        string expectedName = "User1";
        
        // Act
        var result = await _userController.GetUserById(userId);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnUser = Assert.IsType<UserDto>(okResult.Value);
        
        Assert.Equal(expectedId, returnUser.UserId);
        Assert.Equal(expectedName, returnUser.Name);
    }

    [Fact]
    public async Task UserController_CreateUser_ReturnsOkResultWithUserDto()
    {
        // Arrange
        var createUserDto = new UserCreateDto { Name = "New User" };
        var user = _mapper.Map<User>(createUserDto);
        _mockUserRepository.Setup(repo => repo.CreateUser(It.IsAny<User>())).ReturnsAsync(user);
        
        // Act
        var result = await _userController.CreateUser(createUserDto);
        
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnUser = Assert.IsType<UserDto>(okResult.Value);
        Assert.Equal("New User", returnUser.Name);
    }
}