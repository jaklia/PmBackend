using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PmBackend.API.DTOs.Rooms;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;

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
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomsAsync()
        {
            var rooms = await _roomService.GetRoomsAsync();
            var roomsDto = rooms.Select(r => new RoomDto(r));
            return Ok(roomsDto);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoomAsync(int id)
        {
            try
            {
                var room = await _roomService.GetRoomAsync(id);
                var roomDto = new RoomDto(room);
                return Ok(roomDto);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<RoomDto>> CreateRoomAsync([FromBody] RoomDto newRoomDto)
        {
            var r = newRoomDto.ToRoom();
            var room = await _roomService.InsertRoomAsync(r);
            var roomDto = new RoomDto(room);
            return Ok(roomDto);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoomAsync(int id, [FromBody] RoomDto updatedRoom)
        {
            try
            {
                var r = updatedRoom.ToRoom();
                await _roomService.UpdateRoomAsync(id, r);
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
