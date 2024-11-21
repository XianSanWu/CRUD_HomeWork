using CRUD_HomeWork.Models.DBEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_HomeWork.Service.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
