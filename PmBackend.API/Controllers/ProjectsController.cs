using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Project> Get()
        {
            return _projectService.GetProjects();
        }

        // GET: api/Projects/5
        [HttpGet("{id}", Name = "GetProject")]
        public Project Get(int id)
        {
            return _projectService.GetProject(id);
        }

        // POST: api/Projects
        [HttpPost]
        public Project Post([FromBody] Project value)
        {
            var created = _projectService.InsertProject(value);
            return created;
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Project value)
        {
            _projectService.UpdateProject(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projectService.DeleteProject(id);
        }
    }
}
