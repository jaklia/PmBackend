using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.API.DTOs.Meetings;
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
        public async Task<ActionResult<IEnumerable<MeetingDto>>> GetMeetingsAsync()
        {
            var meetings = await _meetingService.GetMeetingsAsync();
            var meetingsDto = meetings.Select(m => new MeetingDto(m));
            return Ok(meetingsDto);
        }

        // GET: api/Meetings/5
        [HttpGet("{id}", Name = "GetMeeting")]
        public async Task<ActionResult<MeetingDto>> GetMeetingAsync(int id)
        {
            try
            {
                var meeting = await _meetingService.GetMeetingAsync(id);
                var meetingDto = new MeetingDto(meeting);
                return Ok(meetingDto);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Meetings
        [HttpPost]
        public async Task<ActionResult<MeetingDto>> CreateMeetingAsync([FromBody] CreateMeetingDto newMeeting)
        {
            var m = newMeeting.ToMeetingModel();
            var meeting = await _meetingService.InsertMeetingAsync(m);
            // this puts "/api/meeting/{id}"  in the location header 

            //return Created(
            //    HttpContext.Request.Path + "/" + meeting.Id.ToString(),
            //    meeting
            //);
            var meetingDto = new MeetingDto(meeting);
            return CreatedAtAction("GetMeeting", new { id = meeting.Id }, meetingDto);

        }

        // PUT: api/Meetings/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMeetingAsync(int id, [FromBody] MeetingDto updatedMeeting)
        {
            try
            {
                var m = updatedMeeting.ToMeeting();
                await _meetingService.UpdateMeetingAsync(id, m);
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
