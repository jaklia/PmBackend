using PmBackend.API.DTOs.Rooms;
using PmBackend.API.DTOs.Users;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Meetings
{
    public class MeetingDetailsDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public RoomDto Room { get; set; }
        public ICollection<UserDto> UserMeetings { get; set; }

        public MeetingDetailsDto(Meeting meeting)
        {
            Id = meeting.Id;
            StartDate = meeting.StartDate;
            EndDate = meeting.EndDate;
            Title = meeting.Title;
            Room = new RoomDto(meeting.Room);
        }

        public Meeting ToMeeting()
        {
            return new Meeting
            {
                Id = Id,
                StartDate = StartDate,
                EndDate = EndDate,
                Title = Title,
                RoomId = Room.Id

            };
        }
    }
}
