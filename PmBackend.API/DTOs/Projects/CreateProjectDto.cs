using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
