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

    public async Task<string> CreateEmployee(EmployeeViewModel employeeViewModel)
    {
        if (employeeViewModel == null) return "Invalid employee data.";

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
        if (result) return "Employee created successfully.";
        return "Failed to create employee.";
    }

    public Task<Employee> GetById(int id)
    {
        return  _employeeInformation.GetById(id);
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
        string sortDirection = "ASC")
    {
        var employees = _employeeInformation.GetEmployee(
            officeLocation, 
            DepartmentId, 
            MaritalStatusId, 
            SectionId, 
            religionId,
            JobStatusId, 
            PageNumber, 
            PageSize, 
            sortDirection);
        return employees;
    }

    public async Task<bool> UpdateEmployeeAsync(Employee model)
    {
        var result = await _employeeInformation.UpdateEmployeeAsync(model);
        return result;
    }
}