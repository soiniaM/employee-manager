using EmployeeManagement.Application.Entities;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync(
      CancellationToken cancellationToken = default);

        Task<Employee?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);
    }
}
