using System;


namespace PmBackend.DAL.Entities
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }

        public int IssueId { get; set; }
        public Issue Issue { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
