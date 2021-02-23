using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Interfaces
{
    public interface ITimeEntryService
    {
        TimeEntry GetTimeEntry(int timeEntryId);

        IEnumerable<TimeEntry> GetTimeEntries();
        IEnumerable<TimeEntry> GetTimeEntriesForUser(int userId);


        TimeEntry InsertTimeEntry(TimeEntry newTimeEntry);
        void UpdateTimeEntry(int timeEntryId, TimeEntry updatedTimeEntry);
        void DeleteTimeEntry(int timeEntryId);

    }
}
