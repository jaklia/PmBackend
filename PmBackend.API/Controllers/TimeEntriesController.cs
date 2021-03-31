using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;

namespace PmBackend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntriesController : ControllerBase
    {
        private readonly ITimeEntryService _timeEntryService;
        public TimeEntriesController(ITimeEntryService timeEntryService)
        {
            _timeEntryService = timeEntryService;
        }

        // GET: api/TimeEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeEntry>>> GetTimeEntriesAsync()
        {
            var timeentries = await _timeEntryService.GetTimeEntriesAsync();
            return Ok(timeentries);
        }

        // GET: api/TimeEntries/5
        [HttpGet("{id}", Name = "GetTimeEntry")]
        public async Task<ActionResult<TimeEntry>> GetTimeEntryAsync(int id)
        {
            try
            {
                var timeentry = await _timeEntryService.GetTimeEntryAsync(id);
                return Ok(timeentry);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        // POST: api/TimeEntries
        [HttpPost]
        public async Task<ActionResult<TimeEntry>> CreateTimeEntryAsync([FromBody] TimeEntry value)
        {
            var created = await _timeEntryService.InsertTimeEntryAsync(value);
            return Ok(created);
        }

        // PUT: api/TimeEntries/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTimeEntryAsync(int id, [FromBody] TimeEntry value)
        {
            try
            {
                await _timeEntryService.UpdateTimeEntryAsync(id, value);
                return Ok();
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTimeEntryAsync(int id)
        {
            try
            {
                await _timeEntryService.DeleteTimeEntryAsync(id);
                return Ok();
            } catch (EntityNotFoundException e)
            {

                return NotFound(e.Message);
            }
            
        }
    }
}
