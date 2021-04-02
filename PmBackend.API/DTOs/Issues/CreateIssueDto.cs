using PmBackend.BLL.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Issues
{
    public class CreateIssueDto
    {
        
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedHours { get; set; }
        public int ProjectId { get; set; }



        public CreateIssueModel ToModel()
        {
            return new CreateIssueModel
            {
                Subject = Subject,
                Description = Description,
                StartDate = StartDate,
                DueDate = DueDate,
                EstimatedHours = EstimatedHours,
                ProjectId = ProjectId
            };
        }
    }
}
