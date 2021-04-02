using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PmBackend.API.DTOs.Issues;
using PmBackend.API.DTOs.Projects;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;

namespace PmBackend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectsAsync()
        {
            var projects = await _projectService.GetProjectsAsync();
            var projectsDto = projects.Select(p => new ProjectDto(p));
            return Ok(projectsDto);
        }

        // GET: api/Projects/5
        [HttpGet("{id}"/*, Name = "GetProject"*/)]
        public async Task<ActionResult<ProjectDto>> GetProjectAsync(int id)
        {
            try
            {
                var project = await _projectService.GetProjectAsync(id);
                var projectDto = new ProjectDto(project);
                return Ok(projectDto);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}/issues"/*, Name = "GetProjectIssues"*/)]
        public async Task<ActionResult<IEnumerable<IssueDto>>> GetProjectIssuesAsync(int id)
        { 
            try
            {
                var issues = await _projectService.GetProjectIssuesAsync(id);
                var issuesDto = issues.Select(i => new IssueDto(i));
                return Ok(issuesDto);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProjectAsync([FromBody] CreateProjectDto newProject)
        {
            var p = new Project
            {
                Name = newProject.Name,
                Description = newProject.Description
            };
            var created =  await _projectService.InsertProjectAsync(p);

            var createdDto = new ProjectDto(created);
            return Ok(createdDto);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] ProjectDto projectDto)
        {
            try
            {
                await _projectService.UpdateProjectAsync(id, projectDto.ToProject());
                return Ok();
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
