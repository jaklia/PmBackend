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
        private readonly PmDbContext _ctx;
        public IssueService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteIssue(int issueId)
        {
            _ctx.Issues.Remove(new Issue { Id = issueId });
            _ctx.SaveChanges();
        }

        public Issue GetIssue(int issueId)
        {
            return _ctx.Issues
              //  .Include(i => i.Project)
                .SingleOrDefault(i => i.Id == issueId);
        }

        public IEnumerable<Issue> GetIssues()
        {
            return _ctx.Issues.ToList();
        }

        //public IEnumerable<Issue> GetIssuesForProject(int projectId)
        //{
        //    throw new NotImplementedException();
        //}

        public Issue InsertIssue(Issue newIssue)
        {
            _ctx.Issues.Add(newIssue);
            _ctx.SaveChanges();
            return newIssue;
        }

        public void UpdateIssue(int issueId, Issue updatedIssue)
        {
            updatedIssue.Id = issueId;
            var i = _ctx.Attach(updatedIssue);
            i.State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
