using System;
using System.ComponentModel.DataAnnotations;
using PmBackend.DAL.Entities;

namespace PmBackend.API.DTOs.TimeEntries
{
    public class TimeEntryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Minutes required")]
        public int Minutes { get; set; }

        [Required(ErrorMessage = "Description is reqired")]
        public string Description { get; set; }

        [Required(ErrorMessage = "IssueId is required")]
        public int IssueId { get; set; }

        [Required(ErrorMessage = "IssueName is required")]
        public String IssueName { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        public TimeEntryDto(TimeEntry t)
        {
            Id = t.Id;
            Date = t.Date;
            Minutes = t.Minutes;
            Description = t.Description;
            IssueId = t.IssueId;
            UserId = t.UserId;
            IssueName = t.Issue.Subject;
            UserName = t.User.UserName;
        }

    }
}
