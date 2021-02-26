using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.Entities
{
    public class User : IdentityUser<int>
    {

       
        public IEnumerable<TimeEntry> TimeEntries { get; set; }
        
    }
}
