using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Models.TimeEntries
{
    public class CreateTimeEntryModel
    {
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }

        public int IssueId { get; set; }
        public int UserId { get; set; }
    }
}
