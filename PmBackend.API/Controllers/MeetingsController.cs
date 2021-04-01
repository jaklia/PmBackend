using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Exceptions;
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
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetingsAsync()
        {
            var meetings = await _meetingService.GetMeetingsAsync();
            return Ok(meetings);
        }

        // GET: api/Meetings/5
        [HttpGet("{id}", Name = "GetMeeting")]
        public async Task<ActionResult<Meeting>> GetMeetingAsync(int id)
        {
            try
            {
                var meeting = await _meetingService.GetMeetingAsync(id);
                return Ok(meeting);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Meetings
        [HttpPost]
        public async Task<ActionResult<Meeting>> CreateMeetingAsync([FromBody] Meeting newMeeting)
        {
            var meeting = await _meetingService.InsertMeetingAsync(newMeeting);
            // this puts "/api/meeting/{id}"  in the location header 

            //return Created(
            //    HttpContext.Request.Path + "/" + meeting.Id.ToString(),
            //    meeting
            //);
            return CreatedAtAction("GetMeeting", new { id = meeting.Id }, meeting);

        }

        // PUT: api/Meetings/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMeetingAsync(int id, [FromBody] Meeting updatedMeeting)
        {
            try
            {
                await _meetingService.UpdateMeetingAsync(id, updatedMeeting);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMeetingAsync(int id)
        {
            try
            {
                await _meetingService.DeleteMeetingAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
