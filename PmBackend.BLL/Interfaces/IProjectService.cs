using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Interfaces
{
    public interface IProjectService
    {
        Project GetProject(int id);
        IEnumerable<Project> GetProjects();
        IEnumerable<Project> GetProjectsForUser(int userId);

        Project InsertProject(Project newProject);
        void UpdateProject(int projectId, Project updatedProject);
        void DeleteProject(int projectId);
        
    }
}
