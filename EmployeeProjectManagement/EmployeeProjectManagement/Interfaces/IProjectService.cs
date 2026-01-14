using EmployeeProjectManagement.Models;
namespace EmployeeProjectManagement.Interfaces
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync(Project project);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
    }
}
