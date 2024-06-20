using APIApp.Models.DataModels;
using APIApp.Models.DTOs.Project;
using APIApp.Models.DTOs.User;
using AutoMapper;
namespace APIApp.Profiles;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();

        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectCreateDto, Project>();
        CreateMap<ProjectUpdateDto, Project>();
    }
}