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
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        // GET: api/Meetings
        [HttpGet]
        public IEnumerable<Meeting> Get()
        {
            return _meetingService.GetMeetings();
        }

        // GET: api/Meetings/5
        [HttpGet("{id}", Name = "GetMeeting")]
        public Meeting Get(int meetingId)
        {
            return _meetingService.GetMeeting(meetingId);
        }

        // POST: api/Meetings
        [HttpPost]
        public Meeting Post([FromBody] Meeting newMeeting)
        {
            return _meetingService.InsertMeeting(newMeeting);
        }

        // PUT: api/Meetings/5
        [HttpPut("{id}")]
        public void Put(int meetingId, [FromBody] Meeting updatedMeeting)
        {
            _meetingService.UpdateMeeting(meetingId, updatedMeeting);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int meetingId)
        {
            _meetingService.DeleteMeeting(meetingId);
        }
    }
}
