using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PmBackend.API.DTOs.TimeEntries;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;

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
        public async Task<ActionResult<IEnumerable<TimeEntryDto>>> GetTimeEntriesAsync()
        {
            var timeentries = await _timeEntryService.GetTimeEntriesAsync();
            var timeentriesDto = timeentries.Select(t => new TimeEntryDto(t));
            return Ok(timeentriesDto);
        }

        // GET: api/TimeEntries/5
        [HttpGet("{id}", Name = "GetTimeEntry")]
        public async Task<ActionResult<TimeEntryDto>> GetTimeEntryAsync(int id)
        {
            try
            {
                var timeentry = await _timeEntryService.GetTimeEntryAsync(id);
                var timeEntryDto = new TimeEntryDto(timeentry);
                return Ok(timeEntryDto);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        // POST: api/TimeEntries
        [HttpPost]
        public async Task<ActionResult<TimeEntryDto>> CreateTimeEntryAsync([FromBody] CreateTimeEntryDto value)
        {
            var t = value.ToModel();
            var created = await _timeEntryService.InsertTimeEntryAsync(t);
            var createdDto = new TimeEntryDto(created);
            return Ok(createdDto);
        }

        // PUT: api/TimeEntries/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTimeEntryAsync(int id, [FromBody] UpdateTimeEntryDto value)
        {
            try
            {
                var t = value.ToModel(id);
                await _timeEntryService.UpdateTimeEntryAsync(id, t);
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
