using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.SeedConfig
{
    public class IssueSeed : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasData(
                new Issue { Id = 1, Subject = "Sample Issue 1", ProjectId = 1 },
                new Issue { Id = 2, Subject = "Sample Issue 2", ProjectId = 1 }
            );
        }
    }
}
