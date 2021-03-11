using PmBackend.DAL.Entities;
using System.Collections.Generic;

namespace PmBackend.BLL.Interfaces
{
    public interface ILeaveService
    {
        Leave GetLeave(int leaveId);
        IEnumerable<Leave> GetLeaves();

        Leave InsertLeave(Leave newLeave);
        void UpdateLeave(int leaveId, Leave updatedLeave);
        void DeleteLeave(int leaveId);
    }
}
