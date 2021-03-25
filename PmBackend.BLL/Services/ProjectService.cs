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
        private readonly PmDbContext _ctx;
        public ProjectService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteProject(int projectId)
        {
            _ctx.Projects.Remove(new Project { Id = projectId });
            _ctx.SaveChanges();
        }

        public Project GetProject(int projectId)
        {
            return _ctx.Projects
                .Include(p=> p.Issues)
                .SingleOrDefault(p => p.Id == projectId);
        }

        public IEnumerable<Issue> GetProjectIssues(int projectId)
        {
            return _ctx.Issues.Where(i => i.ProjectId == projectId).ToList();
        }

        public IEnumerable<Project> GetProjects()
        {
            return _ctx.Projects.ToList();
        }

        public IEnumerable<Project> GetProjectsForUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Project InsertProject(Project newProject)
        {
            _ctx.Projects.Add(newProject);
            _ctx.SaveChanges();
            return newProject;
        }

        public void UpdateProject(int projectId, Project updatedProject)
        {
            updatedProject.Id = projectId;
            var p = _ctx.Attach(updatedProject);
            p.State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
