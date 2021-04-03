using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.BLL.Models.TimeEntries;
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
        public TimeEntryService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task DeleteTimeEntryAsync(int timeEntryId)
        {
            _ctx.TimeEntries.Remove(new TimeEntry { Id = timeEntryId });
            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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


        public async Task<IEnumerable<TimeEntry>> GetTimeEntriesAsync()
        {
            var timeEntries = await _ctx.TimeEntries
                .Include(t => t.Issue)
                .Include(t => t.User)
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
                .Include(t => t.Issue)
                .Include(t => t.User)
                .SingleOrDefaultAsync(t => t.Id == timeEntryId)
                ?? throw new EntityNotFoundException("Timeentry not found");
        }

        public async Task<TimeEntry> InsertTimeEntryAsync(CreateTimeEntryModel newTimeEntry)
        {
            var timeEntry = new TimeEntry
            {
                Date = newTimeEntry.Date,
                Minutes = newTimeEntry.Minutes,
                Description = newTimeEntry.Description,
                IssueId = newTimeEntry.IssueId,
                UserId = newTimeEntry.UserId
            };
            timeEntry.Issue = await _ctx.Issues.FirstOrDefaultAsync(u => u.Id == newTimeEntry.IssueId);
            timeEntry.User = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == newTimeEntry.UserId);

            _ctx.TimeEntries.Add(timeEntry);
            await _ctx.SaveChangesAsync();
            return timeEntry;
        }

        public async Task UpdateTimeEntryAsync(int timeEntryId, UpdateTimeEntryModel updatedTimeEntry)
        {
            var timeEntry = await _ctx.TimeEntries
                .Include(t => t.User)
                .Include(t => t.Issue)
                .FirstOrDefaultAsync(t => t.Id == timeEntryId);
            if (timeEntry == null)
            {
                throw new EntityNotFoundException("Timeentry not found");
            }
            timeEntry.Date = updatedTimeEntry.Date;
            timeEntry.Minutes = updatedTimeEntry.Minutes;
            timeEntry.Description = updatedTimeEntry.Description;

            if (timeEntry.IssueId != updatedTimeEntry.IssueId)
            {
                timeEntry.IssueId = updatedTimeEntry.IssueId;
                timeEntry.Issue = await _ctx.Issues.FirstOrDefaultAsync(u => u.Id == updatedTimeEntry.IssueId);
            }
            if (timeEntry.UserId != updatedTimeEntry.UserId)
            {
                timeEntry.UserId = updatedTimeEntry.UserId;
                timeEntry.User = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == updatedTimeEntry.UserId);
             }
            await _ctx.SaveChangesAsync();
        }

    }
}
