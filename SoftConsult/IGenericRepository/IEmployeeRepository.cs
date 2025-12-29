using Microsoft.AspNetCore.Mvc.Rendering;
using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.IGenericRepository;

public interface IEmployeeRepository
{
    Task<bool> CreateEmployeeAsync(Employee employeeInformation, string operation= "Create");
    public Task<PagedViewModel> GetEmployee(
        string? officeLocation, 
        int? DepartmentId, 
        int? MaritalStatusId,
        int? SectionId, 
        int? religionId,
        int? jobStatusId,
        int PageNumber,
        int PageSize,
        string sortDirection = "ASC",
        string operation = "GetAll"
        );
    public Task<Employee> GetById(int id , string GetById= "GetById");
    public Task<bool> UpdateEmployeeAsync(Employee model, string GetById="Update");
    public Task<List<SelectListItem>> Fill_Comb(int a);
  }