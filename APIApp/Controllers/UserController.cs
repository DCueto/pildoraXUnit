using APIApp.Models.DataModels;
using APIApp.Models.DTOs.User;
using APIApp.Repositories.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserCreateDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var userCreated = await _userRepository.CreateUser(user);
            var userCreatedDto = _mapper.Map<UserDto>(userCreated);
            return Ok(userCreatedDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UserUpdateDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            await _userRepository.UpdateUser(id, user);
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            return Ok(user);
        }

    }
}
