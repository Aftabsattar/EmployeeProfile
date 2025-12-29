using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftConsult.Context;
using SoftConsult.IService;
using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeInformation;
    public EmployeeController(IEmployeeService employeeInformation)
    {
        _employeeInformation = employeeInformation;
    }

    [HttpGet]
    public async Task<IActionResult> CreateEmployee()
    {
        var vm = new EmployeeViewModel
        {
            SurNameList = await _employeeInformation.Fill_Comb(14),
            NationalityList = await _employeeInformation.Fill_Comb(11),
            SectionList = await _employeeInformation.Fill_Comb(13),
            DepartmentLevelList = await _employeeInformation.Fill_Comb(2),
            LevelPolicyList = await _employeeInformation.Fill_Comb(9),
            ReligionList = await _employeeInformation.Fill_Comb(12),
            GenderList = await _employeeInformation.Fill_Comb(6),
            MaritalStatusList = await _employeeInformation.Fill_Comb(10),
            BloodGroupList = await _employeeInformation.Fill_Comb(1),
            DesignationsList = await _employeeInformation.Fill_Comb(4),
            DepartmentList = await _employeeInformation.Fill_Comb(3),
            Grades = await _employeeInformation.Fill_Comb(7),
            EmploymentStatusList = await _employeeInformation.Fill_Comb(5),
            JobStatusList = await _employeeInformation.Fill_Comb(8)
        };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(EmployeeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.SurNameList = await _employeeInformation.Fill_Comb(14);
            model.NationalityList = await _employeeInformation.Fill_Comb(11);
            model.SectionList = await _employeeInformation.Fill_Comb(13);
            model.DepartmentLevelList = await _employeeInformation.Fill_Comb(2);
            model.LevelPolicyList = await _employeeInformation.Fill_Comb(9);
            model.ReligionList = await _employeeInformation.Fill_Comb(12);
            model.GenderList = await _employeeInformation.Fill_Comb(6);
            model.MaritalStatusList = await _employeeInformation.Fill_Comb(10);
            model.BloodGroupList = await _employeeInformation.Fill_Comb(1);
            model.DesignationsList = await _employeeInformation.Fill_Comb(4);
            model.DepartmentList = await _employeeInformation.Fill_Comb(3);
            model.Grades = await _employeeInformation.Fill_Comb(7);
            model.EmploymentStatusList = await _employeeInformation.Fill_Comb(5);
            model.JobStatusList = await _employeeInformation.Fill_Comb(8);
            return View(model);
        }

        var result = await _employeeInformation.GetById(model.Id);

        if (result != null && result.Id == model.Id)
        {
            // Update existing
            result.Id = model.Id;
            result.EmployeeCode = model.EmployeeCode;
            result.FullName = model.FullName;
            result.FatherName = model.FatherName;
            result.ProfilePictureUrl = model.ProfilePictureUrl;
            result.OPRCode = model.OPRCode;
            result.DateOfBirth = model.DateOfBirth;
            result.DateOfLeaving = model.DateOfLeaving;
            result.ConfirmationDate = model.ConfirmationDate;
            result.IDExpiryDate = model.IDExpiryDate;
            result.JoiningDate = model.JoiningDate;
            result.CNIC = model.CNIC;
            result.Reason = model.Reason;
            result.IsAsstHOD = model.IsAsstHOD;
            result.IsHOD = model.IsHOD;
            var updateResult = await _employeeInformation.UpdateEmployeeAsync(result);

            TempData["Success"] = "Employee updated successfully";
            // PRG to avoid returning view with missing lists
            return RedirectToAction("EmployeeList");
        }
        else
        {
            // Create new
            var createResult = await _employeeInformation.CreateEmployee(model);
            TempData["Success"] = "Employee added successfully";
            return RedirectToAction("EmployeeList");
        }
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeList(
        string? officeLocation,
        int? MaritalStatusId,
        int? SectionId,
        int? DepartmentId,
        int? religionId,
        int? JobStatusId,
        int PageNumber =1,
        int PageSize =30,
        string sortDirection = "ASC"
        )
    {
        if (PageNumber <1) PageNumber =1;
        var employees = await _employeeInformation.GetEmployee(
            officeLocation,
            MaritalStatusId,
            SectionId,
            DepartmentId,
            religionId,
            JobStatusId,
            PageNumber,
            PageSize,
            sortDirection);
        ViewBag.ReligionList = await _employeeInformation.Fill_Comb(12);
        ViewBag.SelectedReligionId = religionId;
        ViewBag.MaritalStatusList = await _employeeInformation.Fill_Comb(10);
        ViewBag.MaritalStatusSelectedId = MaritalStatusId;
        ViewBag.DepartmentList = await _employeeInformation.Fill_Comb(3);
        ViewBag.DepartmentId = DepartmentId;
        ViewBag.SectionList = await _employeeInformation.Fill_Comb(13);
        ViewBag.SectionId = SectionId;
        ViewBag.JobStatusList = await _employeeInformation.Fill_Comb(8);
        ViewBag.JobStatusSelectedId = JobStatusId;
        if (employees == null)
        {
            return View(employees);
        }
        return View(employees);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetEmployee(int Id)
    {
        var employee = await _employeeInformation.GetById(Id);
        if (employee == null)
            return NotFound();

        var NewVm = new EmployeeViewModel
        {
            Id = employee.Id,
            OPRCode = employee.OPRCode,
            FatherName = employee.FatherName,
            FullName = employee.FullName,
            ProfilePictureUrl = employee.ProfilePictureUrl,
            OfficeLocation = employee.OfficeLocation,
            DateOfBirth = employee.DateOfBirth,
            DateOfLeaving = employee.DateOfLeaving,
            IDExpiryDate = employee.IDExpiryDate,
            JoiningDate = employee.JoiningDate,
            ConfirmationDate = employee.ConfirmationDate,
            Reason = employee.Reason,
            CNIC = employee.CNIC,
            IsAsstHOD = employee.IsAsstHOD,
            IsHOD = employee.IsHOD,
            SurNameList = await _employeeInformation.Fill_Comb(14),
            NationalityList = await _employeeInformation.Fill_Comb(11),
            SectionList = await _employeeInformation.Fill_Comb(13),
            DepartmentLevelList = await _employeeInformation.Fill_Comb(2),
            LevelPolicyList = await _employeeInformation.Fill_Comb(9),
            ReligionList = await _employeeInformation.Fill_Comb(12),
            GenderList = await _employeeInformation.Fill_Comb(6),
            MaritalStatusList = await _employeeInformation.Fill_Comb(10),
            BloodGroupList = await _employeeInformation.Fill_Comb(1),
            DesignationsList = await _employeeInformation.Fill_Comb(4),
            DepartmentList = await _employeeInformation.Fill_Comb(3),
            Grades = await _employeeInformation.Fill_Comb(7),
            EmploymentStatusList = await _employeeInformation.Fill_Comb(5),
            JobStatusList = await _employeeInformation.Fill_Comb(8)
        };
        return View("CreateEmployee", NewVm);
    }
}