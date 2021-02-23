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
        private readonly ITimeEntryService timeEntryService;
        public TimeEntriesController(ITimeEntryService timeEntryService)
        {
            this.timeEntryService = timeEntryService;
        }

        // GET: api/TimeEntries
        [HttpGet]
        public IEnumerable<TimeEntry> Get()
        {
            return timeEntryService.GetTimeEntries();
        }

        // GET: api/TimeEntries/5
        [HttpGet("{id}", Name = "GetTimeEntry")]
        public TimeEntry Get(int id)
        {
            return timeEntryService.GetTimeEntry(id);
        }

        // POST: api/TimeEntries
        [HttpPost]
        public TimeEntry Post([FromBody] TimeEntry value)
        {
            var created = timeEntryService.InsertTimeEntry(value);
            return created;
        }

        // PUT: api/TimeEntries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TimeEntry value)
        {
            timeEntryService.UpdateTimeEntry(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            timeEntryService.DeleteTimeEntry(id);
        }
    }
}
