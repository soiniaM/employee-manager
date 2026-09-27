using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
namespace EmployeeManagement.Application.Services;
internal class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmployeeDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var employees = await _repository.GetAllAsync(cancellationToken);

        return employees.Select(employee => new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Department = employee.Department,
            JobTitle = employee.JobTitle
        }).ToList();
    }

        public async Task<EmployeeDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var employee = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        if (employee == null)
        {
            return null;
        }

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Department = employee.Department,
            JobTitle = employee.JobTitle
        };
    }
}