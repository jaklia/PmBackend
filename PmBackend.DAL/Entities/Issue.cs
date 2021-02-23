using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.Entities
{
    public class Issue
    {
        
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedHours { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public IEnumerable<TimeEntry> timeEntries { get; }

        // status
        // priority

    }
}
