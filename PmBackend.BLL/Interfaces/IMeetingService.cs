using PmBackend.DAL.Entities;
using System.Collections.Generic;

namespace PmBackend.BLL.Interfaces
{
    public interface IMeetingService
    {
        Meeting GetMeeting(int meetingId);
        IEnumerable<Meeting> GetMeetings();

        Meeting InsertMeeting(Meeting newMeeting);
        void UpdateMeeting(int meetingId, Meeting updatedMeeting);
        void DeleteMeeting(int meetingId);
    }
}
