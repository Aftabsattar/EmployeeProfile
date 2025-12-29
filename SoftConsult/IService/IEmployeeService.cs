using Microsoft.AspNetCore.Mvc.Rendering;
using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.IService;

public interface IEmployeeService
{
    public Task<bool> CreateEmployee(EmployeeViewModel employeeViewModel, string Create = "Create");
    public Task<PagedViewModel> GetEmployee(
        string? officeLocation,
        int? MaritalStatusId,
        int? SectionId,
        int? DepartmentId,
        int? religionId,
        int? JobStatusId,
        int PageNumber,
        int PageSize,
        string sortDirection = "ASC",
        string Create = "GetAll");
    public Task<Employee> GetById(int id, string GetById = "GetById");
    public Task<bool> UpdateEmployeeAsync(Employee model, string Create = "Update");
    public Task<List<SelectListItem>> Fill_Comb(int a);
}