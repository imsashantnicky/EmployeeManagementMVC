using EmployeeManagementMVC.Models;
using EmployeeManagementMVC.Models.DTOs;
namespace EmployeeManagementMVC.Mapping;

public static class EmployeeV2Mapper
{
    public static EmployeeV2Response ToResponse(Employee employee)
    {
        return new EmployeeV2Response
        {
            Id = employee.Id,
            Name = new PersonName
            {
                First = employee.FirstName,
                Last = employee.LastName
            },
            Employment = new EmploymentDetails
            {
                Department = employee.Department,
                Salary = employee.Salary
            }
        };
    }
}