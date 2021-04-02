using PmBackend.API.DTOs.Users;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.Leaves
{
    public class LeaveDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approved { get; set; }

        public int UserId { get; set; }
        //public UserDto User { get; set; }

        public LeaveDto(Leave leave)
        {
            Id = leave.Id;
            StartDate = leave.StartDate;
            EndDate = leave.EndDate;
            UserId = leave.UserId;
            Approved = leave.Approved;
        }
    }
}
