using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.BLL.Models.Rooms;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly PmDbContext _ctx;
        public RoomService(PmDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task DeleteRoomAsync(int roomId)
        {
            _ctx.Rooms.Remove(new Room { Id = roomId });
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.Rooms.FirstOrDefaultAsync(r => r.Id == roomId) == null)
                {
                    throw new EntityNotFoundException("Room not found");
                } else
                {
                    throw;
                }
            }
        }

        public async Task<Room> GetRoomAsync(int roomId)
        {
            return await _ctx.Rooms
                .SingleOrDefaultAsync(r => r.Id == roomId)
                ?? throw new EntityNotFoundException("Room not found");
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _ctx.Rooms.ToListAsync();
        }

        public async Task<Room> InsertRoomAsync(CreateRoomModel newRoom)
        {
            var room = new Room
            {
                Name = newRoom.Name,
                Capacity  = newRoom.Capacity
            };
            _ctx.Rooms.Add(room);
            await _ctx.SaveChangesAsync();
            return room;
        }

        public async Task UpdateRoomAsync(int roomId, UpdateRoomModel updatedRoom)
        {
            var room = await _ctx.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);
            if (room == null)
            {
                throw new EntityNotFoundException("Room not found");
            }
            room.Name = updatedRoom.Name;
            room.Capacity = updatedRoom.Capacity;
            await _ctx.SaveChangesAsync();

           
        }
    }
}
