using PmBackend.DAL.Entities;
using System.Collections.Generic;

namespace PmBackend.BLL.Interfaces
{
    public interface IRoomService
    {
        Room GetRoom(int roomId);
        IEnumerable<Room> GetRooms();

        Room InsertRoom(Room newRoom);
        void UpdateRoom(int roomId, Room updatedRoom);
        void DeleteRoom(int roomId);
    }
}
