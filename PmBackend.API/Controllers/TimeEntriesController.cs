using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;

namespace PmBackend.API.Controllers
{
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
        public IEnumerable<TimeEntry> Get()
        {
            return _timeEntryService.GetTimeEntries();
        }

        // GET: api/TimeEntries/5
        [HttpGet("{id}", Name = "GetTimeEntry")]
        public TimeEntry Get(int id)
        {
            return _timeEntryService.GetTimeEntry(id);
        }

        // POST: api/TimeEntries
        [HttpPost]
        public TimeEntry Post([FromBody] TimeEntry value)
        {
            var created = _timeEntryService.InsertTimeEntry(value);
            return created;
        }

        // PUT: api/TimeEntries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TimeEntry value)
        {
            _timeEntryService.UpdateTimeEntry(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _timeEntryService.DeleteTimeEntry(id);
        }
    }
}
