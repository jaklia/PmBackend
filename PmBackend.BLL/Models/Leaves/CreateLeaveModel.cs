using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Models.Leaves
{
    public class CreateLeaveModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approved { get; set; } = false;

        public int UserId { get; set; }
    }
}
