using CRUD_HomeWork.Models.DBEntity;
using CRUD_HomeWork.Repository.Interface;
using CRUD_HomeWork.Service;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CRUD_HomeWork_Test
{
    public class EmployeeServiceTest
    {
        private readonly Mock<IDbRepository> _mockRepo;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceTest()
        {
            _mockRepo = new Mock<IDbRepository>();
            _employeeService = new EmployeeService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllEmployeesAsync_ReturnsListOfEmployees()
        {
            var mockEmployees = new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe" },
                new Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Smith" }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync<Employee>())
                     .ReturnsAsync(mockEmployees); 

            var result = await _employeeService.GetAllEmployeesAsync();

            Assert.Equal(2, result.Count); 
            Assert.Contains(result, e => e.FirstName == "John");
            Assert.Contains(result, e => e.FirstName == "Jane");
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ReturnsEmployee()
        {
            var mockEmployee = new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe" };
            _mockRepo.Setup(repo => repo.GetByIdAsync<Employee>(It.IsAny<int>())).ReturnsAsync(mockEmployee);

            var result = await _employeeService.GetEmployeeByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }

        [Fact]
        public async Task AddEmployeeAsync_AddsEmployee()
        {
            var newEmployee = new Employee { FirstName = "Alice", LastName = "Johnson" };

            _mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            await _employeeService.AddEmployeeAsync(newEmployee);

            _mockRepo.Verify(repo => repo.CreateAsync(It.Is<Employee>(e => e.FirstName == "Alice" && e.LastName == "Johnson")), Times.Once);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_UpdatesEmployee()
        {
            var existingEmployee = new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe" };
            var updatedEmployee = new Employee { EmployeeId = 1, FirstName = "John", LastName = "Smith" };

            _mockRepo.Setup(repo => repo.GetByIdAsync<Employee>(It.IsAny<int>())).ReturnsAsync(existingEmployee);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            await _employeeService.UpdateEmployeeAsync(updatedEmployee);

            _mockRepo.Verify(repo => repo.UpdateAsync(It.Is<Employee>(e => e.LastName == "Smith")), Times.Once);
        }

        [Fact]
        public async Task DeleteEmployeeAsync_DeletesEmployee()
        {
            var employeeToDelete = new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe" };
            _mockRepo.Setup(repo => repo.GetByIdAsync<Employee>(It.IsAny<object>())).ReturnsAsync(employeeToDelete);
            _mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            await _employeeService.DeleteEmployeeAsync(1);

            _mockRepo.Verify(repo => repo.DeleteAsync(It.Is<Employee>(e => e.EmployeeId == 1)), Times.Once);
        }
    }
}
