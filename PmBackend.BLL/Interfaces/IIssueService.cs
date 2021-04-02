using PmBackend.BLL.Models.Issues;
using PmBackend.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface IIssueService
    {
        public Task<Issue> GetIssueAsync(int issueId);
        public Task<IEnumerable<Issue>> GetIssuesAsync();
       // IEnumerable<Issue> GetIssuesForProject(int projectId);

        public Task<Issue> InsertIssueAsync(CreateIssueModel newIssue);
        public Task UpdateIssueAsync(int issueId, UpdateIssueModel updatedIssue);
        public Task DeleteIssueAsync(int issueId);
    }
}
