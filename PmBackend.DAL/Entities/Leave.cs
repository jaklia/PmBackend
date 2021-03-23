using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PmBackend.DAL.Entities
{
    
   public class Leave
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approved { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
