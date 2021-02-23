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
    public class ProjectService : IProjectService
    {
        private readonly PmDbContext ctx;
        public ProjectService(PmDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void DeleteProject(int projectId)
        {
            ctx.Projects.Remove(new Project { Id = projectId });
            ctx.SaveChanges();
        }

        public Project GetProject(int projectId)
        {
            return ctx.Projects
                .Include(p=> p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
        }

        public IEnumerable<Project> GetProjects()
        {
            return ctx.Projects.ToList();
        }

        public IEnumerable<Project> GetProjectsForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Project InsertProject(Project newProject)
        {
            ctx.Projects.Add(newProject);
            ctx.SaveChanges();
            return newProject;
        }

        public void UpdateProject(int projectId, Project updatedProject)
        {
            updatedProject.Id = projectId;
            var p = ctx.Attach(updatedProject);
            p.State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
