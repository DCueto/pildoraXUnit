using APIApp.Models.DataModels;
using APIApp.Models.DTOs.Project;
using APIApp.Repositories.Project;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var projects = await _projectRepository.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            var project = await _projectRepository.GetProjectById(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(ProjectCreateDto createProjectDto)
        {
            var project = _mapper.Map<Project>(createProjectDto);
            await _projectRepository.CreateProject(project);
            return Ok(project);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProjectDto>> UpdateProject(int id, ProjectUpdateDto updateProjectDto)
        {
            var project = _mapper.Map<Project>(updateProjectDto);
            await _projectRepository.UpdateProject(id, project);
            return Ok(project);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProjectDto>> DeleteProject(int id)
        {
            var project = await _projectRepository.DeleteProject(id);
            return Ok(project);
        }

    }
}
