using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;

namespace PmBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService issueService;
        public IssuesController(IIssueService issueService)
        {
            this.issueService = issueService;
        }

        // GET: api/Issues
        [HttpGet]
        public IEnumerable<Issue> Get()
        {
            return issueService.GetIssues();
        }

        // GET: api/Issues/5
        [HttpGet("{id}", Name = "GetIssue")]
        public Issue Get(int id)
        {
            return issueService.GetIssue(id);
        }

        // POST: api/Issues
        [HttpPost]
        public Issue Post([FromBody] Issue value)
        {
            var created = issueService.InsertIssue(value);
            return created;
        }

        // PUT: api/Issues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Issue value)
        {
            issueService.UpdateIssue(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            issueService.DeleteIssue(id);
        }
    }
}
