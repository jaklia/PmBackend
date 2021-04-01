using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
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
            _ctx.Meeting.Remove(new Meeting { Id = meetingId });
            try
            {
                await _ctx.SaveChangesAsync();
            } catch
            {
                if (await _ctx.Meeting.FirstOrDefaultAsync(m => m.Id == meetingId) == null)
                {
                    throw new EntityNotFoundException("Meeting not found");
                } else
                {
                    throw;
                }
            }
        }

        public async Task<Meeting> GetMeetingAsync(int meetingId)
        {
            return await _ctx.Meeting
                .SingleOrDefaultAsync(m => m.Id == meetingId)
                ?? throw new EntityNotFoundException("Meeting not found");
        }

        public async Task<IEnumerable<Meeting>> GetMeetingsAsync()
        {
            return await _ctx.Meeting.ToListAsync();
        }

        public async Task<Meeting> InsertMeetingAsync(Meeting newMeeting)
        {
           
            _ctx.Meeting.Add(newMeeting);
            await _ctx.SaveChangesAsync();
            return newMeeting;
        }

        public async Task UpdateMeetingAsync(int meetingId, Meeting updatedMeeting)
        {
            updatedMeeting.Id = meetingId;
            var m = _ctx.Attach(updatedMeeting);
            m.State = EntityState.Modified;
            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch
            {
                if (await _ctx.Meeting.FirstOrDefaultAsync(m => m.Id == meetingId) == null)
                {
                    throw new EntityNotFoundException("Meeting not found");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
