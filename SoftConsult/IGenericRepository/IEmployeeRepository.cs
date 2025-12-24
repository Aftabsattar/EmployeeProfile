using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.IGenericRepository;

public interface IEmployeeRepository
{
    Task<bool> CreateEmployeeAsync(Employee employeeInformation);
    public Task<PagedViewModel> GetEmployee(
        string? officeLocation, 
        int? DepartmentId, 
        int? MaritalStatusId,
        int? SectionId, 
        int? religionId,
        int? jobStatusId,
        int PageNumber,
        int PageSize,
        string sortDirection = "ASC"
        );
    public Task<Employee> GetById(int id);
    public Task<bool> UpdateEmployeeAsync(Employee model);
}