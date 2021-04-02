using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.Entities
{
    public class User : IdentityUser<int>
    {


        public ICollection<TimeEntry> TimeEntries { get; } = new List<TimeEntry>();

        public ICollection<UserMeeting> UserMeetings { get; } = new List<UserMeeting>();
        public ICollection<Leave> Leaves { get; } = new List<Leave>();
        
    }
}
