using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PmBackend.BLL.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly PmDbContext _ctx;
        public TimeEntryService(PmDbContext ctx) {
            _ctx = ctx;
        }

        public void DeleteTimeEntry(int timeEntryId)
        {
            _ctx.TimeEntries.Remove(new TimeEntry { Id = timeEntryId });
            _ctx.SaveChanges();
        }

        public IEnumerable<TimeEntry> GetTimeEntries()
        {
            var timeEntries = _ctx.TimeEntries
                //.Include(t => t.Issue)
                //.Include(t=> t.User)
                .ToList();
            return timeEntries;
        }

        public IEnumerable<TimeEntry> GetTimeEntriesForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public TimeEntry GetTimeEntry(int timeEntryId)
        {
            return _ctx.TimeEntries
                //.Include(t => t.Issue)
                .SingleOrDefault(t => t.Id == timeEntryId);
        }

        public TimeEntry InsertTimeEntry(TimeEntry newTimeEntry)
        {
            _ctx.TimeEntries.Add(newTimeEntry);
            _ctx.SaveChanges();
            return newTimeEntry;
        }

        public void UpdateTimeEntry(int timeEntryId, TimeEntry updatedTimeEntry)
        {
            updatedTimeEntry.Id = timeEntryId;
            var t = _ctx.Attach(updatedTimeEntry);
            t.State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
