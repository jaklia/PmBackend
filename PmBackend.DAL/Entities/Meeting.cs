using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PmBackend.DAL.Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public int DurationMinutes { get; set; }

        public string Title { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<UserMeeting> UserMeetings { get; } = new List<UserMeeting>();
    }
}
