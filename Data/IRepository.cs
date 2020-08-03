using System;
using System.Threading.Tasks;
using Assignment.API.Helpers;
using Assignment.API.Models;

namespace Assignment.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<Employee>> GetEmployee(EmployeeParams employeeParams);
        Task<Employee> GetEmployee(int id);
    }
}
