using PmBackend.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface IRoomService
    {
        public Task<Room> GetRoomAsync(int roomId);
        public Task<IEnumerable<Room>> GetRoomsAsync();

        public Task<Room> InsertRoomAsync(Room newRoom);
        public Task UpdateRoomAsync(int roomId, Room updatedRoom);
        public Task DeleteRoomAsync(int roomId);
    }
}
