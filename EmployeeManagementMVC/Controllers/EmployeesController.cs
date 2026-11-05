using EmployeeManagementMVC.Mapping;
using EmployeeManagementMVC.Models.DTOs;
using EmployeeManagementMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagementMVC.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _repository;
    public EmployeesController(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public ActionResult<IReadOnlyList<EmployeeResponse>> GetAll()
    {
        var responses = _repository.GetAll()
            .Select(EmployeeMapper.ToResponse)
            .ToList();
        return Ok(responses);
    }
    [HttpGet("{id:int}")]
    public ActionResult<EmployeeResponse> GetById(int id)
    {
        var employee = _repository.GetById(id);
        if (employee is null)
            return NotFound();
        return Ok(EmployeeMapper.ToResponse(employee));
    }
    [HttpPost]
    public ActionResult<EmployeeResponse> Create(
        EmployeeCreateRequest request)
    {
        var entity = EmployeeMapper.ToEntity(request);
        var created = _repository.Create(entity);
        var response = EmployeeMapper.ToResponse(created);
        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            response);
    }


    [HttpPut("{id:int}")]
    public IActionResult Update(
        int id,
        EmployeeUpdateRequest request)
    {
        var existing = _repository.GetById(id);
        if (existing is null)
            return NotFound();
        var entity = EmployeeMapper.ToEntity(id, request);
        var updated = _repository.Update(entity);
        if (!updated)
            return NotFound();
        return NoContent();
    }
        [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _repository.Delete(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}