using PmBackend.BLL.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Projects
{
    public class UpdateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public UpdateProjectModel ToModel(int projectId)
        {
            return new UpdateProjectModel
            {
                Id = projectId,
                Name = Name,
                Description = Description
            };
        }
    }
}
