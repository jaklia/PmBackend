using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.SeedConfig
{
    public class TimeEntrySeed : IEntityTypeConfiguration<TimeEntry>
    {
        public void Configure(EntityTypeBuilder<TimeEntry> builder)
        {
            builder.HasData(
                new TimeEntry { Id = 1, Date = DateTime.Now, Minutes = 2 * 60, IssueId = 1, UserId = 1, Description = "Write specification" },
                new TimeEntry { Id = 2, Date = DateTime.Now, Minutes = 5 * 60, IssueId = 1, UserId = 1, Description = "init project, base navigation system" },
                new TimeEntry { Id = 3, Date = DateTime.Now, Minutes = 10 * 60, IssueId = 2, UserId = 2, Description = "API research" }
            );
        }
    }
}
