using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.IService;

public interface IEmployeeService
{
    public Task<string> CreateEmployee(EmployeeViewModel employeeViewModel);
    public Task<PagedViewModel> GetEmployee(
        string? officeLocation, 
        int? MaritalStatusId, 
        int? SectionId, 
        int? DepartmentId, 
        int? religionId,
        int? JobStatusId,
        int PageNumber,
        int PageSize,
        string sortDirection = "ASC");
    public Task<Employee> GetById(int id);
    public Task<bool> UpdateEmployeeAsync(Employee model);
}