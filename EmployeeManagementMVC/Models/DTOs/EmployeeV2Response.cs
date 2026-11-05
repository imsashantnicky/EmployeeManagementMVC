namespace EmployeeManagementMVC.Models.DTOs;

public sealed class EmployeeV2Response
{
    public int Id { get; init; }
    public PersonName Name { get; init; } = new();
    public EmploymentDetails Employment { get; init; } = new();
}
public sealed class PersonName
{
    public string First { get; init; } = string.Empty;
    public string Last { get; init; } = string.Empty;
}
public sealed class EmploymentDetails
{
    public string Department { get; init; } = string.Empty;
    public decimal Salary { get; init; }
}