using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;

namespace PmBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return _roomService.GetRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "GetRoom")]
        public Room Get(int roomId)
        {
            return _roomService.GetRoom(roomId);
        }

        // POST: api/Rooms
        [HttpPost]
        public Room Post([FromBody] Room newRoom)
        {
            return _roomService.InsertRoom(newRoom);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public void Put(int roomId, [FromBody] Room updatedRoom)
        {
            _roomService.UpdateRoom(roomId, updatedRoom);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int roomId)
        {
            _roomService.DeleteRoom(roomId);
        }
    }
}
