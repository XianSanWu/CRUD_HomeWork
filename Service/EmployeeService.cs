using CRUD_HomeWork.Models.DBEntity;
using CRUD_HomeWork.Repository.Interface;
using CRUD_HomeWork.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_HomeWork.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbRepository _repository;

        public EmployeeService(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync<Employee>();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync<Employee>(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _repository.CreateAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var existing = await _repository.GetByIdAsync<Employee>(employee.EmployeeId);

            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Title = employee.Title;
            existing.HireDate = employee.HireDate;

            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _repository.GetByIdAsync<Employee>(id);
            if (employee != null)
            {
                await _repository.DeleteAsync(employee);
            }
        }
    }
}
