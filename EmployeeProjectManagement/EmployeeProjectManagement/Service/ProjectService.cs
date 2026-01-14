using EmployeeProjectManagement.Interfaces;
using EmployeeProjectManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectManagement.Service
{
    public class ProjectService(AppDbContext context) : IProjectService
    {
        private readonly AppDbContext _context = context;
        public async Task<Project> CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.Employees) 
                .ThenInclude(e => e.Department) 
                .ToListAsync();
        }
    }
}
