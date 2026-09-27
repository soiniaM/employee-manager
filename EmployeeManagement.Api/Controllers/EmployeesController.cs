using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // GET: /api/employees
    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAll(
        CancellationToken cancellationToken)
    {
        var employees = await _employeeService.GetAllAsync(
            cancellationToken);

        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployeeDto>> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetByIdAsync(
            id,
            cancellationToken);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }
}