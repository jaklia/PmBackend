using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Models.Meetings
{
    public class CreateMeetingModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public int RoomId { get; set; }
        public ICollection<int> UserIds { get; set; }


    }
}
