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


        public Task<TimeEntry> InsertTimeEntryAsync(TimeEntry newTimeEntry);
        public Task UpdateTimeEntryAsync(int timeEntryId, TimeEntry updatedTimeEntry);
        public Task DeleteTimeEntryAsync(int timeEntryId);

    }
}
