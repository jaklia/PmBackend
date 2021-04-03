using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.BLL.Models.Projects;
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
            // TODO: throw exception when project not exists
            return await _ctx.Issues
                .Include(i => i.Project)
                .Where(i => i.ProjectId == projectId)
                .ToListAsync();
        }

       public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _ctx.Projects.ToListAsync();
        }

        //public IEnumerable<Project> GetProjectsForUser(int userId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Project> InsertProjectAsync(CreateProjectModel newProject)
        {
            var project = new Project
            {
                Name = newProject.Name,
                Description = newProject.Description
            };
            _ctx.Projects.Add(project);
            await _ctx.SaveChangesAsync();
            return project;
        }

        public async Task UpdateProjectAsync(int projectId, UpdateProjectModel updatedProject)
        {
            var project = await _ctx.Projects
                .Include(p => p.Issues)
                .SingleOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
            {
                throw new EntityNotFoundException("Project not found");
            }
            project.Description = updatedProject.Description;
            project.Name = updatedProject.Name;
            await _ctx.SaveChangesAsync();

            // TODO:  ?? update issues here ??? 

        }
    }
}
