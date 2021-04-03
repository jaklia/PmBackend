using PmBackend.BLL.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Rooms
{
    public class CreateRoomDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public CreateRoomModel ToModel()
        {
            return new CreateRoomModel
            {
                Name = Name,
                Capacity = Capacity
            };
        }
    }
}
