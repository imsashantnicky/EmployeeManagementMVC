using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementMVC.Models;

public class Employee
{
    public int Id { get; set; }
    [Required, StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;
    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = string.Empty;
    [Required, StringLength(50)]
    public string Department { get; set; } = string.Empty;
    [Range(0, 10000000)]
    public decimal Salary { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}