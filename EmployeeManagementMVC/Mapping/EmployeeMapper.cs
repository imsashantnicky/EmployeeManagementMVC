using EmployeeManagementMVC.Models;
using EmployeeManagementMVC.Models.DTOs;
namespace EmployeeManagementMVC.Mapping;

public static class EmployeeMapper
{
    public static Employee ToEntity(EmployeeCreateRequest request)
    {
        return new Employee
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.Trim(),
            Department = request.Department.Trim(),
            Salary = request.Salary
        };
    }
    public static Employee ToEntity(
        int id,
        EmployeeUpdateRequest request)
    {

        return new Employee
        {
            Id = id,
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.Trim(),
            Department = request.Department.Trim(),
            Salary = request.Salary
        };
}
public static EmployeeResponse ToResponse(Employee employee)
{
    return new EmployeeResponse
    {
        Id = employee.Id,
        FirstName = employee.FirstName,
        LastName = employee.LastName,
        FullName = employee.FullName,
        Email = employee.Email,
        Department = employee.Department,
        Salary = employee.Salary
    };
}
}