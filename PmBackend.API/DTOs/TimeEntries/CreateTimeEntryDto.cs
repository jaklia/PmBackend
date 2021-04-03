using PmBackend.BLL.Models.TimeEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PmBackend.API.DTOs.TimeEntries
{
    public class CreateTimeEntryDto
    {
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Description { get; set; }

        public int IssueId { get; set; }
        public int UserId { get; set; }

        public CreateTimeEntryModel ToModel()
        {
            return new CreateTimeEntryModel
            {
                Date = Date,
                Minutes = Minutes,
                Description = Description,
                IssueId = IssueId,
                UserId = UserId
            };
        }
    }
}
