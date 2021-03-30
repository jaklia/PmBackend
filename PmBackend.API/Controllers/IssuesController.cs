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
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;
        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        // GET: api/Issues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssuesAsync()
        {
            var issues = await _issueService.GetIssuesAsync();
            return Ok(issues);
        }

        // GET: api/Issues/5
        [HttpGet("{id}", Name = "GetIssue")]
        public async Task<ActionResult<Issue>> GetIssueAsync(int id)
        {
            try
            {
                var issue = await _issueService.GetIssueAsync(id);
                return Ok(issue);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Issues
        [HttpPost]
        public async Task<ActionResult<Issue>> CreateIssueAsync([FromBody] Issue value)
        {
            var created = await _issueService.InsertIssueAsync(value);
            return created;
        }

        // PUT: api/Issues/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIssueAsync(int id, [FromBody] Issue value)
        {
            try
            {
                await _issueService.UpdateIssueAsync(id, value);
                return Ok();
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIssueAsync(int id)
        {
            try
            {
                await _issueService.DeleteIssueAsync(id);
                return Ok();
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
