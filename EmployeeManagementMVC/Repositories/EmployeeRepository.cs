using EmployeeManagementMVC.Controllers;
using EmployeeManagementMVC.Models;
using EmployeeManagementMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagementMVC.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new();
    private int _nextId = 1;
    public EmployeeRepository() => SeedData();
    public IReadOnlyList<Employee> GetAll() =>

    _employees.OrderBy(e => e.Id).ToList();
    public Employee? GetById(int id) =>
    _employees.FirstOrDefault(e => e.Id == id);
    public Employee Create(Employee employee)
    {
        employee.Id = _nextId++;
        _employees.Add(employee);
        return employee;
    }
    public bool Update(Employee employee)
    {
        var existing = GetById(employee.Id);
        if (existing is null) return false;
        existing.FirstName = employee.FirstName;
        existing.LastName = employee.LastName;
        existing.Email = employee.Email;
        existing.Department = employee.Department;
        existing.Salary = employee.Salary;
        return true;
    }
    public bool Delete(int id)
    {
        var employee = GetById(id);
        if (employee is null) return false;
        _employees.Remove(employee);
        return true;
    }
    private void SeedData()
    {
        Create(new Employee
        {
            FirstName = "Aarav",
            LastName = "Sharma",
            Email = "aarav@example.com",
            Department = "IT",
            Salary = 45000
        });
        Create(new Employee
        {
            FirstName = "Priya",
            LastName = "Verma",
            Email = "priya@example.com",
            Department = "HR",
            Salary = 50000
        });
        Create(new Employee
        {
            FirstName = "Rahul",
            LastName = "Patel",
            Email = "rahul@example.com",
            Department = "Finance",
            Salary = 60000
        });
    }
}
