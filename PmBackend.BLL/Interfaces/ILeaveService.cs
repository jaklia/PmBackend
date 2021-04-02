using PmBackend.BLL.Models.Leaves;
using PmBackend.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface ILeaveService
    {
        public Task<Leave> GetLeaveAsync(int leaveId);
        public Task<IEnumerable<Leave>> GetLeavesAsync();

        public Task<Leave> InsertLeaveAsync(CreateLeaveModel newLeave);
        public Task UpdateLeaveAsync(int leaveId, UpdateLeaveModel updatedLeave);
        public Task DeleteLeaveAsync(int leaveId);
    }
}
