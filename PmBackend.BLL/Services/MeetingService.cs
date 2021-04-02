using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.BLL.Models.Meetings;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.BLL.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly PmDbContext _ctx;
        public MeetingService(PmDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task DeleteMeetingAsync(int meetingId)
        {
            _ctx.Meetings.Remove(new Meeting { Id = meetingId });
            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch
            {
                if (await _ctx.Meetings.FirstOrDefaultAsync(m => m.Id == meetingId) == null)
                {
                    throw new EntityNotFoundException("Meeting not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Meeting> GetMeetingAsync(int meetingId)
        {
            return await _ctx.Meetings
                .Include(m => m.Room)
                .Include(m => m.UserMeetings)
                .SingleOrDefaultAsync(m => m.Id == meetingId)
                ?? throw new EntityNotFoundException("Meeting not found");
        }

        public async Task<IEnumerable<Meeting>> GetMeetingsAsync()
        {
            return await _ctx.Meetings
                .Include(m => m.Room)
                .Include(m => m.UserMeetings)
                .ToListAsync();
        }

        public async Task<Meeting> InsertMeetingAsync(CreateMeetingModel newMeeting)
        {
            // this is working  
            // TODO:  other endpoints, separate models in each layer (create/updateModel, + dtos)
            var meeting = new Meeting
            {
                Title = newMeeting.Title,
                StartDate = newMeeting.StartDate,
                EndDate = newMeeting.EndDate,
                RoomId = newMeeting.RoomId
            };
            _ctx.Meetings.Add(meeting);
            meeting.Room = await _ctx.Rooms.FirstOrDefaultAsync(r => r.Id == newMeeting.RoomId);
            foreach (var userId in newMeeting.UserIds)
            {
                _ctx.UserMeetings.Add(
                    new UserMeeting
                    {
                        Meeting = meeting,
                        UserId = userId
                    }
                );
            }
            await _ctx.SaveChangesAsync();
            return meeting;
        }

        public async Task UpdateMeetingAsync(int meetingId, UpdateMeetingModel updatedMeeting)
        {
            var meeting = await _ctx.Meetings
                .Include(m => m.UserMeetings)
                .Include(m => m.Room)
                .FirstOrDefaultAsync(m => m.Id == meetingId);
            meeting.Title = updatedMeeting.Title;
            meeting.StartDate = updatedMeeting.StartDate;
            meeting.EndDate = updatedMeeting.EndDate;
            if (meeting.RoomId != updatedMeeting.RoomId)
            {
                meeting.RoomId = updatedMeeting.RoomId;
                meeting.Room = await _ctx.Rooms.FirstOrDefaultAsync(r => r.Id == updatedMeeting.RoomId);
            }

            var toDelete = meeting.UserMeetings.Where(um => !updatedMeeting.UserIds.Contains(um.UserId));
            var toAdd = updatedMeeting.UserIds
                .Except(meeting.UserMeetings.Select(um => um.UserId))
                .Select(userId=> new UserMeeting { 
                    UserId = userId, 
                    Meeting = meeting 
                });
            _ctx.UserMeetings.RemoveRange(toDelete);
            _ctx.UserMeetings.AddRange(toAdd);
            await _ctx.SaveChangesAsync();
        }
    }
}
