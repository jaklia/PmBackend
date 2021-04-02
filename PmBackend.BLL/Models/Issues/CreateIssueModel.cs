using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Models.Issues
{
    public class CreateIssueModel
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedHours { get; set; }
        public int ProjectId { get; set; }

    }
}
