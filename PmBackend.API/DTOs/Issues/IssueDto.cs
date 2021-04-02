using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Issues
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedHours { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public IssueDto(Issue issue)
        {
            Id = issue.Id;
            Subject = issue.Subject;
            Description = issue.Description;
            StartDate = issue.StartDate;
            DueDate = issue.DueDate;
            EstimatedHours = issue.EstimatedHours;
            ProjectId = issue.ProjectId;
            ProjectName = issue.Project.Name;
        }
    }
}
