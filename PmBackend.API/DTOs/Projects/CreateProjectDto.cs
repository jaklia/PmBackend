﻿using PmBackend.BLL.Models.Projects;
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

        public CreateProjectModel ToModel()
        {
            return new CreateProjectModel
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
