using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.Entities
{
    public class UserMeeting
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
