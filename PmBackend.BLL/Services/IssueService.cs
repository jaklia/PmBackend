using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PmBackend.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly PmDbContext ctx;
        public IssueService(PmDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void DeleteIssue(int issueId)
        {
            ctx.Issues.Remove(new Issue { Id = issueId });
            ctx.SaveChanges();
        }

        public Issue GetIssue(int issueId)
        {
            return ctx.Issues
              //  .Include(i => i.Project)
                .SingleOrDefault(i => i.Id == issueId);
        }

        public IEnumerable<Issue> GetIssues()
        {
            return ctx.Issues.ToList();
        }

        public IEnumerable<Issue> GetIssuesForProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public Issue InsertIssue(Issue newIssue)
        {
            ctx.Issues.Add(newIssue);
            ctx.SaveChanges();
            return newIssue;
        }

        public void UpdateIssue(int issueId, Issue updatedIssue)
        {
            updatedIssue.Id = issueId;
            var i = ctx.Attach(updatedIssue);
            i.State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
