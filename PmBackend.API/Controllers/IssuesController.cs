using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PmBackend.API.DTOs.Issues;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;

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
        public async Task<ActionResult<IEnumerable<IssueDto>>> GetIssuesAsync()
        {
            var issues = await _issueService.GetIssuesAsync();
            var issuesDto = issues.Select(i => new IssueDto(i));
            return Ok(issuesDto);
        }

        // GET: api/Issues/5
        [HttpGet("{id}", Name = "GetIssue")]
        public async Task<ActionResult<IssueDto>> GetIssueAsync(int id)
        {
            try
            {
                var issue = await _issueService.GetIssueAsync(id);
                var issueDto = new IssueDto(issue);
                return Ok(issueDto);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Issues
        [HttpPost]
        public async Task<ActionResult<IssueDto>> CreateIssueAsync([FromBody] IssueDto value)
        {
            var issue = value.ToIssue();
            var created = await _issueService.InsertIssueAsync(issue);
            var createdDto = new IssueDto(created);
            return createdDto;
        }

        // PUT: api/Issues/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIssueAsync(int id, [FromBody] IssueDto value)
        {
            try
            {
                var issue = value.ToIssue();
                await _issueService.UpdateIssueAsync(id, issue);
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
