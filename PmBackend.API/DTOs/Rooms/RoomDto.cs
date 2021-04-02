using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public RoomDto(Room room)
        {
            Id = room.Id;
            Name = room.Name;
            Capacity = room.Capacity;
        }

        public Room ToRoom()
        {
            return new Room
            {
                Id = Id,
                Name = Name,
                Capacity = Capacity
            };
        }

    }
}
