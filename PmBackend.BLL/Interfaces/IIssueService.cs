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

        public Task<Issue> InsertIssueAsync(Issue newIssue);
        public Task UpdateIssueAsync(int issueId, Issue updatedIssue);
        public Task DeleteIssueAsync(int issueId);
    }
}
