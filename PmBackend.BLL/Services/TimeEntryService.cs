using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PmBackend.BLL.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly PmDbContext _ctx;
        public TimeEntryService(PmDbContext ctx) {
            _ctx = ctx;
        }

        public async Task DeleteTimeEntryAsync(int timeEntryId)
        {
            _ctx.TimeEntries.Remove(new TimeEntry { Id = timeEntryId });
            try
            {
                await  _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.TimeEntries.FirstOrDefaultAsync(t=> t.Id == timeEntryId) == null)
                {
                    throw new EntityNotFoundException("Timeentry not found");
                } else
                {
                    throw;
                }
            }
        }
       

        public async Task<IEnumerable<TimeEntry>> GetTimeEntriesAsync()
        {
            var timeEntries = await _ctx.TimeEntries
                //.Include(t => t.Issue)
                //.Include(t=> t.User)
                .ToListAsync();
            return timeEntries;
        }

        //public IEnumerable<TimeEntry> GetTimeEntriesForUser(int userId)
        //{
        //    return _ctx.TimeEntries.Where(t => t.UserId == userId).ToList();
        //}

        public async Task<TimeEntry> GetTimeEntryAsync(int timeEntryId)
        {
            return await _ctx.TimeEntries
                //.Include(t => t.Issue)
                .SingleOrDefaultAsync(t => t.Id == timeEntryId)
                ?? throw new EntityNotFoundException("Timeentry not found");
        }

        public async Task<TimeEntry> InsertTimeEntryAsync(TimeEntry newTimeEntry)
        {
            _ctx.TimeEntries.Add(newTimeEntry);
            await _ctx.SaveChangesAsync();
            return newTimeEntry;
        }

        public async Task UpdateTimeEntryAsync(int timeEntryId, TimeEntry updatedTimeEntry)
        {
            updatedTimeEntry.Id = timeEntryId;
            var t = _ctx.Attach(updatedTimeEntry);
            t.State = EntityState.Modified;
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.TimeEntries.FirstOrDefaultAsync(t => t.Id == timeEntryId) == null)
                {
                    throw new EntityNotFoundException("Timeentry not found");
                }
                else
                {
                    throw;
                }
            }
        }

    }
}
