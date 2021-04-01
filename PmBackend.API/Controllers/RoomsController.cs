using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;
using YamlDotNet.Serialization.TypeInspectors;

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
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsAsync()
        {
            var rooms = await _roomService.GetRoomsAsync();
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomAsync(int id)
        {
            try
            {
                var room = await _roomService.GetRoomAsync(id);
                return Ok(room);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoomAsync([FromBody] Room newRoom)
        {
            var room = await _roomService.InsertRoomAsync(newRoom);
            return Ok(room);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoomAsync(int id, [FromBody] Room updatedRoom)
        {
            try
            {
                await _roomService.UpdateRoomAsync(id, updatedRoom);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoomAsync(int id)
        {
            try
            {
                await _roomService.DeleteRoomAsync(id);
                return Ok();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
