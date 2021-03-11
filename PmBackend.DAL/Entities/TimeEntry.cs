using System;
using System.ComponentModel.DataAnnotations;

namespace PmBackend.DAL.Entities
{
    public class TimeEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Minutes required")]
        public int Minutes { get; set; }

        [Required(ErrorMessage = "Description is reqired")]
        public string Description { get; set; }

        [Required(ErrorMessage ="IssueId is required")]
        public int IssueId { get; set; }
        public Issue Issue { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
