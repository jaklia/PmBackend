using PmBackend.BLL.Models.TimeEntries;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface ITimeEntryService
    {
        public Task<TimeEntry> GetTimeEntryAsync(int timeEntryId);

        public Task<IEnumerable<TimeEntry>> GetTimeEntriesAsync();
       // IEnumerable<TimeEntry> GetTimeEntriesForUser(int userId);


        public Task<TimeEntry> InsertTimeEntryAsync(CreateTimeEntryModel newTimeEntry);
        public Task UpdateTimeEntryAsync(int timeEntryId, UpdateTimeEntryModel updatedTimeEntry);
        public Task DeleteTimeEntryAsync(int timeEntryId);

    }
}
