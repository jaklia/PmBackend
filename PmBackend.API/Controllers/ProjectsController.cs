using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsAsync()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        // GET: api/Projects/5
        [HttpGet("{id}"/*, Name = "GetProject"*/)]
        public async Task<ActionResult<Project>> GetProjectAsync(int id)
        {
            try
            {
                var project = await _projectService.GetProjectAsync(id);
                return Ok(project);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}/issues"/*, Name = "GetProjectIssues"*/)]
        public async Task<ActionResult<IEnumerable<Issue>>> GetProjectIssuesAsync(int id)
        { 
            try
            {
                var issues = await _projectService.GetProjectIssuesAsync(id);
                return Ok(issues);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProjectAsync([FromBody] Project newProject)
        {
            var created =  await _projectService.InsertProjectAsync(newProject);
            return created;
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(int id, [FromBody] Project project)
        {
            try
            {
                await _projectService.UpdateProjectAsync(id, project);
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
