using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
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

        public async Task<Issue> InsertIssueAsync(Issue newIssue)
        {
            _ctx.Issues.Add(newIssue);
            await _ctx.SaveChangesAsync();
            return newIssue;
        }

        public async Task UpdateIssueAsync(int issueId, Issue updatedIssue)
        {
            updatedIssue.Id = issueId;
            var i = _ctx.Attach(updatedIssue);
            i.State = EntityState.Modified;
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.Issues.FirstOrDefaultAsync(i => i.Id == issueId) == null)
                {
                    throw new EntityNotFoundException("Issue not found");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
