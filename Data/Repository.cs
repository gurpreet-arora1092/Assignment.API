using System;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.Helpers;
using Assignment.API.Models;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<PagedList<Employee>> GetEmployee(EmployeeParams employeeParams)
        {
            var employee = _context.Employees.OrderByDescending(x => x.FirstName).AsQueryable();

            employee = employee.Where(x => x.EmployeeId != employeeParams.EmployeeId);

            return await PagedList<Employee>.CreateAsync(employee, employeeParams.PageNumber, employeeParams.PageSize);
        }

        public  async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            return employee;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
