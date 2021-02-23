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
        private readonly PmDbContext ctx;
        public TimeEntryService(PmDbContext ctx) {
            this.ctx = ctx;
        }

        public void DeleteTimeEntry(int timeEntryId)
        {
            ctx.TimeEntries.Remove(new TimeEntry { Id = timeEntryId });
            ctx.SaveChanges();
        }

        public IEnumerable<TimeEntry> GetTimeEntries()
        {
            var timeEntries = ctx.TimeEntries
                .Include(t => t.Issue)
                .ToList();
            return timeEntries;
        }

        public IEnumerable<TimeEntry> GetTimeEntriesForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public TimeEntry GetTimeEntry(int timeEntryId)
        {
            return ctx.TimeEntries
                .Include(t => t.Issue)
                .SingleOrDefault(t => t.Id == timeEntryId);
        }

        public TimeEntry InsertTimeEntry(TimeEntry newTimeEntry)
        {
            ctx.TimeEntries.Add(newTimeEntry);
            ctx.SaveChanges();
            return newTimeEntry;
        }

        public void UpdateTimeEntry(int timeEntryId, TimeEntry updatedTimeEntry)
        {
            updatedTimeEntry.Id = timeEntryId;
            var t = ctx.Attach(updatedTimeEntry);
            t.State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
