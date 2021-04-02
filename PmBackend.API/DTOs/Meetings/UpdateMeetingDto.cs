using System;
using System.Collections.Generic;
using PmBackend.BLL.Models.Meetings;

namespace PmBackend.API.DTOs.Meetings
{
    public class UpdateMeetingDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public int RoomId { get; set; }
        public ICollection<int> UserIds { get; set; }


        public UpdateMeetingModel ToModel(int meetingId)
        {
            return new UpdateMeetingModel
            {
                Id = meetingId, 
                StartDate = StartDate,
                EndDate = EndDate,
                Title = Title,
                RoomId = RoomId,
                UserIds = new List<int>(UserIds)
            };
        }
    }
}
