using PmBackend.BLL.Models.Meetings;
using PmBackend.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface IMeetingService
    {
        public Task<Meeting> GetMeetingAsync(int meetingId);
        public Task<IEnumerable<Meeting>> GetMeetingsAsync();

        public Task<Meeting> InsertMeetingAsync(CreateMeetingModel newMeeting);
        public Task UpdateMeetingAsync(int meetingId, Meeting updatedMeeting);
        public Task DeleteMeetingAsync(int meetingId);
    }
}
