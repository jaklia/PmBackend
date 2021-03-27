using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PmBackend.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly PmDbContext _ctx;
        public ProjectService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

       
      public async Task DeleteProjectAsync(int projectId)
        {
            _ctx.Projects.Remove(new Project { Id = projectId });
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.Projects.SingleOrDefaultAsync(p => p.Id == projectId) == null)
                {
                    throw new EntityNotFoundException("Project not found");
                } else
                {
                    throw;
                }
            }
        }
        
        public async Task<Project> GetProjectAsync(int projectId)
        {
            return await _ctx.Projects
                .SingleOrDefaultAsync(p => p.Id == projectId)
                ?? throw new EntityNotFoundException("Project not found");
        }

        public async Task<IEnumerable<Issue>> GetProjectIssuesAsync(int projectId)
        {
            return await _ctx.Issues.Where(i => i.ProjectId == projectId).ToListAsync();
        }

       public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _ctx.Projects.ToListAsync();
        }

        //public IEnumerable<Project> GetProjectsForUser(int userId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Project> InsertProjectAsync(Project newProject)
        {
            _ctx.Projects.Add(newProject);
            await _ctx.SaveChangesAsync();
            return newProject;
        }

        public async Task UpdateProjectAsync(int projectId, Project updatedProject)
        {
            updatedProject.Id = projectId;
            var p = _ctx.Attach(updatedProject);
            p.State = EntityState.Modified;
            try
            {
                await _ctx.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (await _ctx.Projects.SingleOrDefaultAsync(p => p.Id == projectId) == null)
                {
                    throw new EntityNotFoundException("Project not found");
                } else 
                {
                    throw;
                }
            }
        }
    }
}
