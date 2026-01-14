using EmployeeProjectManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Models.Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdProject = await _projectService.CreateProjectAsync(project);
            return CreatedAtAction(nameof(GetAllProjects), new { id = createdProject.ProjectId }, createdProject);
        }
    }
}
