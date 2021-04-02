using PmBackend.API.DTOs.Rooms;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Meetings
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }

        //public int RoomId { get; set; }
        public RoomDto Room { get; set; }
        public ICollection<int> UserIds { get; set; }


        public MeetingDto(Meeting meeting)
        {
            Id = meeting.Id;
            StartDate = meeting.StartDate;
            EndDate = meeting.EndDate;
            Title = meeting.Title;
            //RoomId = meeting.RoomId;
            Room = new RoomDto(meeting.Room);
            UserIds = meeting.UserMeetings.Select(um => um.UserId).ToList();
        }
    }
}
