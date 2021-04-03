using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.BLL.Models.Issues;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmBackend.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly PmDbContext _ctx;
        public IssueService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task DeleteIssueAsync(int issueId)
        {
            _ctx.Issues.Remove(new Issue { Id = issueId });
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.Issues.FirstOrDefaultAsync(i => i.Id == issueId) == null)
                {
                    throw new EntityNotFoundException("Issue not found");
                } else
                {
                    throw;
                }
            }
        }
        
        public async Task<Issue> GetIssueAsync(int issueId)
        {
            return await _ctx.Issues
                .Include(i => i.Project)
                .Include(i => i.TimeEntries)
                .SingleOrDefaultAsync(i => i.Id == issueId)
                ?? throw new EntityNotFoundException("Issue not found");
        }
       
        public async Task<IEnumerable<Issue>> GetIssuesAsync()
        {
            return await _ctx.Issues
                .Include(i => i.Project)
                .Include(i => i.TimeEntries)
                .ToListAsync();
        }

        public async Task<Issue> InsertIssueAsync(CreateIssueModel newIssue)
        {
            var issue = new Issue
            {
                StartDate = newIssue.StartDate,
                DueDate = newIssue.DueDate,
                Subject = newIssue.Subject,
                Description = newIssue.Description,
                EstimatedHours =newIssue.EstimatedHours,
                ProjectId = newIssue.ProjectId
            };
            issue.Project = await _ctx.Projects.FirstOrDefaultAsync(p => p.Id == issue.ProjectId);
            _ctx.Issues.Add(issue);
            await _ctx.SaveChangesAsync();
            return issue;
        }

        public async Task UpdateIssueAsync(int issueId, UpdateIssueModel updatedIssue)
        {
            var issue = await _ctx.Issues
                .Include(i => i.Project)
                .FirstOrDefaultAsync(i => i.Id == issueId);
            if (issue == null)
            {
                throw new EntityNotFoundException("Issue not found");
            }
            issue.ProjectId = updatedIssue.ProjectId;
            issue.StartDate = updatedIssue.StartDate;
            issue.DueDate = updatedIssue.DueDate;
            issue.EstimatedHours = updatedIssue.EstimatedHours;
            issue.Subject = updatedIssue.Subject;
            issue.Description = updatedIssue.Description;
            await _ctx.SaveChangesAsync();
        }
    }
}
