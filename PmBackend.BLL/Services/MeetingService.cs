using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PmBackend.BLL.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly PmDbContext _ctx;
        public MeetingService(PmDbContext ctx)
        {
            _ctx = ctx;
        }
        public void DeleteMeeting(int meetingId)
        {
            _ctx.Meeting.Remove(new Meeting { Id = meetingId });
            _ctx.SaveChanges();
        }

        public Meeting GetMeeting(int meetingId)
        {
            return _ctx.Meeting
                .SingleOrDefault(m => m.Id == meetingId);
        }

        public IEnumerable<Meeting> GetMeetings()
        {
            return _ctx.Meeting.ToList();
        }

        public Meeting InsertMeeting(Meeting newMeeting)
        {
           
            _ctx.Meeting.Add(newMeeting);
            _ctx.SaveChanges();
            return newMeeting;
        }

        public void UpdateMeeting(int meetingId, Meeting updatedMeeting)
        {
            updatedMeeting.Id = meetingId;
            var m = _ctx.Attach(updatedMeeting);
            m.State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
