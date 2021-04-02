using PmBackend.BLL.Models.Leaves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Leaves
{
    public class CreateLeaveDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approved { get; set; } = false;

        public int UserId { get; set; }

        public CreateLeaveModel ToModel()
        {
            return new CreateLeaveModel
            {
                StartDate = StartDate,
                EndDate = EndDate,
                UserId = UserId,
                Approved = Approved
            };
        }
    }
}
