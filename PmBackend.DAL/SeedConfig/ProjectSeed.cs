using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.SeedConfig
{
    public class ProjectSeed : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project { Id = 1, Name = "Sample Project 1" },
                new Project { Id = 2, Name = "Sample Project 2" }
            );
        }
    }
}
