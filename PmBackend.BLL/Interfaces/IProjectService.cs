using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface IProjectService
    {
        public Task<Project> GetProjectAsync(int projectId);
        public Task<IEnumerable<Project>> GetProjectsAsync();
      //  Task<IEnumerable<Project>> GetProjectsForUser(int userId);

        public Task<IEnumerable<Issue>> GetProjectIssuesAsync(int projectId);

        public Task<Project> InsertProjectAsync(Project newProject);
        public Task UpdateProjectAsync(int projectId, Project updatedProject);
        public Task DeleteProjectAsync(int projectId);
        
    }
}
