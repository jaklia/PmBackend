using PmBackend.DAL.Entities;
using System.Collections.Generic;

namespace PmBackend.BLL.Interfaces
{
    public interface IIssueService
    {
        Issue GetIssue(int issueId);
        IEnumerable<Issue> GetIssues();
        IEnumerable<Issue> GetIssuesForProject(int projectId);

        Issue InsertIssue(Issue newIssue);
        void UpdateIssue(int issueId, Issue updatedIssue);
        void DeleteIssue(int issueId);
    }
}
