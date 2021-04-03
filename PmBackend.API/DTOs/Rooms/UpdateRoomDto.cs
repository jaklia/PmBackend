﻿using PmBackend.BLL.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Rooms
{
    public class UpdateRoomDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public UpdateRoomModel ToModel(int roomId)
        {
            return new UpdateRoomModel
            {
                Id = roomId,
                Name = Name,
                Capacity = Capacity
            };
        }
    }
}
