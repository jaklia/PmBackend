using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PmBackend.BLL.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly PmDbContext _ctx;
        public LeaveService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteLeave(int leaveId)
        {
            _ctx.Leaves.Remove(new Leave { Id = leaveId });
            _ctx.SaveChanges();
        }

        public Leave GetLeave(int leaveId)
        {
            return _ctx.Leaves
                .SingleOrDefault(a => a.Id == leaveId);
        }

        public IEnumerable<Leave> GetLeaves()
        {
            return _ctx.Leaves.ToList();
        }

        public Leave InsertLeave(Leave newLeave)
        {
            _ctx.Leaves.Add(newLeave);
            _ctx.SaveChanges();
            return newLeave;
        }

        public void UpdateLeave(int leaveId, Leave updatedLeave)
        {
            updatedLeave.Id = leaveId;
            var leave = _ctx.Attach(updatedLeave);
            leave.State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
