using Microsoft.AspNetCore.Mvc.Rendering;
using SoftConsult.IGenericRepository;
using SoftConsult.IService;
using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeInformation;
    
    public EmployeeService(IEmployeeRepository employeeInformation)
    {
        _employeeInformation = employeeInformation;
    }

    public async Task<bool> CreateEmployee(EmployeeViewModel employeeViewModel, string Create = "Create")
    {
        if (employeeViewModel == null) return false;

        var employeeInformation = new Employee
        {
            EmployeeCode = employeeViewModel.EmployeeCode,
            OPRCode = employeeViewModel.OPRCode,
            SurnameId = employeeViewModel.SurnameId,
            FatherName = employeeViewModel.FatherName,
            FullName = employeeViewModel.FullName,
            ProfilePictureUrl = employeeViewModel.ProfilePictureUrl,
            OfficeLocation= employeeViewModel.OfficeLocation,
            NationalityId = employeeViewModel.NationalityId,
            DateOfBirth = employeeViewModel.DateOfBirth,
            CNIC = employeeViewModel.CNIC,
            IDExpiryDate = employeeViewModel.IDExpiryDate,
            SectionId = employeeViewModel.SectionId,
            DepartmentId= employeeViewModel.DepartmentId,
            DesignationId = employeeViewModel.DesignationId,
            ReligionId = employeeViewModel.ReligionId,
            GenderId = employeeViewModel.GenderId,
            MaritalStatusId = employeeViewModel.MaritalStatusId,
            BloodGroupId = employeeViewModel.BloodGroupId,
            IsHOD = employeeViewModel.IsHOD,
            IsAsstHOD = employeeViewModel.IsAsstHOD,
            LeavePolicyCodeId = employeeViewModel.LeavePolicyCodeId,
            JoiningDate = employeeViewModel.JoiningDate,
            EmploymentStatusId = employeeViewModel.EmploymentStatusId,
            JobStatusId = employeeViewModel.JobStatusId,
            ConfirmationDate = employeeViewModel.ConfirmationDate,
            DateOfLeaving = employeeViewModel.DateOfLeaving,
            Reason = employeeViewModel.Reason,
            GradeId = employeeViewModel.GradeId,
            DepartmentLevelId = employeeViewModel.DepartmentLevelId
        };
        var result = await _employeeInformation.CreateEmployeeAsync(employeeInformation);
        if (result == null) return false;
        return true;
    }

    public async Task<List<SelectListItem>> Fill_Comb(int a)
    {
        return await _employeeInformation.Fill_Comb(a);
    }

    public async Task<Employee?> GetById(int id, string GetById = "GetById")
    {
        var employee = await _employeeInformation.GetById(id,GetById);
        return employee;
    }

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
        string Operation = "GetAll")
    {
        return _employeeInformation.GetEmployee(
            officeLocation, 
            DepartmentId, 
            MaritalStatusId, 
            SectionId, 
            religionId, 
            JobStatusId, 
            PageNumber, 
            PageSize, 
            sortDirection, Operation);
    }

    public async Task<bool> UpdateEmployeeAsync(Employee model, string Operation = "Update")
    {
        var result = await _employeeInformation.UpdateEmployeeAsync(model, Operation);
        return result;
    }
}