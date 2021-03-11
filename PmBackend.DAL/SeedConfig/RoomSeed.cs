using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.SeedConfig
{
    public class RoomSeed : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room { Id = 1, Name = "R11", Capacity = 20 },
                new Room { Id = 2, Name = "R22", Capacity = 50 },
                new Room { Id = 3, Name = "C111", Capacity = 100 },
                new Room { Id = 4, Name = "M44", Capacity = 20 }
            );
        }
    }
}
