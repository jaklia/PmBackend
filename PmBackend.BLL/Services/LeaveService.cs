using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.BLL.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly PmDbContext _ctx;
        public LeaveService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task DeleteLeaveAsync(int leaveId)
        {
            _ctx.Leaves.Remove(new Leave { Id = leaveId });
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) 
            {
                if (await _ctx.Leaves.FirstOrDefaultAsync(a => a.Id == leaveId) == null)
                {
                    throw new EntityNotFoundException("Leave not found");
                } else
                {
                    throw;
                }
            }
        }

        public async Task<Leave> GetLeaveAsync(int leaveId)
        {
            return await _ctx.Leaves
                .SingleOrDefaultAsync(a => a.Id == leaveId)
                ?? throw new EntityNotFoundException("Leave not found");
        }

        public async Task<IEnumerable<Leave>> GetLeavesAsync()
        {
            return await _ctx.Leaves.ToListAsync();
        }

        public async Task<Leave> InsertLeaveAsync(Leave newLeave)
        {
            _ctx.Leaves.Add(newLeave);
            await _ctx.SaveChangesAsync();
            return newLeave;
        }

        public async Task UpdateLeaveAsync(int leaveId, Leave updatedLeave)
        {
            updatedLeave.Id = leaveId;
            var leave = _ctx.Attach(updatedLeave);
            leave.State = EntityState.Modified;
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.Leaves.FirstOrDefaultAsync(a => a.Id == leaveId) == null)
                {
                    throw new EntityNotFoundException("Leave not found");
                } else
                {
                    throw;
                }
            }
        }
    }
}
