using Asp.Versioning;

using EmployeeManagementMVC.Mapping;
using EmployeeManagementMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagementMVC.Controllers.V2;

[ApiController]
[Asp.Versioning.ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/employees")]
public sealed class EmployeesV2Controller : ControllerBase
{
    private readonly IEmployeeRepository _repository;
    public EmployeesV2Controller(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    [ProducesResponseType(
    typeof(IEnumerable<EmployeeManagementMVC.Models.DTOs.EmployeeV2Response>),
    StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var employees = _repository.GetAll();
        return Ok(employees.Select(EmployeeV2Mapper.ToResponse));
    }
    [HttpGet("{id:int}")]
    [ProducesResponseType(
    typeof(EmployeeManagementMVC.Models.DTOs.EmployeeV2Response),
    StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var employee = _repository.GetById(id);
        if (employee is null)
            return NotFound();
        return Ok(EmployeeV2Mapper.ToResponse(employee));
    }
}