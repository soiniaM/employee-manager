using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<EmployeeDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);
}