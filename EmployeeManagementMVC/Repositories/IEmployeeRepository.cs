using EmployeeManagementMVC.Models;
namespace EmployeeManagementMVC.Repositories;

public interface IEmployeeRepository
{
    IReadOnlyList<Employee> GetAll();
    Employee? GetById(int id);
    Employee Create(Employee employee);
    bool Update(Employee employee);
    bool Delete(int id);
}