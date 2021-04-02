using PmBackend.BLL.Models.Meetings;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Meetings
{
    public class CreateMeetingDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public int RoomId { get; set; }
        public ICollection<int> UserIds { get; set; }


        public CreateMeetingModel ToMeetingModel()
        {
            return new CreateMeetingModel
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Title = Title,
                RoomId = RoomId,
                UserIds =  new List<int> (UserIds)
            };
        }
    }
}
