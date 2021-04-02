using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PmBackend.DAL.Entities;

namespace PmBackend.API.DTOs.Projects
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IssueCount { get; set; }

        public ProjectDto(Project p)
        {
            Id = p.Id;
            Name = p.Name;
            Description = p.Description;
            IssueCount = p.Issues.Count;
        }

        public Project ToProject()
        {
            return new Project
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }
}
