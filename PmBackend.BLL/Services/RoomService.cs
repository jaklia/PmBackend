using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PmBackend.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly PmDbContext _ctx;
        public RoomService(PmDbContext ctx)
        {
            _ctx = ctx;
        }
        public void DeleteRoom(int roomId)
        {
            _ctx.Room.Remove(new Room { Id = roomId });
        }

        public Room GetRoom(int roomId)
        {
            return _ctx.Room
                .SingleOrDefault(r => r.Id == roomId);
        }

        public IEnumerable<Room> GetRooms()
        {
            return _ctx.Room.ToList();
        }

        public Room InsertRoom(Room newRoom)
        {
            _ctx.Room.Add(newRoom);
            _ctx.SaveChanges();
            return newRoom;
        }

        public void UpdateRoom(int roomId, Room updatedRoom)
        {
            updatedRoom.Id = roomId;
            var r = _ctx.Attach(updatedRoom);
            r.State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
