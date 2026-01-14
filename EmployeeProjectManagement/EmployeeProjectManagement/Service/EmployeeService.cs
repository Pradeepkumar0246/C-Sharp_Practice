using EmployeeProjectManagement.Interfaces;
using EmployeeProjectManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectManagement.Service
{
    public class EmployeeService(AppDbContext context) : IEmployeeService
    {
        private readonly AppDbContext _context = context;
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Projects)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Projects)
                .ToListAsync();
        }
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.DepartmentId = employee.DepartmentId;
            employee.Projects = employee.Projects;
            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        //internal async Task GetEmployeeById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
