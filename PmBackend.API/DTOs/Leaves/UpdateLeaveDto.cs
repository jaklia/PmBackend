using PmBackend.BLL.Models.Leaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Leaves
{
    public class UpdateLeaveDto 
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approved { get; set; } = false;
        public int UserId { get; set; }

        public UpdateLeaveModel ToModel(int leaveId)
        {
            return new UpdateLeaveModel
            {
                Id = leaveId,
                StartDate = StartDate,
                EndDate = EndDate,
                UserId = UserId,
                Approved = Approved
            };
        }
    }
}
